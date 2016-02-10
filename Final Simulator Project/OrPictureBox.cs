using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project { 

    class OrPictureBox : MyPictureBox
{
    public OrPictureBox()
    {
        this.ImageLocation = "C:\\Gate Pictures\\OrGate.JPG";
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
            Public_Static_Variables.Orgatecontainer_counter++;
            Public_Static_Variables.Reset_draw_rect = Public_Static_Variables.Orgatecontainer_counter;
            Public_Static_Variables.Orgatecontainer[Public_Static_Variables.Orgatecontainer_counter] = new OrGateContainer();
            panel1.Controls.Add(Public_Static_Variables.Orgatecontainer[Public_Static_Variables.Orgatecontainer_counter]);
            Public_Static_Variables.Orgatecontainer[Public_Static_Variables.Orgatecontainer_counter].Location = Gate_Location_On_Panel;

            // Checking for overlapping
            Rectangle This_Rectangle = new Rectangle();
            This_Rectangle.Location = Gate_Location_On_Panel;
            This_Rectangle.Width = Public_Static_Variables.Orgatecontainer[Public_Static_Variables.Orgatecontainer_counter].Width;
            This_Rectangle.Height = Public_Static_Variables.Orgatecontainer[Public_Static_Variables.Orgatecontainer_counter].Height;
            foreach (Control Gate in panel1.Controls)
            {
                Rectangle Gate_Rectangle = new Rectangle();
                Gate_Rectangle.Location = Gate.Location;
                Gate_Rectangle.Height = Gate.Height;
                Gate_Rectangle.Width = Gate.Width;
                if (Gate.GetType() != typeof(Non_Rectangular_Control) && Gate_Rectangle.IntersectsWith(This_Rectangle))
                {
                    if (Gate != Public_Static_Variables.Orgatecontainer[Public_Static_Variables.Orgatecontainer_counter])
                    {
                        if (Gate_Rectangle.Contains(This_Rectangle.Location))
                        {
                            Public_Static_Variables.Orgatecontainer[Public_Static_Variables.Orgatecontainer_counter].Location = new Point(Gate_Location_On_Panel.X + 100, Gate_Location_On_Panel.Y);
                        }
                        else if (Gate_Rectangle.Contains(new Point(This_Rectangle.Right, This_Rectangle.Top)))
                        {
                            Public_Static_Variables.Orgatecontainer[Public_Static_Variables.Orgatecontainer_counter].Location = new Point(Gate_Location_On_Panel.X - 100, Gate_Location_On_Panel.Y);
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
}
}
