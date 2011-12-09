using System.Collections.Generic;
using System.Linq;
using DB;

namespace Systoque.Relatorios
{
    public static class VendaExtratoComissaoExt
    {
        public static ExtratoComissao ToExtratoComissao(this Venda venda, double comissao)
        {
            return new ExtratoComissao(venda, comissao);
        }

        public static IEnumerable<ExtratoComissao> ToExtratoComissao(this IEnumerable<Venda> venda, double comissao)
        {
            return venda.Select(v => v.ToExtratoComissao(comissao));
        }
    }
}
