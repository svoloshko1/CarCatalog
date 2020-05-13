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
using System.Diagnostics;

namespace IndividualTask
{
    public partial class MainForm : Form
    {
        FileStream fs = new FileStream(@"D:\1.txt", FileMode.Create);
        private string filename;
        private List<Transport> list;
       

        public MainForm()
        {
            LoadForm k = new LoadForm();
            k.ShowDialog();
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
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
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
            dataGridView1.Rows.Clear();
            list.Clear();
            MessageBox.Show("Created succesfully");

            
        }

        #region зчитування з файлу
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;

            dataGridView1.Rows.Clear();
            list.Clear();
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

            
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    for (int i = 0; i < dataGridView1.Rows[j].Cells.Count; i++)
                    {
                        streamWriter.Write(dataGridView1.Rows[j].Cells[i].Value + "     ");
                    }

                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Saved succesfully");
            }
            catch
            {
                MessageBox.Show("Error!");
            }


        }

    
        #endregion


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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
                        if (list[i] is Car)
                        {
                            writer.WriteLine("Car\t"+string.Join("\t", line));
                        }
                        if (list[i] is Bus)
                        {
                            writer.WriteLine("Bus\t"+string.Join("\t", line));
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            list.Clear();
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

                ItemForm k = new ItemForm("Car");
                k.ShowDialog();
                if (!(k.Transport is null))
                { 
                    list.Add(k.Transport);
                }
                k.Close();
                dataGridView1.Rows.Clear();
                foreach (var car in list)
                {
                    dataGridView1.Rows.Add((car.ToString()).Split('\t'));

                }
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

                ItemForm k = new ItemForm("Bus");
                k.ShowDialog();
                if (!(k.Transport is null))
                {
                    list.Add(k.Transport);
                }
                k.Close();
                dataGridView1.Rows.Clear();
                foreach (var car in list)
                {
                    dataGridView1.Rows.Add((car.ToString()).Split('\t'));

                }
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }

        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

                ItemForm k = new ItemForm("Car");
                k.ShowDialog();
            if (!(k.Transport is null))
            {
                list.Add(k.Transport);
            }
            k.Close();
                dataGridView1.Rows.Clear();
                foreach (var car in list)
                {
                    dataGridView1.Rows.Add((car.ToString()).Split('\t'));

                }
            
            


        }
    

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(ind);
        }

        private void addBusToolStripMenuItem_Click(object sender, EventArgs e)
        {



            ItemForm k = new ItemForm("Bus");
            k.ShowDialog();
            if (!(k.Transport is null))
            {
                list.Add(k.Transport);
            }
            k.Close();
            dataGridView1.Rows.Clear();
            foreach (var car in list)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));

            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            //list.Add(k.Transport);
          
            int index = dataGridView1.CurrentCell.RowIndex;
            
            
            if(list[index] is Car)
            {
                ItemForm k = new ItemForm("Car");
                k.ShowDialog();
                if(!(k.Transport is null)){
                    list[index] = k.Transport;
                }

            }
            else 
            {
                ItemForm k = new ItemForm("Bus");
                k.ShowDialog();
                if (!(k.Transport is null))
                {
                    list[index] = k.Transport;
                }
                
            }

            dataGridView1.Rows.Clear();

            foreach (var car in list)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.CurrentCell.RowIndex;


            if (list[index] is Car)
            {
                ItemForm k = new ItemForm("Car");
                k.ShowDialog();
                if (!(k.Transport is null))
                {
                    list[index] = k.Transport;
                }

            }
            else
            {
                ItemForm k = new ItemForm("Bus");
                k.ShowDialog();
                if (!(k.Transport is null))
                {
                    list[index] = k.Transport;
                }

            }

            dataGridView1.Rows.Clear();

            foreach (var car in list)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }


        }
        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Svyatik228/CarCatalog");
        }
        private  void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/feed/");
        }
      

        private void button6_Click(object sender, EventArgs e)
        {
            checkBox4.Visible=true;
            checkBox3.Visible = true;
          
        }
  
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true || checkBox4.Checked == true)
            {

                ChartForm b = new ChartForm(list,"P");
                b.ShowDialog();
                checkBox3.Checked = false;
                checkBox4.Checked = false;

            }

        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true || checkBox4.Checked == true)
            {

                ChartForm b = new ChartForm(list,"E");
                b.ShowDialog();
                checkBox3.Checked = false;
                checkBox4.Checked = false;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            checkBox5.Visible = true;
            checkBox6.Visible = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = false;
            var selectItem = from t in list
                             orderby t.Brand
                             select t;

            dataGridView1.Rows.Clear();
            foreach (var car in selectItem)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox6.Checked = false;
            var selectItem = from t in list
                             orderby t.Price
                             select t;
            dataGridView1.Rows.Clear();
            foreach (var car in selectItem)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button10_Click(object sender, EventArgs e)
        {
            checkBox7.Visible = true;
            checkBox8.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Visible = true;

            button9.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string k = textBox5.Text;
            var selectItem = from t in list
                             where t.TransportModel == k
                             select t;
            dataGridView1.Rows.Clear();
            foreach (var car in selectItem)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            checkBox7.Checked = false;

            var selectItem = from t in list
                            where t is Car
                            select t;
            dataGridView1.Rows.Clear();
            foreach (var car in selectItem)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            checkBox8.Checked = false;
            var selectItem = from t in list
                             where t is Bus
                             select t;
            dataGridView1.Rows.Clear();
            foreach (var car in selectItem)
            {
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var car in list)
            {
                car.Price=car.Price * 0.95;
                dataGridView1.Rows.Add((car.ToString()).Split('\t'));
            }
        }
    }
}
