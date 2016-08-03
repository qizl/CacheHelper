using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.EnjoyCodes.CacheHelper.Tests
{
    [TestClass]
    public class CacheHelperTest
    {
        [TestMethod]
        public void TestInsert()
        {
            string key = "a";
            object value = 123;
            CacheHelper.Insert(CacheHelper.GenerateKey(key), value);
            var result = CacheHelper.Get(CacheHelper.GenerateKey(key));

            Assert.AreEqual(value, result);
        }
    }
}
