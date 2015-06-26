using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace team2
{
    [TestClass]
    [DeploymentItem("account.txt")]
    public class RegisterTestClass
    {
        List<Account> AccountDataBase = new List<Account>();
        List<ArticleThread> ArticleThreadDataBase = new List<ArticleThread>();

        [TestMethod]
        public void testAccountExist()
        {
            // Arrange
            string UserID = "TestUserID";
            string Password = "TestPassword";
            string Email = "Test@email.com";
            string Code = Register.getCAPTCHA();
            //Act
            RegisterValue Result1 = Register.RegisterAccount(UserID, Password, Password, Email, Code, Code, ref AccountDataBase);
            RegisterValue Result2 = Register.RegisterAccount(UserID, Password, Password, Email, Code, Code, ref AccountDataBase);
            //Assert
            Assert.AreEqual(Result1, RegisterValue.RegisterSuccess);
            Assert.AreEqual(Result2, RegisterValue.AccountExist);
        }

        [TestMethod]
        public void testEmailExist()
        {
            // Arrange
            string UserID = "TestUserID";
            string OtherUserID = "TestUserID2";
            string Password = "TestPassword";
            string Email = "Test@email.com";
            string Code = Register.getCAPTCHA();
            //Act
            RegisterValue Result1 = Register.RegisterAccount(UserID, Password, Password, Email, Code, Code, ref AccountDataBase);
            RegisterValue Result2 = Register.RegisterAccount(OtherUserID, Password, Password, Email, Code, Code, ref AccountDataBase);
            //Assert
            Assert.AreEqual(Result1, RegisterValue.RegisterSuccess);
            Assert.AreEqual(Result2, RegisterValue.EmailExist);
        }

        [TestMethod]
        public void testAccountFormat()
        {
            //test account's format

            //正常Case
            Assert.IsTrue(Register.VerifyAccount("abcde123"));
            Assert.IsTrue(Register.VerifyAccount("abcdeFGH"));
            //過長
            Assert.IsFalse(Register.VerifyAccount("abcdefghASijk123dkfasfdjasjdkaslkdasld456789"));
            //過短
            Assert.IsFalse(Register.VerifyAccount("abc123"));
            Assert.IsFalse(Register.VerifyAccount(""));
            //非英文開頭
            Assert.IsFalse(Register.VerifyAccount("123abcdefg"));
            //包含英文和數字以外的字元
            Assert.IsFalse(Register.VerifyAccount("123我是中文"));
            Assert.IsFalse(Register.VerifyAccount("敏捷軟體開發課程"));
            Assert.IsFalse(Register.VerifyAccount("            "));
        }

        [TestMethod]
        public void testPasswordFormat()
        {
            //test password's format

            //正常密碼Case
            Assert.IsTrue(Register.VerifyPassword("123456789"));
            Assert.IsTrue(Register.VerifyPassword("abc12345"));
            Assert.IsTrue(Register.VerifyPassword("125abcde"));
            //過長
            Assert.IsFalse(Register.VerifyPassword("abcdefghASijk123dkfasfdjasjdkaslkdasld456789"));
            //過短
            Assert.IsFalse(Register.VerifyPassword("abc1234"));
            Assert.IsFalse(Register.VerifyPassword("123abc"));
            Assert.IsFalse(Register.VerifyPassword(""));
            Assert.IsFalse(Register.VerifyPassword("abc123"));
            //包含英文和數字以外的字元
            Assert.IsFalse(Register.VerifyPassword("123我是中文"));
            Assert.IsFalse(Register.VerifyPassword("!@#$%^&&*"));
            Assert.IsFalse(Register.VerifyPassword("            "));
        }

        [TestMethod]
        public void testRetypePasswordSame()
        {
            //test two password are the same

            //正常Case
            Assert.IsTrue(Register.VerifyPasswordSame("123456789", "123456789"));
            //不相同
            Assert.IsFalse(Register.VerifyPasswordSame("123456789", "123456987"));
        }

         [TestMethod]
        public void Test_EmailFormat()
        {
            //test Email's format

            //正常case
            Assert.IsTrue(Register.VerifyEmail("test1@gmail.com"));
            Assert.IsTrue(Register.VerifyEmail("test_1@gmail.com"));
            Assert.IsTrue(Register.VerifyEmail("1test@gmail.com"));
            Assert.IsTrue(Register.VerifyEmail("test1@mail.yzu.edu.tw"));
            Assert.IsTrue(Register.VerifyEmail("test_1@mail.yzu.edu.tw"));
            Assert.IsTrue(Register.VerifyEmail("test1@web_mail.com"));
            Assert.IsTrue(Register.VerifyEmail("test_1@web_mail.com"));
            Assert.IsTrue(Register.VerifyEmail("9fbw2313test_1565@yahoo.com.tw"));

            //包含 英文,數字,_ 以外的字元
            Assert.IsFalse(Register.VerifyEmail("電子信箱@mail.yzu.edu.tw"));
            Assert.IsFalse(Register.VerifyEmail("test1@電子信箱伺服器.com"));
            Assert.IsFalse(Register.VerifyEmail("test_1@web_mail.com.台灣"));
            Assert.IsFalse(Register.VerifyEmail("tes#$#$t_1@web_mail.com.tw"));

            //不是電子信箱格式
            Assert.IsFalse(Register.VerifyEmail("test_1^web_mail.com"));
            Assert.IsFalse(Register.VerifyEmail("test_1小老鼠web_mail.com"));
            Assert.IsFalse(Register.VerifyEmail("test_1$web_mail.com"));
            Assert.IsFalse(Register.VerifyEmail("test123@@@@web_mail.com"));
            Assert.IsFalse(Register.VerifyEmail("test123@happy@web_mail.com"));
        }

        [TestMethod]
        public void TestCAPTCHA()
         {
            //驗證驗證碼是否符合長度及只包含英文及數字
             Assert.IsTrue(Regex.IsMatch(Register.getCAPTCHA(),"^[A-Z0-9]{4}$"));
         }

         [TestMethod]
         public void TestRegisterAccount() //整體測試
         {
             // Arrange
             string CorrectUserID1 = "CorrectUserID1";
             string CorrectUserID2 = "CorrectUserID2";
             string ErrorUserID = "測試用UserID1";
             string CorrectPassword = "12345678Pwd";
             string ErrorPassword = "測試用123456";
             string CorrectEmail1 = "Correct1@mail.com";
             string CorrectEmail2 = "Correct2@mail.com";
             string ErrorEmail = "電子信箱@mail.edu.tw";
             string genCode = Register.getCAPTCHA();
             //Act
             RegisterValue result1 = Register.RegisterAccount(CorrectUserID1, CorrectPassword, CorrectPassword, CorrectEmail1, genCode, genCode, ref AccountDataBase);
             RegisterValue result2 = Register.RegisterAccount(ErrorUserID, CorrectPassword, CorrectPassword, CorrectEmail1, genCode, genCode, ref AccountDataBase);
             RegisterValue result3 = Register.RegisterAccount(CorrectUserID1, CorrectPassword, CorrectPassword, CorrectEmail1, genCode, genCode, ref AccountDataBase);
             RegisterValue result4 = Register.RegisterAccount(CorrectUserID2, ErrorPassword, CorrectPassword, CorrectEmail1, genCode, genCode, ref AccountDataBase);
             RegisterValue result5 = Register.RegisterAccount(CorrectUserID2, CorrectPassword, ErrorPassword, CorrectEmail1, genCode, genCode, ref AccountDataBase);
             RegisterValue result6 = Register.RegisterAccount(CorrectUserID2, CorrectPassword, CorrectPassword, ErrorEmail, genCode, genCode, ref AccountDataBase);
             RegisterValue result7 = Register.RegisterAccount(CorrectUserID2, CorrectPassword, CorrectPassword, CorrectEmail1, genCode, genCode, ref AccountDataBase);
             RegisterValue result8 = Register.RegisterAccount(CorrectUserID2, CorrectPassword, CorrectPassword, CorrectEmail2, genCode, "0000", ref AccountDataBase);
             RegisterValue result9 = Register.RegisterAccount(CorrectUserID2, CorrectPassword, CorrectPassword, CorrectEmail2, genCode, genCode, ref AccountDataBase);
             //Assert
             Assert.AreEqual(result1, RegisterValue.RegisterSuccess);
             Assert.AreEqual(result2, RegisterValue.AccountFormatFail);
             Assert.AreEqual(result3, RegisterValue.AccountExist);
             Assert.AreEqual(result4, RegisterValue.PasswordFormatFail);
             Assert.AreEqual(result5, RegisterValue.PasswordSame);
             Assert.AreEqual(result6, RegisterValue.EmailFormatFail);
             Assert.AreEqual(result7, RegisterValue.EmailExist);
             Assert.AreEqual(result8, RegisterValue.CAPTCHAFail);
             Assert.AreEqual(result9, RegisterValue.RegisterSuccess);
             Assert.AreEqual(2, AccountDataBase.Count);
         }

    }

    [TestClass]
    public class ForumTestClass
    {
        List<Account> AccountDataBase = new List<Account>();
        List<ArticleThread> ArticleThreadDataBase = new List<ArticleThread>();

        void setAccounts()
        {
            Account testAccount1 = new Account("TestAccount1", "12345678", "TestAccount1@mail.com");
            Account testAccount2 = new Account("TestAccount2", "12345678", "TestAccount2@mail.com");
            Account testAccount3 = new Account("TestAccount3", "12345678", "TestAccount3@mail.com");
            AccountDataBase.Add(testAccount1);
            AccountDataBase.Add(testAccount2);
            AccountDataBase.Add(testAccount3);
        }

        [TestMethod]
        public void LoginLogoutTest()
        {
            // Arrange
            OnlineForum ServerClient = new OnlineForum();
            setAccounts();
            string notExistAccount = "NotExistAccount1";
            string errorPassword = "123456789";
            string loginAccount = "TestAccount1";
            string loginPassword = "12345678";
            // Act1
            LoginStatus result1 = ServerClient.Login(notExistAccount, loginPassword, ref AccountDataBase);
            LoginStatus result2 = ServerClient.Login(loginAccount, errorPassword, ref AccountDataBase);
            LoginStatus result3 = ServerClient.Login(loginAccount, loginPassword, ref AccountDataBase);
            //Assert1
            Assert.AreEqual(AccountStatus.Login, ServerClient.curStatus);
            Assert.AreEqual(result1, LoginStatus.LoginFail);
            Assert.AreEqual(result2, LoginStatus.LoginFail);
            Assert.AreEqual(result3, LoginStatus.LoginSuccess);
            //Act2
            ServerClient.Logout();
            //Assert2
            Assert.AreEqual(AccountStatus.Logout, ServerClient.curStatus);
            //Act3
            ServerClient.Login(notExistAccount, loginPassword, ref AccountDataBase);
            ServerClient.Login(notExistAccount, loginPassword, ref AccountDataBase);
            ServerClient.Login(notExistAccount, loginPassword, ref AccountDataBase);
            ServerClient.Login(notExistAccount, loginPassword, ref AccountDataBase);
            ServerClient.Login(notExistAccount, loginPassword, ref AccountDataBase);
            LoginStatus result4 = ServerClient.Login(loginAccount, loginPassword, ref AccountDataBase);
            //Assert3
            Assert.AreEqual(AccountStatus.Logout, ServerClient.curStatus);
            Assert.AreEqual(result4, LoginStatus.RejectLogin);
        }

        [TestMethod]
        public void TestArticle()
        {
            string testAuthor = "Author";
            try
            {
                string testContentsLess20 = "123";
                Article testContentsTooShort = new Article(testContentsLess20, testAuthor, 1);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("文章內容不符規定(長度需為21~499)", ex.Message);
            }

            try
            {
                string testContentsOver500 = "0123456789";
                for (int i = 0; i < 6; i++)
                    testContentsOver500 += testContentsOver500;

                Article testContentsTooLong = new Article(testContentsOver500, testAuthor, 1);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("文章內容不符規定(長度需為21~499)", ex.Message);
            }

            string testContentsAccept = "012345678901234567890";
            Article testArticle = new Article(testContentsAccept, testAuthor, 1);
            Assert.AreEqual(testContentsAccept, testArticle.Contents);
            Assert.AreEqual(testAuthor, testArticle.Author);
            Assert.AreEqual(1, testArticle.ThreadNumber);


        }
        [TestMethod]
        public void TestArticleThread()
        {
            Article testArticle = new Article("It is article test!123456", "testAuthor", 1);

            List<Article> testList = new List<Article>();
            testList.Add(testArticle);

            try
            {
                ArticleThread TestTitleTooShort = new ArticleThread("t", testArticle, 1);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("標題不符合規定", ex.Message);
            }

            ArticleThread TestThread = new ArticleThread("test", testArticle, 1);
            Assert.AreEqual("test", TestThread.Title);  //test the title
            Assert.IsTrue(Enumerable.SequenceEqual(testList, TestThread.Thread));   //test the article list
            Assert.AreEqual(1, TestThread.ThreadNumber);    //test the thread number

        }

        [TestMethod]
        public void title_verify()
        {
            ArticleThread artic = new ArticleThread();

            //欄位字數不可大於10字，不可小於2字
            Assert.AreEqual(true, artic.titleVerify("hello"));
            Assert.AreEqual(true, artic.titleVerify("he"));
            Assert.AreEqual(true, artic.titleVerify("hello*")); //含有特殊字元  
            Assert.AreEqual(true, artic.titleVerify("hello中文哦")); //含有特殊字元  
            Assert.AreEqual(true, artic.titleVerify("_===**")); //含有特殊字元  
            Assert.AreEqual(false, artic.titleVerify(""));
            Assert.AreEqual(false, artic.titleVerify("12345678910測試"));
        }

        [TestMethod]
        public void ReplyArticleThread()
        {
            Assert.AreEqual(1, 1);
            Article testArticle = new Article("It is article test!123456", "testAuthor", 1);
            List<Article> testList = new List<Article>();
            testList.Add(testArticle);
            ArticleThread TestTitleTooShort = new ArticleThread();

            //回復文章
            //正常case
            Assert.AreEqual(true, TestTitleTooShort.AddComment(1, "awesome"));
            Assert.AreEqual(true, TestTitleTooShort.AddComment(1, "hello"));
            Assert.AreEqual(true, TestTitleTooShort.AddComment(1, "word"));
            Assert.AreEqual(true, TestTitleTooShort.AddComment(1, "wonderful project"));

            //未輸入就回文
            Assert.AreEqual(false, TestTitleTooShort.AddComment(1, ""));

            //輸入過長的回文 (最多50)
            Assert.AreEqual(false, TestTitleTooShort.AddComment(1, "asdasdasdasdasdasdasfdsfjrijfirwjfijrkfrifjeijfiejfiejfiejfiejamsndkde"));

            //查看回文

            //正常case
            Assert.AreEqual("awesome", TestTitleTooShort.GetComment(1)[0]);
            Assert.AreEqual("hello", TestTitleTooShort.GetComment(1)[1]);
            Assert.AreEqual("word", TestTitleTooShort.GetComment(1)[2]);
            Assert.AreEqual("wonderful project", TestTitleTooShort.GetComment(1)[3]);


            //輸入了不存在的title編號
            Assert.AreEqual(null, TestTitleTooShort.GetComment(2));
            Assert.AreEqual(null, TestTitleTooShort.GetComment(0));
        }
        [TestMethod]
        public void TestArticleByOnlineForum() //整合測試
        {
            //Arrange1 //新增文章測試
            OnlineForum OF = new OnlineForum();
            setAccounts();
            OF.Login("TestAccount1", "12345678", ref AccountDataBase);

            string testArticleTitle = "測試標題1";
            string testArticleContent = "這是一個測試的文章，裡面必須含有至少21個字元。\n<br>並且能儲存換行字元，無論是程式或網頁";
            string titleTooShort = "";
            string titleTooLong = "這是一個好長好長好長好長好長好長好長的標題";
            string contentTooShort = "很短的文章";
            //Act1
            AddNewArticleThreadStatus result1 = OF.AddArticleThread(titleTooShort, testArticleContent, OF.curUser.UserID, ref ArticleThreadDataBase);
            AddNewArticleThreadStatus result2 = OF.AddArticleThread(titleTooLong, testArticleContent, OF.curUser.UserID, ref ArticleThreadDataBase);
            AddNewArticleThreadStatus result3 = OF.AddArticleThread(testArticleTitle, contentTooShort, OF.curUser.UserID, ref ArticleThreadDataBase);
            AddNewArticleThreadStatus result4 = OF.AddArticleThread(testArticleTitle, testArticleContent, OF.curUser.UserID, ref ArticleThreadDataBase);
            //Arrest1
            Assert.AreEqual(AddNewArticleThreadStatus.TitleFail, result1);
            Assert.AreEqual(AddNewArticleThreadStatus.TitleFail, result2);
            Assert.AreEqual(AddNewArticleThreadStatus.ContentFail, result3);
            Assert.AreEqual(AddNewArticleThreadStatus.AddSuccess, result4);

            //Arrange2 文章搜尋測試
            OF.AddArticleThread("測試標題2", "測試文章內容：1234567891011121314151617181920", OF.curUser.UserID, ref ArticleThreadDataBase);
            OF.AddArticleThread("測試標題3", "測試文章內容：1234567891011121314151617181920", OF.curUser.UserID, ref ArticleThreadDataBase);
            OF.AddArticleThread("測試標題4", "測試文章內容：1234567891011121314151617181920", OF.curUser.UserID, ref ArticleThreadDataBase);
            OF.AddArticleThread("測試標題5", "測試文章內容：1234567891011121314151617181920", OF.curUser.UserID, ref ArticleThreadDataBase);
            //Act2
            ArticleThread getArticleThread1 = OF.getArticleThreadByNumber(1, ref ArticleThreadDataBase);
            ArticleThread getArticleThread2 = OF.getArticleThreadByNumber(4, ref ArticleThreadDataBase);
            ArticleThread getArticleThread3 = OF.getArticleThreadByNumber(6, ref ArticleThreadDataBase);
            //Assert2
            Assert.AreEqual("測試標題1", getArticleThread1.Title);
            Assert.AreEqual("測試標題4", getArticleThread2.Title);
            Assert.AreEqual(null, getArticleThread3);

            //Act3 回覆文章測試
            ReplyArticleThradStatus result5 = OF.ReplyArticleThread(testArticleContent, OF.curUser.UserID, 6, ref ArticleThreadDataBase);
            ReplyArticleThradStatus result6 = OF.ReplyArticleThread(contentTooShort, OF.curUser.UserID, 1, ref ArticleThreadDataBase);
            ReplyArticleThradStatus result7 = OF.ReplyArticleThread(testArticleContent, OF.curUser.UserID, 1, ref ArticleThreadDataBase);
            //Assert3
            Assert.AreEqual(ReplyArticleThradStatus.NoThread, result5);
            Assert.AreEqual(ReplyArticleThradStatus.ContentFail, result6);
            Assert.AreEqual(ReplyArticleThradStatus.AddSucess, result7);
        }
    }
}
