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
        protected bool Draw_Gate_AT_current_Location = true;
        protected bool Create_A_New_First_Gate = false;
        ToolTip toolTip1 = new ToolTip();
        public MyPictureBox()
        {
            this.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.PNG";
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
                Point Gate_Location = this.Location;
                this.Parent = Original_Parent;
                this.Location = This_Location;
                this.BringToFront();
                Public_Static_Variables.gatecontainer_counter++;
                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter] = new AndGateContainer();
                panel1.Controls.Add(Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter]);
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = Gate_Location;
                current_location_Retangle.Width = Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Width;
                current_location_Retangle.Height = Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Height;
                for (int i = 1; i < Public_Static_Variables.gatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                    {
                        AndGateContainer local_Control = Public_Static_Variables.gatecontainer[i];
                        Rectangle Local_Rectangle = new Rectangle();
                        Local_Rectangle.Location = local_Control.Location;
                        Local_Rectangle.Width = local_Control.Width;
                        Local_Rectangle.Height = local_Control.Height;
                        if (current_location_Retangle.IntersectsWith(Local_Rectangle))
                        {
                            if (Local_Rectangle.Contains(current_location_Retangle.Location))
                            {
                                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = new Point(Gate_Location.X + 100, Gate_Location.Y);
                                break;
                            }
                            else if (Local_Rectangle.Contains(new Point(current_location_Retangle.Right, current_location_Retangle.Top)))
                            {
                                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = new Point(Gate_Location.X - 100, Gate_Location.Y);
                                break;
                            }
                        }
                        else Draw_Gate_AT_current_Location = true;
                    }
                }
                if (Draw_Gate_AT_current_Location || !Public_Static_Variables.gatecontainer_created)
                {
                    Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = Gate_Location;
                }
                else if (Create_A_New_First_Gate)
                {
                    Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = Gate_Location;
                    Create_A_New_First_Gate = false;
                }
                Public_Static_Variables.gatecontainer_created = true;
                Draw_Gate_AT_current_Location = false;
                Public_Static_Variables.DoThread = true;
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
