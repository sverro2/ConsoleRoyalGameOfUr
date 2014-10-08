using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Model
{
    public class Start : Veld
    {
        public Start(int id) : base(id)
        {

        }
        public override String ToString()
        {
            StringBuilder alleStukken = new StringBuilder();
            
            foreach(Stuk stuk in Stukken){
                alleStukken.Append(stuk.ID + " ");
            }
            return "Begin: " + "[ " + alleStukken.ToString() + "]\n";
        }
    }
}
