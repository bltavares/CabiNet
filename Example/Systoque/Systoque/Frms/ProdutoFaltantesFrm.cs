using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DB;

namespace Systoque
{
    public partial class ProdutoFaltantesFrm : Form
    {
        readonly Banco _db = new Banco();

        public ProdutoFaltantesFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<Produto> produtos = _db.Produtos.Where("quantidade", CabiNet.WhereConditions.LOWER, "quantidademinima", true);
            dataGridView1.DataSource = produtos;
        }
    }
}
