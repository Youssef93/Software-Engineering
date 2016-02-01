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
        public MyPanel()
        {
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Move_Wires();
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
        public static void Delete_Wire(Point output_point, Point input_point)
        {
            for (int i = 0; i < Public_Static_Variables.wires.Count; i++)
            {
                Non_Rectangular_Control Temp_Wire = new Non_Rectangular_Control();
                Temp_Wire = Public_Static_Variables.wires.ElementAt(i);
                if (Temp_Wire.Output_Point == output_point && Temp_Wire.Input_Point == input_point)
                {
                    Control panel1 = new Control();
                    panel1 = Temp_Wire.Parent;
                    panel1.Controls.Remove(Public_Static_Variables.wires.ElementAt(i));
                    Public_Static_Variables.wires.RemoveAt(i);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i * 6, 6);
                }
            }
            int Output_Gate_Index = 0;
            int Input_Gate_Index = 0;
            int Input_Rectnagle_Index = 0;
            int Output_Gate_Type = 100;
            int Input_Gate_Type = 100;
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Rectangle rectangle3 = new Rectangle();

            for (int i =1; i<= Public_Static_Variables.gatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;
                if (rectangle3.Contains(output_point))
                {
                    Output_Gate_Type = 0;
                    Output_Gate_Index = i;
                }
                if (rectangle1.Contains(input_point))
                {
                    Input_Gate_Type = 0;
                    Input_Gate_Index = i;
                    Input_Rectnagle_Index = 1;
                }
                else if (rectangle2.Contains(input_point))
                {
                    Input_Gate_Type = 0;
                    Input_Gate_Index = i;
                    Input_Rectnagle_Index = 2;
                }
            }
            if (Output_Gate_Type != 100 && Input_Gate_Type != 100)
            {
                for (int i =1; i<= Public_Static_Variables.Notgatecontainer_counter; i++)
                {
                    rectangle1 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_1;
                    rectangle2 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_2;
                    rectangle3 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_3;
                    if (rectangle3.Contains(output_point))
                    {
                        Output_Gate_Type = 1;
                        Output_Gate_Index = i;
                    }
                    if (rectangle1.Contains(input_point))
                    {
                        Input_Gate_Type = 1;
                        Input_Gate_Index = i;
                        Input_Rectnagle_Index = 1;
                    }
                    else if (rectangle2.Contains(input_point))
                    {
                        Input_Gate_Type = 1;
                        Input_Gate_Index = i;
                        Input_Rectnagle_Index = 2;
                    }
                }
            }
            if (Output_Gate_Type == 0)
            {
                Public_Static_Variables.gatecontainer[Output_Gate_Index].selectionRectangle3.Connected = false;
            }
            else if (Output_Gate_Type == 1)
            {
                Public_Static_Variables.Notgatecontainer[Output_Gate_Index].selectionRectangle3.Connected = false;
            }
            if (Input_Gate_Type == 0)
            {
                switch (Input_Rectnagle_Index)
                {
                    case 1: Public_Static_Variables.gatecontainer[Input_Gate_Index].selectionRectangle1.Connected = false;
                        break;
                    case 2: Public_Static_Variables.gatecontainer[Input_Gate_Index].selectionRectangle2.Connected = false;
                        break;
                }
            }
            else if (Input_Gate_Type == 1)
            {
                switch (Input_Rectnagle_Index)
                {
                    case 1:
                        Public_Static_Variables.Notgatecontainer[Input_Gate_Index].selectionRectangle1.Connected = false;
                        break;
                    case 2:
                        Public_Static_Variables.Notgatecontainer[Input_Gate_Index].selectionRectangle2.Connected = false;
                        break;
                }
            }
        }
        public static void Add_Wires_To_Panel(int Gate_Type_1, int Gate_Index_1, int Rectangle_Index_1, int Gate_Type_2, int Gate_Index_2, int Rectangle_Index_2, Control This_panel)
        {
            int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Do_My_Condtiton(Gate_Type_1, Gate_Index_1, Rectangle_Index_1, Gate_Type_2, Gate_Index_2, Rectangle_Index_2, ref rectangle1,ref  rectangle2);
            if (Rectangle_Index_2 % 3 == 0)
            {
                Rectangle Temp_Rectangle = new Rectangle();
                Temp_Rectangle = rectangle1;
                rectangle1 = rectangle2;
                rectangle2 = Temp_Rectangle;
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
            for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 6)
            {
                Rectangle rectangle1 = new Rectangle();
                Rectangle rectangle2 = new Rectangle();
                int Gate_Type_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                int Gate_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i+1);
                int Rectangle_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 2);
                int Gate_Type_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3);
                int Gate_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4);
                int Rectangle_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5);
                Do_My_Condtiton(Gate_Type_1, Gate_Index_1, Rectangle_Index_1, Gate_Type_2, Gate_Index_2, Rectangle_Index_2, ref rectangle1, ref rectangle2);
                
                if (Rectangle_Index_2 % 3 == 0)
                {
                    Rectangle Temp_Rectnagle = new Rectangle();
                    Temp_Rectnagle = rectangle1;
                    rectangle1 = rectangle2;
                    rectangle2 = Temp_Rectnagle;
                }
                Point p1 = new Point(rectangle1.Left + RectWidthAndHeight / 2 - 3, rectangle1.Top + 2); // midpoint of first rectangle
                Point p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2); // midpoint of first rectangle
                if (Public_Static_Variables.wires[i / 6].Output_Point != p1 || Public_Static_Variables.wires[i / 6].Input_Point != p2)
                {
                    Public_Static_Variables.wires[i / 6].Points_Changed(p1, p2);
                }
            }
        }
        // Similar to the function "Do My COndition" in selection Rectangle
        public static void Do_My_Condtiton(int Gate_Type_1, int Gate_Index_1, int Rectangle_Index_1, int Gate_Type_2, int Gate_Index_2, int Rectangle_Index_2, ref Rectangle rectangle1, ref Rectangle rectangle2)
        {
            if (Gate_Type_1 == 0)
            {
                switch (Rectangle_Index_1)
                {
                    case 1: rectangle1 = Public_Static_Variables.gatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 2: rectangle1 = Public_Static_Variables.gatecontainer[Gate_Index_1].Connecting_Rectangle_2;
                        break;
                    case 3: rectangle1 = Public_Static_Variables.gatecontainer[Gate_Index_1].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_1 == 1)
            {
                switch (Rectangle_Index_1)
                {
                    case 1:
                        rectangle1 = Public_Static_Variables.Notgatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle1 = Public_Static_Variables.Notgatecontainer[Gate_Index_1].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle1 = Public_Static_Variables.Notgatecontainer[Gate_Index_1].Connecting_Rectangle_3;
                        break;
                }
            }
            if (Gate_Type_2 == 0)
            {
                switch (Rectangle_Index_2)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.gatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.gatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle2 = Public_Static_Variables.gatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_2 == 1)
            {
                switch (Rectangle_Index_2)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.Notgatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.Notgatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle2 = Public_Static_Variables.Notgatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                        break;
                }
            }
        }
    }
}