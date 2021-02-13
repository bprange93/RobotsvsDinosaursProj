using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Armory
    {
        //member variables
        public List<Weapon> weapons;


        //constructor
        public Armory()
        {
            weapons = new List<Weapon>();
        }

        //methods
        public void AddWeaponToArmory(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public void AssignWeaponToRobot(Robot robot)
        {
            Console.WriteLine("Select Weapon for Robot");
            int weaponsInArmory = weapons.Count;
            for (int i = 0; i <weaponsInArmory; i++)
            {
                int weaponNumber = i + 1;
                Console.WriteLine($"{weaponNumber}. {weapons[i].type}");
            }
            string userInput = Console.ReadLine();
            int weaponIndex = int.Parse(userInput);

            robot.weapon = weapons[weaponIndex - 1];
        }

        public void ComputerPlayerWeapons(Robot robot)
        {
            int weaponsInArmory = weapons.Count;
            for(int i = 0; i < weaponsInArmory; i++)
            {
                robot.weapon = weapons[i];
            }
        }
    }
}
