using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
    abstract class SelectionRectangle : UserControl
    {
        protected int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        protected Rectangle Inner_Rectangle;
        protected Graphics g;
        protected int Index_Of_First_Gate;
        protected int Rectangle_Of_First_Gate;
         /* not implemeted functions :
          Paint, Move ,AddWires, MouseUp
         */
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
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.White;
        }
        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            this.BackColor = this.Parent.BackColor;
        }
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
                if (rectangle1.Contains(p))
                {
                    index = i;
                    return 1;
                }

                else if (rectangle2.Contains(p))
                {
                    index = i;
                    return 2;

                }
                else if (rectangle3.Contains(p))
                {
                    index = i;
                    return 3;
                }
            }
            return 0;
        }
        // a function that returns which gate this control lies in and which selection rectangle
        // the return value is the which rectangle and the index variable is the index of the gate it lies in
        protected int Index_Of_This_Control(Rectangle rectangle, ref int index)
        {
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Rectangle rectangle3 = new Rectangle();
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
    }
}
