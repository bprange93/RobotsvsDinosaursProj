using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Dinosaur
    {

        //member variables
        public string type;
        public double health;
        public double energy;
        public double attackPower;
        public bool dinosaurAlive;
        public string dinosaurHerd;

        //constructor
        public Dinosaur(string type, double health, double energy, double attackPower)
        {
            this.type = type;
            this.health = health;
            this.energy = energy;
            this.attackPower = attackPower;

        }

        //member methods

        public void CheckDinosaurLife()
        {
            if(health <= 0)
            {
                health = 0;
                dinosaurAlive = false;
                Console.WriteLine(type + " has died.");

            }
            else
            {
                Console.WriteLine(type + " has " + health + " health remaining.");
            }
        }

        public void attackRobot(Robot robot)
        {
            robot.health = robot.health - attackPower;

            if (robot.health <= 0)
            {
                Console.WriteLine("Robot is dead.");
                Console.ReadLine();
            }
            else if (robot.health > 0)
            {
                Console.WriteLine("Robot is still alive!");
                Console.ReadLine();
            }
        }




    }
}
