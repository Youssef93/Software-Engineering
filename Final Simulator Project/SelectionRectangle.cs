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
        //protected override void WndProc(ref Message m)    //disables all events
        //{
        //    const int WM_NCHITTEST = 0x0084;
        //    const int HTTRANSPARENT = (-1);

        //    if (m.Msg == WM_NCHITTEST)
        //    {
        //        m.Result = (IntPtr)HTTRANSPARENT;
        //    }
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}

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
                Form form1 = this.FindForm();
                p = form1.PointToClient(MousePosition);
                //MessageBox.Show(p.ToString());
                for  (int i =1; i<Public_Static_Variables.gatecontainer_counter*3; i++)
                {
                    if (Public_Static_Variables.Screen_Connecting_Rectangles[i].Contains(p))
                    {
                        MessageBox.Show("Here2");
                       if(i%3 == 0)
                        {
                            MessageBox.Show("Here");
                            Public_Static_Variables.gatecontainer[i / 3].selectionRectangle3.BackColor = Color.LightGreen;
                        }
                    }
                }
                
            }
        }
       
        public void Enter_Color()
        {
            this.BackColor = Color.LightBlue;
        }
        public void Leave_color()
        {
            this.BackColor = Color.White;
        }
    }
}
