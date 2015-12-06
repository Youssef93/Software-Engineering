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
        public static bool DoThread = false;  // to prevent the flickering bug
        public static bool gatecontainer_created = false; // to prevent bug created when Panel1_mouseMove event is raised before any gate is created
        AndGateContainer [] gatecontainer = new AndGateContainer[50];// number of and gates
        public static int gatecontainer_counter = 0; // counter of and gates
        Graphics g;
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        public static int Reset_draw_rect = 0; // a variable to send back to the control to mofify the location
        int width = GateVariables.width;
        int height = GateVariables.height;
        int RectWidthAndHeight = GateVariables.RectWidthAndHeight;
        bool drawFirstGate = false; // to avoid entering the thread before any gate i drawn
        public static Rectangle[] ContainerRectangle = new Rectangle[50]; // number of rectangles (all gates' positions)
        public static Rectangle[] Connecting_Rectangles = new Rectangle[200]; // an array that holds all input/output nodes of all gates
        public static int Connecting_Rectangles_Counter = 1;
        public static Rectangle Temp_Output_Rectangle = new Rectangle(); // temp rectangles to connect lines
        public static Rectangle Temp_Input_Rectangle = new Rectangle();
        bool Panel1MouseUp = false; // prevents a bug
        public static Rectangle[] Output_rectangles = new Rectangle[50]; // arrays that hold the input or output nodes that will be used to draw
        public static Rectangle[] Input_Rectangles = new Rectangle[50];
        public static int Output_Rectangles_Counter = 0;
        public static int Input_Rectangles_Counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 1; i <=gatecontainer_counter; i++)
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
                if (drawFirstGate && DoThread)
                {
                    g.Clear(Color.FromKnownColor(KnownColor.Control));
                    int X, Y;
                    // x,y is the top point of the vertical line of the AND gate
                    // drawing the and gate starts here

                    for (int i = 1; i <= gatecontainer_counter; i++)   
                    {
                        X = AndGateContainer.ContainerScreenLocation[i].X ;
                        Y = AndGateContainer.ContainerScreenLocation[i].Y;
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
                    if (Temp_Output_Rectangle.Left != 0 && Temp_Input_Rectangle.Left != 0 && Temp_Output_Rectangle.Top != 0 && Temp_Input_Rectangle.Top != 0)
                    {
                        Point p1 = new Point(Temp_Output_Rectangle.Left + RectWidthAndHeight/ 2, Temp_Output_Rectangle.Top + RectWidthAndHeight/ 2); // midpoint of first rectangle
                        Point p2 = new Point(Temp_Input_Rectangle.Left + RectWidthAndHeight/ 2, Temp_Input_Rectangle.Top + RectWidthAndHeight/2); // midpoint of first rectangle
                        g.DrawLine(pen, p1, p2);
                    }
                    DoThread = false;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            Thread t = new Thread(Draw);
            t.Start();
            gatecontainer[0] = null;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < Connecting_Rectangles_Counter; i++)
            {
                if (Connecting_Rectangles[i].Contains (new Point (e.X,e.Y)))
                {
                    Temp_Output_Rectangle = Connecting_Rectangles[i];
                    Panel1MouseUp = true;
                    Output_Rectangles_Counter = i;
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
                    Set_Input_Output_Rectangles();
                    Input_Rectangles_Counter = i;
                    Panel1MouseUp = false;
                    break;
                }
            }
        }
        void Set_Input_Output_Rectangles()
        {
            Output_rectangles[Output_Rectangles_Counter] = Temp_Output_Rectangle;
            Input_Rectangles[Input_Rectangles_Counter] = Temp_Input_Rectangle;
            DoThread = true;
        }
    }
}
