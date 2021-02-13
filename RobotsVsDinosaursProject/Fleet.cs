using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    //member variables
    class Fleet
    {
        public List<Robot> robots;
        public bool fleetStanding;
        public string fleetName;
        public double fleetHealth;
       
        //constructor
        public Fleet()
        {
            robots = new List<Robot>();
            fleetStanding = true;
                        
        }

        //methods
        public void AddRobotToFleet(Robot robot)
        {
            robots.Add(robot);
        }

        //checks robots still standing
        public double CheckFleet()
        {
            double fleetHealth;
            fleetHealth = robots.Sum(robots => robots.robotHealth);
            return fleetHealth;
        }

        public void ListFleet()
        {
            foreach(Robot robot in robots)
            {
                Console.WriteLine($"Name: {robot.robotName} Health {robot.robotHealth} Power Level {robot.robotPowerLevel}");
                Console.WriteLine($"Weapon: {robot.weapon.type} Attack Power: {robot.weapon.attackPower}");
            }
        }

    }
}

