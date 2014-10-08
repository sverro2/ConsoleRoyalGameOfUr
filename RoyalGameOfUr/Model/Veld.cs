using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Model
{
    public class Veld
    {
        public List<Stuk> Stukken { get; private set; }
        public int random;

        public Veld(int veldId)
        {
            Stukken = new List<Stuk>();
            random = veldId;
        }

        public void AddStuk(Stuk stuk)
        {
            Stukken.Add(stuk);
        }

        public void RemoveStuk(Stuk stuk)
        {
            Stukken.Remove(stuk);
        }

        public bool IsBezet()
        {
            return Stukken.Count > 0;
        }

        public bool HeeftZwartStuk()
        {
            if (!IsBezet())
            {
                return false;
            }
            foreach (Stuk stuk in Stukken)
            {
                if (stuk.Kleur == "zwart")
                {
                    return true;
                }
            }
            return false;
        }

        public bool HeeftWitStuk()
        {
            if (!IsBezet())
            {
                return false;
            }
            foreach (Stuk stuk in Stukken)
            {
                if (stuk.Kleur == "wit")
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            if (Stukken.Count != 0)
            {
                return Stukken[0].ID;
            }
            else
            {
                return "--";
            }
        }
    }
}
