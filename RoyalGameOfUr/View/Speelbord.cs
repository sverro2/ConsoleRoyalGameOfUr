using RoyalGameOfUr.Model;
using System;
using System.Collections;
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

        private void ToonSpeelbord()
        {
            List<Veld> speler1Lijst = routeSpeler1.ToList<Veld>();
            List<Veld> speler2Lijst = routeSpeler2.ToList<Veld>();

            StringBuilder top = new StringBuilder();
            StringBuilder middle = new StringBuilder();
            StringBuilder bottom = new StringBuilder();

            //Verkrijg de lengte van het speelbord
            for (int x = 0; x < speler1Lijst.Count; x++ )
            {
                if (speler1Lijst[x].random == speler2Lijst[x].random)
                {
                    middle.Append(speler1Lijst[x] + " ");
                    top.Append("   ");
                    bottom.Append("   ");
                }
                else
                {
                    top.Append(speler1Lijst[x] + " ");
                    bottom.Append(speler2Lijst[x] + " ");
                    middle.Append("   ");
                }
            }
            
            Console.WriteLine("\n" + top.ToString());
            Console.WriteLine("\n" + middle.ToString());
            Console.WriteLine("\n" + bottom.ToString());

        }

        public int UserInput(int playerInt, int dobbelWaarde)
        {
            Console.WriteLine("##Je hebt " + dobbelWaarde + " gegooit##\n\n");
            Console.WriteLine("| Royal Game of Ur| \tTurn: " + SpelerKleur(playerInt));
            Console.WriteLine("*****************************************************");

            ToonSpeelbord();

            Console.WriteLine("Welk stuk wil je verplaatsen? 1-6");
            int input = 0;
            try
            {
                input = Convert.ToInt16(Console.ReadKey().KeyChar.ToString());
            }catch(Exception e){
                ShowStatus("Verkeerde input... Gebruik een nummer tussen 1 en 6");
                return UserInput(playerInt, dobbelWaarde);
            }
            Console.WriteLine("De volgende speler is aan de beurt...");
            Console.ReadKey();
            Console.Clear();

            return input-1;
        }

        private String SpelerKleur(int playerInt)
        {
            if (playerInt == 1)
            {
                return "Zwart";
            }
            else
            {
                return "White";
            }
        }

        public ConsoleKey Besturing(int playerInt)
        {
            Console.WriteLine("Gebruik SPATIE om te gooien voor " + SpelerKleur(playerInt) + " of gebruik S aan om het spel te stoppen");
            ConsoleKey key = Console.ReadKey().Key;
            return key;
        }

        public void ShowStatus(String status)
        {
            Console.WriteLine("> " + status);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
