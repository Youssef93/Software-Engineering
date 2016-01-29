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
    class NotPictureBox : MyPictureBox
    {
        public NotPictureBox()
        {
            this.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NotGate.JPG";
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
                Public_Static_Variables.Notgatecontainer_counter++;
                Public_Static_Variables.Notgatecontainer[Public_Static_Variables.Notgatecontainer_counter] = new NotGateContainer();
                panel1.Controls.Add(Public_Static_Variables.Notgatecontainer[Public_Static_Variables.Notgatecontainer_counter]);
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = Gate_Location;
                current_location_Retangle.Width = Public_Static_Variables.Notgatecontainer[Public_Static_Variables.Notgatecontainer_counter].Width;
                current_location_Retangle.Height = Public_Static_Variables.Notgatecontainer[Public_Static_Variables.Notgatecontainer_counter].Height;
                for (int i = 1; i < Public_Static_Variables.Notgatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.Notgatecontainer[i]))
                    {
                        NotGateContainer local_Control = Public_Static_Variables.Notgatecontainer[i];
                        Rectangle Local_Rectangle = new Rectangle();
                        Local_Rectangle.Location = local_Control.Location;
                        Local_Rectangle.Width = local_Control.Width;
                        Local_Rectangle.Height = local_Control.Height;
                        if (current_location_Retangle.IntersectsWith(Local_Rectangle))
                        {
                            if (Local_Rectangle.Contains(current_location_Retangle.Location))
                            {
                                Public_Static_Variables.Notgatecontainer[Public_Static_Variables.Notgatecontainer_counter].Location = new Point(Gate_Location.X + 100, Gate_Location.Y);
                                break;
                            }
                            else if (Local_Rectangle.Contains(new Point(current_location_Retangle.Right, current_location_Retangle.Top)))
                            {
                                Public_Static_Variables.Notgatecontainer[Public_Static_Variables.Notgatecontainer_counter].Location = new Point(Gate_Location.X - 100, Gate_Location.Y);
                                break;
                            }
                        }
                        else Draw_Gate_AT_current_Location = true;
                    }
                }
                if (Draw_Gate_AT_current_Location || !Public_Static_Variables.gatecontainer_created)
                {
                    Public_Static_Variables.Notgatecontainer[Public_Static_Variables.Notgatecontainer_counter].Location = Gate_Location;
                }
                else if (Create_A_New_First_Gate)
                {
                    Public_Static_Variables.Notgatecontainer[Public_Static_Variables.Notgatecontainer_counter].Location = Gate_Location;
                    Create_A_New_First_Gate = false;
                }
                Public_Static_Variables.gatecontainer_created = true;
                Draw_Gate_AT_current_Location = false;
                Public_Static_Variables.DoThread = true;
            }
        }
    }
}
