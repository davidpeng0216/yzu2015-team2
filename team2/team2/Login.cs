using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace team2
{
    class Login : Account
    {
         bool login_status ;
         int try_count ;

        public Login()
        {
            login_status = false;
            try_count = 0;
        }
     

      public  bool get_login_status()
        {
            return login_status;
        }

      public int get_try_count()
        {
            return try_count;
        }

     public void set_login_status(bool status)
     {
         login_status = status;
     }
        public  bool login(string userid, string password)
        {
            if (try_count > 5)
            {
                return false;
            }
            
            bool checkPassword = false;

            char[] delimiters = new char[] { '\t', ' ' };

            StreamReader sr = new StreamReader("..\\..\\account.txt");
            while (!sr.EndOfStream) // 每次讀取一行，直到檔尾            
            {
                string line = sr.ReadLine();    // 讀取文字到 line 變數
                string[] item = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (item[0].Equals(userid))
                {
                    if (item[1].Equals(password))
                    {
                        checkPassword = true;
                        break;
                    }
                }
            }
            sr.Close();

            if (checkPassword == false)
            {
                try_count++;
                login_status = false;
            }

            else
            {
                try_count = 0;
                login_status = true;
            }
            return checkPassword;
        }

    }
}
