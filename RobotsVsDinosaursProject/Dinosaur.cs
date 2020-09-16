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

        //constructor
        public Dinosaur(string type, double health, double energy, double attackPower)
        {
            this.type = type;
            this.health = health;
            this.energy = energy;
            this.attackPower = attackPower;

        }

        //member methods

        public void attackRobot(Robot robot)
        {
            robot.health = robot.health - attackPower;
        }


    }
}
