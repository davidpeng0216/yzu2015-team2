using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team2
{
    class Account : Login
    {
        private string user;
        private string password;
        private string email;
        private int experience;

        public Account(string _user, string _password, string _email)
        {
            user = _user;
            password = _password;
            email = _email;
            experience = 0;
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value;  }
        }

        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        public void SignUp()
        {
            experience++;
        }

    }
}

