namespace Systoque
{
    partial class ProdutoFrm
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
            this.inNome = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbGarantia = new System.Windows.Forms.Label();
            this.inValidade = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.inLote = new System.Windows.Forms.TextBox();
            this.lbValidade = new System.Windows.Forms.Label();
            this.inPrazoGarantia = new System.Windows.Forms.TextBox();
            this.inQuantidadeMinima = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.inQuantidade = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inCodBarra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inBusca = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inNome
            // 
            this.inNome.Location = new System.Drawing.Point(117, 19);
            this.inNome.MaxLength = 250;
            this.inNome.Name = "inNome";
            this.inNome.Size = new System.Drawing.Size(195, 20);
            this.inNome.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.lbGarantia);
            this.groupBox1.Controls.Add(this.inValidade);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.inLote);
            this.groupBox1.Controls.Add(this.lbValidade);
            this.groupBox1.Controls.Add(this.inPrazoGarantia);
            this.groupBox1.Controls.Add(this.inQuantidadeMinima);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.inQuantidade);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.inValor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.inCodBarra);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inNome);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(3, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 413);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Produto perecivel?";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Escolha um item",
            "Sim",
            "Não"});
            this.comboBox1.Location = new System.Drawing.Point(117, 142);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // lbGarantia
            // 
            this.lbGarantia.AutoSize = true;
            this.lbGarantia.Location = new System.Drawing.Point(31, 172);
            this.lbGarantia.Name = "lbGarantia";
            this.lbGarantia.Size = new System.Drawing.Size(80, 13);
            this.lbGarantia.TabIndex = 19;
            this.lbGarantia.Text = "Prazo Garantia:";
            this.lbGarantia.Visible = false;
            // 
            // inValidade
            // 
            this.inValidade.Location = new System.Drawing.Point(117, 210);
            this.inValidade.Name = "inValidade";
            this.inValidade.Size = new System.Drawing.Size(195, 20);
            this.inValidade.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Lote:";
            // 
            // inLote
            // 
            this.inLote.Location = new System.Drawing.Point(432, 209);
            this.inLote.MaxLength = 250;
            this.inLote.Name = "inLote";
            this.inLote.Size = new System.Drawing.Size(161, 20);
            this.inLote.TabIndex = 16;
            // 
            // lbValidade
            // 
            this.lbValidade.AutoSize = true;
            this.lbValidade.Location = new System.Drawing.Point(34, 216);
            this.lbValidade.Name = "lbValidade";
            this.lbValidade.Size = new System.Drawing.Size(77, 13);
            this.lbValidade.TabIndex = 15;
            this.lbValidade.Text = "Data Validade:";
            // 
            // inPrazoGarantia
            // 
            this.inPrazoGarantia.Location = new System.Drawing.Point(117, 169);
            this.inPrazoGarantia.MaxLength = 250;
            this.inPrazoGarantia.Name = "inPrazoGarantia";
            this.inPrazoGarantia.Size = new System.Drawing.Size(195, 20);
            this.inPrazoGarantia.TabIndex = 14;
            this.inPrazoGarantia.Visible = false;
            // 
            // inQuantidadeMinima
            // 
            this.inQuantidadeMinima.Location = new System.Drawing.Point(432, 97);
            this.inQuantidadeMinima.MaxLength = 250;
            this.inQuantidadeMinima.Name = "inQuantidadeMinima";
            this.inQuantidadeMinima.Size = new System.Drawing.Size(161, 20);
            this.inQuantidadeMinima.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Quantidade Minima:";
            // 
            // inQuantidade
            // 
            this.inQuantidade.Location = new System.Drawing.Point(117, 97);
            this.inQuantidade.MaxLength = 250;
            this.inQuantidade.Name = "inQuantidade";
            this.inQuantidade.Size = new System.Drawing.Size(195, 20);
            this.inQuantidade.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Novo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantidade Estoque:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor de venda:";
            // 
            // inValor
            // 
            this.inValor.Location = new System.Drawing.Point(117, 71);
            this.inValor.MaxLength = 250;
            this.inValor.Name = "inValor";
            this.inValor.Size = new System.Drawing.Size(195, 20);
            this.inValor.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Código de barra:";
            // 
            // inCodBarra
            // 
            this.inCodBarra.Location = new System.Drawing.Point(117, 45);
            this.inCodBarra.MaxLength = 250;
            this.inCodBarra.Name = "inCodBarra";
            this.inCodBarra.Size = new System.Drawing.Size(195, 20);
            this.inCodBarra.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Código de barra:";
            // 
            // inBusca
            // 
            this.inBusca.Location = new System.Drawing.Point(99, 12);
            this.inBusca.MaxLength = 250;
            this.inBusca.Name = "inBusca";
            this.inBusca.Size = new System.Drawing.Size(422, 20);
            this.inBusca.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(527, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ProdutoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 477);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inBusca);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProdutoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inNome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inCodBarra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inBusca;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox inValor;
        private System.Windows.Forms.Label lbValidade;
        private System.Windows.Forms.TextBox inPrazoGarantia;
        private System.Windows.Forms.TextBox inQuantidadeMinima;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox inQuantidade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inLote;
        private System.Windows.Forms.Label lbGarantia;
        private System.Windows.Forms.DateTimePicker inValidade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}