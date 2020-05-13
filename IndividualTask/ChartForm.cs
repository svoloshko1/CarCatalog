using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IndividualTask
{
    public partial class ChartForm : Form
    {
        public ChartForm(List<Transport> d, string r)
        {

            InitializeComponent();
            if (r == "P")
            {
                foreach (var k in d)
                {
                    chart1.Series["Price"].Points.AddXY(k.Brand, k.Price);
                }
            }
            else if (r == "E")
            {
                foreach (var k in d)
                {

                    chart1.Series["Engine"].Points.AddXY(k.Brand, k.EngineCapacity);

                }
            }
        }
        private void ChartForm_Load(object sender, EventArgs e)
        {

        }

        public void chart1_Click(object sender, EventArgs e)
        {
            //chart1.Series["Price"].Points.AddXY(d.CurrentRowIndex);
        }
    }
}
