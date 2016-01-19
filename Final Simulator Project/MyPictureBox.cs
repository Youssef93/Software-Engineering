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
        enum Gate : int
        {
            and = 0, or= 1, not=2, xor=3, xnor=4, none = 5
        }
        Point MovingPoint = new Point();
        Point This_Location = new Point();
        Gate gatenumber;
        Control Original_Parent = new Control();
        bool first_time = true;
        public MyPictureBox(int number)
        {
            if (number >= 0 && number <= 4)
            {
                switch (number)
                {
                    case 0:
                        gatenumber = Gate.and;
                        this.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.PNG";
                        break;
                    case 1:
                        gatenumber = Gate.or;
                        break;
                    case 2:
                        gatenumber = Gate.not;
                        break;
                    case 3:
                        gatenumber = Gate.xor;
                        break;
                    case 4:
                        gatenumber = Gate.xnor;
                        break;
                }
            }
            else
            {
                gatenumber = Gate.none;
            }
        }
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
                        if ( panel.GetType() == typeof(MyPanel))
                        {
                            this.Parent = panel;
                        }
                    }
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.Parent.GetType() == typeof(MyPanel))
            {
                Point Gate_Location = this.Location;
                MessageBox.Show(Original_Parent.ToString());
                this.Parent = Original_Parent;
                this.Location = This_Location;
                this.BringToFront();
            }
        }
    }
}
