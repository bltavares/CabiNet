using System;
using System.Windows.Forms;
using DB;

namespace Systoque
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendedorFrm frm = new VendedorFrm(new Vendedor());
            frm.ShowDialog();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdutoFrm frm = new ProdutoFrm(new Produto());
            frm.ShowDialog();
        }

        private void pEdidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PedidoFrm frm = new PedidoFrm(new Venda());
            frm.ShowDialog();
        }

        private void extratoDeComissaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioExtratoComissaoFrm frm = new RelatorioExtratoComissaoFrm();
            frm.ShowDialog();
        }

        private void produtosEmFaltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdutoFaltantesFrm frm = new ProdutoFaltantesFrm();
            frm.ShowDialog();
        }

        private void produtosEmEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioProdutosEstoqueFrm frm = new RelatorioProdutosEstoqueFrm();
            frm.ShowDialog();
        }

        private void aturamentoPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioFaturamentoPeriodoFrm frm = new RelatorioFaturamentoPeriodoFrm();
            frm.ShowDialog();
        }
    }
}
