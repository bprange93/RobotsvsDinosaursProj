using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Robot
    {
        //member variables
        public string robotName;
        public double robotHealth;
        public double robotPowerLevel;
        public Weapon weapon;
        public bool robotAlive;
        public string robotFleet;

        //constructor
        public Robot(string robotName)
        {
            robotHealth = 100;
            robotPowerLevel = 150;
            robotAlive = true;
            this.robotName = robotName;
        }

        //possible better way
        public void attackDinosaur(Dinosaur dinosaur)
        {
            dinosaur.dinosaurHealth = dinosaur.dinosaurHealth - weapon.attackPower;


            if (dinosaur.dinosaurHealth <= 0)
            {
                Console.WriteLine("Dinosaur is dead.");
                Console.ReadLine();
            }
            else if (dinosaur.dinosaurHealth < 0)
            {
                Console.WriteLine("Dinosaur is alive!");
                Console.ReadLine();
                
            }
            
        }

        public void CheckRobotLife()
        {
            if(robotHealth <= 0)
            {
                robotHealth = 0;
                robotAlive = false;
                Console.WriteLine(robotName + " has died");
            }
            else
            {
                Console.WriteLine(robotName + " has " + robotHealth + " health remaining");
            }
        }

        public void IncomingAttack(double damage)
        {
            
        }
    }
}
