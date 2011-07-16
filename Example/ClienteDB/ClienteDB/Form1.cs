using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace ClienteDB
{
    public partial class Form1 : Form
    {
        Lib.Banco banco = new Lib.Banco();
        Cliente[] clientes;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListarTodos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Nome = inNome.Text,
                Email = inEmail.Text,
                Endereco = inEndereco.Text,
                Telefone = inTel.Text
            };

            banco.Clientes.Insert(cliente);
            Pedido p = new Pedido
            {
                Cliente_id = cliente.Id,
                Num = "tes"
            };
            string o =  cliente.GenereteCreateSQL();
            cliente.HasLotsOf<Pedido>().Insert(p);
            var t = cliente.HasLotsOf<Pedido>().All();
            ListarTodos();
        }

        private void ListarTodos()
        {
            clientes = banco.Clientes.All();
            long size = banco.Clientes.Count();
            var t = clientes.Last().HasLotsOf<Pedido>().All();
            dataGridView1.DataSource = clientes;
            var o = clientes.Last();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (clientes == null)
                clientes = banco.Clientes.All();
            string nome = inNome.Text;
            IEnumerable<Cliente> cliente = clientes.Where(cli => cli.Nome == nome);
            banco.Clientes.Delete(cliente, true);
            ListarTodos();
        }
    }
}
