using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team2
{
    class Logout : Login
    {

      
        
        public void do_logout(string input)
        {

            if (get_login_status() == true)
            {
                if (input[0].Equals('y') || input[0].Equals('Y'))
                     set_login_status(false);
                    
            }

            else
                set_login_status(true);
          
        }
    }
}
