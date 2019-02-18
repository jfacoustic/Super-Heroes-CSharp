using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PowerLib
{
    [TestFixture()]
    class TestFlyingPower
    {

        [Test]
        public void TestUseFlight()
        {
            Fly fly = new Fly();
            Assert.AreEqual(fly.UsePower(), 0);
        }
        [Test]
        public void TestFightingPower()
        {
            FightingPower punch = new Punch();
            Assert.AreEqual(punch.UsePower(), 1);
            punch.UpgradeStrength(100);
            Assert.AreEqual(punch.UsePower(), 101);
        }
        [Test]
        public void TestListPower()
        {
            List<Power> list = new List<Power>();
            list.Add(new Fly());
            list.Add(new Punch());
            list.Add(new Block());
            list[1].UpgradeStrength(100);
            Console.WriteLine(list[1].UsePower());
            list.Sort();
        }
    }
}