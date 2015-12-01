using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    public partial class Form1 : Form
    {
        public static Point point;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GateContainer gatecontainer = new GateContainer();
            panel1.Controls.Add(gatecontainer);
            gatecontainer.Location = new System.Drawing.Point (110,110);
        
        }
        
    }
}
