using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualTask
{
    public partial class ItemForm :Form
    {

        private Transport transport;
        public Transport Transport { get => transport; }
        private string typeElem;
        public ItemForm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {

        }


        public ItemForm(string type)
        {
            InitializeComponent();
            if (type == "Car")
            {
                typeElem = type;
                label5.Text = "Transmission";
                textBox5.Visible = true;
                label5.Visible = true;
            }
            if (type == "Bus")
            {
                typeElem = type;
                textBox5.Visible = true;
                label5.Text = "Passengers";
                label5.Visible = true;
                label5.Location = new Point(614, 213);


                textBox6.Visible = true;
                label7.Visible = true;
            }
        }
        public void button1_Click(object sender, EventArgs e)
        {
            string brand = textBox1.Text;
            string model = textBox2.Text;
            string engine = textBox3.Text;
            string price = textBox4.Text;

            if (typeElem == "Car")
            {
                transport = new Car(brand, model, Convert.ToDouble(engine), Convert.ToDouble(price), textBox5.Text);
            }

            else if (typeElem == "Bus")
            {
                transport = new Bus(brand, model, 
                    Convert.ToDouble(engine),
                    Convert.ToDouble(price),
                    Convert.ToInt32(textBox5.Text),
                    Convert.ToInt32(textBox6.Text));
            }

            this.Close();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void Update(string update)
        {
           
            string[] info = update.Split('\t');
            textBox1.Text = info[0];
            textBox2.Text = info[1];
            textBox3.Text = info[2];
            textBox4.Text = info[3];
            button1.Text = "Update";
            if (typeElem == "Car")
            {
                textBox5.Text = info[4];
            }
            else if (typeElem == "Bus")
            {
                textBox5.Text = info[4];
                textBox6.Text = info[5];
            }
          

        }
    }
}
