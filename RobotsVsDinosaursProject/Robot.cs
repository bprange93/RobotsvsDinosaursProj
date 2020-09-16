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
        public string name;
        public double health;
        public double powerLevel;
        public Weapon weapon;

        public Robot(string name, double health, double powerLevel, Weapon weapon)
        {
            this.name = name;
            this.health = health;
            this.powerLevel = powerLevel;
            this.weapon = weapon;

        }

        public void attackDinosaur(Dinosaur dinosaur)
        {
            dinosaur.health = dinosaur.health - weapon.attackPower;


            if (dinosaur.health <= 0)
            {
                Console.WriteLine("Dinosaur is dead.");
                Console.ReadLine();
            }
        }
    }
}
