using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
    class MyPanel : Panel
    {
        Rectangle Temp_Draw_Rectangle = new Rectangle();
        bool DrawTempRectangle = false;
        bool Panel1MouseUp = false; // prevents a bug
        int Temp_Counter = 0; // a temp integer which takes the value of the rectangle to be connected and addit to the list
        int Temp_Counter2 = 0;
        bool Create_A_New_First_Gate = false;
        Graphics g;
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        int width = Public_Static_Variables.width;
        int height = Public_Static_Variables.height;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
     
        public MyPanel()
        {
            //this.DoubleBuffered = true;
            this.BackColor = Color.White;
            g = this.CreateGraphics();
            this.BorderStyle = BorderStyle.FixedSingle;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            draw();
           
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            for (int i = 1; i < Public_Static_Variables.Connecting_Rectangles_Counter; i++)
            {
                if (Public_Static_Variables.Connecting_Rectangles[i].Contains(new Point(e.X, e.Y)))
                {
                    Temp_Counter = i;
                    Panel1MouseUp = true;
                    break;
                }
            }
        }
        void draw()
        {
            g.Dispose();
            g = this.CreateGraphics();
            g.Clear(Color.White);
            int X, Y;
            // x,y is the top point of the vertical line of the AND gate
            // drawing the and gate starts here
            if (Public_Static_Variables.gatecontainer_created)
            {
                for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                {
                    if (this.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                    {
                        Point point = new Point();
                        point = Public_Static_Variables.gatecontainer[i].ContainerScreenLocation;
                        X = point.X;
                        Y = point.Y;
                        Rectangle rectangle = new Rectangle();
                        rectangle = Public_Static_Variables.gatecontainer[i].ContainerRectangle;
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
                }

                for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 2)
                {
                    Rectangle rectangle1 = new Rectangle();
                    Rectangle rectangle2 = new Rectangle();
                    int num1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
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
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            for (int i = 1; i < Public_Static_Variables.Connecting_Rectangles_Counter; i++)
            {
                if (Public_Static_Variables.Connecting_Rectangles[i].Contains(new Point(e.X, e.Y)) && Panel1MouseUp)
                {
                    Temp_Counter2 = i;
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Temp_Counter);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Temp_Counter2);
                    draw();
                    Panel1MouseUp = false;
                    break;
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Public_Static_Variables.gatecontainer_created)
            {
                for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle = Public_Static_Variables.gatecontainer[i].ContainerRectangle;
                    if (rectangle.Contains(new Point(e.X, e.Y)) && Public_Static_Variables.gatecontainer_created)
                    {
                        Public_Static_Variables.gatecontainer[i].Visible = true;
                        Public_Static_Variables.Reset_draw_rect = i;
                        break;
                    }

                    else if (Public_Static_Variables.gatecontainer_created)
                    {
                        Public_Static_Variables.gatecontainer[i].Visible = false;
                    }
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
                    draw();
                    break;
                }
                else if (DrawTempRectangle)
                {
                    DrawTempRectangle = false;
                    draw();
                }
            }
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            //    base.OnControlRemoved(e);
            if (Public_Static_Variables.Gate_Removed)
            {
                bool Do_While_bool = false;
                Rectangle Zero_Rectangle = new Rectangle();
                Zero_Rectangle.Location = new Point(-1, 0);
                Zero_Rectangle.Width = 0;
                Zero_Rectangle.Height = 0;
                Public_Static_Variables.gatecontainer[Public_Static_Variables.Reset_draw_rect].ZeroRectangle();
                Public_Static_Variables.gatecontainer[Public_Static_Variables.Reset_draw_rect].ContainerScreenLocation = new Point(-1, -1);
                Public_Static_Variables.Gate_Removed = false;
                int current_index = Public_Static_Variables.Reset_draw_rect * 3;
                Equalize_Rectangles(ref Zero_Rectangle, ref Public_Static_Variables.Connecting_Rectangles[current_index]);
                Equalize_Rectangles(ref Zero_Rectangle, ref Public_Static_Variables.Connecting_Rectangles[current_index - 1]);
                Equalize_Rectangles(ref Zero_Rectangle, ref Public_Static_Variables.Connecting_Rectangles[current_index - 2]);
                if (this.Controls.Count == 0)
                    Create_A_New_First_Gate = true;
                do
                {
                    Do_While_bool = false;
                    for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 2)
                    {
                        int num1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                        int num2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                        if (current_index == num1 || current_index == num2 || current_index - 1 == num1 || current_index - 1 == num2 || current_index - 2 == num1 || current_index - 2 == num2)
                        {
                            Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i, 2);
                            Do_While_bool = true;
                            break;
                        }
                    }
                }
                while (Do_While_bool);
                if (this.Controls.Count == 0)
                {
                    Public_Static_Variables.gatecontainer_counter = 0;
                    Public_Static_Variables.Connecting_Rectangles_Counter = 1;
                    Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
                    Public_Static_Variables.gatecontainer = new AndGateContainer[50];
                    Array.Clear(Public_Static_Variables.Connecting_Rectangles, 0, Public_Static_Variables.Connecting_Rectangles.Length);
                    Public_Static_Variables.Connecting_Rectangles = new Rectangle[200];
                    Public_Static_Variables.gatecontainer_created = false;
                }
                System.Threading.Thread.Sleep(50); //prevents a bug
                draw();
            }
        }
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (this.Controls.Contains(Public_Static_Variables.gatecontainer[i]) && Public_Static_Variables.gatecontainer[i].Right >= this.Width)
                {
                    Public_Static_Variables.Reset_draw_rect = i;
                    Public_Static_Variables.gatecontainer[i].Location = new Point(this.Width - 100, Public_Static_Variables.gatecontainer[i].Location.Y);
                }
            }
            draw();
        }
        
   
        void Equalize_Rectangles(ref Rectangle Refernce_Rectangle, ref Rectangle Modified_Rectangle)
        {
            Modified_Rectangle.Location = Refernce_Rectangle.Location;
            Modified_Rectangle.Width = Refernce_Rectangle.Width;
            Modified_Rectangle.Height = Refernce_Rectangle.Height;
        }
    }
}
