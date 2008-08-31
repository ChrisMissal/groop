using System.Security.Principal;

namespace CRIneta.Website.Impl.Security.Principal
{
    public class GuestIdentity : IIdentity
    {
        private readonly string name;

        public GuestIdentity(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public string AuthenticationType
        {
            get { return null; }
        }

        public bool IsAuthenticated
        {
            get { return false; }
        }
    }
}