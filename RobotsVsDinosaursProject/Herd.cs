using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Herd
    {
        public List<Dinosaur> dinosaurs;
        public bool herdAlive;
        public string herdName;
        public double herdHealth;

        public Herd()
        {
            dinosaurs = new List<Dinosaur>();
            herdAlive = true;
        }

        public void AddDinosaurToHerd(Dinosaur dinosaur)
        {
            dinosaurs.Add(dinosaur);
        }

        //checks dinosaurs still standing
        public double CheckHerd()
        {
            double herdHealth;
            herdHealth = dinosaurs.Sum(dinosaurs => dinosaurs.dinosaurHealth);
            return herdHealth;
        }

        public void ListHerd()
        {
            foreach (Dinosaur dinosaur in dinosaurs)
            {
                Console.WriteLine($"Name: {dinosaur.dinosaurType} Health {dinosaur.dinosaurHealth} Power Level {dinosaur.dinosaurEnergy}");
                Console.WriteLine($"Energy: {dinosaur.dinosaurEnergy} Attack Power: {dinosaur.dinosaurAttackPower}");
            }
        }

    }
}
