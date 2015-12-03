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
        public static bool[] gatecontainer_created = new bool[60];
        
        GateContainer[] gatecontainer = new GateContainer[50];
        int gatecontainer_counter = 0;
        public static Point point;
        Rectangle[] SavedContainerRectangles = new Rectangle[50];
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (GateContainer.ContainerRectangle.Contains(new Point(e.X, e.Y)))
            {
                gatecontainer[gatecontainer_counter].Visible = true;

            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i <= gatecontainer_counter; i++)
            {

                if (SavedContainerRectangles[i].Contains(new Point(e.X, e.Y)) && gatecontainer_created[i])
                {
                    gatecontainer[i].Visible = true;

                }
                else if (gatecontainer_created[i])
                {
                    GateContainer.Redraw_Gate_After_Visibility_Change = true;
                    gatecontainer[i].Visible = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gatecontainer[gatecontainer_counter] = new GateContainer();
            panel1.Controls.Add(gatecontainer[gatecontainer_counter]);
            gatecontainer[gatecontainer_counter].Location = new Point(100, 100);
            gatecontainer_created [gatecontainer_counter]= true;
            SaveGate();
            gatecontainer_counter++;
        }
        public void SaveGate()
        {
            SavedContainerRectangles[gatecontainer_counter] =  GateContainer.ContainerRectangle;
        }
        public void setAllBoolsFalse()
        {
            for (int i = 0; i <= 50; i++)
            {
                gatecontainer_created[i] = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setAllBoolsFalse();
        }
    }
}
