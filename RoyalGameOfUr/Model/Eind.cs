using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Model
{
    public class Eind : Veld{

        public Eind(int id) : base(id)
        {

        }
        public override String ToString()
        {
            StringBuilder alleStukken = new StringBuilder();

            foreach (Stuk stuk in Stukken)
            {
                alleStukken.Append(stuk.ID + " ");
            }
            return "Eind: " + "[ " + alleStukken.ToString() + "]\n";
        }
    }
      
    
}
