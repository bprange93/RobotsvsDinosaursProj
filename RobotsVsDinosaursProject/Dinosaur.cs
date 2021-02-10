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
        public string dinosaurType;
        public double dinosaurHealth;
        public double dinosaurEnergy;
        public double dinosaurAttackPower;
        public bool dinosaurAlive;
        public string dinosaurHerd;

        //constructor
        public Dinosaur(string dinosaurType, double dinosaurAttackPower)
        {
            this.dinosaurType = dinosaurType;
            dinosaurHealth = 100;
            dinosaurEnergy = 150;
            dinosaurAlive = true;
            this.dinosaurAttackPower = dinosaurAttackPower;

        }

        //member methods
        
        //checks dino health and lets them know if they are alive or dead and if alive how much health remaining
        public void CheckDinosaurLife()
        {
            if(dinosaurHealth <= 0)
            {
                dinosaurHealth = 0;
                dinosaurAlive = false;
                Console.WriteLine(dinosaurType + " has died.");

            }
            else
            {
                Console.WriteLine(dinosaurType + " has " + dinosaurHealth + " health remaining.");
            }
        }


        public void attackRobot(Robot robot)
        {
            robot.robotHealth = robot.robotHealth - dinosaurAttackPower;

        }
        //calculate damage recieved from a robots attack
        public void RobotAttackingDinosaur(double damage)
        {
            dinosaurHealth -= damage;
            CheckDinosaurLife();
        }
        //takes energy away after an attack has been done
        public void PostAttackEnergy()
        {
            dinosaurEnergy -= 10;
            if(dinosaurAlive == true)
            {
                Console.WriteLine(dinosaurType + "'s energy is now: " + dinosaurEnergy);
            }
        }

    }
}
