using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DB;
using Systoque.Properties;

namespace Systoque
{
    public partial class PedidoFrm : Form
    {
        private BindingList<ItemDecorator> _itens = new BindingList<ItemDecorator>();
        private Produto _ultimoProduto;
        private readonly Banco _db = new Banco();
        private Venda _venda;

        public PedidoFrm(Venda venda)
        {
            _venda = venda;

            InitializeComponent();
            BindAll();
        }

        private void BindAll()
        {
            inVendedores.DataSource = _db.Vendedores.All();
            inVendedores.ValueMember = "Id";
            inVendedores.DisplayMember = "Nome";

            dataGridView1.DataSource = _itens;

            inDataPrevEntrega.DataBindings.Add("Value", _venda, "DataPrevEntrega");
            inDataVenda.DataBindings.Add("Value", _venda, "DataVenda");
            inVendedores.DataBindings.Add("SelectedValue", _venda, "vendedor_id");
            inStatus.DataBindings.Add("SelectedItem", _venda, "Status");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inCodigo.Focus();

            if (_ultimoProduto == null)
            {
                MessageBox.Show(Resources.PedidoFrm_button1_Click_Escolha_um_produto);
                return;
            }
            double qtd;
            if (!Double.TryParse(inQuantidade.Text, out qtd))
            {
                MessageBox.Show(Resources.PedidoFrm_button1_Click_Digite_uma_quantidade_válida);
                return;
            }
            if (qtd > _ultimoProduto.Quantidade)
            {
                MessageBox.Show(Resources.PedidoFrm_button1_Click_Quantidade_não_existe_no_estoque);
                return;
            }

            ItemDecorator it = new ItemDecorator(
                new Item
                {
                    produto_id = _ultimoProduto.Id,
                    Quantidade = qtd,
                    Valor = _ultimoProduto.Valor
                }
                , _ultimoProduto);

            if (!AddProduto(it))
                MessageBox.Show(Resources.PedidoFrm_button1_Click_Remova_o_item_da_lista_para_alterar_sua_quantidade);
        }

        private bool AddProduto(ItemDecorator it)
        {
            if (_itens.Any(i => i.Codigo == it.Codigo))
                return false;

            _itens.Add(it);
            _venda.Total += it.ValorSubTotal();
            inTotal.Text = _venda.Total.ToString("C");
            return true;
        }

        private void ProcurarProduto()
        {
            _ultimoProduto = _db.Produtos.Where("codbarra", inCodigo.Text).FirstOrDefault();
            if (_ultimoProduto == null)
            {
                inProdutoNome.Text = "";
                inProdutoValor.Text = "";
                inQuantidadeMax.Text = "";
            }
            else
            {
                inProdutoNome.Text = _ultimoProduto.Nome;
                inProdutoValor.Text = _ultimoProduto.Valor.ToString("C");
                inQuantidadeMax.Text = "(" + _ultimoProduto.Quantidade + ")";
            }

        }
        private void inCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcurarProduto();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            _venda.Total = _itens.Aggregate(0.0, (sum, it) => sum += it.ValorSubTotal());
            inTotal.Text = _venda.Total.ToString("C");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!_venda.IsValid() && _itens.Count == 0)
            {
                MessageBox.Show(Resources.ProdutoFrm_button1_Click_Preencha_os_campos_corretamente);
                return;
            }

            if (_venda.IsNew())
            {
                _db.Vendas.Insert(_venda);
                IEnumerable<Item> itens = _itens.Select(itd =>
                {
                    Item it = itd.Item();
                    it.venda_id = _venda.Id;
                    return it;
                });
                _db.Items.Insert(itens, true);

                _db.Produtos.Update(_itens.Select(itd => itd.ProdutoMinusQuantity()), true);

                MessageBox.Show("Compra n: " + _venda.Id + ". Finalizado com sucesso");
                Close();
            }
        }

        private void inStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inStatus.SelectedItem == "Entregue")
                inDataPrevEntrega.Value = _venda.DataPrevEntrega = DateTime.Now;
        }

    }
}
