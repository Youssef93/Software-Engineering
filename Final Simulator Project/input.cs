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
    public partial class input : UserControl
    {
        public Rectangle intersecting_Rectangle = new Rectangle();
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        public input()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            //this.BackColor = Color.White;
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
            intersecting_Rectangle.Location = new Point(this.Right - RectWidthAndHeight, this.Bottom - this.Height / 2 - RectWidthAndHeight / 2);
            intersecting_Rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawLine(pen, new Point(radioButton1.Right, radioButton1.Top + radioButton1.Height / 2), new Point(radioButton1.Right + 10, radioButton1.Top + radioButton1.Height / 2)); // first horizontal line
            g.DrawLine(pen, new Point(radioButton2.Right, radioButton2.Top + radioButton2.Height / 2), new Point(radioButton2.Right + 10, radioButton2.Top + radioButton2.Height / 2)); //second horizontal line
            g.DrawLine(pen, new Point(radioButton1.Right + 10, radioButton1.Top + radioButton1.Height / 2), new Point(radioButton2.Right + 10, radioButton2.Top + radioButton2.Height / 2)); // vertical line
            int y = this.Height/2;
            g.DrawLine(pen, new Point(radioButton1.Right + 10, y), new Point(this.Width, y)); //last horizontal line
            Rectangle rectangle = new Rectangle();
            rectangle.Location = new Point(this.Width- RectWidthAndHeight, y - RectWidthAndHeight/2);
            rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
            g.FillRectangle(sb, rectangle);
        }
    }
}
