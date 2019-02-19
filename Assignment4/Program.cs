using System;
using System.Collections.Generic;
using HeroLib;
namespace Assignment4
{
    class Program
    {
        static public List<Hero> Heroes = new List<Hero>();

        static bool HeroInList(string heroName)
        {
            foreach(Hero h in Heroes)
            {
                if (h.GetName() == heroName) return true;
            }

            return false;
        }

        static Hero GetHero(string heroName)
        {
            foreach (Hero h in Heroes)
            {
                if (h.GetName() == heroName) return h;
            }
            throw new Exception("Hero not found");
        }

        static void Help()
        {
            Console.WriteLine("Here are your commands: \n");
            Console.WriteLine("help: view these commands.");
            Console.WriteLine("add-hero: add hero to your arsenal.");
            Console.WriteLine("add-power: add power to hero.");
            Console.WriteLine("upgrade-power: your hero is growing up.");
            Console.WriteLine("list-heroes: displays your arsenal.");
            Console.WriteLine("list-powers: shows a hero's power.");
            Console.WriteLine("sort: sorts your heroes by strength and lists arsenal.");
            Console.WriteLine("quit: exits this program");
        }

        static void AddHero()
        {
            Console.WriteLine("Enter your Hero's name.");
            string heroName = Console.ReadLine();
            if (!HeroInList(heroName))
            {
                Hero hero;
                switch (heroName)
                {
                    case "Superman":
                        hero = new Superman();
                        break;
                    case "Batman":
                        hero = new Batman();
                        break;
                    case "Wonderwoman":
                        hero = new Wonderwoman();
                        break;
                    case "Deadpool":
                        hero = new Deadpool();
                        break;
                    default:
                        Console.WriteLine("What's your hero's secret identity?");
                        hero = new CustomHero(heroName, Console.ReadLine());
                        break;
                }
                Heroes.Add(hero);
            }
            else throw new Exception("Hero already exists.");
        }

        static void AddPower()
        {
            Console.WriteLine("What is your hero's name?");
            Hero h = GetHero(Console.ReadLine());
            Console.WriteLine("Enter your new power's name.");
            string power = Console.ReadLine();
            Console.WriteLine("Will your power be used directly in combat? (Y/N)");
            if (Console.ReadLine() == "N") h.LearnNeutralPower(power);
            else h.LearnFightingPower(power);
        }
        static void UpgradePower()
        {
            Console.WriteLine("What's your hero's name?");
            Hero h = GetHero(Console.ReadLine());
            Console.WriteLine("Which power?");
            string p = Console.ReadLine();
            Console.WriteLine("How much experience?");
            int.TryParse(Console.ReadLine(), out int xp);
            h.UpgradeFightingPower(p, xp);
            Console.WriteLine("Power level: " + h.PowerInfo(p));
        }
        static void ListHeroes()
        {
            foreach(Hero h in Heroes)
            {
                Console.WriteLine("Hero: " + h.GetName() + " Secret Identity: " + h.GetSecretIdentity() + " Level: " + h.Level());
            }
        }
        static void ListPowers()
        {
            Console.WriteLine("For which hero?");
            try
            {
                Hero h = GetHero(Console.ReadLine());
                foreach(string p in h.GetPowers())
                {
                    Console.WriteLine(p + ": " + h.PowerInfo(p) + " xp");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        static void Sort()
        {
            Heroes.Sort();
            ListHeroes();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hero Simulator.");
            Help();
            bool running = true;
            while(running)
            {
                Console.Write("HeroSim: ");
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "add-hero": AddHero(); break;
                        case "add-power": AddPower(); break;
                        case "list-heroes": ListHeroes(); break;
                        case "list-powers": ListPowers(); break;
                        case "upgrade-power": UpgradePower(); break;
                        case "sort": Sort(); break;
                        case "quit": running = false; break;
                        default: Help(); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
