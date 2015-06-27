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
    enum ReplyArticleThreadStatus {AddSucess, NoThread, ContentFail, OtherFail};

    class OnlineForum
    {
        internal AccountStatus currentStatus;
        internal Account currentUser;
        private int LoginTryCount;

        public OnlineForum()
        {
            currentStatus = AccountStatus.Logout;
            currentUser = null;
            LoginTryCount = 0;
        }

        public LoginStatus Login(string userid, string password, ref List<Account> AccountList)
        {
            if (LoginTryCount > 4)
                return LoginStatus.RejectLogin;
           
            if (AccountList.Exists(x => x.UserID == userid && x.Password == password))
            {
                LoginTryCount = 0;
                currentUser = AccountList.Find(x => x.UserID == userid && x.Password == password);
                currentStatus = AccountStatus.Login;
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
            currentUser = null;
            currentStatus = AccountStatus.Logout;
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

        public ReplyArticleThreadStatus ReplyArticleThread(string content, string userID, int threadID, ref  List<ArticleThread> ArticleThreadDatabase)
        {
            ArticleThread thisThread = ArticleThreadDatabase.Find(x => x.ThreadNumber == threadID);
            if (thisThread != null)
            {
                try
                {
                    Article replyArticle = new Article(content, userID, threadID);
                    thisThread.addArticle(replyArticle);
                    return ReplyArticleThreadStatus.AddSucess;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "文章內容不符規定(長度需為21~499)")
                        return ReplyArticleThreadStatus.ContentFail;
                    else
                        return ReplyArticleThreadStatus.OtherFail;
                }
            }
            else
                return ReplyArticleThreadStatus.NoThread;
        }

        public ArticleThread getArticleThreadByNumber(int number, ref List<ArticleThread> ArticleThreadDatabase)
        {
            return ArticleThreadDatabase.Find(x => x.ThreadNumber == number);
        }
    }
}
