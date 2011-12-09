using DB;

namespace Systoque
{
    class ItemDecorator
    {
        private Item _item;
        private Produto _produto;

        public string Codigo { get { return _produto.CodBarra; } }

        public string Nome { get { return _produto.Nome; } }

        public double ValorUnitario { get { return _item.Valor; } }

        public double Quantidade { get { return _item.Quantidade; } }

        public string SubTotal { get { return ValorSubTotal().ToString("C"); } }

        public double ValorSubTotal()
        {
            return ValorUnitario * Quantidade;
        }

        public ItemDecorator(Item item, Produto produto)
        {
            _item = item;
            _produto = produto;
        }

        public Item Item()
        {
            return _item;
        }

        public Produto Produto()
        {
            return _produto;
        }

        public Produto ProdutoMinusQuantity()
        {
            Produto p = (Produto)_produto.Clone();
            p.Quantidade -= Quantidade;
            return p;
        }
    }
}
