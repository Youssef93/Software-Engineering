using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    public partial class GateContainer : UserControl
    {
        public static Rectangle ContainerRectangle = new Rectangle();
        public static Point ContainerScreenLocation = new Point();
        public GateContainer()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.Width = 55 + ANDGate.width; // Width of all gate
            this.Height = 20 + ANDGate.height; // height of all gate
            this.BackColor = Color.Black;

           
            Form Form1 = this.FindForm();
            Control panel1 = this.Parent;
            MessageBox.Show(panel1.Name);
            ContainerRectangle.Width = this.Width;
            ContainerRectangle.Height = this.Height;

            ContainerRectangle.Location = this.Location; // created a rectangle at the same location of this container
            
            ContainerScreenLocation = new Point(ContainerRectangle.X, ContainerRectangle.Y);
            //ContainerScreenLocation = panel1.PointToClient(ContainerScreenLocation);
            // created a point of the location of the rectangle relative to screen
           
            ANDGate andgate = new ANDGate(panel1);
            //this.Visible = false;
        }

        private void GateContainer_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Hello");
            MessageBox.Show(ContainerScreenLocation.ToString());

        }
    }
}
