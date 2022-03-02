using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest
{
    public class Class1
    {
        [Test]
        public static void FirstTest()
        {
            int leftover = 5 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
            Assert.IsTrue(0 == leftover, "5 is not even");
        }

        [Test]
        public static void TestNowIs19h()
        {
            DateTime currectTime = DateTime.Now;
            Assert.AreEqual(19, currectTime.Hour, "Now is not 19 h");

        }


        

        





    }
}
