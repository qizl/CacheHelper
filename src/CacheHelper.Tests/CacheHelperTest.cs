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
        public void Insert()
        {
            string key = "a";
            object value = 123;
            CacheHelper.Insert(CacheHelper.GenerateKey(1), value);
            var result = CacheHelper.Get(CacheHelper.GenerateKey(1));

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Get()
        {
            var str = "test string";
            CacheHelper.Insert(CacheHelper.GenerateKey(), str);
            var result = CacheHelper.Get().ToString();
            Assert.AreEqual(str, result);
        }
    }
}
