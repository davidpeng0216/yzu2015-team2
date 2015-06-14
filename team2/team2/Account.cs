using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team2
{
    class Account 
    {
        internal string UserID;
        internal string Password;
        internal string Email;
        internal int Experience;

        public Account() { }

        public Account(string _user, string _password, string _email)
        {
            UserID = _user;
            Password = _password;
            Email = _email;
            Experience = 0;
        }

        public void SignUp()
        {
            Experience++;
        }

    }
}

