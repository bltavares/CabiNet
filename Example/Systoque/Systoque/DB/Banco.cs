
using CabiNet;

namespace DB
{
    class Banco : ICabinet
    {

        public Shelf<Vendedor> Vendedores { get { return Unshelve<Vendedor>(); } }

        public Shelf<Venda> Vendas { get { return Unshelve<Venda>(); } }

        public Shelf<Item> Items { get { return Unshelve<Item>(); } }

        public Shelf<Produto> Produtos { get { return Unshelve<Produto>(); } }


        public Banco()
            : base("driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;pwd=;database=sys_10900039")
        { }


    }
}
