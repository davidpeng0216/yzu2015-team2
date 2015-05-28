using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team2
{
    class Account
    {
        private string account;
        private string password;
        private string Email;

        public Account(string _account, string _password, string _Email)
        {
            this.setAcount(_account).setPassword(_password).setEmail(_Email);
        }

        public string getAccount()
        {
            return this.account;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getEmail()
        {
            return this.Email;
        }

        public Account setAcount(string _account)
        {
            this.account = _account;
            return this;
        }

        public Account setPassword(string _password)
        {
            this.password = _password;
            return this;
        }

        public Account setEmail(string _Email)
        {
            this.Email = _Email;
            return this;
        }
    }
}

