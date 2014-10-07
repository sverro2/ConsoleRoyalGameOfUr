using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr.Utils
{
    public class Dobbelsteen
    {
        private static Random random = new Random();

        public static int Gooi()
        {
            return random.Next(5);
        }
    }
}
