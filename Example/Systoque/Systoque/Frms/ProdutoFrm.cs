using System;
using System.Linq;
using System.Windows.Forms;
using DB;
using Systoque.Properties;

namespace Systoque
{
    public partial class ProdutoFrm : Form
    {
        private Produto _produto;
        private readonly Banco _db = new Banco();

        public ProdutoFrm(Produto produto)
        {
            _produto = produto;
            InitializeComponent();
            BindAll();
        }


        private void BindAll()
        {
            foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
            {
                textBox.DataBindings.Add("Text", _produto, textBox.Name.Remove(0, 2));
            }
            inValidade.DataBindings.Add("Text", _produto, "Validade");
        }

        private void ResetFields()
        {
            foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
            {
                textBox.ResetBindings();
            }
            inValidade.ResetBindings();
            BindAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Produto p = _db.Produtos.Where("codbarra", inBusca.Text).FirstOrDefault();
            if (p != null)
            {
                _produto = p;
                ResetFields();
                button1.Text = Resources.VendedorFrm_button2_Click_Alterar;
                comboBox1.SelectedItem = string.IsNullOrWhiteSpace(_produto.PrazoGarantia) ? "Sim" : "Não";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_produto.IsValid())
            {
                MessageBox.Show(Resources.ProdutoFrm_button1_Click_Preencha_os_campos_corretamente);
                return;
            }

            if (_produto.IsNew())
                _db.Produtos.Insert(_produto);
            else
                _db.Produtos.Update(_produto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _produto = new Produto();
            ResetFields();
            button1.Text = Resources.VendedorFrm_button3_Click_Salvar;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            lbGarantia.Visible = inPrazoGarantia.Visible = comboBox1.SelectedItem == "Não";
            lbValidade.Visible = inValidade.Visible = !lbGarantia.Visible;

            if (string.IsNullOrWhiteSpace(_produto.PrazoGarantia))
                inPrazoGarantia.Text = _produto.PrazoGarantia = "";

            if (_produto.Validade == DateTime.Now)
                inValidade.Value = _produto.Validade = DateTime.Now;
        }
    }
}
