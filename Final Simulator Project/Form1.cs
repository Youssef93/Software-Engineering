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
            

                if (GateContainer.ContainerRectangle.Contains(new Point(e.X, e.Y)) && gatecontainer_created)
                {
                    gatecontainer[gatecontainer_counter].Visible = true;

                }
                else if (gatecontainer_created)
                {
                    GateContainer.Redraw_Gate_After_Visibility_Change = true;
                    gatecontainer[gatecontainer_counter].Visible = false;
                }
           }
        

        private void button2_Click(object sender, EventArgs e)
        {
            gatecontainer[gatecontainer_counter] = new GateContainer();
            panel1.Controls.Add(gatecontainer[gatecontainer_counter]);
            gatecontainer[gatecontainer_counter].Location = new Point(100, 100);
            gatecontainer_created= true;
            //SaveGate();
        }
        public void SaveGate()
        {
            SavedContainerRectangles[gatecontainer_counter] =  GateContainer.ContainerRectangle;
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
    }
}
