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
        void Equalize_Rectangles(ref Rectangle Refernce_Rectangle, ref Rectangle Modified_Rectangle)
        {
            Modified_Rectangle.Location = Refernce_Rectangle.Location;
            Modified_Rectangle.Width = Refernce_Rectangle.Width;
            Modified_Rectangle.Height = Refernce_Rectangle.Height;
        }
        public static void Delete_Wire(Point output_point, Point input_point)
        {
            int index = 0;
            int Rectnagle_Index = 0;
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Rectangle rectangle3 = new Rectangle();
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.Contains(output_point) || rectangle1.Contains(input_point))
                {
                    index = i;
                    Rectnagle_Index = 1;
                    break;
                }
                else if (rectangle2.Contains(output_point) || rectangle2.Contains(input_point))
                {
                    index = i;
                    Rectnagle_Index = 2;
                    break;
                }
                else if (rectangle3.Contains(output_point) || rectangle3.Contains(input_point))
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