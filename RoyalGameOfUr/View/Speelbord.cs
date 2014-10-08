using RoyalGameOfUr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.View
{
    class Speelbord
    {
        private LinkedList<Veld> routeSpeler1;
        private LinkedList<Veld> routeSpeler2;

        public Speelbord(Speler speler1, Speler speler2)
        {
            routeSpeler1 = speler1.Velden;
            routeSpeler2 = speler2.Velden;
        }

        private void toonSpeelbord()
        {
            Console.WriteLine(routeSpeler1);
        }
    }
}
