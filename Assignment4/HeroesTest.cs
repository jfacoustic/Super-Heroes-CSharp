using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace HeroLib
{
    [TestFixture]
    public class HeroesTest
    {
        [Test]
        public void TestEquality()
        {
            Hero superman = new Superman();
            Hero clarkkent = new Superman();
            Assert.AreEqual(superman, clarkkent);
            Hero wonderwoman = new Wonderwoman();
            Assert.AreNotEqual(superman, wonderwoman);
        }
        [Test]
        public void TestHeroList()
        {
            List<Hero> list = new List<Hero>
            {
                new Superman(),
                new Batman(),
                new Wonderwoman(),
                new Deadpool()
            };
            list.Sort();
            for(int i = 0; i < 3; i++)
            {
                Assert.LessOrEqual(list[i].Level(), list[i + 1].Level());
            }
        }
        [Test]
        public void TestLearnPower()
        {
            Hero superman = new Superman();
            superman.LearnNeutralPower("Jump");
            Assert.AreEqual(superman.UsePower("Jump"), 0);
            superman.LearnFightingPower("Kick");
            Assert.AreEqual(superman.UsePower("Kick"), 1);
            Assert.Throws<ExistingPowerException>(() => superman.LearnNeutralPower("Fly"));
        }
        [Test]
        public void TestUpgradeFightingPower()
        {
            Hero superman = new Superman();
            int temp = superman.UsePower("Punch");
            superman.UpgradeFightingPower("Punch", 10);
            Assert.AreEqual(superman.UsePower("Punch"), temp + 10);
            Assert.Throws<InvalidPowerException>(() => superman.UpgradeFightingPower("Fly",10));
            Assert.Throws<InvalidPowerException>(() => superman.UpgradeFightingPower("Sit down",10));
        }
        [Test]
        public void TestGetPowersAndCustomHero()
        {
            Hero GhostRider = new CustomHero("Ghost Rider", "Johnny Blaze");
            List<String> powers = new List<string>
            {
                "Punch",
                "Block",
                "Dodge"
            };
            Assert.AreEqual(powers, GhostRider.GetPowers());
        }
    }
}
