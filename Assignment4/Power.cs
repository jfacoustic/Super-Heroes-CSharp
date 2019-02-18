using System;

namespace PowerLib
{
    public abstract class Power : IComparable, IEquatable<Power>
    {
        protected int Strength;
        public int Experience()
        {
            return Strength;
        }
        public abstract int UsePower();
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (obj is Power otherPower)
                return this.UsePower().CompareTo(otherPower.UsePower());
            else throw new ArgumentException("Object is not a power.");
        }
        public bool Equals(Power otherPower)
        {
            return Strength == otherPower.Strength;
        }
        virtual public void UpgradeStrength(int upgradePoints) { }
    }
    public abstract class FightingPower : Power
    {
        override public void UpgradeStrength(int upgradePoints)
        {
            Strength += upgradePoints;
        }
        protected FightingPower()
        {
            Strength = 1;
        }
    }
    public class Fly : Power
    {
        public Fly()
        {
            Strength = 0;
        }
        override public int UsePower()
        {
            Console.WriteLine("I'm flying!");
            return Strength;
        }
    }
    public class Punch : FightingPower
    {
        public override int UsePower()
        {
            Console.WriteLine("Throws a punch with " + Strength + " strength");
            return Strength;
        }
    }
    public class LaserVision : FightingPower
    {
        public override int UsePower()
        {
            Console.WriteLine("Shoots a laser beam with " + Strength + " strength");
            return Strength;
        }
    }
    public class Block : FightingPower
    {
        public override int UsePower()
        {
            Console.WriteLine("Blocks with " + Strength + " strength");
            return Strength;
        }
    }
    public class Dodge : FightingPower
    {
        public override int UsePower()
        {
            Console.WriteLine("Dodges wtih + " + Strength + " strength");
            return Strength;
        }
    }
}
