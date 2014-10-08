using RoyalGameOfUr.Model;
using RoyalGameOfUr.Utils;
using RoyalGameOfUr.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Controller
{
    public class Spel
    {
        public Speler Beurt { get; private set; }
        public Speler Tegenstander { get; private set; }

        private Speler speler1;
        private Speler speler2;
        private int dobbelWaarde;

        //Views
        Speelbord speelBordView;

        public void DoeRonde()
        {
            dobbelWaarde = Dobbelsteen.Gooi();
            ConsoleKey key = speelBordView.Besturing(Beurt.playerInt);

            //controlleer of het spel moet worden gestopt of dat een dobbelsteen moet worden gegooid
            if (key == ConsoleKey.S)
            {
                Environment.Exit(0);
            }

            if (dobbelWaarde == 0)
            {
                // er is 0 gegooid
                // laat dit weten aan de view, nu is volgende speler aan de beurt
                speelBordView.ShowStatus("Je hebt 0 gegooid... De volgende speler is aan de beurt.");
                
            }

            // nu kijken of er wel een beurt mogelijk is (bord niet bezet) (alleen checken als er meer dan 0 is gegooid)
            if (dobbelWaarde > 0)
            {
                bool beurtMogelijk = false;
                foreach (Stuk stuk in Beurt.Stukken)
                {
                    if (stuk.VeldNode.Value is Eind)
                    {
                        // deze kan niet verplaatst worden...
                        continue;
                    }
                    LinkedListNode<Veld> node = stuk.VeldNode;
                    for (int i = 0; i < dobbelWaarde; i++)
                    {
                        node = node.Next;
                        if (node.Value is Eind)
                        {
                            // einde bereikt dus er is een beurt mogelijk
                            beurtMogelijk = true;
                            goto EndLoop; // zo kom je uit een geneste loop
                        }
                    }
                    // nu is de eind veldnode duidelijk, kijk nu of daar een stuk geplaatst kan worden 
                    if (node.Value is Rozet && node.Value.IsBezet())
                    {
                        continue; // kan hier niet opgezet worden
                    }
                    if (node.Value.IsBezet())
                    {
                        string kleur = stuk.Kleur;
                        if (kleur == "zwart" && node.Value.HeeftZwartStuk())
                        {
                            // kan niet op eigen kleur plaatsen
                            continue;
                        }
                        else if (kleur == "wit" && node.Value.HeeftWitStuk())
                        {
                            // kan niet op eigen kleur plaatsen
                            continue;
                        }
                    }
                    // alle checks gedaan, er is een beurt mogelijk
                    beurtMogelijk = true;
                    break;
                }
            EndLoop:

                if (!beurtMogelijk)
                {
                    // er is geen beurt mogelijk met deze dobbelwaarde
                    // laat dit weten aan een view
                    // andere speler nu aan de beurt
                    speelBordView.ShowStatus("Met de huidige dobbelwaarde is geen beurt mogelijk. De volgende is aan de beurt");

                }
                else
                {
                    // er is een beurt mogelijk, nu loopen totdat de speler een geldige steen kiest
                    bool klaarBeurt = false;
                    while (!klaarBeurt)
                    {
                        string success = Beurt.DoeBeurt(Dobbelsteen.Gooi());

                        // kijk naar de string van success en op basis daarvan roep de juiste views aan en check wat nu te doen
                    
                        klaarBeurt = true;
                        switch (success)
                        {
                            case "fail-end":
                                // deze steen staat al op t einde
                                // view
                                klaarBeurt = false;
                                break;
                            case "fail-taken":
                                // er is al een stuk van jezelf op het target veld
                                // view
                                klaarBeurt = false;
                                break;
                            case "fail-rozet-taken":
                                // er is al een stuk op het target rozet veld
                                // view
                                klaarBeurt = false;
                                break;
                            case "success-normal":
                                // stuk normaal verplaatst
                                // view
                                break;
                            case "success-geslagen":
                                // stuk normaal verplaatst en stuk van tegenstander geslagen
                                // view
                                break;
                            case "success-rozet":
                                // stuk op een rozet geplaatst, speler nog keer aan beurt
                                // view
                                klaarBeurt = false;
                                break;
                            case "success-einde":
                                // stuk naar het einde gebracht
                                // view
                                break;
                        }
                    }
                }
            }


            if (Beurt == speler1)
            {
                Beurt = speler2;
                Tegenstander = speler1;
            }
            else
            {
                Beurt = speler1;
                Tegenstander = speler2;
            }
           

        }



        public int KrijgSpelerInput(int playerInt)
        {
            // verkrijgt de index van het stuk dat de speler wilt verplaatsen.

            return speelBordView.UserInput(playerInt, dobbelWaarde);
        }

        public void Start()
        {
            speler1 = new Speler(this, 0);
            speler2 = new Speler(this, 1);


            Beurt = speler1;
            Tegenstander = speler2;

            Bord.NieuwBord(speler1, speler2);
            speelBordView = new Speelbord(speler1, speler2);

            while (SpelBezig())
            {
                DoeRonde();

            }


        }

        public bool SpelBezig()
        {
            return speler1.Velden.Last.Value.Stukken.Count < 6 && speler2.Velden.Last.Value.Stukken.Count < 6;
        }
    }
}
