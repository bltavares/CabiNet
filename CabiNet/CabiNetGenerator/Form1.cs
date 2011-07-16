using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CabiNet.Generator
{
    public partial class Form1 : Form
    {
        CabinetGenerator Cabinet = new CabinetGenerator() { ConnectioString = "ConnectionString", Name = "DB", NameSpace = "Database" };

        public Form1()
        {
            InitializeComponent();
        }

        private void inDBName_TextChanged(object sender, EventArgs e)
        {
            Cabinet.Name = inDBName.Text;
        }

        private void inDBNamespace_TextChanged(object sender, EventArgs e)
        {
            Cabinet.NameSpace = inDBNamespace.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Cabinet.ConnectioString = inDbConnectionstring.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataTables.DataSource = Cabinet.Shelfs;
        }

        private void dataTables_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataColumns.DataSource = Cabinet.Shelfs[e.RowIndex].Collumns;
            TypeCollumn.DataPropertyName = "Type";
            dataColumns.Columns["Type"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cabinet.InjectCabientOnShelfs();
                GeneratorFileWriter writer = new GeneratorFileWriter(dialog.SelectedPath);
                writer.ClassToFile(Cabinet);
                foreach (TableGenerator shelf in Cabinet.Shelfs)
                    writer.ClassToFile(shelf);

                writer.ToFile("README.txt", Cabinet.Readme());
                MessageBox.Show("Go to the folder and check the README");
            }

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dialog.FileName);
                XmlSerializer serializer = new XmlSerializer(Cabinet.GetType());
                serializer.Serialize(writer, Cabinet);
                writer.Close();
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextReader reader = new StreamReader(dialog.FileName);
                XmlSerializer serializer = new XmlSerializer(Cabinet.GetType());
                Cabinet = (CabinetGenerator)serializer.Deserialize(reader);
                reader.Close();
            }
        }

    }
}
