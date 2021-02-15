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
        
    }
}
