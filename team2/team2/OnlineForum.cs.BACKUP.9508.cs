using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace team2
{
    enum AccountStatus {Logout, Login};
    enum LoginStatus {LoginSuccess, LoginFail, RejectLogin};

    class OnlineForum
    {
        internal AccountStatus curStatus;
        private Account curUser;
        private int LoginTryCount;

        public OnlineForum()
        {
            curStatus = AccountStatus.Logout;
            curUser = null;
            LoginTryCount = 0;
        }

        public LoginStatus Login(string userid, string password, ref List<Account> AccountList)
        {
            if (LoginTryCount > 4)
                return LoginStatus.RejectLogin;
           
<<<<<<< HEAD
            char[] delimiters = new char[] { '\t', ' ' };

            StreamReader sr = new StreamReader("account.txt");
            while (!sr.EndOfStream) // 每次讀取一行，直到檔尾            
            {
                string line = sr.ReadLine();    // 讀取文字到 line 變數
                string[] item = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (item[0].Equals(userid) && item[1].Equals(password))
                {
                    curUser = new Account(item[0], item[1], item[2]);
                    curStatus = AccountStatus.Login;
                    break;
                }
            }
            sr.Close();

            if (curStatus == AccountStatus.Login)
=======
            if (AccountList.Exists(x => x.UserID == userid && x.Password == password))
>>>>>>> 3a7332b32169ad049eb6bd4372a838c1d3da4dcd
            {
                LoginTryCount = 0;
                curUser = AccountList.Find(x => x.UserID == userid && x.Password == password);
                curStatus = AccountStatus.Login;
                return LoginStatus.LoginSuccess;
            }
            else
            {
                LoginTryCount++;
                return LoginStatus.LoginFail;
            }
        }

        public void Logout()
        {
            curUser = null;
            curStatus = AccountStatus.Logout;
        }

        public void AddArticle(ArticleThread newArticle)
        {

        }
    }
}
