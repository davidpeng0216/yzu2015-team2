using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace team2
{
    public struct CAPTCHA_check
    {
        public string ID, CPATCHA_code;
        public CAPTCHA_check(string a, string b)
        {
            ID = a;
            CPATCHA_code = b;
        }
    }
    
    class Register
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

        static internal bool VerifyPasswordSame(string password, string confirmPassword)
        {
            if (password.Equals(confirmPassword))
                return true;
            else return false;
        }

        static internal bool VerifyEmail(string email)
        {
            if (Regex.IsMatch(email, "^[a-zA-Z0-9_]+@[a-zA-Z0-9._]+$"))
                return true;
            else 
                return false;
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

        static internal bool CheckEmailExist(string EmailToCheck)
        {
            bool EmailExist = false;

            char[] delimiters = new char[] { '\t', ' ' };
            StreamReader sr = new StreamReader("account.txt");
            while (!sr.EndOfStream) // 每次讀取一行，直到檔尾            
            {
                string line = sr.ReadLine();    // 讀取文字到 line 變數
                string[] item = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (item[2].Equals(EmailToCheck))
                {
                    EmailExist = true;
                    break;
                }
            }
            sr.Close();
            return EmailExist;
        }

        static internal string getCAPTCHA()
        {
            string result = "";
            Random seed = new Random();
            for (int i = 0; i < 4; i++)
            {
                int num = seed.Next(0, 36);
                if (num < 10)
                    result += num.ToString();
                else
                {
                    num += 55;
                    result += Convert.ToChar(num);
                }
            }
            return result;
        }

        static internal string RegisterAccount(string acc, string pwd1, string pwd2, string email, string genCode, string inputCode)
        {
            string resultMessage = "註冊尚未完成";
            try
            {
                if (!VerifyAccount(acc))
                    throw new Exception("帳號格式不符！");
                else if (CheckAcountExist(acc))
                    throw new Exception("此帳號已存在！");
                else if (!VerifyPassword(pwd1))
                    throw new Exception("密碼格式不符！");
                else if (!VerifyPasswordSame(pwd1, pwd2))
                    throw new Exception("請輸入相同的密碼！");
                else if (!VerifyEmail(email))
                    throw new Exception("電子信箱格式不符！");
                else if (CheckEmailExist(email))
                    throw new Exception("此電子信箱已被使用！");
                else if (!genCode.Equals(inputCode))
                    throw new Exception("驗證碼輸入錯誤！");

                int experience = 0;

                FileInfo AccountDataBase = new FileInfo("account.txt");
                if (AccountDataBase.Exists)
                {
                    StreamWriter SaveAccount = AccountDataBase.AppendText();
                    SaveAccount.WriteLine(acc + '\t' + pwd1 + '\t' + email + '\t' + experience);
                    SaveAccount.Flush();
                    SaveAccount.Close();
                    resultMessage = "註冊成功";
                }
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }
            return resultMessage;
        }


        internal static bool C_check()
        {
            CAPTCHA_check user = new CAPTCHA_check();
            user.ID = "Daniel Lo";
            user.CPATCHA_code = CODE();
            Console.WriteLine("1000+200+30+4=?\n");
            string input = Console.ReadLine();

            if (CHECK(user.CPATCHA_code, input))
                return true;
            else
                return false;

        }
        internal static bool CHECK(string a, string b)
        {
            if (a == b)
                return true;
            else
                return false;
        }
        internal static string CODE()
        {
            string code = "1234";
            return code;
        }

    
    }
}
