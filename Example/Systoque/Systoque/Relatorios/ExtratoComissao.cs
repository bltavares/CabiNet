using System;
using DB;

namespace Systoque.Relatorios
{
    public class ExtratoComissao
    {
        private Venda Pedido;
        private double Comissao;

        public Int64 Cod_Pedido { get { return Pedido.Id; } }
        public DateTime Data { get { return Pedido.DataVenda; } }
        public Double Total { get { return Pedido.Total; } }
        public Double ValorComissao { get { return Pedido.Total * Comissao; } }

        public ExtratoComissao(Venda pedido, double comissao)
        {
            Pedido = pedido;
            Comissao = comissao;
        }
    }
}
