﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace team2
{
    [TestClass]
    public class RegisterTestClass
    {
        [TestMethod]
        public void testAccountExist()
        {
            Assert.IsTrue(Register.CheckAcountExist("testtest1"));
            Assert.IsTrue(Register.CheckAcountExist("testtest2"));
            Assert.IsTrue(Register.CheckAcountExist("testtest3"));

            Assert.IsFalse(Register.CheckAcountExist("testtest"));
            Assert.IsFalse(Register.CheckAcountExist("DDDDDDDDD"));

            Assert.IsFalse(Register.CheckAcountExist("Test1"));
            Assert.IsFalse(Register.CheckAcountExist("test1@gmail.com"));
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
        public void CAPTCHA_TEST()
        {
            //Assert.AreEqual("1234", OnlineForum.C_check());
            Assert.IsTrue(Register.CHECK("1", "1"));
            Assert.IsFalse(Register.CHECK("1", "2"));
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
         public void TestRegisterAccount()
         {
             string newCAPTCHA = Register.getCAPTCHA();
             //成功案例
             Assert.AreEqual("註冊成功", Register.RegisterAccount("abcde123", "12345678", "12345678", "test_1@web_mail.com", newCAPTCHA, newCAPTCHA));
             //確定有存入資料庫
             Assert.IsTrue(Register.CheckAcountExist("abcde123"));
            
             Assert.AreEqual("註冊成功", Register.RegisterAccount("DavidTest", "12345678", "12345678", "test_11@web_mail.com", newCAPTCHA, newCAPTCHA));
             //確定有存入資料庫
             Assert.IsTrue(Register.CheckAcountExist("DavidTest"));

             //錯誤案例
             Assert.AreEqual("帳號格式不符！", Register.RegisterAccount("e123", "12345678", "12345678", "test_1@web_mail.com", newCAPTCHA, newCAPTCHA));
             Assert.AreEqual("帳號格式不符！", Register.RegisterAccount("e123", "12345", "12345678", "test_1@web_mail.com", newCAPTCHA, newCAPTCHA));
             Assert.AreEqual("密碼格式不符！", Register.RegisterAccount("abcde1234", "12345", "12345678", "test_1@web_mail.com", newCAPTCHA, newCAPTCHA));
             Assert.AreEqual("請輸入相同的密碼！", Register.RegisterAccount("abcde1234", "12345678", "12345", "test_1@web_mail.com", newCAPTCHA, newCAPTCHA));
             Assert.AreEqual("電子信箱格式不符！", Register.RegisterAccount("abcde1234", "12345678", "12345678", "test_1^web_mail.com", newCAPTCHA, newCAPTCHA));
             Assert.AreEqual("此帳號已存在！", Register.RegisterAccount("abcde123", "12345678", "12345678", "test_1@web_mail.com", newCAPTCHA, newCAPTCHA));
             Assert.AreEqual("此電子信箱已被使用！", Register.RegisterAccount("abcde1234", "12345678", "12345678", "test1@gmail.com", newCAPTCHA, newCAPTCHA));
             Assert.AreEqual("驗證碼輸入錯誤！", Register.RegisterAccount("abcde1234", "12345678", "12345678", "9fbw2313test_1565@yahoo.com.tw", newCAPTCHA, "0000"));
         }

    }

    [TestClass]
    public class ForumTestClass
    {
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
            Assert.AreEqual(false, Login.login("", ""));
            //"all wrong

            Assert.AreEqual(false, Login.login("asfdgdfgd3", "asddfgfga"));
            Assert.AreEqual(false, Login.login("asfdfgfdgdasd", "efddfgdfge"));
            Assert.AreEqual(false, Login.login("", "3333333333"));
            Assert.AreEqual(false, Login.login("asassadsad3", "12345678"));

            //嘗試了超過5次所以失敗
            Assert.AreEqual(false, Login.login("testtest3", "12345678"));
        }

        [TestMethod]
        public void Test_SignUp()
        {
            Account test = new Account("testtest", "12345678", "test@gmail.com");
            int tmp = test.Experience;
            test.SignUp();
            Assert.AreEqual(tmp + 1, test.Experience);
            test.SignUp();
            Assert.AreEqual(tmp + 2, test.Experience);

        }
    }
}
