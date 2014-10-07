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

        public static void NieuwBord(Speler speler1, Speler speler2)
        {
            LinkedList<Veld> speler1Route = new LinkedList<Veld>();
            LinkedList<Veld> speler2Route = new LinkedList<Veld>();

            // begin velden
            speler1Route.AddLast(new Start());
            speler2Route.AddLast(new Start());

            // begin route
            for (int i = 0; i < 3; i++)
            {
                speler1Route.AddLast(new Veld());
                speler2Route.AddLast(new Veld());
            }

            speler1Route.AddLast(new Rozet());
            speler2Route.AddLast(new Rozet());

            // velden voor beide spelers
            for (int i = 0; i < 8; i++)
            {
                Veld veld = null;
                if (i == 3)
                {
                    veld = new Veld();
                }
                else
                {
                    veld = new Rozet();
                }
                speler1Route.AddLast(veld);
                speler2Route.AddLast(veld);
            }

            // einde route

            speler1Route.AddLast(new Veld());
            speler2Route.AddLast(new Veld());

            speler1Route.AddLast(new Rozet());
            speler2Route.AddLast(new Rozet());

            speler1Route.AddLast(new Eind());
            speler2Route.AddLast(new Eind());

        }
    }
}
