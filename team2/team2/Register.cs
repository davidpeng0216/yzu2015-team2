using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace team2
{
    enum RegisterStatus {AccountFormatFail, PasswordFormatFail, PasswordNotSame, EmailFormatFail, AccountExist, EmailExist, CAPTCHAFail, RegisterSuccess };

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
            else return false;
        }

        static internal bool CheckAccountExist(string accountToCheck, List<Account> AccountList)
        {
            if (AccountList.Exists(x => x.UserID == accountToCheck))
                return true;
            else return false;
        }

        static internal bool CheckEmailExist(string EmailToCheck, List<Account> AccountList)
        {
            if (AccountList.Exists(x => x.Email == EmailToCheck))
                return true;
            else return false;
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

        static internal RegisterStatus RegisterAccount(string account, string password1, string password2, string email, string genCode, string inputCode, ref List<Account> AccountList)
        {
            if (!VerifyAccount(account))
                return RegisterStatus.AccountFormatFail;
            else if (CheckAccountExist(account, AccountList))
                return RegisterStatus.AccountExist;
            else if (!VerifyPassword(password1))
                return RegisterStatus.PasswordFormatFail;
            else if (!VerifyPasswordSame(password1, password2))
                return RegisterStatus.PasswordNotSame;
            else if (!VerifyEmail(email))
                return RegisterStatus.EmailFormatFail;
            else if (CheckEmailExist(email, AccountList))
                return RegisterStatus.EmailExist;
            else if (!genCode.Equals(inputCode))
                return RegisterStatus.CAPTCHAFail;
            else
            {
                Account newAccount = new Account(account, password1, email);
                AccountList.Add(newAccount);
                return RegisterStatus.RegisterSuccess;
            }
        }

    }
}
