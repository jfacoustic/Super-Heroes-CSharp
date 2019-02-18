using System;
using System.Collections;
using PowerLib;

namespace HeroLib
{
    public abstract class Hero : IComparable, IEquatable<Hero>
    {
        protected readonly string Secret_Identity;
        protected Power[] Powers;

        protected Hero(string _secret_identity)
        {
            Secret_Identity = _secret_identity;
        }
        public int Level()
        {
            int levelPoints = 0;
            foreach(Power p in Powers)
            {
                levelPoints += p.Experience();
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

    }

    public class Superman : Hero
    {
        public Superman() : base("Clark Kent") { }

    }
}


