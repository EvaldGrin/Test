using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autotest
{
    internal class Class2
    {
        [Test]

        public static void Test1()
        {
            int dalijasi = 995 % 3;
            Assert.AreEqual(0, dalijasi, "Nesidalina"); //pasibaigti
        }

        [Test]

        public static void Test2()
        {
            DateTime currentTime = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Thursday, currentTime.DayOfWeek, "Something went wrong"); //gerai
        }

        [Test]

        public static void Test3()
        {
            Thread.Sleep(5000); //arba "Task.Delay(5000)"
            
        }               
    }
}
