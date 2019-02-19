using System;
using System.Collections.Generic;
using PowerLib;

namespace HeroLib
{
    public abstract class Hero : IComparable, IEquatable<Hero>
    {
        protected readonly string Secret_Identity;
        protected readonly string Name;
        protected Dictionary<String, Power> Powers = new Dictionary<string, Power>();

        protected Hero(string _hero_name, string _secret_identity)
        {
            Secret_Identity = _secret_identity;
            Name = _hero_name;

            Powers.Add("Punch", new Punch());
            Powers.Add("Block", new Block());
            Powers.Add("Dodge", new Dodge());
        }
        public string GetName()
        {
            return Name;
        }
        public string GetSecretIdentity()
        {
            return Secret_Identity;
        }
        public int Level()
        {
            int levelPoints = 0;
            foreach(String p in Powers.Keys)
            {
                levelPoints += Powers[p].Experience();
            }
            return levelPoints;
        }
        public int CompareTo(object obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Invalid comparison");
            }
            if (obj is Hero otherHero)
            {
                return this.Level().CompareTo(otherHero.Level());
            }
            else throw new ArgumentException("Invalid comparison");
        }
        public bool Equals(Hero otherHero)
        {
            return Secret_Identity == otherHero.Secret_Identity;
        }
        public void LearnFightingPower(string PowerName)
        {
            if(Powers.ContainsKey(PowerName))
            {
                throw new ExistingPowerException("Power exists");
            }
            else
            {
                Powers.Add(PowerName, new CustomFightingPower(PowerName));
            }
        }
        public void LearnNeutralPower(string PowerName)
        {
            if (Powers.ContainsKey(PowerName))
            {
                throw new ExistingPowerException("Power exists");
            }
            else
            {
                Powers.Add(PowerName, new CustomNeutralPower(PowerName));
            }
        }
        public void UpgradeFightingPower(string PowerName, int XP)
        {
            if (!Powers.ContainsKey(PowerName))
            {
                throw new InvalidPowerException("Power does not exist.");
            }
            else if (Powers[PowerName].GetType().BaseType != typeof(FightingPower))
            {
                throw new InvalidPowerException("Cannot upgrade non-combative power.");
            }
            else
            {
                Powers[PowerName].UpgradeStrength(XP);
            }
        }
        public int UsePower(string PowerName)
        {
            if(!Powers.ContainsKey(PowerName))
            {
                throw new InvalidPowerException("Power does not exist.");
            }
            else
            {
                return Powers[PowerName].UsePower();
            }
        }
        public int PowerInfo(string PowerName)
        {
            if(!Powers.ContainsKey(PowerName)) {
                throw new InvalidPowerException("Power does not exist.");
            }
            else
            {
                return Powers[PowerName].Experience();
            }
        }
        public List<String> GetPowers()
        {
            List<String> powers = new List<string>();
            foreach(string p in Powers.Keys)
            {
                powers.Add(p);
            }
            return powers;
        }

    }

    public class Superman : Hero
    {
        public Superman() : base("Superman","Clark Kent") {
            Powers.Add("Fly", new Fly());
            Powers.Add("LaserVision", new LaserVision());
            Powers["LaserVision"].UpgradeStrength(100);
            Powers["Punch"].UpgradeStrength(60);
        }

    }

    public class Wonderwoman : Hero
    {
        public Wonderwoman() : base("Wonderwoman","Princess Diana of Themyscira") {
            Powers.Add("Fly", new Fly());
            Powers["Punch"].UpgradeStrength(60);
            Powers["Dodge"].UpgradeStrength(40);
        }
    }

    public class Batman : Hero
    {
        public Batman() : base("Batman","Bruce Wayne") {
            Powers.Add("Throw Ninja Star", new CustomFightingPower("Throw Ninja Star"));
            Powers["Throw Ninja Star"].UpgradeStrength(30);
            Powers["Punch"].UpgradeStrength(30);
            Powers["Dodge"].UpgradeStrength(40);
            Powers["Block"].UpgradeStrength(10);
        }
    }

    public class Deadpool : Hero
    {
        public Deadpool() : base("Deadpool","Wade Wilson") {
            Powers.Add("Regenerate", new Regenerate());
            Powers.Add("Shoot", new CustomFightingPower("Shoot"));
            Powers["Shoot"].UpgradeStrength(60);
        }
    }

    public class CustomHero : Hero
    {
        public CustomHero(string heroName, string secretID) : base(heroName, secretID) { }
    }

    public class ExistingPowerException : Exception
    {
        public ExistingPowerException(string message) : base(message) { }
    }

    public class InvalidPowerException : Exception
    {
        public InvalidPowerException(string message) : base(message) { }
    }
}


