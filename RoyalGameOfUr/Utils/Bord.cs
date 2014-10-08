using RoyalGameOfUr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Utils
{
    public class Bord
    {
        private static int VeltId = 0;
        public static void NieuwBord(Speler speler1, Speler speler2)
        {
            LinkedList<Veld> speler1Route = new LinkedList<Veld>();
            LinkedList<Veld> speler2Route = new LinkedList<Veld>();

            // begin velden
            speler1Route.AddLast(new Start(VeltId++));
            speler2Route.AddLast(new Start(VeltId++));

            // begin route
            for (int i = 0; i < 3; i++)
            {
                speler1Route.AddLast(new Veld(VeltId++));
                speler2Route.AddLast(new Veld(VeltId++));
            }

            speler1Route.AddLast(new Rozet(VeltId++));
            speler2Route.AddLast(new Rozet(VeltId++));

            // velden voor beide spelers
            for (int i = 0; i < 8; i++)
            {
                Veld veld = null;
                if (i != 3)
                {
                    veld = new Veld(VeltId++);
                }
                else
                {
                    veld = new Rozet(VeltId++);
                }
                speler1Route.AddLast(veld);
                speler2Route.AddLast(veld);
            }

            // einde route

            speler1Route.AddLast(new Veld(VeltId++));
            speler2Route.AddLast(new Veld(VeltId++));

            speler1Route.AddLast(new Rozet(VeltId++));
            speler2Route.AddLast(new Rozet(VeltId++));

            speler1Route.AddLast(new Eind(VeltId++));
            speler2Route.AddLast(new Eind(VeltId++));

            // geef de players de gemaakte routes
            speler1.SetVelden(speler1Route);
            speler2.SetVelden(speler2Route);

        }
    }
}
