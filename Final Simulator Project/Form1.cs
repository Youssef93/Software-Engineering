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
        public static bool DoThread = false;  // to prevent the flickering bug
        public static bool gatecontainer_created = false; // to prevent bug created when Panel1_mouseMove event is raised before any gate is created
        AndGateContainer [] gatecontainer = new AndGateContainer[50];// number of and gates
        public static int gatecontainer_counter = 0; // counter of and gates
        Graphics g;
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        public static Point[] ContainerScreenLocation = new Point[50];
        public static int Reset_draw_rect = 0; // a variable to send back to the control to mofify the location
        int width = GateVariables.width;
        int height = GateVariables.height;
        int RectWidthAndHeight = GateVariables.RectWidthAndHeight;
        bool drawFirstGate = false; // to avoid entering the thread before any gate i drawn
        public static Rectangle[] ContainerRectangle = new Rectangle[50]; // number of rectangles (all gates' positions)
        public static Rectangle[] Connecting_Rectangles = new Rectangle[200]; // an array that holds all input/output nodes of all gates
        public static int Connecting_Rectangles_Counter = 1;
        Rectangle Temp_Draw_Rectangle = new Rectangle();
        bool DrawTempRectangle = false;
        public static Rectangle Temp_Output_Rectangle = new Rectangle(); // temp rectangles to connect lines
        public static Rectangle Temp_Input_Rectangle = new Rectangle();
        bool Panel1MouseUp = false; // prevents a bug
        public static List<Rectangle> Pair_Input_Output_Rectangles = new List<Rectangle>(); // a list where each two consequetive rectangles are the rectangles connected to each other
        public static bool[] Connecting_Rectangles_Bools = new bool[200];
        int Temp_Counter = 0;
        int Temp_Counter2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 1; i <= gatecontainer_counter; i++)
            {
                if (ContainerRectangle[i].Contains(new Point(e.X, e.Y)) && gatecontainer_created)
                {
                    gatecontainer[i].Visible = true;
                    Reset_draw_rect = i;
                    AndGateContainer.MouseMove = true;
                    break;
                }
               
                else if (gatecontainer_created)
                {
                    gatecontainer[i].Visible = false;
                    AndGateContainer.MouseMove = false;
                }
            }
            for (int i = 1; i < Connecting_Rectangles_Counter; i++)
            {
                 if (Connecting_Rectangles[i].Contains(new Point(e.X, e.Y)))
                {
                    Temp_Draw_Rectangle = Connecting_Rectangles[i];
                    Temp_Draw_Rectangle.Location = new Point(Connecting_Rectangles[i].Left - 2, Connecting_Rectangles[i].Top - 2);
                    Temp_Draw_Rectangle.Width = Connecting_Rectangles[i].Width + 4;
                    Temp_Draw_Rectangle.Height = Connecting_Rectangles[i].Height + 4;
                    DrawTempRectangle = true;
                    DoThread = true;
                    break;
                }
                 else if (DrawTempRectangle)
                {
                    DrawTempRectangle = false;
                    DoThread = true;
                }
            }
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            gatecontainer_counter++;
            gatecontainer[gatecontainer_counter]= new AndGateContainer();
            panel1.Controls.Add(gatecontainer[gatecontainer_counter]);
            gatecontainer[gatecontainer_counter].Location = new Point(100, 100);
            gatecontainer_created = true;
            drawFirstGate = true;
            DoThread = true; 
        }
        

        public void Draw()
        {
            while (true)
            {
                //System.Threading.Thread.Sleep(50);
                if (drawFirstGate && DoThread)
                {
                    g.Clear(Color.FromKnownColor(KnownColor.Control));
                    int X, Y;
                    // x,y is the top point of the vertical line of the AND gate
                    // drawing the and gate starts here

                    for (int i = 1; i <= gatecontainer_counter; i++)   
                    {
                        X = ContainerScreenLocation[i].X ;
                        Y = ContainerScreenLocation[i].Y;
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
                    for (int i = 0; i < Pair_Input_Output_Rectangles.Count; i = i+2)
                    {
                        Rectangle rectangle1 = Pair_Input_Output_Rectangles.ElementAt(i);
                        Rectangle rectangle2 = Pair_Input_Output_Rectangles.ElementAt(i+1);
                        Point p1 = new Point(rectangle1.Left + RectWidthAndHeight / 2, rectangle1.Top + RectWidthAndHeight / 2+1); // midpoint of first rectangle
                        Point p2 = new Point(rectangle2.Left + RectWidthAndHeight / 2, rectangle2.Top + RectWidthAndHeight / 2+1); // midpoint of first rectangle
                        g.DrawLine(pen, p1, p2);
                    }
                    if (DrawTempRectangle)
                    {
                        Pen DashedPen = new Pen(Color.Black);
                        float[] dashValues = { 2, 2, 2, 2 };
                        DashedPen.DashPattern = dashValues;
                        g.DrawRectangle(DashedPen, Temp_Draw_Rectangle);                      
                    }
                    DoThread = false;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            t = new Thread(Draw);
            t.Start();
            gatecontainer[0] = null;
            SetAllBoolsToFalse();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < Connecting_Rectangles_Counter; i++)
            {
                if (Connecting_Rectangles[i].Contains (new Point (e.X,e.Y)))
                {
                    Temp_Output_Rectangle = Connecting_Rectangles[i];
                    Temp_Counter = i;
                    Panel1MouseUp = true;
                    break;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < Connecting_Rectangles_Counter; i++)
            {
                if (Connecting_Rectangles[i].Contains (new Point(e.X, e.Y)) && Panel1MouseUp)
                {
                    Temp_Input_Rectangle = Connecting_Rectangles[i];
                    Temp_Counter2 = i;
                    Connecting_Rectangles_Bools[Temp_Counter] = true;
                    Connecting_Rectangles_Bools[Temp_Counter2] = true;
                    Set_Input_Output_Rectangles();
                    Panel1MouseUp = false;
                    break;
                }
            }
        }
         public static void Set_Input_Output_Rectangles()
        {
            
            //Pair_Input_Output_Rectangles.Add(Temp_Output_Rectangle);
            //Pair_Input_Output_Rectangles.Add(Temp_Input_Rectangle);
            Pair_Input_Output_Rectangles.Clear();
            for (int i = 0; i < 200; i++)
            {
                if (Connecting_Rectangles_Bools[i])
                {
                    Pair_Input_Output_Rectangles.Add(Connecting_Rectangles[i]);
                }
            }
            DoThread = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }
        public void SetAllBoolsToFalse()
        {
            for (int i = 0; i < 200; i++)
            {
                Connecting_Rectangles_Bools[i] = false;
            }
        }
    }
}
