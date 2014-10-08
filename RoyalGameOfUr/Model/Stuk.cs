using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Model
{
    public class Stuk
    {
        public string Kleur { get; private set; }
        public string ID { get; private set; }

        public LinkedListNode<Veld> VeldNode
        {
            get;
            set;
        }

        public Stuk(string kleur, int idNumber)
        {
            ID = (kleur == "wit" ? "W" : "Z") + idNumber;
            Kleur = kleur;
        }
    }
}
