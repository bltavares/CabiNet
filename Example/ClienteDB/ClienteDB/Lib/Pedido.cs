using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabiNet;

namespace ClienteDB
{
    class Pedido : IThing
    {
        [Persistent]
        public string Num { get; set; }
        [Persistent]
        public long Cliente_id { get; set; }
    }
}
