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
            Move_Wires();
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (Public_Static_Variables.Gate_Removed)
            {
                bool Do_While_bool = false;
                Public_Static_Variables.Gate_Removed = false;
                int current_index = Public_Static_Variables.Reset_draw_rect;
                do
                {
                    Do_While_bool = false;

                    for (int i = 0; i<Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 4)
                    {
                        int Gate_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                        int Rectnagle_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                        int Gate_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 2);
                        int Rectangle_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3);
                        if (current_index == Gate_Index_1 || current_index == Gate_Index_2)
                        {
                            Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i, 4);
                            this.Controls.Remove(Public_Static_Variables.wires[i / 4]);
                            Public_Static_Variables.wires.RemoveAt(i / 4);
                            Do_While_bool = true;
                            break;
                        }
                    }
                }
                while (Do_While_bool);

                if (this.Controls.Count == 0)
                {
                    Public_Static_Variables.gatecontainer_counter = 0;
                    Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
                    Public_Static_Variables.gatecontainer = new AndGateContainer[50]; 
                    Public_Static_Variables.gatecontainer_created = false;
                }
                Public_Static_Variables.Gate_Removed = false;
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
            int index = 0;
            int Rectnagle_Index = 0;
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1.Contains(output_point) || Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1.Contains(input_point))
                {
                    index = i;
                    Rectnagle_Index = 1;
                    break;
                }
                else if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2.Contains(output_point) || Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2.Contains(input_point))
                {
                    index = i;
                    Rectnagle_Index = 2;
                    break;
                }
                else if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3.Contains(output_point) || Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3.Contains(input_point))
                {
                    index = i;
                    Rectnagle_Index = 3;
                    break;
                }
            }
            for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 4)
            {
                int Gate_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                int Rectangle_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                int Gate_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 2);
                int Rectangle_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3);

                if ((Gate_Index_1 == index && Rectnagle_Index == Rectangle_Index_1) || (Gate_Index_2==index && Rectangle_Index_2== Rectnagle_Index))
                {
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i, 4);
                    Control panel1 = Public_Static_Variables.wires[i / 4].Parent;
                    panel1.Controls.Remove(Public_Static_Variables.wires[i / 4]);
                    Public_Static_Variables.wires.RemoveAt(i / 4);
                    switch (Rectangle_Index_1)
                    {
                        case 1: Public_Static_Variables.gatecontainer[Gate_Index_1].selectionRectangle1.Connected = false;
                            break;
                        case 2: Public_Static_Variables.gatecontainer[Gate_Index_1].selectionRectangle2.Connected = false;
                            break;
                        case 3: Public_Static_Variables.gatecontainer[Gate_Index_1].selectionRectangle3.Connected = false;
                            break;
                    }
                    switch (Rectangle_Index_2)
                    {
                        case 1:
                            Public_Static_Variables.gatecontainer[Gate_Index_2].selectionRectangle1.Connected = false;
                            break;
                        case 2:
                            Public_Static_Variables.gatecontainer[Gate_Index_2].selectionRectangle2.Connected = false;
                            break;
                        case 3:
                            Public_Static_Variables.gatecontainer[Gate_Index_2].selectionRectangle3.Connected = false;
                            break;
                    }
                    break;
                }
            }
        }
        public static void Add_Wires_To_Panel(int Gate_Index_1, int Rectangle_Index_1, int Gate_Index_2, int Rectangle_Index_2,Control This_panel)
        {
    
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
            for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 4)
            {
                Rectangle rectangle1 = new Rectangle();
                Rectangle rectangle2 = new Rectangle();
                int Gate_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                int Rectangle_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                int Gate_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i+2);
                int Rectangle_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3);

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
                Point p1 = new Point(rectangle1.Left + RectWidthAndHeight / 2 - 3, rectangle1.Top + 2); // midpoint of first rectangle
                Point p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2); // midpoint of first rectangle
                if (Public_Static_Variables.wires[i / 4].Output_Point != p1 || Public_Static_Variables.wires[i / 4].Input_Point != p2)
                {
                    Public_Static_Variables.wires[i / 4].Points_Changed(p1, p2);
                }
            }
        }
        
    }
}