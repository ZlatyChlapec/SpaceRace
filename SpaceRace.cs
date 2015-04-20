using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _422616Homework5
{
    class SpaceRace : ISpaceRace
    {
        public event EventHandler<ImportantEventArgs> ImportantEventHandler;

        private int stepProduction = 100;
        private int productionAmount = 0;
        private int enemyStepProduction = 100;
        private int enemyProductionAmount = 0;
        private IPart actuallyWorkingOn = null;
        private ISpaceShip myShip = new SpaceShip();
        private ISpaceShip enemyShip = new SpaceShip();
        private List<ISpace> space = new List<ISpace>();
        private List<int> enemyMoves = new List<int>();
        private bool race = true;
        private bool enemyRace = false;
        private int myTurn = 0;
        private int turn = 0;

        public SpaceRace()
        {
            try
            {
                Parser parser = new Parser("../../data/space.txt");
                space.AddRange(FillSpaces(parser.Numbers));
            }
            catch (IOException e)
            {
                space.AddRange(FillSpaces(GenerateSpace(20)));
            }

            try
            {
                Parser parser = new Parser("../../data/enemy.txt");
                enemyMoves.AddRange(parser.Numbers);
                Enemy();
            }
            catch (IOException e)
            {
                Console.WriteLine("enemy.txt not found.");
                System.Environment.Exit(0);
            }
        }

        private static List<int> GenerateSpace(int amount)
        {
            List<int> numbers = new List<int>();
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                numbers.Add(random.Next(0, 4));
            }
            return numbers;
        }

        private static List<ISpace> FillSpaces(List<int> list)
        {
            List<ISpace> finallList = new List<ISpace>();
            foreach (int i in list)
            {
                switch (i)
                {
                    case 0:
                        finallList.Add(new EmptySpace());
                        break;
                    case 1:
                        finallList.Add(new DangerousSpace());
                        break;
                    case 2:
                        finallList.Add(new ExtremlyDangerousSpace());
                        break;
                    case 3:
                        finallList.Add(new AnomalySpace());
                        break;
                }
            }
            return finallList;
        }

        public void Turn()
        {
            if (actuallyWorkingOn == null)
            {
                Handler("Something must be in process of making.");
            }
            else
            {
                if (productionAmount < actuallyWorkingOn.RequiredPoints)
                {
                    productionAmount += stepProduction;
                    Handler("Actually building " + PartTypeToString(actuallyWorkingOn.Type) + " " + productionAmount + " from " + actuallyWorkingOn.RequiredPoints);
                }
                if (productionAmount >= actuallyWorkingOn.RequiredPoints)
                {
                    Builder(actuallyWorkingOn);
                    int temp = productionAmount;
                    productionAmount -= actuallyWorkingOn.RequiredPoints;
                    Handler(PartTypeToString(actuallyWorkingOn.Type) + " is complete " + productionAmount + " points will be transfered to your next building.", null);
                }
                //Console.WriteLine(myTurn); Tu je myTrun o jedno menšie ako bude na riadku 121 WTF? BLACK MAGIC!!!
                myTurn++;
                EnemyLaunch();
            }
        }

        public void Launch()
        {
            if (Control("all"))
            {
                Handler("Ship released.");
                //Console.WriteLine(turn);
                //Console.WriteLine(myTurn);
                EnemyLaunch();
                int position = 0;
                int enemyPosition = 0;
                myShip.Speed = myShip.BasicSpeed;
                enemyShip.Speed = enemyShip.BasicSpeed;
                bool truth = true;

                while (race)
                {
                    myShip.Speed += myShip.Speed;
                    enemyShip.Speed += enemyShip.Speed;

                    if (enemyRace)
                    {
                        for (int i = 0; i <= (int)enemyShip.Speed; i++)
                        {
                            ISpace temp = space.ElementAt(enemyPosition);
                            enemyShip.HP -= temp.HPDamage;
                            enemyShip.Speed -= temp.SpeedDamage;

                            if (enemyPosition == space.Count - 1 && enemyShip.HP > 1)
                            {
                                race = false;
                                Handler("GAME OVER.\nEnemy was faster then you.", false);
                                truth = false;
                                break;
                            }
                            enemyPosition++;
                        }
                    }

                    if (race)
                    {
                        myTurn++;
                        Handler("Speed of ship for next move is " + myShip.Speed + " and HP is " + myShip.HP);
                        EnemyLaunch();
                        Thread.Sleep(2000);
                    }

                    for (int i = 0; i <= (int)myShip.Speed; i++)
                    {
                        if (!truth) break;
                        ISpace temp = space.ElementAt(position);
                        myShip.HP -= temp.HPDamage;
                        myShip.Speed -= temp.SpeedDamage;

                        if (myShip.HP < 1 && position < space.Count)
                        {
                            race = false;
                            Handler("GAME OVER.\nHP of your ship gone on zero or lower :-( You are dead.", false);
                            break;
                        }

                        if (position == space.Count - 1 && myShip.HP > 1 && truth)
                        {
                            race = false;
                            Handler("YOU ARE WINNER!!! You did it, congratulations.\nYou arrived to finish with " + myShip.HP + " HP.", false);
                            break;
                        }
                        position++;
                    }

                    if (myShip.Speed < myShip.BasicSpeed)
                        myShip.Speed = myShip.BasicSpeed;
                    if (enemyShip.Speed < enemyShip.BasicSpeed)
                        enemyShip.Speed = enemyShip.BasicSpeed;
                }
            }
        }

        public void Production(SpaceShipPartsProduction type)
        {
            switch (type)
            {
                case SpaceShipPartsProduction.Casing:
                    if (actuallyWorkingOn == null && Control("casing"))
                        Handler("Casing will be built.", new Casing());
                    else
                        if (Control("casing"))
                            Handler(PartTypeToString(actuallyWorkingOn.Type) + " is building right now. You can't build more than one at once.");
                    break;
                case SpaceShipPartsProduction.Cockpit:
                    if (actuallyWorkingOn == null && Control("cockpit"))
                        Handler("Cockpit will be built.", new Cockpit());
                    else
                        if (Control("cockpit"))
                            Handler(PartTypeToString(actuallyWorkingOn.Type) + " is building right now. You can't build more than one at once.");
                    break;
                case SpaceShipPartsProduction.Engine:
                    if (actuallyWorkingOn == null && Control("engine"))
                        Handler("Engine will be built.", new Engine());
                    else
                        if (Control("engine"))
                            Handler(PartTypeToString(actuallyWorkingOn.Type) + " is building right now. You can't build more than one at once.");
                    break;
                case SpaceShipPartsProduction.LifeSupport:
                    if (actuallyWorkingOn == null && Control("lifeSupport"))
                        Handler("Life Support will be built.", new LifeSupport());
                    else
                        if (Control("lifeSupport"))
                            Handler(PartTypeToString(actuallyWorkingOn.Type) + " is building right now. You can't build more than one at once.");
                    break;
                case SpaceShipPartsProduction.Production:
                    if (actuallyWorkingOn == null)
                    {
                        myTurn++;
                        myTurn++;
                        stepProduction += 10;
                        Handler("Production will be increased by 10.");
                        Handler("One round penalty.");
                    }
                    else
                        Handler(PartTypeToString(actuallyWorkingOn.Type) + " is building right now. You can't build more than one at once.");
                    break;
                case SpaceShipPartsProduction.StasisChamber:
                    if (actuallyWorkingOn == null && Control("stasisChamber"))
                        Handler("Stasis Chamber will be built.", new StasisChamber());
                    else
                        if (Control("stasisChamber"))
                            Handler(PartTypeToString(actuallyWorkingOn.Type) + " is building right now. You can't build more than one at once.");
                    break;
                case SpaceShipPartsProduction.Thruster:
                    if (actuallyWorkingOn == null && Control("thruster"))
                        Handler("Thruster will be built.", new Thruster());
                    else
                        if (Control("thruster"))
                            Handler(PartTypeToString(actuallyWorkingOn.Type) + " is building right now. You can't build more than one at once.");
                    break;
                case SpaceShipPartsProduction.None:
                    Handler("None");
                    break;
            }
        }

        private bool Control(string what)
        {
            int casing = 0;
            int cockpit = 0;
            int engine = 0;
            int lifeSupport = 0;
            int stasisChamber = 0;
            int thruster = 0;

            foreach (IPart p in myShip.Parts)
            {
                if (p is Casing)
                    casing++;
                if (p is Cockpit)
                    cockpit++;
                if (p is Engine)
                    engine++;
                if (p is LifeSupport)
                    lifeSupport++;
                if (p is StasisChamber)
                    stasisChamber++;
                if (p is Thruster)
                    thruster++;
            }

            if (what.Equals("casing"))
            {
                if (casing + 1 > 5)
                {
                    Handler("5 casings is max.");
                    return false;
                }
            }
            if (what.Equals("cockpit"))
            {
                if (cockpit + 1 > 1)
                {
                    Handler("You can have just one.");
                    return false;
                }
            }
            if (what.Equals("engine"))
            {
                if (engine + 1 > 1)
                {
                    Handler("You can have just one.");
                    return false;
                }
            }
            if (what.Equals("lifeSupport"))
            {
                if (lifeSupport + 1 > 1)
                {
                    Handler("You can have just one.");
                    return false;
                }
            }
            if (what.Equals("stasisChamber"))
            {
                if (stasisChamber + 1 > 1)
                {
                    Handler("You can have just one.");
                    return false;
                }
            }
            if (what.Equals("thruster"))
            {
                if (thruster + 1 > 5)
                {
                    Handler("5 casings is max.");
                    return false;
                }
            }
            bool test = true;
            if (what.Equals("all"))
            {
                if (casing < 1)
                {
                    Handler("You have to build at least one casing.");
                    test = false;
                }
                if (cockpit < 1)
                {
                    Handler("You have to build at least one cockpit.");
                    test = false;
                }
                if (engine < 1)
                {
                    Handler("You have to build at least one engine.");
                    test = false;
                }
                if (lifeSupport < 1)
                {
                    Handler("You have to build at least one life support.");
                    test = false;
                }
                if (stasisChamber < 1)
                {
                    Handler("You have to build at least one stasis chamber.");
                    test = false;
                }
                if (thruster < 1)
                {
                    Handler("You have to build at least one thruster.");
                    test = false;
                }
            }
            return test;
        }

        private string PartTypeToString(SpaceShipPartsProduction type)
        {
            switch (type)
            {
                case SpaceShipPartsProduction.Casing:
                    return "Casing";
                case SpaceShipPartsProduction.Cockpit:
                    return "Cockpit";
                case SpaceShipPartsProduction.Engine:
                    return "Engine";
                case SpaceShipPartsProduction.LifeSupport:
                    return "Life Support";
                case SpaceShipPartsProduction.Production:
                    return "Production";
                case SpaceShipPartsProduction.StasisChamber:
                    return "Stasis Chamber";
                case SpaceShipPartsProduction.Thruster:
                    return "Thruster";
                default:
                    return "None";
            }
        }

        private void Builder(IPart part)
        {
            switch (part.Type)
            {
                case SpaceShipPartsProduction.Casing:
                    myShip.HP += 5;
                    myShip.Parts.Add(part);
                    break;
                case SpaceShipPartsProduction.Cockpit:
                    myShip.Parts.Add(part);
                    break;
                case SpaceShipPartsProduction.Engine:
                    myShip.BasicSpeed += 1;
                    myShip.Parts.Add(part);
                    break;
                case SpaceShipPartsProduction.LifeSupport:
                    myShip.Parts.Add(part);
                    break;
                case SpaceShipPartsProduction.StasisChamber:
                    myShip.Parts.Add(part);
                    break;
                case SpaceShipPartsProduction.Thruster:
                    myShip.BasicSpeed += 0.25;
                    myShip.Parts.Add(part);
                    break;
            }
        }

        private void Handler(string message)
        {
            Handler(message, true);
        }

        private void Handler(string message, bool end)
        {
            Handler(message, end, actuallyWorkingOn);
        }

        private void Handler(string message, IPart part)
        {
            Handler(message, true, part);
        }

        private void Handler(string message, bool end, IPart part)
        {
            actuallyWorkingOn = part;
            EventHandler<ImportantEventArgs> handler = ImportantEventHandler;
            ImportantEventArgs newEvent = new ImportantEventArgs(message);
            newEvent.End = end;
            if (handler != null)
                handler(this, newEvent);
        }

        private void EnemyLaunch()
        {
            if (turn == myTurn)
            {
                Handler("Enemey released ship.");
                enemyRace = true;
            }
        }

        private void Enemy()
        {
            for (int i = 0; i < enemyMoves.Count; i++)
            {
                switch (enemyMoves.ElementAt(i))
                {
                    case 0:
                        enemyStepProduction += 10;
                        enemyProductionAmount = enemyStepProduction;
                        turn++;
                        turn++;
                        break;
                    case 1:
                        while (enemyProductionAmount < 250)
                        {
                            enemyProductionAmount += enemyStepProduction;
                            turn++;
                        }
                        enemyProductionAmount -= 250;
                        enemyShip.Parts.Add(new Cockpit());
                        break;
                    case 2:
                        while (enemyProductionAmount < 250)
                        {
                            enemyProductionAmount += enemyStepProduction;
                            turn++;
                        }
                        enemyProductionAmount -= 250;
                        enemyShip.Parts.Add(new LifeSupport());
                        break;
                    case 3:
                        while (enemyProductionAmount < 750)
                        {
                            enemyProductionAmount += enemyStepProduction;
                            turn++;
                        }
                        enemyProductionAmount -= 750;
                        enemyShip.Parts.Add(new StasisChamber());
                        break;
                    case 4:
                        while (enemyProductionAmount < 750)
                        {
                            enemyProductionAmount += enemyStepProduction;
                            turn++;
                        }
                        enemyProductionAmount -= 750;
                        enemyShip.BasicSpeed += 1;
                        enemyShip.Parts.Add(new Engine());
                        break;
                    case 5:
                        while (enemyProductionAmount < 400)
                        {
                            enemyProductionAmount += enemyStepProduction;
                            turn++;
                        }
                        enemyProductionAmount -= 400;
                        enemyShip.BasicSpeed += 0.25;
                        enemyShip.Parts.Add(new Thruster());
                        break;
                    case 6:
                        while (enemyProductionAmount < 300)
                        {
                            enemyProductionAmount += enemyStepProduction;
                            turn++;
                        }
                        enemyProductionAmount -= 300;
                        enemyShip.HP += 5;
                        enemyShip.Parts.Add(new Casing());
                        break;
                    case 7:
                        turn++;
                        break;
                }
            }
        }
    }
}