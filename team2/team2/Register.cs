using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace team2
{
    class Register
    {
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
