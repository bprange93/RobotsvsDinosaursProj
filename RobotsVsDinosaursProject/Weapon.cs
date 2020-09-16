using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Weapon
    {
        string type;
        double attackPower;

        public Weapon(string type, double attackPower)
        {
            this.type = type;
            this.attackPower = attackPower;

        }
    }
}
