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
        Point MovingPoint = new Point();
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
            XNorPictureBox XNOr_PictureBox = new XNorPictureBox();

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
            groupBox1.Controls.Add(XNOr_PictureBox);
            XNOr_PictureBox.Location = XNorPictureBox_.Location;

            AndGate_PictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.JPG";
            NotpictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NotGate.JPG";
            OrPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\OrGate.JPG";
            NorPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NorGate.JPG";
            XOrPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\XOrGate.JPG";
            XNorPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\XNOrGate.JPG";

            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panel1.BackColor = Color.White;

            Input_pictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_pictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";           
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
            if (Input_pictureBox.Parent == panel1)
            {
                Point Control_Location = Input_pictureBox.Location;
                Input_pictureBox.Parent = groupBox2;
                Input_pictureBox.Location = Input_pictureBox2.Location;
                Input_pictureBox.BringToFront();

                input Temp_Input = new input();
                panel1.Controls.Add(Temp_Input);
                Temp_Input.Location = Control_Location;

                int Gate_Type = 0; // object sent as refernce to decide which type of gate connected
                Rectangle IntersectingRectangle = new Rectangle(); // Rectangle sent as reference to determine which Rectangle
                int Rectangle_Index = 0; // Intger sent as reference to determine the index of which rectangle
                int Gate_Index = Do_My_Condition(Temp_Input.intersecting_Rectangle, ref Gate_Type, ref IntersectingRectangle, ref Rectangle_Index);

                if (Gate_Index == 0)
                {
                    panel1.Controls.Remove(Temp_Input);
                    MessageBox.Show("Please drop the Input at a valid position" + Environment.NewLine + Environment.NewLine
                        + " Valid positions are 'only' input nodes that aren't connected to any other gate");
                }
                else
                {
                    Temp_Input.Gate_Type = Gate_Type;
                    Temp_Input.Gate_Index = Gate_Index;
                    Temp_Input.Rectangle_Index = Rectangle_Index;
                    Public_Static_Variables.Inputs_List.Add(Temp_Input);
                    Temp_Input.Change_Location(IntersectingRectangle);
                    Temp_Input.BringToFront();
                }
            }
            else
            {
                Input_pictureBox.Parent = groupBox2;
                Input_pictureBox.Location = Input_pictureBox2.Location;
                Input_pictureBox.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //Resetting Everything
            Public_Static_Variables.gatecontainer_counter = 0;
            Public_Static_Variables.Notgatecontainer_counter = 0;
            Public_Static_Variables.Orgatecontainer_counter = 0;
            Public_Static_Variables.Norgatecontainer_counter = 0;
            Public_Static_Variables.XOrgatecontainer_counter = 0;
            Public_Static_Variables.XNorgatecontainer_counter = 0;

            Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
            Array.Clear(Public_Static_Variables.Notgatecontainer, 0, Public_Static_Variables.Notgatecontainer.Length);
            Array.Clear(Public_Static_Variables.Orgatecontainer, 0, Public_Static_Variables.Orgatecontainer.Length);
            Array.Clear(Public_Static_Variables.Norgatecontainer, 0, Public_Static_Variables.Norgatecontainer.Length);
            Array.Clear(Public_Static_Variables.XOrgatecontainer, 0, Public_Static_Variables.XOrgatecontainer.Length);
            Array.Clear(Public_Static_Variables.XNorgatecontainer, 0, Public_Static_Variables.XNorgatecontainer.Length);


            Public_Static_Variables.gatecontainer = new AndGateContainer[50];
            Public_Static_Variables.Notgatecontainer = new NotGateContainer[50];
            Public_Static_Variables.Orgatecontainer = new OrGateContainer[50];
            Public_Static_Variables.Norgatecontainer = new NorGateContainer[50];
            Public_Static_Variables.XOrgatecontainer = new XOrGateContainer[50];
            Public_Static_Variables.XNorgatecontainer = new XNorGateContainer[50];

            Public_Static_Variables.wires.Clear();
            Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Clear();
            MyPanel.Check_Connection(panel1);
        }
        /* 
        This function will return zero in the following cases :
        1- rectangle sent to it doesnt intersect with any node of any rectangle
        2- rectangle sent to it intersects with an output node
        3- rectangle sent to it intersects with a connected node

            Otherwise it returns the index of the gate & modifies the "sent by reference" objects 
            to determine:
            1- The Gate type
            2- Which rectangle 
            3- The exact rectangle that this input is connected to
        */
        private int Do_My_Condition(Rectangle rectangle, ref int Gate_Type, ref Rectangle Return_Rectangle, ref int Rectangle_Index)
        {
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Rectangle rectangle3 = new Rectangle();
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 0;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 0;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Notgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 1;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.Notgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 1;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.Notgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                } 
            }
            for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 2;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 2;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.Orgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                } 
            }
            for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 3;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 3;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.Norgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 4;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.XOrgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 4;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.XOrgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 5;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.XNorgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 5;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.XNorgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
            }
            return 0;
        }
    }
}

