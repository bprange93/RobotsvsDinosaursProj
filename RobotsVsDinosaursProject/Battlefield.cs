using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Battlefield
    {
        //member variables
        Fleet fleet;
        Herd herd;
        string playerTeam;
        string computerTeam;
        bool playAsRobot;
        string player;
        string computer;
        Armory activeArmory;
        string[] activeAttacks;
        
        //constructor
        public Battlefield()
        {
            activeArmory = InitializeArmory();
            
        }

        //methods

        //add weapons to armory
        public Armory InitializeArmory()
        {
            Armory armory = new Armory();
            return armory;
        }
        
        public void ArmRobots()
        {
            int totalRobots = fleet.robots.Count;
            for (int i = 0; i < totalRobots; i++)
               activeArmory.AssignWeaponToRobot(fleet.robots[i]);
        }

        public void ArmComputerRobots()
        {
            int totalRobots = fleet.robots.Count;
            for (int i = 0; i < totalRobots; i++)
                activeArmory.ComputerPlayerWeapons(fleet.robots[i]);
        }

        public Fleet CreateRobots()
        {
            //adds weapons to armory
            Weapon weaponOne = new Weapon("Beam Sword", 5);
            activeArmory.AddWeaponToArmory(weaponOne);
            Weapon weaponTwo = new Weapon("Laser Cannon", 10);
            activeArmory.AddWeaponToArmory(weaponTwo);
            Weapon weaponThree = new Weapon("Ion Axe", 15);
            activeArmory.AddWeaponToArmory(weaponThree);

            //creates robots
            Robot robotOne = new Robot("Omega");
            Robot robotTwo = new Robot("Beta");
            Robot robotThree = new Robot("Alpha");

            //add robots to the fleet
            Fleet fleetOne = new Fleet();
            fleetOne.AddRobotToFleet(robotOne);
            fleetOne.AddRobotToFleet(robotTwo);
            fleetOne.AddRobotToFleet(robotThree);

            //Shows fleet and displays list of weapons
            Console.WriteLine("Fleet has been created.");
            foreach (Robot robot in fleetOne.robots)
            {
                Console.WriteLine($"Name: {robot.robotName}");
                Console.ReadLine();
            }
            return fleetOne;
        }

        public Herd CreateDinosaurs()
        {
            //create dino attacks
            string[] dinosAttacks = new string[3];
            dinosAttacks[0] = "Chomp";
            dinosAttacks[1] = "Tear";
            dinosAttacks[2] = "Rip";
            activeAttacks = dinosAttacks;

            Dinosaur dinoOne = new Dinosaur("Raptor", 5);
            Dinosaur dinoTwo = new Dinosaur("T-Rex", 10);
            Dinosaur dinoThree = new Dinosaur("Spinosaur", 15);

            //add dinos to the herd
            Herd herdOne = new Herd();
            herdOne.AddDinosaurToHerd(dinoOne);
            herdOne.AddDinosaurToHerd(dinoTwo);
            herdOne.AddDinosaurToHerd(dinoThree);

            //Shows fleet and displays list of weapons
            Console.WriteLine("Herd has been created.");
            foreach (Dinosaur dinosaur in herdOne.dinosaurs)
            {
                Console.WriteLine($"Name: {dinosaur.dinosaurType}");
                Console.ReadLine();
            }
            return herdOne;
        }

        public void Attack()
        {
            int attackerIndex;
            int attackedIndex;
            int attackResult;
            double herdHealth;
            double fleetHealth;

            if(playAsRobot == true)
            {
                int herdSize = herd.dinosaurs.Count;
                Console.WriteLine("Which Dinosaur will attack?");
                for(int i = 0; i < herdSize; i++)
                {
                    int choice = i + 1;
                    if(herd.dinosaurs[i].dinosaurAlive == true)
                    {
                        Console.WriteLine($"{choice}: {herd.dinosaurs[i].dinosaurType}");
                    }
                }
                string userInput = Console.ReadLine();
                attackedIndex = int.Parse(userInput) - 1;

                int fleetSize = fleet.robots.Count;
                Console.WriteLine("Which Robot will attack");
                for(int i = 0; i < fleetSize; i++)
                {
                    int choiceTwo = i + 1;
                    if(fleet.robots[i].robotAlive == true)
                    {
                        Console.WriteLine($"{choiceTwo}: { fleet.robots[i].robotName}");
                    }
                }
                string userInputTwo = Console.ReadLine();
                attackerIndex = int.Parse(userInputTwo) - 1;
            }
            else
            {
                int fleetSize = fleet.robots.Count;
                Console.WriteLine("Which Robot will attack?");
                for(int i = 0; i < fleetSize; i++)
                {
                    int choiceTwo = i + 1;
                    if (fleet.robots[i].robotAlive == true)
                    {
                        Console.WriteLine($"{choiceTwo}: {fleet.robots[i].robotName}");
                    }
                }
                string userInputTwo = Console.ReadLine();
                attackedIndex = int.Parse(userInputTwo) - 1;

                int herdSize = herd.dinosaurs.Count;
                Console.WriteLine("Which Robot will attack");
                for (int i = 0; i < fleetSize; i++)
                {
                    int choice = i + 1;
                    if (herd.dinosaurs[i].dinosaurAlive == true)
                    {
                        Console.WriteLine($"{choice}: {herd.dinosaurs[i].dinosaurType}");
                    }
                }
                string userInput = Console.ReadLine();
                attackerIndex = int.Parse(userInput) - 1;

                DinosaurAttack(herd.dinosaurs[attackerIndex]);
            }
            attackResult = DetermineAttackResult();

            if (attackResult == 1 && playAsRobot == true)
            {
                Console.WriteLine("Successful Attack");
                fleet.robots[attackerIndex].AttackDinosaur(herd.dinosaurs[attackedIndex]);
                herdHealth = herd.CheckHerd();
                fleet.robots[attackerIndex].PostAttackPowerLevel();

                if (herdHealth <= 0)
                {
                    RobotWin();
                }
                else
                {
                    GameMenu();
                }

            }
            else if (attackResult == 0 && playAsRobot == true)
            {
                Console.WriteLine($"Unsuccessful Attack!  You have been counter attacked by {herd.dinosaurs[attackedIndex].dinosaurType}");
                herd.dinosaurs[attackedIndex].AttackRobot(fleet.robots[attackerIndex]);
                fleetHealth = fleet.CheckFleet();
                fleet.robots[attackerIndex].PostAttackPowerLevel();
                if (fleetHealth <= 0)
                {
                    DinosaurWin();
                }
                else
                {
                    GameMenu();
                }

            }
            else if (attackResult == 2 && playAsRobot == true)
            {
                Console.WriteLine("The attack has ended in a stalemate!  You have taken no damage, nor have you inflicted any");
                fleet.robots[attackerIndex].PostAttackPowerLevel();
                GameMenu();
            }
            else if (attackResult == 1 && playAsRobot == false)
            {
                Console.WriteLine("Successful Attack");
                herd.dinosaurs[attackerIndex].AttackRobot(fleet.robots[attackedIndex]);
                fleetHealth = fleet.CheckFleet();
                herd.dinosaurs[attackerIndex].PostAttackEnergy();
                if (fleetHealth <= 0)
                {
                    DinosaurWin();
                }
                else
                {
                    GameMenu();
                }

            }
            else if (attackResult == 0 && playAsRobot == false)
            {
                Console.WriteLine($"Unsuccessful Attack!  You have been counter attacked by {fleet.robots[attackedIndex].robotName}");
                fleet.robots[attackedIndex].AttackDinosaur(herd.dinosaurs[attackerIndex]);
                herdHealth = herd.CheckHerd();
                herd.dinosaurs[attackerIndex].PostAttackEnergy();
                if (herdHealth <= 0)
                {
                    RobotWin();
                }
                else
                {
                    GameMenu();
                }


            }
            else if (attackResult == 2 && playAsRobot == false)
            {
                Console.WriteLine("The attack has ended in a stalemate!  You have taken no damage, nor have you inflicted any");
                herd.dinosaurs[attackerIndex].PostAttackEnergy();
                GameMenu();
            }




        }

        public void GameMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine($"1. View My {playerTeam}");
            Console.WriteLine($"2. Attack a {computer}");
            Console.WriteLine("3. Exit Game");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    if (playAsRobot == false)
                    {
                        herd.ListHerd();
                        GameMenu();
                    }
                    else
                    {
                        fleet.ListFleet();
                        GameMenu();
                    }
                    break;
                case "2":
                    Attack();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    GameMenu();
                    break;
            }

        }
    

        public void DinosaurAttack(Dinosaur dinosaur)
        {
            Console.WriteLine("Pick Dinosaur Attack");

            for(int i = 0; i < 3; i++)
            {
                int attackChoice = i + 1;
                Console.WriteLine($"{attackChoice}: {activeAttacks[i]}");
            }
            string userInput = Console.ReadLine();
            int attackIndex = int.Parse(userInput) - 1;
            Console.WriteLine(dinosaur.dinosaurType + activeAttacks[attackIndex] + "s the robot");
        }
        
        public int DetermineAttackResult()
        {
            int playerRoll;
            int computerRoll;
            int rollResult;

            playerRoll = RollDice(20);
            Console.WriteLine($"You rolled {playerRoll}");
            System.Threading.Thread.Sleep(500);
            computerRoll = RollDice(20);
            Console.WriteLine($"Computer rolled {computerRoll}");

            rollResult = CompareRolls(playerRoll, computerRoll);
            return rollResult;
        }

        public int RollDice(int number)
        {
            Random random;
            random = new Random();
            return random.Next(number);
        }
        public int CompareRolls(int playerRoll, int computerRoll)
        {
            if (playerRoll > computerRoll)
            {
                return 1;
            }
            else if (playerRoll < computerRoll)
            {
                return 0;
            }
            else
            {
                return 2;
            }

        }
        public void DinosaurWin()
        {
            Console.WriteLine("The Robots have defeated the Herd!");
            Console.WriteLine("Would you like to play again? Y or N");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                case "Y":
                    StartGame();
                    break;
                case "n":
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        public void RobotWin()
        {
            Console.WriteLine("The Dinosaurs have defeated the Robots!");
            Console.WriteLine("Would you like to play again? Y or N");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                case "Y":

                    StartGame();
                    break;
                case "n":
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Robots Vs Dinosaurs!");
            Console.WriteLine("Would you like to play as the Robots or Dinosaurs?");
            Console.WriteLine("1. Robots");
            Console.WriteLine("2. Dinosaurs");
            Console.WriteLine("3. Exit Game");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    player = "Robot";
                    playerTeam = "Fleet";
                    playAsRobot = true;
                    computer = "Dinosaur";
                    computerTeam = "Herd";
                    fleet = CreateRobots();
                    herd = CreateDinosaurs();
                    ArmRobots();
                    RunGame();
                    Console.Clear();
                    break;

                case "2":
                    player = "Dinosaur";
                    playerTeam = "Herd";
                    playAsRobot = true;
                    computer = "Robot";
                    computerTeam = "Fleet";
                    fleet = CreateRobots();
                    herd = CreateDinosaurs();
                    ArmComputerRobots();
                    RunGame();
                    Console.Clear();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    RunGame();
                    break;

            }
        }

        public void RunGame()
        {
            Console.WriteLine($"Name your {playerTeam}");
            string userInput = Console.ReadLine();
            if(playAsRobot == true)
            {
                fleet.fleetName = userInput;
                herd.herdName = "Enemy  Herd";
                Console.Clear();
                Console.WriteLine(fleet.fleetName + " VS " + herd.herdName);
                Console.WriteLine();
            }
            else
            {
                herd.herdName = userInput;
                fleet.fleetName = "Enemy Fleet";
                Console.Clear();
                Console.WriteLine(herd.herdName + "VS " + fleet.fleetName);
                Console.WriteLine();
            }
            GameMenu();
        }
    }
}
