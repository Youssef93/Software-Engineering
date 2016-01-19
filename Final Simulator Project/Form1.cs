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
            AndGate_PictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.PNG";
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panel1.BackColor = Color.White;
            Input_pictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_pictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_PictureBox_Location = new Point();
            Input_PictureBox_Location = Input_pictureBox.Location;
            MyPictureBox My_Andgate_PictrueBox = new MyPictureBox(0);
            groupBox1.Controls.Add(My_Andgate_PictrueBox);
            My_Andgate_PictrueBox.Location = AndGate_PictureBox2.Location;
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
