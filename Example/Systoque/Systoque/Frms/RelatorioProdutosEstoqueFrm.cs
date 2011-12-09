using System;
using System.Linq;
using System.Windows.Forms;
using DB;

namespace Systoque
{
    public partial class RelatorioProdutosEstoqueFrm : Form
    {
        readonly Banco _db = new Banco();
        public RelatorioProdutosEstoqueFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Produtos.All().OrderBy(p => p.Nome).ToArray();
        }
    }
}
