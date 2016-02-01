using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
    class Not_SelectionRectangle : SelectionRectangle
    {
        public bool Connected = false; // a bool variable to check whether this node is connected to any line/ input/ output or not
        public bool right = true;

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            this.BackColor = Parent.BackColor;
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
            {
                Index_Of_First_Gate = index;
                Add_Wires_To_List();
            }
        }
        private void Add_Wires_To_List()
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
            int Which_Rectangle = Index_Of_This_Control(rectangle, ref index, 1); // which rectangle in this gate

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

            //values change here for each gate
            else if (Which_Rectangle != 3)
            {
                if (Which_Rectangle == 1 && Public_Static_Variables.Notgatecontainer[index].selectionRectangle1.Connected)
                {
                    MessageBox.Show("Cannot connect two inputs to the same node");
                    Connect_Wires = false;
                }
                else if (Which_Rectangle == 2 && Public_Static_Variables.Notgatecontainer[index].selectionRectangle2.Connected)
                {
                    MessageBox.Show("Cannot connect two inputs to the same node");
                    Connect_Wires = false;
                }
            }
            //else if (Rectangle_Of_First_Gate != 3)
            //{
            //    if (Gate_Connected == Connection_State.And)
            //    {
            //        if (Rectangle_Of_First_Gate == 1 && Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
            //        {
            //            MessageBox.Show("Cannot connect two inputs to the same node");
            //            Connect_Wires = false;
            //        }
            //        else if (Rectangle_Of_First_Gate == 2 && Public_Static_Variables.gatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
            //        {
            //            MessageBox.Show("Cannot connect two inputs to the same node");
            //            Connect_Wires = false;
            //        }
            //    }
            //    else if (Gate_Connected == Connection_State.Not)
            //    {
            //        if (Rectangle_Of_First_Gate == 1 && Public_Static_Variables.Notgatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected)
            //        {
            //            MessageBox.Show("Cannot connect two inputs to the same node");
            //            Connect_Wires = false;
            //        }
            //        else if (Rectangle_Of_First_Gate == 2 && Public_Static_Variables.Notgatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected)
            //        {
            //            MessageBox.Show("Cannot connect two inputs to the same node");
            //            Connect_Wires = false;
            //        }
            //    }
            //}
         
            if (Connect_Wires)
            {
                // value here is modified for each gate
                Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(1);

                Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(index);
                Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Which_Rectangle);
                this.Connected = true;
                if (Gate_Connected == Connection_State.And)
                {
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
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(0);

                    // value here is modified for each gate
                    MyPanel.Add_Wires_To_Panel(1, index, Which_Rectangle, 0, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                }
                else if (Gate_Connected == Connection_State.Not)
                {
                    switch (Rectangle_Of_First_Gate)
                    {
                        case 1:
                            Public_Static_Variables.Notgatecontainer[Index_Of_First_Gate].selectionRectangle1.Connected = true;
                            break;
                        case 2:
                            Public_Static_Variables.Notgatecontainer[Index_Of_First_Gate].selectionRectangle2.Connected = true;
                            break;
                        case 3:
                            Public_Static_Variables.Notgatecontainer[Index_Of_First_Gate].selectionRectangle3.Connected = true;
                            break;
                    }
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(1);

                    // value here is modified for each gate
                    MyPanel.Add_Wires_To_Panel(1, index, Which_Rectangle, 1, Index_Of_First_Gate, Rectangle_Of_First_Gate, panel1);
                }
                Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Index_Of_First_Gate);
                Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Rectangle_Of_First_Gate);
            }
        }
    }
}
