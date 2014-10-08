using RoyalGameOfUr.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Model
{
    public class Speler
    {
        private Spel spel;
        public int playerInt { get; private set; }
        public LinkedList<Veld> Velden
        { 
            private set;
            get; 
        }
        public List<Stuk> Stukken
        {
            private set;
            get;
        }

        public Speler(Spel spel, int speler)
        {
            playerInt = speler;
            // stukken aanmaken
            this.spel = spel;

            Stukken = new List<Stuk>();
            string stukKleur = "zwart";
            if (speler == 0)
            {
                stukKleur = "wit";
            }

            for (int i = 0; i < 6; i++)
            {
                Stukken.Add(new Stuk(stukKleur, i+1));
            }
        }

        public string DoeBeurt(int dobbelWaarde)
        {
            int stukIndex = spel.KrijgSpelerInput(playerInt);

            Stuk stuk = Stukken[stukIndex];

            LinkedListNode<Veld> node = stuk.VeldNode;
            if (node.Value is Eind)
            {
                return "fail-end";
            }
            for (int i = 0; i < dobbelWaarde; i++)
            {
                node = node.Next;
                if (node.Value is Eind)
                {
                    // einde bereikt dus er is een beurt mogelijk
                    goto EndCheck; // hoeft niet meer te checken
                }
            }
            // nu is de eind veldnode duidelijk, kijk nu of daar een stuk geplaatst kan worden 
            if (node.Value is Rozet && node.Value.IsBezet())
            {
                // hier staat al een steen op een rozet.
                return "fail-rozet-taken";
            }
            if (node.Value.IsBezet())
            {
                string kleur = stuk.Kleur;
                if (kleur == "zwart" && node.Value.HeeftZwartStuk())
                {
                    // kan niet op eigen kleur plaatsen
                    return "fail-taken";
                }
                else if (kleur == "wit" && node.Value.HeeftWitStuk())
                {
                    // kan niet op eigen kleur plaatsen
                    return "fail-taken";
                }
            }
        EndCheck:

            // nu de stuk verplaatsen

            // eerste alle stukken slaan als het geen eind veld is
            bool stukGeslagen = false;
            if (!(node.Value is Eind) && node.Value.IsBezet())
            {
                List<Stuk> stukken = node.Value.Stukken;
                // list nu clonen om concurrentmodification exception te voorkomen
                stukken = stukken.ToList();
                foreach (Stuk stukTegenstander in stukken)
                {
                    spel.Tegenstander.StukGeslagen(stukTegenstander);
                    stukGeslagen = true;
                }
            }

            // uiteindelijk stuk verplaatsen

            // verwijder stuk van huidig veld
            stuk.VeldNode.Value.RemoveStuk(stuk);

            // koppel veld aan stuk
            stuk.VeldNode = node;

            // add stuk aan veld
            node.Value.AddStuk(stuk);

            if (stukGeslagen)
            {
                return "success-geslagen";
            }

            if (node.Value is Rozet)
            {
                return "success-rozet";
            }
            if (node.Value is Eind)
            {
                return "success-einde";
            }
         
            
            return "success-normal";
        }

        public void SetVelden(LinkedList<Veld> velden)
        {
            // route setten
            if (velden == null || velden.Count == 0)
            {
                throw new Exception("Velden mag niet null of leeg zijn");
            }
            Velden = velden;


            // beginveld koppelen aan alle stukken
            LinkedListNode<Veld> veldNode = velden.First;
            Veld start = veldNode.Value;
            if (!(start is Start))
            {
                throw new Exception("Eerste veld moet startveld zijn");
            }

            foreach (Stuk stuk in Stukken)
            {
                // koppel veld aan stuk
                stuk.VeldNode = veldNode;

                // koppel stuk aan veld
                start.AddStuk(stuk);
            }
        }

        public void StukGeslagen(Stuk stuk)
        {
            // verwijder stuk van veld
            stuk.VeldNode.Value.RemoveStuk(stuk);
            
            // zet stuk op begin
            stuk.VeldNode = Velden.First;

            // voeg stuk toe aan begin
            stuk.VeldNode.Value.AddStuk(stuk);

        }

    }
}
