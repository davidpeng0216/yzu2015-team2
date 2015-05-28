using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace team2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void checkAccountExist()
        {
            Assert.IsTrue(Register.CheckAcountExist("test1"));
            Assert.IsTrue(Register.CheckAcountExist("test2"));
            Assert.IsTrue(Register.CheckAcountExist("test3"));

            Assert.IsFalse(Register.CheckAcountExist("test"));
            Assert.IsFalse(Register.CheckAcountExist("DDD"));

        }
    }
}
