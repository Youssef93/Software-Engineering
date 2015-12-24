using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Final_Simulator_Project
{
    public partial class Non_Rectangular_Control : UserControl
    {
        public int  width = 40;
        public int  height= 45;
        //public int left_coordinate;
        //public int top_coordinate;
        Point MovingPoint;
        Point CheckLocation;
        bool MoveLine = true;
        public Non_Rectangular_Control()
        {
            InitializeComponent();
        }

        private void Non_Rectangular_Control_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.Width = 2000;
            this.Height = 2000;
            //this.Left = left_coordinate;
            //this.Top = top_coordinate;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath MyPath = new GraphicsPath();
            Size Horizontal_Rectangle_Size = new Size(width, 5);
            Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, 0), Horizontal_Rectangle_Size);
            Size Vertical_Rectangle_Size = new Size(5, height);
            Rectangle Vertical_Rectangle = new Rectangle(new Point(width, 0), Vertical_Rectangle_Size);
            MyPath.AddRectangle(Horizontal_Rectangle);
            MyPath.AddRectangle(Vertical_Rectangle);
            this.Region = new Region(MyPath);

            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, new Point(0, 2), new Point(width+1, 2));
            g.DrawLine(pen, new Point(width + 2, 2), new Point(width + 2, height));
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.Beige;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.White;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MoveLine)
            {
                this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
                CheckLocation = this.Location;
            }
        }
    }
}