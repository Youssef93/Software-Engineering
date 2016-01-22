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
        int width = Public_Static_Variables.width;
        int height = Public_Static_Variables.height;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
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
            this.BorderStyle = BorderStyle.FixedSingle;

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
            Move_Wires();
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            //if (Public_Static_Variables.Gate_Removed)
            //{
            //    bool Do_While_bool = false;
            //    Rectangle Zero_Rectangle = new Rectangle();
            //    Zero_Rectangle.Location = new Point(-1, 0);
            //    Zero_Rectangle.Width = 0;
            //    Zero_Rectangle.Height = 0;
            //    Public_Static_Variables.Gate_Removed = false;
            //    int current_index = Public_Static_Variables.Reset_draw_rect * 3;
            //    Equalize_Rectangles(ref Zero_Rectangle, ref Public_Static_Variables.Screen_Connecting_Rectangles[current_index]);
            //    Equalize_Rectangles(ref Zero_Rectangle, ref Public_Static_Variables.Screen_Connecting_Rectangles[current_index - 1]);
            //    Equalize_Rectangles(ref Zero_Rectangle, ref Public_Static_Variables.Screen_Connecting_Rectangles[current_index - 2]);
            //    do
            //    {
            //        Do_While_bool = false;
            //        for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 2)
            //        {
            //            int num1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
            //            int num2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
            //            if (current_index == num1 || current_index == num2 || current_index - 1 == num1 || current_index - 1 == num2 || current_index - 2 == num1 || current_index - 2 == num2)
            //            {
            //                Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i, 2);
            //                this.Controls.Remove(Public_Static_Variables.wires[i / 2]);
            //                Public_Static_Variables.wires.RemoveAt(i / 2);
            //                if (num1 % 3 == 0)
            //                {
            //                    Public_Static_Variables.gatecontainer[num1 /3].selectionRectangle3.Connected = false;
            //                }
            //                else if (num1 % 3 == 1)
            //                {
            //                    Public_Static_Variables.gatecontainer[num1 / 3 + 1].selectionRectangle1.Connected = false;
            //                }
            //                else if (num1 % 3 == 2)
            //                {
            //                    Public_Static_Variables.gatecontainer[num1 / 3 + 1].selectionRectangle2.Connected = false;
            //                }
            //                if (num2 % 3 == 0)
            //                {
            //                    Public_Static_Variables.gatecontainer[num2 / 3].selectionRectangle3.Connected = false;
            //                }
            //                else if (num2 % 3 == 1)
            //                {
            //                    Public_Static_Variables.gatecontainer[num2 /3 + 1].selectionRectangle1.Connected = false;
            //                }
            //                else if (num2 % 3 == 2)
            //                {
            //                    Public_Static_Variables.gatecontainer[num2 / 3 + 1].selectionRectangle2.Connected = false;
            //                }
            //                Do_While_bool = true;
            //                break;
            //            }
            //        }
            //    }
            //    while (Do_While_bool);
            //    if (this.Controls.Count == 0)
            //    {
            //        Public_Static_Variables.gatecontainer_counter = 0;
            //        Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
            //        Public_Static_Variables.gatecontainer = new AndGateContainer[50];
            //        Array.Clear(Public_Static_Variables.Screen_Connecting_Rectangles, 0, Public_Static_Variables.Screen_Connecting_Rectangles.Length);
            //        Public_Static_Variables.Screen_Connecting_Rectangles = new Rectangle[200];
            //        Public_Static_Variables.gatecontainer_created = false;
            //    }
            //    Public_Static_Variables.Gate_Removed = false;
            //}
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
            Move_Wires();
        }
        void Equalize_Rectangles(ref Rectangle Refernce_Rectangle, ref Rectangle Modified_Rectangle)
        {
            Modified_Rectangle.Location = Refernce_Rectangle.Location;
            Modified_Rectangle.Width = Refernce_Rectangle.Width;
            Modified_Rectangle.Height = Refernce_Rectangle.Height;
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
        public static void Delete_Wire(Point output_point, Point input_point)
        {
            //int index = 0;
            //for (int i = 0; i <= Public_Static_Variables.gatecontainer_counter*3; i++)
            //{
            //    if (Public_Static_Variables.Screen_Connecting_Rectangles[i].Contains(output_point) || Public_Static_Variables.Screen_Connecting_Rectangles[i].Contains(input_point))
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            //for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 2)
            //{
            //    int num1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
            //    int num2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
            //    if (num1 == index || num2 == index)
            //    {
            //        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i, 2);
            //        Control panel1 = Public_Static_Variables.wires[i / 2].Parent;
            //        panel1.Controls.Remove(Public_Static_Variables.wires[i / 2]);
            //        Public_Static_Variables.wires.RemoveAt(i / 2);
            //        if (num1%3 == 0)
            //        {
            //            Public_Static_Variables.gatecontainer[num1 /3].selectionRectangle3.Connected = false;
            //        }
            //        else if (num1%3 == 1)
            //        {
            //            Public_Static_Variables.gatecontainer[num1 / 3 + 1].selectionRectangle1.Connected = false;
            //        }
            //        else if (num1%3 == 2)
            //        {
            //            Public_Static_Variables.gatecontainer[num1 / 3 + 1].selectionRectangle2.Connected = false;
            //        }
            //        if (num2 % 3 == 0)
            //        {
            //            Public_Static_Variables.gatecontainer[num2/ 3].selectionRectangle3.Connected = false;
            //        }
            //        else if (num2 % 3 == 1)
            //        {
            //            Public_Static_Variables.gatecontainer[num2 /3 + 1].selectionRectangle1.Connected = false;
            //        }
            //        else if (num2 % 3 == 2)
            //        {
            //            Public_Static_Variables.gatecontainer[num2 / 3 + 1].selectionRectangle2.Connected = false;
            //        }
            //        break;
            //    }
            //}
        }
        public static void Add_Wires_To_Panel(int Gate_Index_1, int Rectangle_Index_1, int Gate_Index_2, int Rectangle_Index_2,Control This_panel)
        {
            //int Diff = index1 - index2;
            int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;

            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            if (Rectangle_Index_2 % 3 == 0)
            {
                rectangle1 = Public_Static_Variables.gatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                switch (Rectangle_Index_1)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.gatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.gatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                }
            }
            else
            {
                rectangle1 = Public_Static_Variables.gatecontainer[Gate_Index_1].Connecting_Rectangle_3;
                switch (Rectangle_Index_2)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.gatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.gatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                }
            }
            //if (index2 % 3 == 0)
            //{
            //    rectangle1 = Public_Static_Variables.Screen_Connecting_Rectangles[index2];
            //    rectangle2 = Public_Static_Variables.Screen_Connecting_Rectangles[index1];
            //}
            //else
            //{
            //    rectangle1 = Public_Static_Variables.Screen_Connecting_Rectangles[index1];
            //    rectangle2 = Public_Static_Variables.Screen_Connecting_Rectangles[index2];
            //}
            Point p1 = new Point(rectangle1.Left + RectWidthAndHeight / 2 - 3, rectangle1.Top + 2); // midpoint of first rectangle
            Point p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2); // midpoint of first rectangle
            Non_Rectangular_Control Temp_Wire = new Non_Rectangular_Control();
            Temp_Wire.Output_Point = p1;
            Temp_Wire.Input_Point = p2;
            Public_Static_Variables.wires.Add(Temp_Wire);
            This_panel.Controls.Add(Temp_Wire);
            Temp_Wire.BringToFront();
        }
        void Move_Wires()
        {
            //for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 2)
            //{
            //    Rectangle rectangle1 = new Rectangle();
            //    Rectangle rectangle2 = new Rectangle();
            //    int num1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
            //    int num2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
            //    if (num2 % 3 == 0)
            //    {
            //        rectangle1 = Public_Static_Variables.Screen_Connecting_Rectangles[num2];
            //        rectangle2 = Public_Static_Variables.Screen_Connecting_Rectangles[num1];
            //    }
            //    else
            //    {
            //        rectangle1 = Public_Static_Variables.Screen_Connecting_Rectangles[num1];
            //        rectangle2 = Public_Static_Variables.Screen_Connecting_Rectangles[num2];
            //    }
            //    Point p1 = new Point(rectangle1.Left + RectWidthAndHeight / 2 - 3, rectangle1.Top + 2); // midpoint of first rectangle
            //    Point p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2); // midpoint of first rectangle
            //    if (Public_Static_Variables.wires[i / 2].Output_Point != p1 || Public_Static_Variables.wires[i / 2].Input_Point != p2)
            //    {
            //        Public_Static_Variables.wires[i / 2].Points_Changed(p1, p2);
            //    }
            //}
        }
        
    }
}