using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Final_Simulator_Project
{
    class MyPictureBox : PictureBox
    {
        protected Point MovingPoint = new Point();
        protected Point This_Location = new Point();
        protected Control Original_Parent = new Control();
        protected bool first_time = true;
        protected ToolTip toolTip1 = new ToolTip();
        protected override void OnLocationChanged(EventArgs e)
        {
            if (first_time)
            {
                This_Location = this.Location;
                first_time = false;
            }
        }
        protected override void OnLoadCompleted(AsyncCompletedEventArgs e)
        {
            Original_Parent = this.Parent;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Control groupBox1 = this.Parent;
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
                if (this.Right - 15 >= groupBox1.Width)
                {
                    foreach (Control panel in this.FindForm().Controls)
                    {
                        if (panel.GetType() == typeof(MyPanel))
                        {
                            this.Parent = panel;
                        }
                    }
                }
            }
        }
    }
}
