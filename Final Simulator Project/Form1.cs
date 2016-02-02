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
        Point Input_PictureBox_Location;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Public_Static_Variables.gatecontainer[0] = null;
            MyPictureBox My_Andgate_PictrueBox = new MyPictureBox();
            NotPictureBox Not_PictureBox = new NotPictureBox();
            OrPictureBox Or_PictureBox = new OrPictureBox();
            NorPictureBox Nor_PictureBox = new NorPictureBox();
            XOrPictureBox XOr_PictureBox = new XOrPictureBox();

            groupBox1.Controls.Add(My_Andgate_PictrueBox);
            My_Andgate_PictrueBox.Location =  AndGate_PictureBox2.Location;
            groupBox1.Controls.Add(Not_PictureBox);
            Not_PictureBox.Location = NotpictureBox2.Location;
            groupBox1.Controls.Add(Or_PictureBox);
            Or_PictureBox.Location = OrPictureBox_.Location;
            groupBox1.Controls.Add(Nor_PictureBox);
            Nor_PictureBox.Location = NorPictureBox_.Location;
            groupBox1.Controls.Add(XOr_PictureBox);
            XOr_PictureBox.Location = XOrPictureBox_.Location;

            AndGate_PictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.JPG";
            NotpictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NotGate.JPG";
            OrPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\OrGate.JPG";
            NorPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NorGate.JPG";
            XOrPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\XOrGate.JPG";


            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panel1.BackColor = Color.White;

            Input_pictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_pictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_PictureBox_Location = new Point();
            Input_PictureBox_Location = Input_pictureBox.Location;
           
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
            Control Picture_Box_Parent = Input_pictureBox.Parent;
            Point Input_Location = new Point();
            Input_Location = Input_pictureBox.Location;
           
            Input_pictureBox.Parent = groupBox2;
            Input_pictureBox.Location = Input_PictureBox_Location;
            Input_pictureBox.BringToFront();
            int X = Input_Location.X;
            int Y = Input_Location.Y;
            if (X <= 0 || Y <= 0 || X + 77 >= panel1.Width || Y + 33>= panel1.Height)
            {
                MessageBox.Show("Cannot put an input outside this panel." + Environment.NewLine + Environment.NewLine +
                    "Please, move the gate towards the middle of the panel if the desired gate is to close to the edge");
            }
            else if (Picture_Box_Parent.GetType() == typeof(MyPanel))
            {
                bool Remove_Input = true;
                input input_1 = new input();
                panel1.Controls.Add(input_1);
                input_1.Location = Input_Location;
                Rectangle rectangle = new Rectangle();
                Rectangle rectangle2 = new Rectangle();
                Rectangle rectangle3 = new Rectangle();

                for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                {

                     rectangle = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                     rectangle2 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                     rectangle3 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;

                     if (rectangle.IntersectsWith(input_1.intersecting_Rectangle))
                     {
                         if (Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected)
                         {
                              panel1.Controls.Remove(input_1);
                              MessageBox.Show("Cannot apply two inputs to the same node");
                        }
                        else
                         {
                            int x = rectangle.Left;
                            int y = rectangle.Top;
                            input_1.Location = new Point(x - input_1.Width + 8, y - input_1.Height / 2 + 6);
                            input_1.BringToFront();
                            Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected = true;
                            Public_Static_Variables.Inputs_List.Add(input_1);

                            Public_Static_Variables.Input_Connected_Gates_Indexes.Add(i);
                            Public_Static_Variables.Input_Connected_Gates_Indexes.Add(1);

                            Public_Static_Variables.Input_Counter++;

                            Remove_Input = false;
                          }
                            break;
                      }

                      else if (rectangle2.IntersectsWith(input_1.intersecting_Rectangle))
                    {
                           if (Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected)
                        {
                            panel1.Controls.Remove(input_1);
                            MessageBox.Show("Cannot apply two inputs to the same node");
                        }
                        else
                         {
                            int x = rectangle2.Left;
                            int y = rectangle2.Top;
                            input_1.Location = new Point(x - input_1.Width + 8, y - input_1.Height / 2 + 6);
                            input_1.BringToFront();
                            Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected = true;
                            Public_Static_Variables.Inputs_List.Add(input_1);

                            Public_Static_Variables.Input_Connected_Gates_Indexes.Add(i);
                            Public_Static_Variables.Input_Connected_Gates_Indexes.Add(2);
                            Public_Static_Variables.Input_Counter++;

                            Remove_Input = false;
                        }
                            break;
                        }
                  else if (rectangle3.IntersectsWith(input_1.intersecting_Rectangle))
                    {
                        panel1.Controls.Remove(input_1);
                        MessageBox.Show("Cannot aply input to an output node");
                        break;
                    }
                }
            if (Remove_Input)
                panel1.Controls.Remove(input_1);
            }
        }
    }
}

