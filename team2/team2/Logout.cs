using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team2
{
    class Logout : Login
    {

        private string input_choice;
        
        public bool already_do_logout()
        {

            if (get_login_status() == true)
            {
                if (input_choice.Equals('y') || input_choice.Equals('Y'))
                    return true;
                else
                    return false;
            }

            else 
                return false;

        }
    }
}
