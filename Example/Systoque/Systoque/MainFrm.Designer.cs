namespace Systoque
{
    partial class MainFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pEdidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extratoDeComissaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosEmFaltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosEmEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aturamentoPorPeriodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.relatoriosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendedorToolStripMenuItem,
            this.produtoToolStripMenuItem,
            this.pEdidoToolStripMenuItem});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // vendedorToolStripMenuItem
            // 
            this.vendedorToolStripMenuItem.Name = "vendedorToolStripMenuItem";
            this.vendedorToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.vendedorToolStripMenuItem.Text = "Vendedor";
            this.vendedorToolStripMenuItem.Click += new System.EventHandler(this.vendedorToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.produtoToolStripMenuItem.Text = "Produto";
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // pEdidoToolStripMenuItem
            // 
            this.pEdidoToolStripMenuItem.Name = "pEdidoToolStripMenuItem";
            this.pEdidoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.pEdidoToolStripMenuItem.Text = "Pedido";
            this.pEdidoToolStripMenuItem.Click += new System.EventHandler(this.pEdidoToolStripMenuItem_Click);
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extratoDeComissaoToolStripMenuItem,
            this.produtosEmFaltaToolStripMenuItem,
            this.produtosEmEstoqueToolStripMenuItem,
            this.aturamentoPorPeriodoToolStripMenuItem});
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatoriosToolStripMenuItem.Text = "Relatorios";
            // 
            // extratoDeComissaoToolStripMenuItem
            // 
            this.extratoDeComissaoToolStripMenuItem.Name = "extratoDeComissaoToolStripMenuItem";
            this.extratoDeComissaoToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.extratoDeComissaoToolStripMenuItem.Text = "Extrato de comissao";
            this.extratoDeComissaoToolStripMenuItem.Click += new System.EventHandler(this.extratoDeComissaoToolStripMenuItem_Click);
            // 
            // produtosEmFaltaToolStripMenuItem
            // 
            this.produtosEmFaltaToolStripMenuItem.Name = "produtosEmFaltaToolStripMenuItem";
            this.produtosEmFaltaToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.produtosEmFaltaToolStripMenuItem.Text = "Produtos em falta";
            this.produtosEmFaltaToolStripMenuItem.Click += new System.EventHandler(this.produtosEmFaltaToolStripMenuItem_Click);
            // 
            // produtosEmEstoqueToolStripMenuItem
            // 
            this.produtosEmEstoqueToolStripMenuItem.Name = "produtosEmEstoqueToolStripMenuItem";
            this.produtosEmEstoqueToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.produtosEmEstoqueToolStripMenuItem.Text = "Produtos em estoque";
            this.produtosEmEstoqueToolStripMenuItem.Click += new System.EventHandler(this.produtosEmEstoqueToolStripMenuItem_Click);
            // 
            // aturamentoPorPeriodoToolStripMenuItem
            // 
            this.aturamentoPorPeriodoToolStripMenuItem.Name = "aturamentoPorPeriodoToolStripMenuItem";
            this.aturamentoPorPeriodoToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.aturamentoPorPeriodoToolStripMenuItem.Text = "Faturamento por periodo";
            this.aturamentoPorPeriodoToolStripMenuItem.Click += new System.EventHandler(this.aturamentoPorPeriodoToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 589);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Systoque";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pEdidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extratoDeComissaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosEmFaltaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosEmEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aturamentoPorPeriodoToolStripMenuItem;
    }
}

