using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    public partial class SelectionRectangle : UserControl
    {
        
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        Rectangle Inner_Rectangle;
        public bool right = true;
        Graphics g;
        int Index_Of_First_Gate;
        int Rectangle_Of_First_Gate;
        //int Temp_Counter;
        public bool Connected = false; // a bool variable to check whether this node is connected to any line/ input/ output or not
        public SelectionRectangle()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.Width = 13;
            this.Height =13;
            Inner_Rectangle = new Rectangle();
            Inner_Rectangle.Location = new Point(4, 4);
            Inner_Rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
            this.BackColor = Color.White;
            g = this.CreateGraphics();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.FillRectangle(sb, Inner_Rectangle);
            if (right)
            {
                g.DrawLine(pen, new Point(9, this.Height / 2), new Point(this.Width, this.Height / 2));
            }
            else
            {
                g.DrawLine(pen, new Point(8, this.Height / 2), new Point(0, this.Height / 2));
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightGreen;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!this.ClientRectangle.Contains(new Point(e.X, e.Y)) && e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                p = PointToScreen(p);
                Control andgate = this.Parent;
                Control panel1 = andgate.Parent;
                p = panel1.PointToClient(MousePosition);
                int index = 0;
                int Condition = Do_My_Condition(p, ref index);
                switch (Condition)
                {
                    case 1: Public_Static_Variables.gatecontainer[index].selectionRectangle1.BackColor = Color.LightGreen;
                        break;
                    case 2: Public_Static_Variables.gatecontainer[index].selectionRectangle2.BackColor = Color.LightGreen;
                        break;
                    case 3: Public_Static_Variables.gatecontainer[index].selectionRectangle3.BackColor = Color.LightGreen;
                        break;
                    case 0: for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                        {
                            Public_Static_Variables.gatecontainer[i].selectionRectangle1.BackColor = Color.White;
                            Public_Static_Variables.gatecontainer[i].selectionRectangle2.BackColor = Color.White;
                            Public_Static_Variables.gatecontainer[i].selectionRectangle3.BackColor = Color.White;
                        }
                        break;
                }
                
                //for  (int i =1; i<=Public_Static_Variables.gatecontainer_counter*3; i++)
                //{
                //    if (Public_Static_Variables.Screen_Connecting_Rectangles[i].Contains(p))
                //    {
                //       if(i%3 == 0)
                //        {
                //            Public_Static_Variables.gatecontainer[i / 3].selectionRectangle3.BackColor = Color.LightGreen;
                //        }
                //       else if (i%3 == 1)
                //        {
                //            Public_Static_Variables.gatecontainer[i / 3 +1].selectionRectangle1.BackColor = Color.LightGreen;
                //        }
                //       else
                //        {
                //            Public_Static_Variables.gatecontainer[i / 3 + 1].selectionRectangle2.BackColor = Color.LightGreen;
                //        }
                //    }
                //    else
                //    {
                //        if (i % 3 == 0)
                //        {
                //            Public_Static_Variables.gatecontainer[i / 3].selectionRectangle3.BackColor = Color.White;
                //        }
                //        else if (i % 3 == 1)
                //        {
                //            Public_Static_Variables.gatecontainer[i / 3 + 1].selectionRectangle1.BackColor = Color.White;
                //        }
                //        else
                //        {
                //            Public_Static_Variables.gatecontainer[i / 3 + 1].selectionRectangle2.BackColor = Color.White;
                //        }
                //    }
                // }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            //bool Entered = false;
            Point p = new Point(e.X, e.Y);
            p = PointToScreen(p);
            Control andgate = this.Parent;
            Control panel1 = andgate.Parent;
            p = panel1.PointToClient(MousePosition);
            int index = 0;
            Rectangle_Of_First_Gate = Do_My_Condition(p, ref index);
            if (Rectangle_Of_First_Gate != 0)
            {
                Index_Of_First_Gate = index;
            }
            //for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter * 3; i++)
            //{
            //    if (Public_Static_Variables.Screen_Connecting_Rectangles[i].Contains(p))
            //    {
            //        Temp_Counter = i;
            //        Entered = true;
            //        break;
            //    }
            //}
            //if (!Entered)
            //    Temp_Counter = 0;
             Add_Wires_To_List();
        }

        public void Enter_Color()
        {
            this.BackColor = Color.LightBlue;
        }
        public void Leave_color()
        {
            this.BackColor = Color.White;
        }
        void Add_Wires_To_List()
        {
            if (Rectangle_Of_First_Gate != 0)
            { 
                int Current_Index;
                bool Connect_Wires = true;
                Control andgate = this.Parent;
                Control panel1 = andgate.Parent;
                Rectangle rectangle = new Rectangle();
                rectangle = this.ClientRectangle;
                rectangle = RectangleToScreen(rectangle);
                rectangle = panel1.RectangleToClient(rectangle);
                int index = 0; // the index of the gate
                int Which_Rectangle = Index_Of_This_Control(rectangle, ref index); // which rectangle in the gate
                MyPanel.Add_Wires_To_Panel(index, Which_Rectangle, Index_Of_First_Gate , Rectangle_Of_First_Gate, panel1);
                //for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter * 3; i++)
                //{   
                //    if (Public_Static_Variables.Screen_Connecting_Rectangles[i].IntersectsWith(rectangle))
                //    {

                //        Current_Index = i;
                //        if (Current_Index % 3 == 0 && Temp_Counter % 3 == 0)
                //        {
                //            MessageBox.Show("Cannot connect 2 outputs together");
                //            Connect_Wires = false;
                //        }
                //        else if (Current_Index % 3 != 0 && Temp_Counter % 3 != 0 && Current_Index / 3 != Temp_Counter / 3)
                //        {
                //            MessageBox.Show("Cannot connect 2 inputs together");
                //            Connect_Wires = false;
                //        }
                //        else
                //        {
                //            foreach (int num in Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting)
                //            {
                //                if ((Temp_Counter == num && Temp_Counter % 3 != 0) || (Current_Index == num && Current_Index % 3 != 0))
                //                {
                //                    MessageBox.Show("Cannot connect two wires to the same input");
                //                    Connect_Wires = false;
                //                    break;
                //                }
                //            }
                //        }
                //        if (Connect_Wires)
                //        {
                //            Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Current_Index);
                //            Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Temp_Counter);
                //            MyPanel.Add_Wires_To_Panel(Current_Index, Temp_Counter, panel1);
                //            this.Connected = true;
                //           if ( Current_Index%3 == 0)
                //            {
                //                Public_Static_Variables.gatecontainer[Current_Index / 3].selectionRectangle3.Connected = true;
                //            }
                //           else if (Current_Index%3 == 1)
                //            {
                //                Public_Static_Variables.gatecontainer[Current_Index / 3 + 1].selectionRectangle1.Connected = true;
                //            }
                //           else
                //            {
                //                Public_Static_Variables.gatecontainer[Current_Index / 3 + 1].selectionRectangle2.Connected = true;
                            
                //            }
                //            if (Temp_Counter % 3 == 0)
                //            {
                //                Public_Static_Variables.gatecontainer[Temp_Counter / 3].selectionRectangle3.Connected = true;
                //            }
                //            else if (Temp_Counter%3 == 1)
                //            {
                //                Public_Static_Variables.gatecontainer[Temp_Counter / 3 + 1].selectionRectangle1.Connected = true;
                //            }
                //            else
                //            {
                //                Public_Static_Variables.gatecontainer[Temp_Counter / 3 + 1].selectionRectangle2.Connected = true;
                //            }
                //            break;
                //        }
                //    }
                //}
            }
        }
        // the bext function checks whether the specified point lies in any connecting rectangle or not 
        // it returns which rectangle the point lies in and adjust the index to have the value of the index of the gate_container in the array
        // if the point doesnt lie anywhere it returbs zero
        int Do_My_Condition(Point p , ref int  index)
        {
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1.Contains(p))
                {
                    index = i;
                    return 1;
                }

                else if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2.Contains(p))
                {
                    index = i;
                    return 2;

                }
                else if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3.Contains(p))
                {
                    index = i;
                    return 3;
                }
            }
            return 0;
        }
        // a function that returns which gate this control lies in and which selection rectangle
        // the return value is the which rectangle and the index variable is the index of the gate it lies in
        int Index_Of_This_Control(Rectangle rectangle, ref int index)
        {
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1.IntersectsWith(rectangle))
                {
                    index = i;
                    return 1;
                }

                else if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2.IntersectsWith(rectangle))
                {
                    index = i;
                    return 2;
                }
                else if (Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3.IntersectsWith(rectangle))
                {
                    index = i;
                    return 3;
                }
            }
            return 0;
        }
    }
}
