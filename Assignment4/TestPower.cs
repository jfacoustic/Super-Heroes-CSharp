using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PowerLib
{
    [TestFixture]
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
            List<Power> list = new List<Power>
            {
                new Fly(),
                new Punch(),
                new Block()
            };
            list[1].UpgradeStrength(100);
            Assert.AreEqual(list[1].UsePower(), 101);
            list.Sort();
            Assert.AreEqual(list[0].UsePower(), 0);
            Assert.AreEqual(list[1].UsePower(), 1);
            Assert.AreEqual(list[2].UsePower(), 101);
        }
        [Test]
        public void TestCustomPowers()
        {
            Assert.AreEqual(new CustomNeutralPower("Laugh").UsePower(), 0);
            FightingPower bite = new CustomFightingPower("Bite");
            Assert.AreEqual(bite.UsePower(), 1);
            bite.UpgradeStrength(100);
            Assert.AreEqual(bite.UsePower(), 101);
        }
    }
}