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
    }
}
