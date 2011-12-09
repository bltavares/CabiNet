namespace Systoque
{
    partial class PedidoFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.inDataVenda = new System.Windows.Forms.DateTimePicker();
            this.inDataPrevEntrega = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inVendedores = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inStatus = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inQuantidadeMax = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.inProdutoValor = new System.Windows.Forms.Label();
            this.inProdutoNome = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.inQuantidade = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.inTotal = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data do pedido:";
            // 
            // inDataVenda
            // 
            this.inDataVenda.Location = new System.Drawing.Point(98, 12);
            this.inDataVenda.Name = "inDataVenda";
            this.inDataVenda.Size = new System.Drawing.Size(200, 20);
            this.inDataVenda.TabIndex = 0;
            // 
            // inDataPrevEntrega
            // 
            this.inDataPrevEntrega.Location = new System.Drawing.Point(636, 12);
            this.inDataPrevEntrega.Name = "inDataPrevEntrega";
            this.inDataPrevEntrega.Size = new System.Drawing.Size(200, 20);
            this.inDataPrevEntrega.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Prevista de entrega:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inVendedores);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vendedor";
            // 
            // inVendedores
            // 
            this.inVendedores.FormattingEnabled = true;
            this.inVendedores.Location = new System.Drawing.Point(37, 43);
            this.inVendedores.Name = "inVendedores";
            this.inVendedores.Size = new System.Drawing.Size(172, 21);
            this.inVendedores.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status do pedido:";
            // 
            // inStatus
            // 
            this.inStatus.FormattingEnabled = true;
            this.inStatus.Items.AddRange(new object[] {
            "A entregar",
            "Entregue"});
            this.inStatus.Location = new System.Drawing.Point(521, 97);
            this.inStatus.Name = "inStatus";
            this.inStatus.Size = new System.Drawing.Size(172, 21);
            this.inStatus.TabIndex = 3;
            this.inStatus.SelectedIndexChanged += new System.EventHandler(this.inStatus_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inQuantidadeMax);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.inProdutoValor);
            this.groupBox2.Controls.Add(this.inProdutoNome);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.inQuantidade);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.inCodigo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(21, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(939, 69);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produto";
            // 
            // inQuantidadeMax
            // 
            this.inQuantidadeMax.AutoSize = true;
            this.inQuantidadeMax.Location = new System.Drawing.Point(789, 34);
            this.inQuantidadeMax.Name = "inQuantidadeMax";
            this.inQuantidadeMax.Size = new System.Drawing.Size(0, 13);
            this.inQuantidadeMax.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(858, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Incluir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inProdutoValor
            // 
            this.inProdutoValor.AutoSize = true;
            this.inProdutoValor.Location = new System.Drawing.Point(450, 34);
            this.inProdutoValor.Name = "inProdutoValor";
            this.inProdutoValor.Size = new System.Drawing.Size(0, 13);
            this.inProdutoValor.TabIndex = 15;
            // 
            // inProdutoNome
            // 
            this.inProdutoNome.AutoSize = true;
            this.inProdutoNome.Location = new System.Drawing.Point(282, 34);
            this.inProdutoNome.Name = "inProdutoNome";
            this.inProdutoNome.Size = new System.Drawing.Size(0, 13);
            this.inProdutoNome.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Valor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Produto:";
            // 
            // inQuantidade
            // 
            this.inQuantidade.Location = new System.Drawing.Point(652, 31);
            this.inQuantidade.Name = "inQuantidade";
            this.inQuantidade.Size = new System.Drawing.Size(131, 20);
            this.inQuantidade.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Quantiade:";
            // 
            // inCodigo
            // 
            this.inCodigo.Location = new System.Drawing.Point(55, 31);
            this.inCodigo.Name = "inCodigo";
            this.inCodigo.Size = new System.Drawing.Size(130, 20);
            this.inCodigo.TabIndex = 1;
            this.inCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inCodigo_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Código:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(939, 172);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(789, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Total:";
            // 
            // inTotal
            // 
            this.inTotal.Location = new System.Drawing.Point(830, 413);
            this.inTotal.Name = "inTotal";
            this.inTotal.ReadOnly = true;
            this.inTotal.Size = new System.Drawing.Size(130, 20);
            this.inTotal.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(410, 501);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Finalizar pedido";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PedidoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 549);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.inTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.inStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.inDataPrevEntrega);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inDataVenda);
            this.Controls.Add(this.label1);
            this.Name = "PedidoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker inDataVenda;
        private System.Windows.Forms.DateTimePicker inDataPrevEntrega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox inVendedores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox inStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label inProdutoValor;
        private System.Windows.Forms.Label inProdutoNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox inQuantidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inTotal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label inQuantidadeMax;

    }
}