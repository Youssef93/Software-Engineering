using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
    class SelectionRectangle : UserControl
    {
        protected int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        protected Rectangle Inner_Rectangle;
        protected Graphics g;
        protected int Index_Of_First_Gate;
        protected int Rectangle_Of_First_Gate;
        protected Connection_State Gate_Connected;
        // The enumeration object that decides which type of gate this control is connected to
        protected enum Connection_State : int
        {
            And = 0, Nand = 1, Or = 2, Nor = 3, XOr = 4, XNor = 5, Not = 6
        }
        //not implemeted functions :
        //  Paint ,AddWires, MouseUp, Parent back color changed
        protected override void OnLoad(EventArgs e)
        {
            this.Width = 13;
            this.Height = 13;
            Inner_Rectangle = new Rectangle();
            Inner_Rectangle.Location = new Point(4, 4);
            Inner_Rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
            this.BackColor = Color.White;
            g = this.CreateGraphics();
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
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.White;
        }
        // the next function checks for mouse position and returns :
        // 1- Which type of gate the mouse is at (Connection_STate)... 2- The index of this gate (index)
        // 2- The index of which rectangle it's on (return value)
        // for loops for the rest of the gates should be added
        // also if the mouse position is at any rectangle it changes its background color immediately
        protected int Do_My_Condition(Point p, ref int index)
        {
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Rectangle rectangle3 = new Rectangle();
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;

                // The next block is to set all background colors to white, if the mouse positions is at any gate it'll change to green in the if condition
                Public_Static_Variables.gatecontainer[i].selectionRectangle1.BackColor = Color.White;
                Public_Static_Variables.gatecontainer[i].selectionRectangle2.BackColor = Color.White;
                Public_Static_Variables.gatecontainer[i].selectionRectangle3.BackColor = Color.White;
                if (rectangle1.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.And;
                    Public_Static_Variables.gatecontainer[i].selectionRectangle1.BackColor = Color.LightGreen;
                    return 1;

                }
                else if (rectangle2.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.And;
                    Public_Static_Variables.gatecontainer[i].selectionRectangle2.BackColor = Color.LightGreen;
                    return 2;

                }
                else if (rectangle3.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.And;
                    Public_Static_Variables.gatecontainer[i].selectionRectangle3.BackColor = Color.LightGreen;
                    return 3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Nandgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_3;

                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle1.BackColor = Color.White;
                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle2.BackColor = Color.White;
                Public_Static_Variables.Nandgatecontainer[i].selectionRectangle3.BackColor = Color.White;
                if (rectangle1.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Nand;
                    Public_Static_Variables.Nandgatecontainer[i].selectionRectangle1.BackColor = Color.LightGreen;
                    return 1;
                }

                else if (rectangle2.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Nand;
                    Public_Static_Variables.Nandgatecontainer[i].selectionRectangle2.BackColor = Color.LightGreen;
                    return 2;

                }
                else if (rectangle3.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Nand;
                    Public_Static_Variables.Nandgatecontainer[i].selectionRectangle3.BackColor = Color.LightGreen;
                    return 3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_3;

                Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.BackColor = Color.White;
                Public_Static_Variables.Orgatecontainer[i].selectionRectangle2.BackColor = Color.White;
                Public_Static_Variables.Orgatecontainer[i].selectionRectangle3.BackColor = Color.White;
                if (rectangle1.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Or;
                    Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.BackColor = Color.LightGreen;
                    return 1;
                }

                else if (rectangle2.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Or;
                    Public_Static_Variables.Orgatecontainer[i].selectionRectangle2.BackColor = Color.LightGreen;
                    return 2;

                }
                else if (rectangle3.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Or;
                    Public_Static_Variables.Orgatecontainer[i].selectionRectangle3.BackColor = Color.LightGreen;
                    return 3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_3;

                Public_Static_Variables.Norgatecontainer[i].selectionRectangle1.BackColor = Color.White;
                Public_Static_Variables.Norgatecontainer[i].selectionRectangle2.BackColor = Color.White;
                Public_Static_Variables.Norgatecontainer[i].selectionRectangle3.BackColor = Color.White;
                if (rectangle1.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Nor;
                    Public_Static_Variables.Norgatecontainer[i].selectionRectangle1.BackColor = Color.LightGreen;
                    return 1;
                }

                else if (rectangle2.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Nor;
                    Public_Static_Variables.Norgatecontainer[i].selectionRectangle2.BackColor = Color.LightGreen;
                    return 2;

                }
                else if (rectangle3.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Nor;
                    Public_Static_Variables.Norgatecontainer[i].selectionRectangle3.BackColor = Color.LightGreen;
                    return 3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Notgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_1;
                rectangle3 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_3;

                Public_Static_Variables.Notgatecontainer[i].selectionRectangle1.BackColor = Color.White;
                Public_Static_Variables.Notgatecontainer[i].selectionRectangle3.BackColor = Color.White;
                if (rectangle1.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Not;
                    Public_Static_Variables.Notgatecontainer[i].selectionRectangle1.BackColor = Color.LightGreen;
                    return 1;
                }
                else if (rectangle3.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.Not;
                    Public_Static_Variables.Notgatecontainer[i].selectionRectangle3.BackColor = Color.LightGreen;
                    return 3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_3;

                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle1.BackColor = Color.White;
                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle2.BackColor = Color.White;
                Public_Static_Variables.XOrgatecontainer[i].selectionRectangle3.BackColor = Color.White;
                if (rectangle1.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.XOr;
                    Public_Static_Variables.XOrgatecontainer[i].selectionRectangle1.BackColor = Color.LightGreen;
                    return 1;
                }

                else if (rectangle2.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.XOr;
                    Public_Static_Variables.XOrgatecontainer[i].selectionRectangle2.BackColor = Color.LightGreen;
                    return 2;

                }
                else if (rectangle3.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.XOr;
                    Public_Static_Variables.XOrgatecontainer[i].selectionRectangle3.BackColor = Color.LightGreen;
                    return 3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_3;

                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle1.BackColor = Color.White;
                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle2.BackColor = Color.White;
                Public_Static_Variables.XNorgatecontainer[i].selectionRectangle3.BackColor = Color.White;
                if (rectangle1.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.XNor;
                    Public_Static_Variables.XNorgatecontainer[i].selectionRectangle1.BackColor = Color.LightGreen;
                    return 1;
                }

                else if (rectangle2.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.XNor;
                    Public_Static_Variables.XNorgatecontainer[i].selectionRectangle2.BackColor = Color.LightGreen;
                    return 2;

                }
                else if (rectangle3.Contains(p))
                {
                    index = i;
                    Gate_Connected = Connection_State.XNor;
                    Public_Static_Variables.XNorgatecontainer[i].selectionRectangle3.BackColor = Color.LightGreen;
                    return 3;
                }
            }
            return 0;
        }
        // a function that returns which gate this control lies in and which selection rectangle
        // the return value is the which rectangle and the index variable is the index of the gate it lies in
        protected int Index_Of_This_Control(Rectangle rectangle, ref int index, int Gate_State)
        {
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Rectangle rectangle3 = new Rectangle();
            // Gate_State is an object sent from the derieved control idicating which type it is
            // and is zero (like the enumeration object) , etc
            if (Gate_State == 0)
            {
                for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                {
                    rectangle1 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                    rectangle2 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                    rectangle3 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;
                    if (rectangle1.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 1;
                    }

                    else if (rectangle2.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 2;
                    }
                    else if (rectangle3.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 3;
                    }
                }
                return 0;
            }
            else if (Gate_State == 1)
            {

                for (int i = 1; i <= Public_Static_Variables.Nandgatecontainer_counter; i++)
                {
                    rectangle1 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_1;
                    rectangle2 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_2;
                    rectangle3 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_3;
                    if (rectangle1.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 1;
                    }

                    else if (rectangle2.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 2;
                    }
                    else if (rectangle3.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 3;
                    }
                }
                return 0;
            }
            else if (Gate_State == 2)
            {
                for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter; i++)
                {
                    rectangle1 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_1;
                    rectangle2 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_2;
                    rectangle3 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_3;
                    if (rectangle1.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 1;
                    }

                    else if (rectangle2.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 2;
                    }
                    else if (rectangle3.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 3;
                    }
                }
                return 0;
            }
            else if (Gate_State == 3)
            {
                for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter; i++)
                {
                    rectangle1 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_1;
                    rectangle2 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_2;
                    rectangle3 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_3;
                    if (rectangle1.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 1;
                    }

                    else if (rectangle2.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 2;
                    }
                    else if (rectangle3.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 3;
                    }
                }
                return 0;
            }
            else if (Gate_State == 4)
            {
                for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
                {
                    rectangle1 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_1;
                    rectangle2 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_2;
                    rectangle3 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_3;
                    if (rectangle1.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 1;
                    }

                    else if (rectangle2.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 2;
                    }
                    else if (rectangle3.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 3;
                    }
                }
                return 0;
            }
            else if (Gate_State == 5)
            {
                for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter; i++)
                {
                    rectangle1 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_1;
                    rectangle2 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_2;
                    rectangle3 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_3;
                    if (rectangle1.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 1;
                    }

                    else if (rectangle2.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 2;
                    }
                    else if (rectangle3.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 3;
                    }
                }
                return 0;
            }
            else if (Gate_State == 6)
            {
                for (int i = 1; i <= Public_Static_Variables.Notgatecontainer_counter; i++)
                {
                    rectangle1 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_1;
                    rectangle3 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_3;
                    if (rectangle1.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 1;
                    }
                    else if (rectangle3.IntersectsWith(rectangle))
                    {
                        index = i;
                        return 3;
                    }
                }
                return 0;
            }
            else return 0;
        }
        protected void Add_Wires_To_list(int Gate_Type, ref bool Add_Wire)
        {
            bool Connect_Wires = true;
            Control andgate = this.Parent;
            Control panel1 = andgate.Parent;
            Rectangle rectangle = new Rectangle();
            rectangle = this.ClientRectangle;
            rectangle = RectangleToScreen(rectangle);
            rectangle = panel1.RectangleToClient(rectangle);
            int index = 0; // the index of the gate

            // value here is modified for each gate
            int Which_Rectangle = Index_Of_This_Control(rectangle, ref index, Gate_Type); // which rectangle in this gate

            if (Which_Rectangle != 3 && Rectangle_Of_First_Gate != 3)
            {
                MessageBox.Show("Cannot connect two inputs togther");
                Connect_Wires = false;
                Add_Wire = false;
            }
            else if (Which_Rectangle == 3 && Rectangle_Of_First_Gate == 3)
            {
                MessageBox.Show("Cannot connect two outputs togther");
                Connect_Wires = false;
                Add_Wire = false;
            }
            // values change here for each gate 
            else if (Which_Rectangle != 3)
            {
                switch (Gate_Type)
                {
                    case 0:
                        if (Which_Rectangle == 1 && Public_Static_Variables.gatecontainer[index].selectionRectangle1.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        else if (Which_Rectangle == 2 && Public_Static_Variables.gatecontainer[index].selectionRectangle2.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        break;
                    case 1:
                        if (Which_Rectangle == 1 && Public_Static_Variables.Nandgatecontainer[index].selectionRectangle1.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        else if (Which_Rectangle == 2 && Public_Static_Variables.Nandgatecontainer[index].selectionRectangle2.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        break;
                    case 2:
                        if (Which_Rectangle == 1 && Public_Static_Variables.Orgatecontainer[index].selectionRectangle1.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        else if (Which_Rectangle == 2 && Public_Static_Variables.Orgatecontainer[index].selectionRectangle2.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        break;
                    case 3:
                        if (Which_Rectangle == 1 && Public_Static_Variables.Norgatecontainer[index].selectionRectangle1.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        else if (Which_Rectangle == 2 && Public_Static_Variables.Norgatecontainer[index].selectionRectangle2.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        break;
                    case 4:
                        if (Which_Rectangle == 1 && Public_Static_Variables.XOrgatecontainer[index].selectionRectangle1.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        else if (Which_Rectangle == 2 && Public_Static_Variables.XOrgatecontainer[index].selectionRectangle2.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        break;
                    case 5:
                        if (Which_Rectangle == 1 && Public_Static_Variables.XNorgatecontainer[index].selectionRectangle1.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        else if (Which_Rectangle == 2 && Public_Static_Variables.XNorgatecontainer[index].selectionRectangle2.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        break;
                    case 6:
                        if (Which_Rectangle == 1 && Public_Static_Variables.Notgatecontainer[index].selectionRectangle1.Connected)
                        {
                            MessageBox.Show("Cannot connect two inputs to the same node");
                            Connect_Wires = false;
                            Add_Wire = false;
                        }
                        break;
                }
               
            }
            if (Connect_Wires)
            {
                Add_Wire = true;
                if (Gate_Connected == Connection_State.And)
                {
                    switch (Rectangle_Of_First_Gate)
                    {
                        case 1:
                            if (Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                        case 2:
                            if (Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                    }

                    // value here is modified for each gate
                    if (Add_Wire)
                    {
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Gate_Type);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(0);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
                        MyPanel.Add_Wires_To_Panel(Gate_Type, index, Which_Rectangle, 0, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                    }
                }
                else if (Gate_Connected == Connection_State.Nand)
                {
                    switch (Rectangle_Of_First_Gate)
                    {
                        case 1:
                            if (Public_Static_Variables.Nandgatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                        case 2:
                            if (Public_Static_Variables.Nandgatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                    }
                    if (Add_Wire)
                    {
                        // value here is modified for each gate
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Gate_Type);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(1);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
                        MyPanel.Add_Wires_To_Panel(Gate_Type, index, Which_Rectangle, 1, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                    }
                }
                else if (Gate_Connected == Connection_State.Or)
                {
                    switch (Rectangle_Of_First_Gate)
                    {
                        case 1:
                            if (Public_Static_Variables.Orgatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                        case 2:
                            if (Public_Static_Variables.Orgatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                    }
                    if (Add_Wire)
                    {
                        // value here is modified for each gate
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Gate_Type);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(2);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
                        MyPanel.Add_Wires_To_Panel(Gate_Type, index, Which_Rectangle, 2, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                    }
                }
                else if (Gate_Connected == Connection_State.Nor)
                {
                    switch (Rectangle_Of_First_Gate)
                    {
                        case 1:
                            if (Public_Static_Variables.Norgatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                        case 2:
                            if (Public_Static_Variables.Norgatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                    }
                    if (Add_Wire)
                    {
                        // value here is modified for each gate
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Gate_Type);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(3);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
                        MyPanel.Add_Wires_To_Panel(Gate_Type, index, Which_Rectangle, 3, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                    }
                }
                else if (Gate_Connected == Connection_State.XOr)
                {
                    switch (Rectangle_Of_First_Gate)
                    {
                        case 1:
                            if (Public_Static_Variables.XOrgatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                        case 2:
                            if (Public_Static_Variables.XOrgatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                    }
                    if (Add_Wire)
                    {
                        // value here is modified for each gate
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Gate_Type);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(4);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
                        MyPanel.Add_Wires_To_Panel(Gate_Type, index, Which_Rectangle, 4, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                    }
                }
                else if (Gate_Connected == Connection_State.XNor)
                {
                    switch (Rectangle_Of_First_Gate)
                    {
                        case 1:
                            if (Public_Static_Variables.XNorgatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                        case 2:
                            if (Public_Static_Variables.XNorgatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
                            {
                                MessageBox.Show("Cannot Connect more than two inputs to the same node");
                                Add_Wire = false;
                            }
                            break;
                    }
                    if (Add_Wire)
                    {
                        // value here is modified for each gate
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Gate_Type);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(5);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
                        MyPanel.Add_Wires_To_Panel(Gate_Type, index, Which_Rectangle, 5, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                    }
                }
                else if (Gate_Connected == Connection_State.Not)
                {

                    if (Public_Static_Variables.Notgatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
                    {
                        MessageBox.Show("Cannot Connect more than two inputs to the same node");
                        Add_Wire = false;
                    }
                    if (Add_Wire)
                    {
                        // value here is modified for each gate
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Gate_Type);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(6);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
                        MyPanel.Add_Wires_To_Panel(Gate_Type, index, Which_Rectangle, 6, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                    }
                }
            }
        }
    }
}
