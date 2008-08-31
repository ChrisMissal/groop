using CRIneta.Model.Domain;

namespace CRIneta.Model
{
    public class UserData
    {
        private bool isAuthenticated;
        private string username;
        private string name;

        public UserData(Member member)
        {
            isAuthenticated = false;
            if (member == null) return;

            isAuthenticated = true;
            username = member.Username;
            name = member.GetName();
        }

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        public string Username
        {
            get { return username; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}