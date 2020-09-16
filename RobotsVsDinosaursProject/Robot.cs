using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Robot
    {
        string name;
        double health;
        double powerLevel;
        Weapon weapon;
        
        public Robot(string name, double health, double powerLevel,Weapon weapon)
        {
            this.name = name;
            this.health = health;
            this.powerLevel = powerLevel;
            this.weapon = weapon;
            
        }
    }
}
