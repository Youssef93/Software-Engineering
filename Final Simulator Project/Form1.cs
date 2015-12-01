﻿using System;
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
        GateContainer gatecontainer = new GateContainer();
        public static Point point;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            panel1.Controls.Add(gatecontainer);
            gatecontainer.Location = new System.Drawing.Point (100,100);
        
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (GateContainer.ContainerRectangle.Contains(new Point(e.X, e.Y)))
            {
                gatecontainer.Visible = true;
                
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (GateContainer.ContainerRectangle.Contains(new Point(e.X, e.Y)))
            {
                gatecontainer.Visible = true;

            }
            else
            {
                GateContainer.Redraw_Gate_After_Visibility_Change = true;
                gatecontainer.Visible = false;
            }
        }
    }
}
