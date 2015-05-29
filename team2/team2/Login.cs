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
        static bool login_status ;
        static  int try_count ;

        public Login()
        {
            login_status = false;
            try_count = 0;
        }
     

        bool get_login_status()
        {
            return login_status;
        }

        int get_try_count()
        {
            return try_count;
        }

        static internal bool login(string accountToCheck)
        {
            bool accountExist = false;

            char[] delimiters = new char[] { '\t', ' ' };
            StreamReader sr = new StreamReader("punch_in.txt");
            while (!sr.EndOfStream) // 每次讀取一行，直到檔尾            
            {
                string line = sr.ReadLine();    // 讀取文字到 line 變數
                string[] item = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (item[0].Equals(accountToCheck))
                {
                    accountExist = true;
                    break;
                }
            }
            sr.Close();

            if (accountExist == false)
            {
                try_count++;
                login_status = false;
            }

            else
            {
                try_count = 0;
                login_status = true;
            }
            return accountExist;
        }

    }
}
