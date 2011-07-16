using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabiNet
{
    class Version
    {

        static string Author = "Bruno Lara Tavares";
        static string License = "LGPL";
        static int Major = 0;
        static int Medio = 0;
        static int Minor = 1;

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}", Major, Medio, Minor);
        }
    }

}
