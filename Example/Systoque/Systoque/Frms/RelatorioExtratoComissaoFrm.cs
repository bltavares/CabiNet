using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DB;
using Systoque.Relatorios;

namespace Systoque
{
    public partial class RelatorioExtratoComissaoFrm : Form
    {
        private readonly Banco _db = new Banco();

        public RelatorioExtratoComissaoFrm()
        {
            InitializeComponent();

            comboBox1.DataSource = _db.Vendedores.All();
            comboBox1.DisplayMember = "Nome";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = (Vendedor)comboBox1.SelectedItem;
            IEnumerable<Venda> vendas = _db.Vendas.Where("vendedor_id", vendedor.Id).Where(v => v.DataVenda <= inFinal.Value && v.DataVenda >= inInicio.Value);
            dataGridView1.DataSource = vendas.ToExtratoComissao(vendedor.Comissao).ToArray();
        }
    }
}
