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
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        int width = Public_Static_Variables.width;
        int height = Public_Static_Variables.height;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        Point MovingPoint = new Point();
        Point CurrentLocation = new Point();
        Point Andgate_Picture_Location = new Point();
        bool Draw_Gate_AT_current_Location = true;
        bool Create_A_New_First_Gate = false;
        Point Input_PictureBox_Location;
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
            Input_pictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_pictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_PictureBox_Location = new Point();
            Input_PictureBox_Location = Input_pictureBox.Location;
            MyPictureBox pic1 = new MyPictureBox(0);
            groupBox1.Controls.Add(pic1);
            pic1.Location = new Point (pic1.Location.X+5, pic1.Location.Y + 100);
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
                Public_Static_Variables.DoThread = true;
        }

        private void AndGate_PictureBox_ParentChanged(object sender, EventArgs e)
        {
            AndGate_PictureBox.BringToFront();
        }

        private void AndGate_PictureBox_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("To add a gate, drag and drop it into the panel", AndGate_PictureBox);
        }

        private void Input_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
            }
        }

        private void Input_pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Input_pictureBox.Location = new Point(Input_pictureBox.Left + (e.X - MovingPoint.X), Input_pictureBox.Top + (e.Y - MovingPoint.Y));
                if (Input_pictureBox.Right - 20 >= groupBox2.Width)
                {
                    Input_pictureBox.Parent = panel1;
                    Input_pictureBox.BringToFront();
                }
            }
        }

        private void Input_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point Panel_Location = new Point();
            bool input_added = false;
            if (Input_pictureBox.Parent == panel1)
            {
                Panel_Location = Input_pictureBox.Location;
                Input_pictureBox.Location = Input_PictureBox_Location;
                Input_pictureBox.Parent = groupBox2;
                Input_pictureBox.BringToFront();
                input INPUT = new input();
                panel1.Controls.Add(INPUT);
                INPUT.Location = Panel_Location;
                for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter*3; i++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle = INPUT.intersecting_Rectangle;
                    if (rectangle.IntersectsWith(Public_Static_Variables.Screen_Connecting_Rectangles[i]))
                    {
                        INPUT.Location = new Point(Public_Static_Variables.Screen_Connecting_Rectangles[i].Location.X + 1 + RectWidthAndHeight - INPUT.Width, Public_Static_Variables.Screen_Connecting_Rectangles[i].Location.Y + RectWidthAndHeight / 2 - INPUT.Height / 2 + 2);
                        INPUT.BringToFront();
                        int index_Of_Gate;
                        if (i % 3 == 0)
                        {
                            MessageBox.Show("Cannot apply input to an output Node");
                        }
                        else
                        {
                            index_Of_Gate = i / 3 + 1;
                            if (i % 3 == 1 && !Public_Static_Variables.gatecontainer[index_Of_Gate].Input_Connected_1)
                            {
                                
                                if (!Public_Static_Variables.gatecontainer[index_Of_Gate].selectionRectangle1.Connected)
                                {
                                    Public_Static_Variables.gatecontainer[index_Of_Gate].Input_Connected_1 = true;
                                    Public_Static_Variables.gatecontainer[index_Of_Gate].Input_Index_1 = Public_Static_Variables.Input_Counter;
                                    Public_Static_Variables.gatecontainer[index_Of_Gate].selectionRectangle1.Connected = true;
                                    Public_Static_Variables.Inputs_List.Add(INPUT);
                                    Public_Static_Variables.Input_Counter++;
                                    input_added = true;
                                }
                                else
                                {
                                    MessageBox.Show("This node is already connected to another input");
                                }
                                break;
                            }
                            else if (i % 3 == 2 && !Public_Static_Variables.gatecontainer[index_Of_Gate].Input_Connected_2)
                            {
                                if (!Public_Static_Variables.gatecontainer[index_Of_Gate].selectionRectangle2.Connected)
                                {
                                    Public_Static_Variables.gatecontainer[index_Of_Gate].Input_Connected_2 = true;
                                    Public_Static_Variables.gatecontainer[index_Of_Gate].Input_Index_2 = Public_Static_Variables.Input_Counter;
                                    Public_Static_Variables.gatecontainer[index_Of_Gate].selectionRectangle2.Connected = true;
                                    Public_Static_Variables.Inputs_List.Add(INPUT);
                                    Public_Static_Variables.Input_Counter++;
                                    input_added = true;
                                }
                                else
                                {
                                    MessageBox.Show("This node is already connected to another input");
                                }
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Cannot apply two inputs to the same node");
                            }
                        }
                    }
                }
                if (!input_added)
                {
                    panel1.Controls.Remove(INPUT);
                }
            }
            else
            {
                Input_pictureBox.Parent = groupBox2;
                Input_pictureBox.Location = Input_PictureBox_Location;
                Input_pictureBox.BringToFront();
            }
        }
    }
}
