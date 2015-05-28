using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace team2
{
    class OnlineForum
    {
        static internal bool VerifyAccount(string account)
        {
            if (Regex.IsMatch(account, "^[a-zA-Z][a-zA-Z0-9]{7,15}$"))
                return true;
            else return false;
        }

        static internal bool VerifyPassword(string password)
        {
            if (Regex.IsMatch(password, "^[a-zA-Z0-9]{8,16}$"))
                return true;
            else return false;
        }

        static internal bool CheckAcountExist(string accountToCheck)
        {
            bool accountExist = false;

            char[] delimiters = new char[] { '\t', ' ' };
            StreamReader sr = new StreamReader("account.txt");
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
            return accountExist;
        }

    }
}
