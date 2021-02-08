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

        public Herd()
        {
            Dinosaur tRex = new Dinosaur("TRex", 150, 200, 300);
            Dinosaur raptor = new Dinosaur("Raptor", 150, 250, 300);
            Dinosaur spinosaur = new Dinosaur("Spinosaur", 200, 300, 400);

            dinosaurs = new List<Dinosaur>();
            dinosaurs.Add(tRex);
            dinosaurs.Add(raptor);
            dinosaurs.Add(spinosaur);
        }



    }
}
