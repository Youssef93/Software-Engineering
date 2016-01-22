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
    public partial class And_SelectionRectangle : UserControl
    {
        
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        Rectangle Inner_Rectangle;
        public bool right = true;
        Graphics g;
        int Index_Of_First_Gate;
        int Rectangle_Of_First_Gate;
        //int Temp_Counter;
        public bool Connected = false; // a bool variable to check whether this node is connected to any line/ input/ output or not
        public And_SelectionRectangle()
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
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.White;
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
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            p = PointToScreen(p);
            Control andgate = this.Parent;
            Control panel1 = andgate.Parent;
            p = panel1.PointToClient(MousePosition);
            int index = 0;
            Rectangle_Of_First_Gate = Do_My_Condition(p, ref index);
            if (Rectangle_Of_First_Gate != 0)
                Index_Of_First_Gate = index; 

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
                bool Connect_Wires = true;
                Control andgate = this.Parent;
                Control panel1 = andgate.Parent;
                Rectangle rectangle = new Rectangle();
                rectangle = this.ClientRectangle;
                rectangle = RectangleToScreen(rectangle);
                rectangle = panel1.RectangleToClient(rectangle);
                int index = 0; // the index of the gate
                int Which_Rectangle = Index_Of_This_Control(rectangle, ref index); // which rectangle in the gate

                if (Which_Rectangle != 3 && Rectangle_Of_First_Gate != 3)
                {
                    MessageBox.Show("Cannot connect two inputs togther");
                    Connect_Wires = false;
                }
                else if (Which_Rectangle == 3 && Rectangle_Of_First_Gate == 3)
                {
                    MessageBox.Show("Cannot connect two outputs togther");
                    Connect_Wires = false;
                }
                else if (Which_Rectangle != 3)
                {
                    if (Which_Rectangle == 1 && Public_Static_Variables.gatecontainer[index].selectionRectangle1.Connected)
                    {
                        MessageBox.Show("Cannot connect two inputs to the same node");
                        Connect_Wires = false;
                    }
                    else if (Which_Rectangle == 2 && Public_Static_Variables.gatecontainer[index].selectionRectangle2.Connected)
                    {
                        MessageBox.Show("Cannot connect two inputs to the same node");
                        Connect_Wires = false;
                    }

                }
                else if (Rectangle_Of_First_Gate != 3)
                {
                    if (Rectangle_Of_First_Gate == 1 && Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
                    {
                        MessageBox.Show("Cannot connect two inputs to the same node");
                        Connect_Wires = false;
                    }
                    else if (Rectangle_Of_First_Gate == 2 && Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
                    {
                        MessageBox.Show("Cannot connect two inputs to the same node");
                        Connect_Wires = false;
                    }

                }
                else if (index == Index_Of_First_Gate && Rectangle_Of_First_Gate == Which_Rectangle)
                    Connect_Wires = false;
                if (Connect_Wires)
                {
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
                    this.Connected = true;
                    switch (Rectangle_Of_First_Gate)
                    {
                        case 1:
                            Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected = true;
                            break;
                        case 2:
                            Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected = true;
                            break;
                        case 3:
                            Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle3.Connected = true;
                            break;
                    }
                    MyPanel.Add_Wires_To_Panel(index, Which_Rectangle, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                }
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
