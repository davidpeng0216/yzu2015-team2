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
    enum AddNewArticleThreadStatus {AddSuccess, TitleFail, ContentFail, OtherFail};

    class OnlineForum
    {
        internal AccountStatus curStatus;
        internal Account curUser;
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

        public AddNewArticleThreadStatus AddArticleThread(string title, string content, string userID, ref List<ArticleThread> ArticleThreadDatabase)
        {
            int newArticleID = ArticleThreadDatabase.Count + 1;
            try
            {
                Article newArticle = new Article(content, userID, newArticleID);
                ArticleThread newArticleThread = new ArticleThread(title, newArticle, newArticleID);
                ArticleThreadDatabase.Add(newArticleThread);
                return AddNewArticleThreadStatus.AddSuccess;
            }
            catch (Exception ex)
            {
                if (ex.Message == "標題不符合規定")
                    return AddNewArticleThreadStatus.TitleFail;
                else if (ex.Message == "文章內容不符規定(長度需為21~499)")
                    return AddNewArticleThreadStatus.ContentFail;
                else
                    return AddNewArticleThreadStatus.OtherFail;
            }
        }
    }
}
