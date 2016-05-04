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
            CacheHelper.Insert(key, value);
            var result = CacheHelper.Get(key);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void TestGet()
        { CacheHelper.Get(1, 2); }
    }
}
