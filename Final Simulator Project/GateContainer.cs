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
        public static bool Redraw_Gate_After_Visibility_Change = false;
        Point MovingPoint;
        Point CheckLocation;
        public GateContainer()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.Width = 55 + ANDGate.width; // Width of all gate
            this.Height = 20 + ANDGate.height; // height of all gate
            this.BackColor = Color.Black;
            this.Visible = false;
           
        }

        private void GateContainer_Click(object sender, EventArgs e)
        {
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            Control panel1 = this.Parent;
            //MessageBox.Show(panel1.Name);
            ContainerRectangle.Width = this.Width;
            ContainerRectangle.Height = this.Height;

            ContainerRectangle.Location = new Point(this.Left, this.Top);
            // created a rectangle at the same location of this container relative to the panel

            //MessageBox.Show(this.Left.ToString());

            ContainerScreenLocation = new Point(ContainerRectangle.X, ContainerRectangle.Y);

            //ContainerScreenLocation = panel1.PointToClient(ContainerScreenLocation);
            // created a point of the location of the rectangle relative to screen
        
            ANDGate andgate = new ANDGate(panel1);
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Redraw_Gate_After_Visibility_Change)
            {
                Control panel1 = this.Parent;
                //MessageBox.Show(panel1.Name);
                ContainerRectangle.Width = this.Width;
                ContainerRectangle.Height = this.Height;

                ContainerRectangle.Location = new Point(this.Left, this.Top);
                // created a rectangle at the same location of this container relative to the panel

                //MessageBox.Show(this.Left.ToString());

                ContainerScreenLocation = new Point(ContainerRectangle.X, ContainerRectangle.Y);

                //ContainerScreenLocation = panel1.PointToClient(ContainerScreenLocation);
                // created a point of the location of the rectangle relative to screen

                ANDGate andgate = new ANDGate(panel1);
                Redraw_Gate_After_Visibility_Change = false;
            }
            
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
                CheckLocation = this.Location;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
        }

    }
}
