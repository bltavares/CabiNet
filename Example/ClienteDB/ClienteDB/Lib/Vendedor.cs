using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabiNet;

namespace ClienteDB.Lib
{
    class Vendedor : IThing
    {
        [Persistent]
        public string Nome { get; set; }

        [Persistent]
        public string Telefone { get; set; }

        [Persistent]
        public int Numero { get; set; }

        [Persistent]
        public DateTime Data { get; set; }
    }
}
