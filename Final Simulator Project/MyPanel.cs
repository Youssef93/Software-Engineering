using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;
namespace Final_Simulator_Project
{
    class MyPanel : Panel
    {
        Graphics g;
        Thread t;
        int width = Public_Static_Variables.width;
        int height = Public_Static_Variables.height;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        Rectangle Temp_Draw_Rectangle = new Rectangle(); // a rectangle that holds the value of the connecting rectangle that the mouse is currently at
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        bool Panel1MouseUp = false; // prevents a bug
        int Temp_Counter = 0; // a temp integer which takes the value of the rectangle to be connected and addit to the list
        int Temp_Counter2 = 0;
        //private const int WM_SETREDRAW = 0x000B;
        //private const int WM_USER = 0x400;
        //private const int EM_GETEVENTMASK = (WM_USER + 59);
        //private const int EM_SETEVENTMASK = (WM_USER + 69);
        //[DllImport("user32", CharSet = CharSet.Auto)]
        //private extern static IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        //IntPtr eventMask = IntPtr.Zero;
        public MyPanel()
        {
            this.BackColor = Color.White;
            g = this.CreateGraphics();
            this.BorderStyle = BorderStyle.FixedSingle;
            t = new Thread(Draw);
            t.Start();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //this.Invalidate();
            //try
            //{
            //    // Stop redrawing:
            //    SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
            //    // Stop sending of events:
            //    eventMask = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
            //    Draw();
            //}
            //finally
            //{
            //    // turn on events
            //    SendMessage(this.Handle, EM_SETEVENTMASK, 0, eventMask);
            //    // turn on redrawing
            //    SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
            //}
            //this.Update();
            //Draw();
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
                   Public_Static_Variables.DrawTempRectangle = true;
                    //Draw();
                    Public_Static_Variables.DoThread = true;
                    break;
                }
                else if (Public_Static_Variables.DrawTempRectangle)
                {
                    Public_Static_Variables.DrawTempRectangle = false;
                    //Draw();
                    Public_Static_Variables.DoThread = true;
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
                //Draw();
                Public_Static_Variables.DoThread = true;
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
            //Draw();
            Public_Static_Variables.DoThread = true;
        }
        void Equalize_Rectangles(ref Rectangle Refernce_Rectangle, ref Rectangle Modified_Rectangle)
        {
            Modified_Rectangle.Location = Refernce_Rectangle.Location;
            Modified_Rectangle.Width = Refernce_Rectangle.Width;
            Modified_Rectangle.Height = Refernce_Rectangle.Height;
        }
        void Draw()
        {
            while (true)
            {
                if (Public_Static_Variables.DoThread)
                {
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
                            g.DrawLine(pen, inputPoint1, new Point(inputPoint1.X - 1, inputPoint1.Y));
                            g.DrawLine(pen, inputPoint2, new Point(inputPoint2.X - 1, inputPoint2.Y));
                            g.DrawLine(pen, outputPoint, new Point(outputPoint.X + 1, outputPoint.Y));

                            Rectangle inputRectangle1 = new Rectangle();
                            Rectangle inputRectangle2 = new Rectangle();
                            Rectangle outputRectangle = new Rectangle();
                            inputRectangle1.Location = new Point(inputPoint1.X - 1 - RectWidthAndHeight, inputPoint1.Y - RectWidthAndHeight / 2);
                            inputRectangle1.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
                            inputRectangle2.Location = new Point(inputPoint2.X - 1 - RectWidthAndHeight, inputPoint2.Y - RectWidthAndHeight / 2);
                            inputRectangle2.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
                            outputRectangle.Location = new Point(outputPoint.X + 1, outputPoint.Y - RectWidthAndHeight / 2);
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
                    if (Public_Static_Variables.DrawTempRectangle)
                    {
                        Pen DashedPen = new Pen(Color.Black);
                        float[] dashValues = { 2, 2, 2, 2 };
                        DashedPen.DashPattern = dashValues;
                        g.DrawRectangle(DashedPen, Temp_Draw_Rectangle);
                    }
                    Public_Static_Variables.DoThread = false;
                    System.Threading.Thread.Sleep(60);  //60  or 50
                }
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