Rem To run this file successfully make sure you have a database called CRIneta
Rem on you your localhost\sqlexpress instance that you can read/modify with integrated security

..\..\bin\subsonic\2.1\sonic migrate /version 0

..\..\bin\subsonic\2.1\sonic migrate

pause