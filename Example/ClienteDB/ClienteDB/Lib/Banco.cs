using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabiNet;

namespace ClienteDB.Lib
{
    class Banco : ICabinet
    {

        public Shelf<Cliente> Clientes { get { return Unshelve<Cliente>(); } }
        public Shelf<Vendedor> Vendedores { get { return Unshelve<Vendedor>(); } }

        public Banco()
            : base("driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;pwd=;database=b_10900039")
        { }


    }
}
