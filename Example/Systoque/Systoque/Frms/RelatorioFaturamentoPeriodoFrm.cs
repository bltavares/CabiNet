using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DB;

namespace Systoque
{
    public partial class RelatorioFaturamentoPeriodoFrm : Form
    {
        readonly Banco _db = new Banco();

        public RelatorioFaturamentoPeriodoFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<Venda> vendas = _db.Vendas.Where("datavenda", CabiNet.WhereConditions.HIGHERorEQUAL, inInicio.Value).Where(v => v.DataVenda <= inFinal.Value).ToArray();
            dataGridView1.DataSource = vendas;
            double result = vendas.Aggregate(0.0, (current, venda) => current + venda.Total);
            inTotal.Text = result.ToString();
        }
    }
}
