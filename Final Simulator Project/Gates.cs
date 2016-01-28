using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
    abstract class   Gates : UserControl
    {
        protected Point MovingPoint;
        protected Point CheckLocation;
        protected bool MoveGate = true;
        protected bool Activate_ToolTip = false;
        protected ToolTip tooltip1 = new ToolTip();
        protected bool First_Time_Created = true;
        protected int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        /* Not Implemented Functions are :
        Location CHanged, Mouse Move, Load, Paint, Set Connecting Rectangles, Mouse Click
        */
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
                CheckLocation = this.Location;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            MoveGate = true;
        }
        protected override void OnMouseHover(EventArgs e)
        {
            if (Activate_ToolTip)
            {
                tooltip1.Show("You cannot overlap 2 gates", this);
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
