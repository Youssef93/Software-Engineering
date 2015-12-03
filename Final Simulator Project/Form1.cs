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
        public static bool gatecontainer_created = false;
        GateContainer[] gatecontainer = new GateContainer[50];
        public static Point point;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (GateContainer.ContainerRectangle[GateContainer.gatecontainer_counter].Contains(new Point(e.X, e.Y)))
            {
                gatecontainer[GateContainer.gatecontainer_counter].Visible = true;

            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            for (int i = 0; i < GateContainer.gatecontainer_counter; i++)
            {

                if (GateContainer.ContainerRectangle[i].Contains(new Point(e.X, e.Y)) && gatecontainer_created)
                {
                    gatecontainer[i].Visible = true;

                }
                else if (gatecontainer_created)
                {
                    GateContainer.Redraw_Gate_After_Visibility_Change = true;
                    gatecontainer[i].Visible = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gatecontainer[GateContainer.gatecontainer_counter] = new GateContainer();
            panel1.Controls.Add(gatecontainer[GateContainer.gatecontainer_counter]);
            gatecontainer[GateContainer.gatecontainer_counter].Location = new Point(100, 100);
            gatecontainer_created= true;
            GateContainer.gatecontainer_counter++;
        }
      
    }
}
