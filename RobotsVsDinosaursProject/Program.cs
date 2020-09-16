﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaursProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Dinosaur tRex = new Dinosaur("TRex", 100, 200, 300);
            Dinosaur raptor = new Dinosaur("Raptor", 150, 250, 300);
            Dinosaur spinosaur = new Dinosaur("Spinosaur", 200, 300, 400);

            Weapon sword = new Weapon("Sword", 150);

            Robot alpha = new Robot("Alpha", 150, 250, sword);
            Robot beta = new Robot("Beta", 100, 200, sword);
            Robot omega = new Robot("Omega", 200, 200, sword);

            Fleet robots = new Fleet();
            robots.robots.Add(alpha);
            robots.robots.Add(beta);
            robots.robots.Add(omega);

            Herd dinosaur = new Herd();

                
        }
    }
}
