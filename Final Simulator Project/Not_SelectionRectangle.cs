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
            this.BackColor = this.Parent.BackColor;
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
                bool Add_Wire = true;
                // value here changes for each gate
                Add_Wires_To_list(6, ref Add_Wire);
                if (Add_Wire)
                    this.Connected = true;
            }
        }
    }
}
