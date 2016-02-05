using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Final_Simulator_Project
{
    class MyPictureBox : PictureBox
    {
        protected Point MovingPoint = new Point();
        protected Point This_Location = new Point();
        protected Control Original_Parent = new Control();
        protected bool first_time = true;
        protected ToolTip toolTip1 = new ToolTip();
        public MyPictureBox()
        {
            this.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.JPG";
        }
        protected override void OnLocationChanged(EventArgs e)
        {
           if (first_time)
            {
                This_Location = this.Location;
                first_time = false;
            }
        }
        protected override void OnLoadCompleted(AsyncCompletedEventArgs e)
        {
            Original_Parent = this.Parent;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Control groupBox1 = this.Parent;
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
                if (this.Right - 15 >= groupBox1.Width)
                {
                    foreach (Control panel in this.FindForm().Controls)
                    {
                        if ( panel.GetType() == typeof(MyPanel))
                        {
                            this.Parent = panel;
                        }
                    }
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.Parent.GetType() == typeof(MyPanel))
            {
                Control panel1 = this.Parent;

                // a point to store the location of the picturebox so the gate can be put at the same location
                Point Gate_Location_On_Panel = new Point();
                Gate_Location_On_Panel = this.Location;

                // Resetting the picture box to its original place
                this.Parent = Original_Parent;
                this.Location = This_Location;
                this.BringToFront();

                // Creating the Gate
                Public_Static_Variables.gatecontainer_counter++;
                Public_Static_Variables.Reset_draw_rect = Public_Static_Variables.gatecontainer_counter;
                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter] = new AndGateContainer();
                panel1.Controls.Add(Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter]);
                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = Gate_Location_On_Panel;
 
                // Checking for overlapping
                Rectangle This_Rectangle = new Rectangle();
                This_Rectangle.Location = Gate_Location_On_Panel;
                This_Rectangle.Width = Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Width;
                This_Rectangle.Height = Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Height;
                foreach (Control Gate in panel1.Controls)
                {
                    Rectangle Gate_Rectangle = new Rectangle();
                    Gate_Rectangle.Location = Gate.Location;
                    Gate_Rectangle.Height = Gate.Height;
                    Gate_Rectangle.Width = Gate.Width;
                    if (Gate.GetType() != typeof(Non_Rectangular_Control) && Gate_Rectangle.IntersectsWith(This_Rectangle))
                    {
                        if (Gate != Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter])
                        {
                           if (Gate_Rectangle.Contains(This_Rectangle.Location))
                            {
                                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = new Point(Gate_Location_On_Panel.X + 100, Gate_Location_On_Panel.Y);
                            }
                           else if (Gate_Rectangle.Contains(new Point(This_Rectangle.Right, This_Rectangle.Top)))
                            {
                                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = new Point(Gate_Location_On_Panel.X - 100, Gate_Location_On_Panel.Y);
                            }
                        }
                    }
                }
            }
            else
            {
                this.Location = This_Location;
            }
        }
        protected override void OnParentChanged(EventArgs e)
        {
            this.BringToFront();
        }
        protected override void OnMouseHover(EventArgs e)
        {
            toolTip1.Show("To add a gate, drag and drop it into the panel",this);
        }
    }
}
