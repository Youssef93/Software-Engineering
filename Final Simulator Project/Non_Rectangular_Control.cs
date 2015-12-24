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
        int Total_Width; // width & height of the wires drawn
        int  Total_Height;
        int local_width_height = 6; // width and height of the control

        //public int left_coordinate;
        //public int top_coordinate;
        Point MovingPoint;
        Point CheckLocation;
        bool MoveLine = true;
        public Point Output_Point = new Point();
        public Point Input_Point = new Point();
        public int Output_Rectangle_Index, Input_Rectangle_Imdex;
        public bool Drawn = false;
        public Non_Rectangular_Control()
        {
            InitializeComponent();
        }

        private void Non_Rectangular_Control_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.Width = 10000;
            this.Height = 10000;
            this.Total_Height = Output_Point.Y - Input_Point.Y - local_width_height/2;
            this.Total_Width = Input_Point.X - Output_Point.X - local_width_height / 2;
            this.Location = new Point(Input_Point.X - Total_Width,Input_Point.Y-local_width_height/2);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath MyPath = new GraphicsPath();
            Size Horizontal_Rectangle_Size = new Size(Total_Width, local_width_height);
            Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, 0), Horizontal_Rectangle_Size);
            Size Vertical_Rectangle_Size = new Size(local_width_height, Total_Height);
            Rectangle Vertical_Rectangle = new Rectangle(new Point(0, local_width_height), Vertical_Rectangle_Size);
            MyPath.AddRectangle(Vertical_Rectangle);
            MyPath.AddRectangle(Horizontal_Rectangle);
            this.Region = new Region(MyPath);

            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, new Point(local_width_height/2, local_width_height/2), new Point(Total_Width + 1, local_width_height/2));  // horizontal line
            g.DrawLine(pen, new Point(local_width_height/2, local_width_height/2), new Point(local_width_height/2, Total_Height+5)); //vertical line
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.White;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //    if (e.Button == MouseButtons.Left && MoveLine)
            //    {
            //        this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
            //    }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        MovingPoint = e.Location;
        //        CheckLocation = this.Location;
        //    }
        }
    }
}