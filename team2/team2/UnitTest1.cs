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
    }
}
