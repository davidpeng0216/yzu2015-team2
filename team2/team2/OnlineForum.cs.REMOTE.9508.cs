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
           
            if (AccountList.Exists(x => x.UserID == userid && x.Password == password))
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
