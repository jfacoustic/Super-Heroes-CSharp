using System;
using System.Collections.Generic;
using HeroLib;
namespace Assignment4
{
    class Program
    {
        static public List<Hero> Heroes = new List<Hero>();

        static public void CyanWriteLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Here are your commands:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  help:view these commands.");
            Console.WriteLine("  add-hero: add hero to your arsenal.");
            Console.WriteLine("  add-power: add power to hero.");
            Console.WriteLine("  upgrade-power: your hero is growing up.");
            Console.WriteLine("  list-heroes: displays your arsenal.");
            Console.WriteLine("  list-powers: shows a hero's power.");
            Console.WriteLine("  sort: sorts your heroes by strength and lists arsenal.");
            Console.WriteLine("  quit: exits this program\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void AddHero()
        {
            CyanWriteLine("Enter your Hero's name.");
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
                        CyanWriteLine("What's your hero's secret identity?");
                        hero = new CustomHero(heroName, Console.ReadLine());
                        break;
                }
                Heroes.Add(hero);
            }
            else throw new Exception("Hero already exists.");
        }

        static void AddPower()
        {
            CyanWriteLine("What is your hero's name?");
            Hero h = GetHero(Console.ReadLine());
            CyanWriteLine("Enter your new power's name.");
            string power = Console.ReadLine();
            CyanWriteLine("Will your power be used directly in combat? (Y/N)");
            if (Console.ReadLine() == "N") h.LearnNeutralPower(power);
            else h.LearnFightingPower(power);
        }
        static void UpgradePower()
        {
            CyanWriteLine("What's your hero's name?");
            Hero h = GetHero(Console.ReadLine());
            CyanWriteLine("Which power?");
            string p = Console.ReadLine();
            CyanWriteLine("How much experience?");
            int.TryParse(Console.ReadLine(), out int xp);
            h.UpgradeFightingPower(p, xp);
            CyanWriteLine("Power level: " + h.PowerInfo(p));
        }
        static void ListHeroes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  {0,-30} {1, -30} {2,7}\n ", "Hero", "Secret Identity", "Level");

            foreach (Hero h in Heroes)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  {0, -30} {1, -30}" , h.GetName(), h.GetSecretIdentity());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("  {0, 7} \n", h.Level());
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        static void ListPowers()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("For which hero?");
            Console.ForegroundColor = ConsoleColor.White;

                Hero h = GetHero(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (string p in h.GetPowers())
                {
                    Console.WriteLine(p + ": \t" + h.PowerInfo(p) + " xp");
                }
                Console.ForegroundColor = ConsoleColor.White;
        }
        static void Sort()
        {
            Heroes.Sort();
            Heroes.Reverse();
            ListHeroes();
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("  Welcome to the Hero Simulator. \n  Brought to you by Joshua Mathews");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Help();
            bool running = true;
            while(running)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("HeroSim:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
