using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Fleet
    {
        public List<Robot> robots;
        public Weapon weapon;

        public Fleet()
        {


            robots = new List<Robot>();

            Robot alpha = new Robot("Alpha", 200, 250, weapon);
            Robot beta = new Robot("Beta", 100, 200, weapon);
            Robot omega = new Robot("Omega", 200, 200, weapon);

            robots.Add(alpha);
            robots.Add(beta);
            robots.Add(omega);
        }
    }
}

