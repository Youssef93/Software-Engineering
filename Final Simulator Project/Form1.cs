using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Final_Simulator_Project
{
    public partial class Form1 : Form
    {
        int width = Public_Static_Variables.width;
        int height = Public_Static_Variables.height;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        Point MovingPoint = new Point();
        Point CurrentLocation = new Point();
        Point Andgate_Picture_Location = new Point();
        bool Draw_Gate_AT_current_Location = true;
        public static bool Create_A_New_First_Gate = false;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Public_Static_Variables.gatecontainer[0] = null;
            AndGate_PictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.PNG";
            AndGate_PictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.PNG";
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panel1.BackColor = Color.White;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
                Andgate_Picture_Location = AndGate_PictureBox.Location ;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AndGate_PictureBox.Location = new Point(AndGate_PictureBox.Left + (e.X - MovingPoint.X), AndGate_PictureBox.Top + (e.Y - MovingPoint.Y));
                if (AndGate_PictureBox.Right -15 >= groupBox1.Width)
                {
                    AndGate_PictureBox.Parent = panel1;
                }
            }
           
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            CurrentLocation = AndGate_PictureBox.Location;
            AndGate_PictureBox.Parent = groupBox1;
            AndGate_PictureBox.Location = Andgate_Picture_Location;
            // creating the and gate
            Public_Static_Variables.gatecontainer_counter++;
            Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter] = new AndGateContainer();
            panel1.Controls.Add(Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter]);
            Rectangle current_location_Retangle = new Rectangle();
            current_location_Retangle.Location = CurrentLocation;
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
                            Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = new Point(CurrentLocation.X + 100, CurrentLocation.Y);
                            break;
                        }
                        else if (Local_Rectangle.Contains(new Point(current_location_Retangle.Right, current_location_Retangle.Top)))
                        {
                            Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = new Point(CurrentLocation.X - 100, CurrentLocation.Y);
                            break;
                        }
                    }
                    else Draw_Gate_AT_current_Location = true;
                }
            }
                if (Draw_Gate_AT_current_Location || !Public_Static_Variables.gatecontainer_created)
                {
                    Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = CurrentLocation;
                }
                else if (Create_A_New_First_Gate)
            {
                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = CurrentLocation;
                Create_A_New_First_Gate = false;
            }
                Public_Static_Variables.gatecontainer_created = true;
                Draw_Gate_AT_current_Location = false;
        }

        private void AndGate_PictureBox_ParentChanged(object sender, EventArgs e)
        {
            AndGate_PictureBox.BringToFront();
        }

        private void AndGate_PictureBox_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("To add a gate, drag and drop it into the panel", AndGate_PictureBox);
        }
        public static void Delete_gate(int num)
        {
            Control panel1 = Public_Static_Variables.gatecontainer[num].Parent;
            Public_Static_Variables.Gate_Removed = true;
            panel1.Controls.Remove(Public_Static_Variables.gatecontainer[num]);
           /*Remember this Line,, it will be very useful
           panel1.Controls.CopyTo
           */
        }
    }
}
