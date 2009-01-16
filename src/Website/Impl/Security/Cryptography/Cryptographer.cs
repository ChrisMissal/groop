using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CRIneta.Web.Core.Security.Cryptography;

namespace CRIneta.Website.Impl.Security.Cryptography
{
    public class Cryptographer : ICryptographer
    {
        private readonly SymmetricCryptographer symmetricCryptographer;

        public Cryptographer()
        {
            symmetricCryptographer = new SymmetricCryptographer(SymmetricCryptographer.ServiceProviderEnum.TripleDES);
            symmetricCryptographer.Key = "crineta1";
        }

        /// <summary>
        /// Create salt for encrypting user passwords.  
        /// Original Source: http://davidhayden.com/blog/dave/archive/2004/02/16/157.aspx
        /// </summary>
        /// <returns></returns>
        public string CreateSalt()
        {
            int size = 64;
            //Generate a cryptographic random number.
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// Create a password hash based on a password and salt.  
        /// Adapted from: http://davidhayden.com/blog/dave/archive/2004/02/16/157.aspx
        /// </summary>
        /// <returns></returns>
        public string Hash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);

            HashAlgorithm algorithm = SHA1.Create();
            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPwd));

            return Convert.ToBase64String(hash);
        }

        public string Encrypt(string plainText)
        {
            return symmetricCryptographer.Encrypt(plainText);
        }

        public string Decrypt(string cipherText)
        {
            return symmetricCryptographer.Decrypt(cipherText);
        }
    }

    public class SymmetricCryptographer
    {
        private string key = string.Empty;
        private string salt = string.Empty;
        private ServiceProviderEnum algorithm;
        private SymmetricAlgorithm cryptoService;

        private void SetLegalIV()
        {
            // Set symmetric algorithm
            switch (algorithm)
            {
                case ServiceProviderEnum.Rijndael:
                    cryptoService.IV = new byte[] {0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc};
                    break;
                default:
                    cryptoService.IV = new byte[] {0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9};
                    break;
            }
        }

        public enum ServiceProviderEnum : int
        {
            // Supported service providers
            Rijndael,
            RC2,
            DES,
            TripleDES
        }

        public SymmetricCryptographer()
        {
            // Default symmetric algorithm
            cryptoService = new RijndaelManaged();
            cryptoService.Mode = CipherMode.CBC;
            algorithm = ServiceProviderEnum.Rijndael;
        }

        public SymmetricCryptographer(ServiceProviderEnum serviceProvider)
        {
            // Select symmetric algorithm
            switch (serviceProvider)
            {
                case ServiceProviderEnum.Rijndael:
                    cryptoService = new RijndaelManaged();
                    algorithm = ServiceProviderEnum.Rijndael;
                    break;
                case ServiceProviderEnum.RC2:
                    cryptoService = new RC2CryptoServiceProvider();
                    algorithm = ServiceProviderEnum.RC2;
                    break;
                case ServiceProviderEnum.DES:
                    cryptoService = new DESCryptoServiceProvider();
                    algorithm = ServiceProviderEnum.DES;
                    break;
                case ServiceProviderEnum.TripleDES:
                    cryptoService = new TripleDESCryptoServiceProvider();
                    algorithm = ServiceProviderEnum.TripleDES;
                    break;
            }
            cryptoService.Mode = CipherMode.CBC;
        }
        
        public virtual byte[] GetLegalKey()
        {
            // Adjust key if necessary, and return a valid key
            if (cryptoService.LegalKeySizes.Length > 0)
            {
                // Key sizes in bits
                int keySize = key.Length * 8;
                int minSize = cryptoService.LegalKeySizes[0].MinSize;
                int maxSize = cryptoService.LegalKeySizes[0].MaxSize;
                int skipSize = cryptoService.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                {
                    // Extract maximum size allowed
                    key = key.Substring(0, maxSize / 8);
                }
                else if (keySize < maxSize)
                {
                    // Set valid size
                    int validSize = (keySize <= minSize) ? minSize :
                                                                       (keySize - keySize % skipSize) + skipSize;
                    if (keySize < validSize)
                    {
                        // Pad the key with asterisk to make up the size
                        key = key.PadRight(validSize / 8, '*');
                    }
                }
            }
            PasswordDeriveBytes derivedKey = new PasswordDeriveBytes(this.key, ASCIIEncoding.ASCII.GetBytes(salt));

            return derivedKey.GetBytes(this.key.Length);
        }

        public virtual string Encrypt(string plainText)
        {
            byte[] plainByte = Encoding.ASCII.GetBytes(plainText);
            byte[] keyByte = GetLegalKey();

            // Set private key
            cryptoService.Key = keyByte;
            SetLegalIV();

            // Encryptor object
            ICryptoTransform cryptoTransform = cryptoService.CreateEncryptor();

            // Memory stream object
            MemoryStream ms = new MemoryStream();

            // Crpto stream object
            CryptoStream cs = new CryptoStream(ms, cryptoTransform,
                                               CryptoStreamMode.Write);

            // Write encrypted byte to memory stream
            cs.Write(plainByte, 0, plainByte.Length);
            cs.FlushFinalBlock();

            // Get the encrypted byte length
            byte[] cryptoByte = ms.ToArray();

            // Convert into base 64 to enable result to be used in Xml
            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));
        }

        public virtual string Decrypt(string cryptoText)
        {
            // Convert from base 64 string to bytes
            byte[] cryptoByte = Convert.FromBase64String(cryptoText);
            byte[] keyByte = GetLegalKey();

            // Set private key
            cryptoService.Key = keyByte;
            SetLegalIV();

            // Decryptor object
            ICryptoTransform cryptoTransform = cryptoService.CreateDecryptor();
            try
            {
                // Memory stream object
                MemoryStream ms = new MemoryStream(cryptoByte, 0, cryptoByte.Length);

                // Crpto stream object
                CryptoStream cs = new CryptoStream(ms, cryptoTransform,
                                                   CryptoStreamMode.Read);

                // Get the result from the Crypto stream
                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        public string Salt
        {
            // Salt value
            get
            {
                return salt;
            }
            set
            {
                salt = value;
            }
        }
    }
}