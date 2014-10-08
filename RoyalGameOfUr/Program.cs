using RoyalGameOfUr.Controller;
using RoyalGameOfUr.Model;
using RoyalGameOfUr.Utils;
using RoyalGameOfUr.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    class Program
    {
        static void Main(string[] args)
        {
            Spel spel = new Spel();
            spel.Start();
            /*
            Speler speler1 = new Speler(spel, 0);
            Speler speler2 = new Speler(spel, 1);
            Bord.NieuwBord(speler1, speler2);
            //Speelbord speelbord = new Speelbord(speler1, speler2);*/
            
        }
    }
}
