using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace team2
{
    [TestClass]
    public class RegisterTestClass
    {
        [TestMethod]
        public void testkAccountExist()
        {
            Assert.IsTrue(Register.CheckAcountExist("testtest1"));
            Assert.IsTrue(Register.CheckAcountExist("testtest2"));
            Assert.IsTrue(Register.CheckAcountExist("testtest3"));

            Assert.IsFalse(Register.CheckAcountExist("testtest"));
            Assert.IsFalse(Register.CheckAcountExist("DDDDDDDDD"));

        }

        [TestMethod]
        public void testEmailExist()
        {
            Assert.IsTrue(Register.CheckEmailExist("test1@gmail.com"));
            Assert.IsTrue(Register.CheckEmailExist("test2@gmail.com"));
            Assert.IsTrue(Register.CheckEmailExist("test3@gmail.com"));

            Assert.IsFalse(Register.CheckEmailExist("Hello@gmail.com"));
            Assert.IsFalse(Register.CheckEmailExist("Bye@gmail.com"));

        }

        [TestMethod]
        public void testAccountFormat()
        {
            //test account's format

            //正常Case
            Assert.IsTrue(Register.VerifyAccount("abcde123"));
            //過長
            Assert.IsFalse(Register.VerifyAccount("abcdefghASijk123dkfasfdjasjdkaslkdasld456789"));
            //過短
            Assert.IsFalse(Register.VerifyAccount("abc123"));
            //非英文開頭
            Assert.IsFalse(Register.VerifyAccount("123abc"));
            //包含英文和數字以外的字元
            Assert.IsFalse(Register.VerifyAccount("123我是中文"));
        }

        [TestMethod]
        public void testPasswordFormat()
        {
            //test password's format

            //正常Case
            Assert.IsTrue(Register.VerifyPassword("123456789"));
            Assert.IsTrue(Register.VerifyPassword("abc12345"));
            Assert.IsTrue(Register.VerifyPassword("125abcde"));
            //過長
            Assert.IsFalse(Register.VerifyPassword("abcdefghASijk123dkfasfdjasjdkaslkdasld456789"));
            //過短
            Assert.IsFalse(Register.VerifyPassword("abc1234"));
            Assert.IsFalse(Register.VerifyPassword("123abc"));
            Assert.IsFalse(Register.VerifyPassword(""));
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
         public void Test_Login()
         {
             //正常case
             Assert.AreEqual(true, Login.login("testtest1", "12345678"));
             Assert.AreEqual(true, Login.login("testtest2", "12345678"));
             Assert.AreEqual(true, Login.login("testtest3", "12345678"));
           
             //錯誤的case
             //id 對 密碼錯
             Assert.AreEqual(false, Login.login("testtest", "asdasggd"));
             //空
             Assert.AreEqual(false, Login.login("",""));
             //"all wrong

             Assert.AreEqual(false, Login.login("asfdgdfgd3", "asddfgfga"));
             Assert.AreEqual(false, Login.login("asfdfgfdgdasd", "efddfgdfge"));
             Assert.AreEqual(false, Login.login("","3333333333"));
             Assert.AreEqual(false, Login.login("asassadsad3","12345678"));

             //嘗試了超過5次所以失敗
             Assert.AreEqual(false, Login.login("testtest3","12345678"));
         }

       


    }
}
