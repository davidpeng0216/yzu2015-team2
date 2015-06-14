using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace team2
{
    enum RegisterValue {AccountFormatFail, PasswordFormatFail, PasswordSame, EmailFormatFail, AccountExist, EmailExist, CAPTCHAFail, RegisterSuccess };

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

        static internal bool CheckAccountExist(string accountToCheck, List<Account> AccountList)
        {
            if (AccountList.Exists(x => x.UserID == accountToCheck))
                return true;
            else
                return false;
        }

        static internal bool CheckEmailExist(string EmailToCheck, List<Account> AccountList)
        {
            if (AccountList.Exists(x => x.Email == EmailToCheck))
                return true;
            else
                return false;
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

        static internal RegisterValue RegisterAccount(string acc, string pwd1, string pwd2, string email, string genCode, string inputCode, ref List<Account> AccountList)
        {
            if (!VerifyAccount(acc))
                return RegisterValue.AccountFormatFail;
            else if (CheckAccountExist(acc, AccountList))
                return RegisterValue.AccountExist;
            else if (!VerifyPassword(pwd1))
                return RegisterValue.PasswordFormatFail;
            else if (!VerifyPasswordSame(pwd1, pwd2))
                return RegisterValue.PasswordSame;
            else if (!VerifyEmail(email))
                return RegisterValue.EmailFormatFail;
            else if (CheckEmailExist(email, AccountList))
                return RegisterValue.EmailExist;
            else if (!genCode.Equals(inputCode))
                return RegisterValue.CAPTCHAFail;
            else
            {
                Account newAccount = new Account(acc, pwd1, email);
                AccountList.Add(newAccount);
                return RegisterValue.RegisterSuccess;
            }
          
        }
    }
}
