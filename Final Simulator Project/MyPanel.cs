using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    class MyPanel : Panel
    {
        Graphics g;
        int width = Public_Static_Variables.width;
        int height = Public_Static_Variables.height;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        Rectangle Temp_Draw_Rectangle = new Rectangle(); // a rectangle that holds the value of the connecting rectangle that the mouse is currently at
        bool DrawTempRectangle = false;
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        bool Panel1MouseUp = false; // prevents a bug
        int Temp_Counter = 0; // a temp integer which takes the value of the rectangle to be connected and addit to the list
        int Temp_Counter2 = 0;
        public MyPanel()
        {
            this.BackColor = Color.White;
            g = this.CreateGraphics();
            this.BorderStyle = BorderStyle.FixedSingle;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Draw();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
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
        protected override void OnMouseMove(MouseEventArgs e)
        {
            foreach ( Rectangle rectangle in Public_Static_Variables.Connecting_Rectangles)
            {
                if (rectangle.Contains(new Point(e.X, e.Y)))
                {
                    Temp_Draw_Rectangle = rectangle;
                    DrawTempRectangle = true;
                    Draw();
                    break;
                }
                else if (DrawTempRectangle)
                {
                    DrawTempRectangle = false;
                    Draw();
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            for (int i = 1; i < Public_Static_Variables.Connecting_Rectangles_Counter; i++)
            {
                if (Public_Static_Variables.Connecting_Rectangles[i].Contains(new Point(e.X, e.Y)) && Panel1MouseUp)
                {
                    Temp_Counter2 = i;
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Temp_Counter);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Temp_Counter2);
                    Panel1MouseUp = false;
                    break;
                }
            }
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
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
                Draw();
            }
        }
        protected override void OnResize(EventArgs eventargs)
        {
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (this.Controls.Contains(Public_Static_Variables.gatecontainer[i]) && Public_Static_Variables.gatecontainer[i].Right >= this.Width)
                {
                    Public_Static_Variables.Reset_draw_rect = i;
                    Public_Static_Variables.gatecontainer[i].Location = new Point(this.Width - 100, Public_Static_Variables.gatecontainer[i].Location.Y);
                }
            }
        }
        void Equalize_Rectangles(ref Rectangle Refernce_Rectangle, ref Rectangle Modified_Rectangle)
        {
            Modified_Rectangle.Location = Refernce_Rectangle.Location;
            Modified_Rectangle.Width = Refernce_Rectangle.Width;
            Modified_Rectangle.Height = Refernce_Rectangle.Height;
        }
        void Draw()
        {
            g.Dispose();
            g = this.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (this.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                {
                    Point outputPoint = new Point();
                    Point inputPoint1 = new Point();
                    Point inputPoint2 = new Point();
                    inputPoint1.X = Public_Static_Variables.gatecontainer[i].Location.X;
                    inputPoint1.Y = Public_Static_Variables.gatecontainer[i].Location.Y + 10 + 5;
                    inputPoint2.X = Public_Static_Variables.gatecontainer[i].Location.X;
                    inputPoint2.Y = Public_Static_Variables.gatecontainer[i].Location.Y + 10 + height - 5;
                    outputPoint.X = Public_Static_Variables.gatecontainer[i].Location.X + Public_Static_Variables.gatecontainer[i].Width;
                    outputPoint.Y = Public_Static_Variables.gatecontainer[i].Location.Y + 30;
                    g.DrawLine(pen, inputPoint1, new Point(inputPoint1.X - 5, inputPoint1.Y));
                    g.DrawLine(pen, inputPoint2, new Point(inputPoint2.X - 5, inputPoint2.Y));
                    g.DrawLine(pen, outputPoint, new Point(outputPoint.X + 5, outputPoint.Y));

                    Rectangle inputRectangle1 = new Rectangle();
                    Rectangle inputRectangle2 = new Rectangle();
                    Rectangle outputRectangle = new Rectangle();
                    inputRectangle1.Location = new Point(inputPoint1.X - 5 - RectWidthAndHeight, inputPoint1.Y - RectWidthAndHeight / 2);
                    inputRectangle1.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
                    inputRectangle2.Location = new Point(inputPoint2.X - 5 - RectWidthAndHeight, inputPoint2.Y - RectWidthAndHeight / 2);
                    inputRectangle2.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
                    outputRectangle.Location = new Point(outputPoint.X + 5, outputPoint.Y - RectWidthAndHeight / 2);
                    outputRectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
                    g.FillRectangle(sb, inputRectangle1);
                    g.FillRectangle(sb, inputRectangle2);
                    g.FillRectangle(sb, outputRectangle);
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