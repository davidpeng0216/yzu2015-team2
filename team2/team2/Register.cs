using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace team2
{
    class OnlineForum
    {
        static internal bool VerifyAccount(string account)
        {
            if (Regex.IsMatch(account,"^[a-zA-Z][a-zA-Z0-9]{7,15}$"))
                return true;
            else return false;
        }

        static internal bool VerifyPassword(string password)
        {
            if (Regex.IsMatch(password, "^[a-zA-Z0-9]{8,16}$"))
                return true;
            else return false;
        }
    }
    
    class Register
    {

    }
}
