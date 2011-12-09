using System;
using System.Linq;
using System.Windows.Forms;
using DB;
using Systoque.Properties;

namespace Systoque
{
    public partial class VendedorFrm : Form
    {
        private Vendedor _vendedor;
        private readonly Banco _db = new Banco();

        public VendedorFrm(Vendedor vendedor)
        {
            _vendedor = vendedor;
            InitializeComponent();
            BindAll();
        }


        private void BindAll()
        {
            foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
            {
                textBox.DataBindings.Add("Text", _vendedor, textBox.Name.Replace("in", ""));
            }
            inNascimento.DataBindings.Add("Text", _vendedor, "Nascimento");
        }

        private void ResetFields()
        {
            foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
            {
                textBox.ResetBindings();
            }
            inNascimento.ResetBindings();
            BindAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vendedor v = _db.Vendedores.Where("matricula", inBusca.Text).FirstOrDefault();
            if (v != null)
            {
                _vendedor = v;
                ResetFields();
                button1.Text = Resources.VendedorFrm_button2_Click_Alterar;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_vendedor.IsValid())
            {
                MessageBox.Show(Resources.VendedorFrm_button1_Click_Preencha_todos_os_campos_corretamente);
                return;
            }

            if (_vendedor.IsNew())
                _db.Vendedores.Insert(_vendedor);
            else
                _db.Vendedores.Update(_vendedor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _vendedor = new Vendedor();
            ResetFields();
            button1.Text = Resources.VendedorFrm_button3_Click_Salvar;
        }
    }
}
