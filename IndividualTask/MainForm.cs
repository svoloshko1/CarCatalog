using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace IndividualTask
{
    public partial class MainForm : Form
    {
        private string filename;
        private List<Transport> list;
        public MainForm()
        {
            InitializeComponent();
            list = new List<Transport>();
            filename = "";
            pictureBox1.BackColor = Color.Transparent;
            

        }
        #region Зчитування з бази
        private void LoadData()
        {
            string connectString = "Data Source=SVYATKO228;Initial Catalog=MainForm;" +
                "Integrated Security=true;";

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT * FROM CarCatalog order by Brand";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }
        #endregion
   
        private void Form1_Load(object sender, EventArgs e)
        {
           
        
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm k = new ItemForm();
            k.ShowDialog();
        }

        #region зчитування з файлу
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {


            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;

            dataGridView1.Rows.Clear();
            string[] readfile = File.ReadAllText(filename).Split('\n');
            for (int i = 0; i < readfile.Length; i++)
            {
                string[] data = readfile[i].Split('\t');
                Transport element;
           
                    switch (data[0])
                    {
                        case "Car":
                            element = new Car(data[1],
                                data[2],
                                double.Parse(data[3]),
                                double.Parse(data[4]),
                                data[5]);
                            list.Add(element);
                            break;
                        case "Bus":

                            element = new Bus(data[1],
                                data[2],
                                double.Parse(data[3]),
                                double.Parse(data[4]),
                                int.Parse(data[5]),
                                int.Parse(data[6]));
                            list.Add(element);
                            break;
                    }
            }
            foreach (var car in list)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }
        }
        #endregion


        #region Зберігання в файл
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowCounter = dataGridView1.RowCount;
            int columnCount = dataGridView1.ColumnCount;
            string[] line = new string[columnCount];
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Txt files (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            line[j] = (string)(dataGridView1.Rows[i].Cells[j].Value ?? "");
                        }
                        writer.WriteLine(string.Join("\t", line));
                    }
                }
            }
        }
        #endregion


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string brand = textBox1.Text;
            string model = textBox2.Text;
            string engine = textBox3.Text;
            string price = textBox4.Text;
            dataGridView1.Rows.Add(brand, model, engine, price);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(ind);
        }


        private void openFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
                
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true || checkBox2.Checked == true)
            {

                ItemForm k = new ItemForm();
                k.ShowDialog();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }



        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            checkBox1.Visible = true;
            checkBox2.Visible = true;

           
        }
  

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox1.Checked == true || checkBox2.Checked == true)
            {

                ItemForm k = new ItemForm();
                k.ShowDialog();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }

        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm k = new ItemForm();
            k.ShowDialog();
        }
    }
}
