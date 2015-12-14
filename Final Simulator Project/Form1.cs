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
        Thread t;
        Graphics g;
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        int width = Public_Static_Variables.width;
        int height = Public_Static_Variables.height;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        bool drawFirstGate = false; // to avoid entering the thread before any gate i drawn
        Rectangle Temp_Draw_Rectangle = new Rectangle();
        bool DrawTempRectangle = false;
        bool Panel1MouseUp = false; // prevents a bug
        int Temp_Counter = 0; // a temp integer which takes the value of the rectangle to be connected and addit to the list
        int Temp_Counter2 = 0;
        Point MovingPoint = new Point();
        Point CurrentLocation = new Point();
        Point Andgate_Picture_Location = new Point();
        bool Draw_Gate_AT_current_Location = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (Public_Static_Variables.ContainerRectangle[i].Contains(new Point(e.X, e.Y)) && Public_Static_Variables.gatecontainer_created)
                {
                    Public_Static_Variables.gatecontainer[i].Visible = true;
                    Public_Static_Variables.Reset_draw_rect = i;
                    Public_Static_Variables.MouseMove = true;
                    break;
                }
               
                else if (Public_Static_Variables.gatecontainer_created)
                {
                    Public_Static_Variables.gatecontainer[i].Visible = false;
                    Public_Static_Variables.MouseMove = false;
                }
            }
            for (int i = 1; i < Public_Static_Variables.Connecting_Rectangles_Counter; i++)
            {
                 if (Public_Static_Variables.Connecting_Rectangles[i].Contains(new Point(e.X, e.Y)))
                {
                    Temp_Draw_Rectangle = Public_Static_Variables.Connecting_Rectangles[i];
                    Temp_Draw_Rectangle.Location = new Point(Public_Static_Variables.Connecting_Rectangles[i].Left - 2, Public_Static_Variables.Connecting_Rectangles[i].Top - 2);
                    Temp_Draw_Rectangle.Width = Public_Static_Variables.Connecting_Rectangles[i].Width + 4;
                    Temp_Draw_Rectangle.Height = Public_Static_Variables.Connecting_Rectangles[i].Height + 4;
                    DrawTempRectangle = true;
                    Public_Static_Variables.DoThread = true;
                    break;
                }
                 else if (DrawTempRectangle)
                {
                    DrawTempRectangle = false;
                    Public_Static_Variables.DoThread = true;
                }
            }
        }
        public void Draw()
        {
            while (true)
            {
                //System.Threading.Thread.Sleep(50);
                if (drawFirstGate && Public_Static_Variables.DoThread)
                {
                    g.Clear(Color.FromKnownColor(KnownColor.Control));
                    int X, Y;
                    // x,y is the top point of the vertical line of the AND gate
                    // drawing the and gate starts here

                    for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)   
                    {
                        X = Public_Static_Variables.ContainerScreenLocation[i].X ;
                        Y = Public_Static_Variables.ContainerScreenLocation[i].Y;
                        Rectangle inputRect1 = new Rectangle(X - 30 - RectWidthAndHeight, Y + RectWidthAndHeight / 2, RectWidthAndHeight, RectWidthAndHeight);// initialize first rectangle
                        Rectangle inputRect2 = new Rectangle(X - 30 - RectWidthAndHeight, Y + RectWidthAndHeight + height - 12, RectWidthAndHeight, RectWidthAndHeight);//initialize secind rectangle
                        Rectangle outputRect = new Rectangle(X + width / 2 + 30 - RectWidthAndHeight + 5, Y + height / 2 - RectWidthAndHeight + 3, RectWidthAndHeight, RectWidthAndHeight);
                        g.DrawPie(pen, X - (width / 2), Y, width, height, 270, 180); //curve
                        g.DrawLine(pen, new Point(X, Y + 5), new Point(X - 30, Y + 5));// first horizontal line
                        g.DrawLine(pen, new Point(X, Y + width - 5), new Point(X - 30, Y + width - 5));// Second Horizontal line
                        g.DrawLine(pen, new Point(X + (width / 2), Y + (height / 2)), new Point(X + (width / 2) + 30, Y + (height / 2)));// last horizontal line
                        g.FillRectangle(sb, inputRect1); // first rectangle
                        g.FillRectangle(sb, inputRect2);// second rectangle
                        g.FillRectangle(sb, outputRect);//output rectangle
                    }
                    
                    for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i=i+2)
                    {
                        Rectangle rectangle1 = new Rectangle();
                        Rectangle rectangle2 = new Rectangle();
                        int  num1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                        int num2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                        if (num2 % 3 == 0)
                        {
                            rectangle1 = Public_Static_Variables.Connecting_Rectangles[num2];
                            rectangle2 = Public_Static_Variables.Connecting_Rectangles[num1];
                        }
                        else
                        {
                            rectangle1 = Public_Static_Variables.Connecting_Rectangles[num1];
                            rectangle2 = Public_Static_Variables.Connecting_Rectangles[num2];
                        }
                        Point p1 = new Point(rectangle1.Left + RectWidthAndHeight / 2, rectangle1.Top + RectWidthAndHeight / 2 + 1); // midpoint of first rectangle
                        Point p12 = new Point(rectangle1.Left + RectWidthAndHeight / 2, rectangle2.Top + RectWidthAndHeight / 2 + 1);
                        Point p2 = new Point(rectangle2.Left + RectWidthAndHeight / 2, rectangle2.Top + RectWidthAndHeight / 2 + 1); // midpoint of first rectangle
                        g.DrawLine(pen, p1, p12);
                        g.DrawLine(pen, p12, p2);
                    }
                    if (DrawTempRectangle)
                    {
                        Pen DashedPen = new Pen(Color.Black);
                        float[] dashValues = { 2, 2, 2, 2 };
                        DashedPen.DashPattern = dashValues;
                        g.DrawRectangle(DashedPen, Temp_Draw_Rectangle);
                    }
                    Public_Static_Variables.DoThread = false;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            t = new Thread(Draw);
            t.Start();
            Public_Static_Variables.gatecontainer[0] = null;
            AndGate_PictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.PNG";
            AndGate_PictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.PNG";
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < Public_Static_Variables.Connecting_Rectangles_Counter; i++)
            {
                if (Public_Static_Variables.Connecting_Rectangles[i].Contains (new Point (e.X,e.Y)))
                {
                    Temp_Counter = i;
                    Panel1MouseUp = true;
                    break;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < Public_Static_Variables.Connecting_Rectangles_Counter; i++)
            {
                if (Public_Static_Variables.Connecting_Rectangles[i].Contains (new Point(e.X, e.Y)) && Panel1MouseUp)
                {
                    Temp_Counter2 = i;
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Temp_Counter);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Temp_Counter2);
                    Public_Static_Variables.DoThread = true;
                    Panel1MouseUp = false;
                    break;
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
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
                    AndGateContainer local_Control = Public_Static_Variables.gatecontainer[i];
                    Rectangle Local_Rectangle = new Rectangle();
                    Local_Rectangle.Location = local_Control.Location;
                    Local_Rectangle.Width = local_Control.Width;
                    Local_Rectangle.Height = local_Control.Height;
                if (current_location_Retangle.IntersectsWith(Local_Rectangle))
                {
                    if (Local_Rectangle.Contains(current_location_Retangle.Location))
                    {
                        Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = new Point(CurrentLocation.X+ 100, CurrentLocation.Y);
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
            if (Draw_Gate_AT_current_Location)
            {
                Public_Static_Variables.gatecontainer[Public_Static_Variables.gatecontainer_counter].Location = CurrentLocation;
            }
            Public_Static_Variables.gatecontainer_created = true;
            drawFirstGate = true;
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
        public static void Delete_Gate (int num)
        {
                for (int i = num; i < Public_Static_Variables.gatecontainer_counter; i++)
                {
                Public_Static_Variables.Deleted_Gate = true;
                Public_Static_Variables.gatecontainer[i].Location = Public_Static_Variables.gatecontainer[i + 1].Location;
                }

            Public_Static_Variables.Deleted_Gate = false;
            Public_Static_Variables.gatecontainer_counter--;

            Public_Static_Variables.DoThread = true;
        }
    }
}
