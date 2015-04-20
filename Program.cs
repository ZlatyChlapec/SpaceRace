using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _422616Homework5
{
    class Program
    {
        private static bool race = true;
        static void Main(string[] args)
        {
            Console.Title = "BEST GAME IN THE WORLD!!! A.K.A. Space Race";
            Music music = new Music();
            Thread thread = new Thread(new ThreadStart(music.Play));
            thread.Start();
            SpaceRace spaceRace = new SpaceRace();
            spaceRace.ImportantEventHandler += (sender, type) => Console.WriteLine(type.Message);
            spaceRace.ImportantEventHandler += (sender, type) => race = type.End;
            while (race)
            {
                switch (Console.ReadLine())
                {
                    case "next turn":
                        spaceRace.Turn();
                        break;
                    case "launch":
                        spaceRace.Launch();
                        break;
                    case "production":
                        spaceRace.Production(SpaceShipPartsProduction.Production);
                        break;
                    case "casing":
                        spaceRace.Production(SpaceShipPartsProduction.Casing);
                        break;
                    case "cockpit":
                        spaceRace.Production(SpaceShipPartsProduction.Cockpit);
                        break;
                    case "engine":
                        spaceRace.Production(SpaceShipPartsProduction.Engine);
                        break;
                    case "life support":
                        spaceRace.Production(SpaceShipPartsProduction.LifeSupport);
                        break;
                    case "stasis chamber":
                        spaceRace.Production(SpaceShipPartsProduction.StasisChamber);
                        break;
                    case "thruster":
                        spaceRace.Production(SpaceShipPartsProduction.Thruster);
                        break;
                    case "exit":
                        Console.WriteLine("All your progres will be lost, are you sure?");
                        if ("y" == Console.ReadLine())
                            System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong command comooon man.");
                        break;
                }
            }
            if (!race)
                thread.Abort();
        }
    }
}
