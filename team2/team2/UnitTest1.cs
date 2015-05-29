using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace team2
{
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void checkAccountExist()
        {
            Assert.IsTrue(OnlineForum.CheckAcountExist("test1"));
            Assert.IsTrue(OnlineForum.CheckAcountExist("test2"));
            Assert.IsTrue(OnlineForum.CheckAcountExist("test3"));

            Assert.IsFalse(OnlineForum.CheckAcountExist("test"));
            Assert.IsFalse(OnlineForum.CheckAcountExist("DDD"));

        }

        [TestMethod]
        public void Test_1003314()
        {
            //正常Case
            Assert.IsTrue(OnlineForum.VerifyAccount("abcde123"));
            //過長
            Assert.IsFalse(OnlineForum.VerifyAccount("abcdefghASijk123dkfasfdjasjdkaslkdasld456789"));
            //過短
            Assert.IsFalse(OnlineForum.VerifyAccount("abc123"));
            //非英文開頭
            Assert.IsFalse(OnlineForum.VerifyAccount("123abc"));
            //包含英文和數字以外的字元
            Assert.IsFalse(OnlineForum.VerifyAccount("123我是中文"));

            //正常Case
            Assert.IsTrue(OnlineForum.VerifyPassword("123456789"));
            Assert.IsTrue(OnlineForum.VerifyPassword("abc12345"));
            Assert.IsTrue(OnlineForum.VerifyPassword("125abcde"));
            //過長
            Assert.IsFalse(OnlineForum.VerifyPassword("abcdefghASijk123dkfasfdjasjdkaslkdasld456789"));
            //過短
            Assert.IsFalse(OnlineForum.VerifyPassword("abc123"));
            //非英文開頭
            Assert.IsFalse(OnlineForum.VerifyPassword("123abc"));
            //包含英文和數字以外的字元
            Assert.IsFalse(OnlineForum.VerifyPassword("123我是中文"));

            //正常Case
            Assert.IsTrue(OnlineForum.VerifyPasswordSame("123456789", "123456789"));
            //不相同
            Assert.IsFalse(OnlineForum.VerifyPasswordSame("123456789", "123456987"));
        }

         [TestMethod]
        public void Test_Email()
        {
            //正常case
            Assert.IsTrue(OnlineForum.VerifyEmail("test1@gmail.com"));
            Assert.IsTrue(OnlineForum.VerifyEmail("test_1@gmail.com"));
            Assert.IsTrue(OnlineForum.VerifyEmail("1test@gmail.com"));
            Assert.IsTrue(OnlineForum.VerifyEmail("test1@mail.yzu.edu.tw"));
            Assert.IsTrue(OnlineForum.VerifyEmail("test_1@mail.yzu.edu.tw"));
            Assert.IsTrue(OnlineForum.VerifyEmail("test1@web_mail.com"));
            Assert.IsTrue(OnlineForum.VerifyEmail("test_1@web_mail.com"));
            Assert.IsTrue(OnlineForum.VerifyEmail("9fbw2313test_1565@yahoo.com.tw"));

            //包含 英文,數字,_ 以外的字元
            Assert.IsFalse(OnlineForum.VerifyEmail("電子信箱@mail.yzu.edu.tw"));
            Assert.IsFalse(OnlineForum.VerifyEmail("test1@電子信箱伺服器.com"));
            Assert.IsFalse(OnlineForum.VerifyEmail("test_1@web_mail.com.台灣"));
            Assert.IsFalse(OnlineForum.VerifyEmail("tes#$#$t_1@web_mail.com.tw"));

            //不是電子信箱格式
            Assert.IsFalse(OnlineForum.VerifyEmail("test_1^web_mail.com"));
            Assert.IsFalse(OnlineForum.VerifyEmail("test_1小老鼠web_mail.com"));
            Assert.IsFalse(OnlineForum.VerifyEmail("test_1$web_mail.com"));
            Assert.IsFalse(OnlineForum.VerifyEmail("test123@@@@web_mail.com"));
            Assert.IsFalse(OnlineForum.VerifyEmail("test123@happy@web_mail.com"));
        }

         [TestMethod]
         public void Test_Login()
         {
             //正常case
            
           
             Assert.AreEqual(true, Login.login("test1"));
           
         }



    }
}
