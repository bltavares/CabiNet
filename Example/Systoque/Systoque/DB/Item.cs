
using System;
using CabiNet;

namespace DB
{
    class Item : IThing
    {
        
        
        [Persistent]
        public Int64 produto_id { get; set; }
        

        
        [Persistent]
        public Int64 venda_id { get; set; }
        

        
        [Persistent]
        public Double Valor { get; set; }
        

        
        [Persistent]
        public Double Quantidade { get; set; }
        

    }
}
