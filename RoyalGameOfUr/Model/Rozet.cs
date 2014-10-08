using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Model
{
    public class Rozet : Veld
    {
        public Rozet(int id) : base(id)
        {

        }
        public override string ToString()
        {
            if (Stukken.Count != 0)
            {
                return "|" + Stukken[0].ID + "|";
            }
            else
            {
                return "|--|";
            }
        }
    }
}
