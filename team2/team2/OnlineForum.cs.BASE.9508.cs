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
        internal List<ArticleThread> threads;
        private Account curUser;
        private int LoginTryCount;

        public OnlineForum()
        {
            curStatus = AccountStatus.Logout;
            curUser = null;
            LoginTryCount = 0;
            threads = new List<ArticleThread>(); //從此處加入資料庫之文章
        }

        public LoginStatus Login(string userid, string password)
        {
            if (LoginTryCount > 5)
                return LoginStatus.RejectLogin;
           
            char[] delimiters = new char[] { '\t', ' ' };

            StreamReader sr = new StreamReader("..\\..\\account.txt");
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
            {
                LoginTryCount = 0;
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
            threads.Add(newArticle);
        }
    }
}
