namespace CabiNet.Generator
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.inDbConnectionstring = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inDBNamespace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataTables = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataColumns = new System.Windows.Forms.DataGridView();
            this.TypeCollumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTables)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataColumns)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.inDbConnectionstring);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.inDBNamespace);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.inDBName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(873, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 51);
            this.button1.TabIndex = 6;
            this.button1.Text = "Generate!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inDbConnectionstring
            // 
            this.inDbConnectionstring.Location = new System.Drawing.Point(254, 36);
            this.inDbConnectionstring.Name = "inDbConnectionstring";
            this.inDbConnectionstring.Size = new System.Drawing.Size(613, 20);
            this.inDbConnectionstring.TabIndex = 5;
            this.inDbConnectionstring.Text = "driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;pwd=;database=";
            this.inDbConnectionstring.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Connection String";
            // 
            // inDBNamespace
            // 
            this.inDBNamespace.Location = new System.Drawing.Point(125, 36);
            this.inDBNamespace.Name = "inDBNamespace";
            this.inDBNamespace.Size = new System.Drawing.Size(100, 20);
            this.inDBNamespace.TabIndex = 3;
            this.inDBNamespace.Text = "Database";
            this.inDBNamespace.TextChanged += new System.EventHandler(this.inDBNamespace_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Namespace";
            // 
            // inDBName
            // 
            this.inDBName.Location = new System.Drawing.Point(10, 36);
            this.inDBName.Name = "inDBName";
            this.inDBName.Size = new System.Drawing.Size(100, 20);
            this.inDBName.TabIndex = 1;
            this.inDBName.TextChanged += new System.EventHandler(this.inDBName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // dataTables
            // 
            this.dataTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTables.Location = new System.Drawing.Point(10, 19);
            this.dataTables.Name = "dataTables";
            this.dataTables.Size = new System.Drawing.Size(969, 202);
            this.dataTables.TabIndex = 1;
            this.dataTables.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTables_RowEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataTables);
            this.groupBox2.Location = new System.Drawing.Point(12, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(985, 229);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tables";
            // 
            // dataColumns
            // 
            this.dataColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeCollumn});
            this.dataColumns.Location = new System.Drawing.Point(10, 19);
            this.dataColumns.Name = "dataColumns";
            this.dataColumns.Size = new System.Drawing.Size(969, 168);
            this.dataColumns.TabIndex = 1;
            // 
            // TypeCollumn
            // 
            this.TypeCollumn.HeaderText = "Type";
            this.TypeCollumn.Items.AddRange(new object[] {
            "String",
            "Int32",
            "Int64",
            "Boolean",
            "Datetime"});
            this.TypeCollumn.Name = "TypeCollumn";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataColumns);
            this.groupBox3.Location = new System.Drawing.Point(12, 348);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(985, 193);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Collumns";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1009, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "Save";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel2.Text = "Restore";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 556);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTables)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataColumns)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox inDbConnectionstring;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inDBNamespace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inDBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataTables;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataColumns;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypeCollumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}

