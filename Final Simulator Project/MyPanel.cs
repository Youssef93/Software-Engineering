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
        bool Movewires = false; // Prevents bug on resizing panel
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
            foreach (Control Gate in this.Controls)
            {
                if (Gate.GetType()!= typeof(Non_Rectangular_Control) && (Gate.Right >= this.Width) || (Gate.Bottom >=this.Height))
                {
                    Random random = new Random();
                    Gate.Location = new Point(random.Next(this.Width - 200, this.Width-100), Gate.Location.Y);
                    Movewires = true;
                }
            }
            Move_Wires();
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
           if (Public_Static_Variables.Logic_Calculated)
            {
                foreach (Output Temp_Output in Public_Static_Variables.Outputs_List)
                    Temp_Output.Paint_Output(2);
            }
        }
        public static void Delete_Wire(Point output_point, Point input_point)
        {
            Control panel1 = new Control();
            for (int i = 0; i < Public_Static_Variables.wires.Count; i++)
            {
                Non_Rectangular_Control Temp_Wire = new Non_Rectangular_Control();
                Temp_Wire = Public_Static_Variables.wires.ElementAt(i);
                if (Temp_Wire.Output_Point == output_point && Temp_Wire.Input_Point == input_point)
                {
                    
                    panel1 = Temp_Wire.Parent;
                    panel1.Controls.Remove(Public_Static_Variables.wires.ElementAt(i));
                    Public_Static_Variables.wires.RemoveAt(i);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i * 6, 6);
                }
            }
            Check_Connection(panel1);
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
            Check_Connection(This_panel);
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
                else if (Movewires)
                {
                    Public_Static_Variables.wires[i / 6].Points_Changed(p1, p2);
                }
            }
            Movewires = false;
            Check_Connection(this);
        }
        // The next function is a function that goes through all gates and checks whether their nodes
        // are connected or not
        public static void Check_Connection (Control panel1)
        {
            int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Rectangle rectangle3 = new Rectangle();
            Point p1 = new Point();
            Point p2 = new Point();
            Point p3 = new Point();
            if (Public_Static_Variables.wires.Count == 0)
            {
                for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                {
                    Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected = false;
                    Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected = false;
                    Public_Static_Variables.gatecontainer[i].selectionRectangle3.Connected = false;
                }
                for (int i = 1; i <= Public_Static_Variables.Nandgatecontainer_counter; i++)
                {
                    Public_Static_Variables.Nandgatecontainer[i].selectionRectangle1.Connected = false;
                    Public_Static_Variables.Nandgatecontainer[i].selectionRectangle2.Connected = false;
                    Public_Static_Variables.Nandgatecontainer[i].selectionRectangle3.Connected = false;
                }
                for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter; i++)
                {
                    Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.Connected = false;
                    Public_Static_Variables.Orgatecontainer[i].selectionRectangle2.Connected = false;
                    Public_Static_Variables.Orgatecontainer[i].selectionRectangle3.Connected = false;
                }
                for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter; i++)
                {
                    Public_Static_Variables.Norgatecontainer[i].selectionRectangle1.Connected = false;
                    Public_Static_Variables.Norgatecontainer[i].selectionRectangle2.Connected = false;
                    Public_Static_Variables.Norgatecontainer[i].selectionRectangle3.Connected = false;
                }
                for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
                {
                    Public_Static_Variables.XOrgatecontainer[i].selectionRectangle1.Connected = false;
                    Public_Static_Variables.XOrgatecontainer[i].selectionRectangle2.Connected = false;
                    Public_Static_Variables.XOrgatecontainer[i].selectionRectangle3.Connected = false;
                }
                for (int i = 1; i <= Public_Static_Variables.Notgatecontainer_counter; i++)
                {
                    Public_Static_Variables.Notgatecontainer[i].selectionRectangle1.Connected = false;
                    Public_Static_Variables.Notgatecontainer[i].selectionRectangle3.Connected = false;
                }
            }
            else
            {
                for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                    {
                        bool Rectangle1_Bool = false;
                        bool Rectangle2_Bool = false;
                        bool Rectangle3_Bool = false;
                        foreach (Non_Rectangular_Control wire in Public_Static_Variables.wires)
                        {
                            rectangle1 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                            rectangle2 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                            rectangle3 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;
                            p3 = new Point(rectangle3.Left + RectWidthAndHeight / 2 - 3, rectangle3.Top + 2);
                            p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2);
                            p1 = new Point(rectangle1.Left + 2, rectangle1.Top + RectWidthAndHeight / 2 + 2);
                            if (wire.Output_Point == p3)
                            {
                                Public_Static_Variables.gatecontainer[i].selectionRectangle3.Connected = true;
                                Rectangle3_Bool = true;
                            }
                            else if (!Rectangle3_Bool)
                                Public_Static_Variables.gatecontainer[i].selectionRectangle3.Connected = false;
                            if (wire.Input_Point == p1)
                            {
                                Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected = true;
                                Rectangle1_Bool = true;
                            }
                            else if (!Rectangle1_Bool)
                                Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected = false;
                            if (wire.Input_Point == p2)
                            {
                                Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected = true;
                                Rectangle2_Bool = true;
                            }
                            else if (!Rectangle2_Bool)
                                Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected = false;
                        }
                    }
                }
                for (int i = 1; i <= Public_Static_Variables.Nandgatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.Nandgatecontainer[i]))
                    {
                        bool Rectangle1_Bool = false;
                        bool Rectangle2_Bool = false;
                        bool Rectangle3_Bool = false;
                        foreach (Non_Rectangular_Control wire in Public_Static_Variables.wires)
                        {
                            rectangle1 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_1;
                            rectangle2 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_2;
                            rectangle3 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_3;
                            p3 = new Point(rectangle3.Left + RectWidthAndHeight / 2 - 3, rectangle3.Top + 2);
                            p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2);
                            p1 = new Point(rectangle1.Left + 2, rectangle1.Top + RectWidthAndHeight / 2 + 2);
                            if (wire.Output_Point == p3)
                            {
                                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle3.Connected = true;
                                Rectangle3_Bool = true;
                            }
                            else if (!Rectangle3_Bool)
                                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle3.Connected = false;
                            if (wire.Input_Point == p1)
                            {
                                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle1.Connected = true;
                                Rectangle1_Bool = true;
                            }
                            else if (!Rectangle1_Bool)
                                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle1.Connected = false;
                            if (wire.Input_Point == p2)
                            {
                                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle2.Connected = true;
                                Rectangle2_Bool = true;
                            }
                            else if (!Rectangle2_Bool)
                                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle2.Connected = false;
                        }
                    }
                }
                for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.Orgatecontainer[i]))
                    {
                        bool Rectangle1_Bool = false;
                        bool Rectangle2_Bool = false;
                        bool Rectangle3_Bool = false;
                        foreach (Non_Rectangular_Control wire in Public_Static_Variables.wires)
                        {
                            rectangle1 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_1;
                            rectangle2 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_2;
                            rectangle3 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_3;
                            p3 = new Point(rectangle3.Left + RectWidthAndHeight / 2 - 3, rectangle3.Top + 2);
                            p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2);
                            p1 = new Point(rectangle1.Left + 2, rectangle1.Top + RectWidthAndHeight / 2 + 2);
                            if (wire.Output_Point == p3)
                            {
                                Public_Static_Variables.Orgatecontainer[i].selectionRectangle3.Connected = true;
                                Rectangle3_Bool = true;
                            }
                            else if (!Rectangle3_Bool)
                                Public_Static_Variables.Orgatecontainer[i].selectionRectangle3.Connected = false;
                            if (wire.Input_Point == p1)
                            {
                                Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.Connected = true;
                                Rectangle1_Bool = true;
                            }
                            else if (!Rectangle1_Bool)
                                Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.Connected = false;
                            if (wire.Input_Point == p2)
                            {
                                Public_Static_Variables.Orgatecontainer[i].selectionRectangle2.Connected = true;
                                Rectangle2_Bool = true;
                            }
                            else if (!Rectangle2_Bool)
                                Public_Static_Variables.Orgatecontainer[i].selectionRectangle2.Connected = false;
                        }
                    }
                }

                for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.Norgatecontainer[i]))
                    {
                        bool Rectangle1_Bool = false;
                        bool Rectangle2_Bool = false;
                        bool Rectangle3_Bool = false;
                        foreach (Non_Rectangular_Control wire in Public_Static_Variables.wires)
                        {
                            rectangle1 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_1;
                            rectangle2 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_2;
                            rectangle3 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_3;
                            p3 = new Point(rectangle3.Left + RectWidthAndHeight / 2 - 3, rectangle3.Top + 2);
                            p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2);
                            p1 = new Point(rectangle1.Left + 2, rectangle1.Top + RectWidthAndHeight / 2 + 2);
                            if (wire.Output_Point == p3)
                            {
                                Public_Static_Variables.Norgatecontainer[i].selectionRectangle3.Connected = true;
                                Rectangle3_Bool = true;
                            }
                            else if (!Rectangle3_Bool)
                                Public_Static_Variables.Norgatecontainer[i].selectionRectangle3.Connected = false;
                            if (wire.Input_Point == p1)
                            {
                                Public_Static_Variables.Norgatecontainer[i].selectionRectangle1.Connected = true;
                                Rectangle1_Bool = true;
                            }
                            else if (!Rectangle1_Bool)
                                Public_Static_Variables.Norgatecontainer[i].selectionRectangle1.Connected = false;
                            if (wire.Input_Point == p2)
                            {
                                Public_Static_Variables.Norgatecontainer[i].selectionRectangle2.Connected = true;
                                Rectangle2_Bool = true;
                            }
                            else if (!Rectangle2_Bool)
                                Public_Static_Variables.Norgatecontainer[i].selectionRectangle2.Connected = false;
                        }
                    }
                }
                for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.XOrgatecontainer[i]))
                    {
                        bool Rectangle1_Bool = false;
                        bool Rectangle2_Bool = false;
                        bool Rectangle3_Bool = false;
                        foreach (Non_Rectangular_Control wire in Public_Static_Variables.wires)
                        {
                            rectangle1 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_1;
                            rectangle2 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_2;
                            rectangle3 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_3;
                            p3 = new Point(rectangle3.Left + RectWidthAndHeight / 2 - 3, rectangle3.Top + 2);
                            p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2);
                            p1 = new Point(rectangle1.Left + 2, rectangle1.Top + RectWidthAndHeight / 2 + 2);
                            if (wire.Output_Point == p3)
                            {
                                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle3.Connected = true;
                                Rectangle3_Bool = true;
                            }
                            else if (!Rectangle3_Bool)
                                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle3.Connected = false;
                            if (wire.Input_Point == p1)
                            {
                                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle1.Connected = true;
                                Rectangle1_Bool = true;
                            }
                            else if (!Rectangle1_Bool)
                                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle1.Connected = false;
                            if (wire.Input_Point == p2)
                            {
                                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle2.Connected = true;
                                Rectangle2_Bool = true;
                            }
                            else if (!Rectangle2_Bool)
                                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle2.Connected = false;
                        }
                    }
                }
                for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.XNorgatecontainer[i]))
                    {
                        bool Rectangle1_Bool = false;
                        bool Rectangle2_Bool = false;
                        bool Rectangle3_Bool = false;
                        foreach (Non_Rectangular_Control wire in Public_Static_Variables.wires)
                        {
                            rectangle1 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_1;
                            rectangle2 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_2;
                            rectangle3 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_3;
                            p3 = new Point(rectangle3.Left + RectWidthAndHeight / 2 - 3, rectangle3.Top + 2);
                            p2 = new Point(rectangle2.Left + 2, rectangle2.Top + RectWidthAndHeight / 2 + 2);
                            p1 = new Point(rectangle1.Left + 2, rectangle1.Top + RectWidthAndHeight / 2 + 2);
                            if (wire.Output_Point == p3)
                            {
                                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle3.Connected = true;
                                Rectangle3_Bool = true;
                            }
                            else if (!Rectangle3_Bool)
                                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle3.Connected = false;
                            if (wire.Input_Point == p1)
                            {
                                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle1.Connected = true;
                                Rectangle1_Bool = true;
                            }
                            else if (!Rectangle1_Bool)
                                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle1.Connected = false;
                            if (wire.Input_Point == p2)
                            {
                                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle2.Connected = true;
                                Rectangle2_Bool = true;
                            }
                            else if (!Rectangle2_Bool)
                                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle2.Connected = false;
                        }
                    }
                }
                for (int i = 1; i <= Public_Static_Variables.Notgatecontainer_counter; i++)
                {
                    if (panel1.Controls.Contains(Public_Static_Variables.Notgatecontainer[i]))
                    {
                        bool Rectangle1_Bool = false;
                        bool Rectangle3_Bool = false;
                        foreach (Non_Rectangular_Control wire in Public_Static_Variables.wires)
                        {
                            rectangle1 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_1;
                            rectangle3 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_3;

                            p3 = new Point(rectangle3.Left + RectWidthAndHeight / 2 - 3, rectangle3.Top + 2);
                            p1 = new Point(rectangle1.Left + 2, rectangle1.Top + RectWidthAndHeight / 2 + 2);

                            if (wire.Output_Point == p3)
                            {
                                Public_Static_Variables.Notgatecontainer[i].selectionRectangle3.Connected = true;
                                Rectangle3_Bool = true;
                            }
                            else if (!Rectangle3_Bool)
                                Public_Static_Variables.Notgatecontainer[i].selectionRectangle3.Connected = false;
                            if (wire.Input_Point == p1)
                            {
                                Public_Static_Variables.Notgatecontainer[i].selectionRectangle1.Connected = true;
                                Rectangle1_Bool = true;
                            }
                            else if (!Rectangle1_Bool)
                                Public_Static_Variables.Notgatecontainer[i].selectionRectangle1.Connected = false;
                        }
                    }
                }
            }
            foreach (INPUT Temp_input in Public_Static_Variables.Inputs_List)
            {
                if (Temp_input.Gate_Type == 0)
                {
                    switch (Temp_input.Rectangle_Index)
                    {
                        case 1: Public_Static_Variables.gatecontainer[Temp_input.Gate_Index].selectionRectangle1.Connected = true;
                            break;
                        case 2: Public_Static_Variables.gatecontainer[Temp_input.Gate_Index].selectionRectangle2.Connected = true;
                            break;
                    }
                }
                else if (Temp_input.Gate_Type == 1)
                {
                    switch (Temp_input.Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.Nandgatecontainer[Temp_input.Gate_Index].selectionRectangle1.Connected = true;
                            break;
                        case 2:
                            Public_Static_Variables.Nandgatecontainer[Temp_input.Gate_Index].selectionRectangle2.Connected = true;
                            break;
                    }
                }
                else if (Temp_input.Gate_Type == 2)
                {
                    switch (Temp_input.Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.Orgatecontainer[Temp_input.Gate_Index].selectionRectangle1.Connected = true;
                            break;
                        case 2:
                            Public_Static_Variables.Orgatecontainer[Temp_input.Gate_Index].selectionRectangle2.Connected = true;
                            break;
                    }
                }
                else if (Temp_input.Gate_Type == 6)
                {
                    Public_Static_Variables.Norgatecontainer[Temp_input.Gate_Index].selectionRectangle1.Connected = true;
                }
                else if (Temp_input.Gate_Type == 3)
                {
                    switch (Temp_input.Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.Norgatecontainer[Temp_input.Gate_Index].selectionRectangle1.Connected = true;
                            break;
                        case 2:
                            Public_Static_Variables.Norgatecontainer[Temp_input.Gate_Index].selectionRectangle2.Connected = true;
                            break;
                    }
                }
                else if (Temp_input.Gate_Type == 4)
                {
                    switch (Temp_input.Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.XOrgatecontainer[Temp_input.Gate_Index].selectionRectangle1.Connected = true;
                            break;
                        case 2:
                            Public_Static_Variables.XOrgatecontainer[Temp_input.Gate_Index].selectionRectangle2.Connected = true;
                            break;
                    }
                }
                else if (Temp_input.Gate_Type == 5)
                {
                    switch (Temp_input.Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.XNorgatecontainer[Temp_input.Gate_Index].selectionRectangle1.Connected = true;
                            break;
                        case 2:
                            Public_Static_Variables.XNorgatecontainer[Temp_input.Gate_Index].selectionRectangle2.Connected = true;
                            break;
                    }
                }
            }
            foreach (Output Temp_Output in Public_Static_Variables.Outputs_List)
            {
                switch (Temp_Output.Gate_Type)
                {
                    case 0: Public_Static_Variables.gatecontainer[Temp_Output.Gate_Index].selectionRectangle3.Connected = true;
                        break;
                    case 1: Public_Static_Variables.Nandgatecontainer[Temp_Output.Gate_Index].selectionRectangle3.Connected = true;
                        break;
                    case 2: Public_Static_Variables.Orgatecontainer[Temp_Output.Gate_Index].selectionRectangle3.Connected = true;
                        break;
                    case 3: Public_Static_Variables.Norgatecontainer[Temp_Output.Gate_Index].selectionRectangle3.Connected = true;
                        break;
                    case 4: Public_Static_Variables.XOrgatecontainer[Temp_Output.Gate_Index].selectionRectangle3.Connected = true;
                        break;
                    case 5: Public_Static_Variables.XNorgatecontainer[Temp_Output.Gate_Index].selectionRectangle3.Connected = true;
                        break;
                    case 6: Public_Static_Variables.Notgatecontainer[Temp_Output.Gate_Index].selectionRectangle3.Connected = true;
                        break;
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
                        rectangle1 = Public_Static_Variables.Nandgatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle1 = Public_Static_Variables.Nandgatecontainer[Gate_Index_1].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle1 = Public_Static_Variables.Nandgatecontainer[Gate_Index_1].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_1 == 2)
            {
                switch (Rectangle_Index_1)
                {
                    case 1:
                        rectangle1 = Public_Static_Variables.Orgatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle1 = Public_Static_Variables.Orgatecontainer[Gate_Index_1].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle1 = Public_Static_Variables.Orgatecontainer[Gate_Index_1].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_1 == 6)
            {
                switch (Rectangle_Index_1)
                {
                    case 1:
                        rectangle1 = Public_Static_Variables.Notgatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 3:
                        rectangle1 = Public_Static_Variables.Notgatecontainer[Gate_Index_1].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_1 == 3)
            {
                switch (Rectangle_Index_1)
                {
                    case 1:
                        rectangle1 = Public_Static_Variables.Norgatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle1 = Public_Static_Variables.Norgatecontainer[Gate_Index_1].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle1 = Public_Static_Variables.Norgatecontainer[Gate_Index_1].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_1 == 4)
            {
                switch (Rectangle_Index_1)
                {
                    case 1:
                        rectangle1 = Public_Static_Variables.XOrgatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle1 = Public_Static_Variables.XOrgatecontainer[Gate_Index_1].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle1 = Public_Static_Variables.XOrgatecontainer[Gate_Index_1].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_1 == 5)
            {
                switch (Rectangle_Index_1)
                {
                    case 1:
                        rectangle1 = Public_Static_Variables.XNorgatecontainer[Gate_Index_1].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle1 = Public_Static_Variables.XNorgatecontainer[Gate_Index_1].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle1 = Public_Static_Variables.XNorgatecontainer[Gate_Index_1].Connecting_Rectangle_3;
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
                        rectangle2 = Public_Static_Variables.Nandgatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.Nandgatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle2 = Public_Static_Variables.Nandgatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_2 == 2)
            {
                switch (Rectangle_Index_2)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.Orgatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.Orgatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle2 = Public_Static_Variables.Orgatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_2 == 6)
            {
                switch (Rectangle_Index_2)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.Notgatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;  
                    case 3:
                        rectangle2 = Public_Static_Variables.Notgatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_2 == 3)
            {
                switch (Rectangle_Index_2)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.Norgatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.Norgatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle2 = Public_Static_Variables.Norgatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_2 == 4)
            {
                switch (Rectangle_Index_2)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.XOrgatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.XOrgatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle2 = Public_Static_Variables.XOrgatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                        break;
                }
            }
            else if (Gate_Type_2 == 5)
            {
                switch (Rectangle_Index_2)
                {
                    case 1:
                        rectangle2 = Public_Static_Variables.XNorgatecontainer[Gate_Index_2].Connecting_Rectangle_1;
                        break;
                    case 2:
                        rectangle2 = Public_Static_Variables.XNorgatecontainer[Gate_Index_2].Connecting_Rectangle_2;
                        break;
                    case 3:
                        rectangle2 = Public_Static_Variables.XNorgatecontainer[Gate_Index_2].Connecting_Rectangle_3;
                        break;
                }
            }
        }
    }
}