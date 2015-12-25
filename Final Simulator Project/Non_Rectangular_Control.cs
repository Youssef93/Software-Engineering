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
using System.Threading;

namespace Final_Simulator_Project
{
    public partial class Non_Rectangular_Control : UserControl
    {
        int Total_Width; // width & height of the wires drawn
        int  Total_Height;
        int local_width_height = 3; // width and height of the control
        Point MovingPoint;
        Point CheckLocation;
        bool MoveLine = true;
        public Point Output_Point = new Point();
        public Point Input_Point = new Point();
        bool WireUp = true;
        Graphics g;
        public Non_Rectangular_Control()
        {
            InitializeComponent();
        }

        private void Non_Rectangular_Control_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            this.BackColor = Color.White;
            this.Width = 10000;
            this.Height = 10000;
            This_Load();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            This_Paint();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            this.BringToFront();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.White;
        }
        void This_Load()
        {
            if (Output_Point.Y >= Input_Point.Y)
            {
                this.Total_Height = Output_Point.Y - Input_Point.Y - local_width_height / 2- 1;
                this.Total_Width = Input_Point.X - Output_Point.X - local_width_height / 2 - 4;
                this.Location = new Point(Input_Point.X - Total_Width , Input_Point.Y - local_width_height / 2);
                WireUp = true;
            }
            else
            {
                this.Total_Height = Input_Point.Y - Output_Point.Y - local_width_height / 2-5;
                this.Total_Width = Input_Point.X - Output_Point.X - local_width_height / 2 -3 ;
                this.Location = new Point(Output_Point.X+4, Output_Point.Y+5);
                WireUp = false;
            }
        }
        void This_Paint()
        {
            GraphicsPath MyPath = new GraphicsPath();
            Size Horizontal_Rectangle_Size = new Size(Total_Width, local_width_height);
            Size Vertical_Rectangle_Size = new Size(local_width_height, Total_Height);
            if (WireUp)
            {
                Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, 0), Horizontal_Rectangle_Size);
                Rectangle Vertical_Rectangle = new Rectangle(new Point(0, local_width_height), Vertical_Rectangle_Size);
                MyPath.AddRectangle(Vertical_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle);
                this.Region = new Region(MyPath);
                //g.Clear(Color.White);
                g = this.CreateGraphics();
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, new Point(local_width_height / 2, local_width_height / 2), new Point(Total_Width + 1, local_width_height / 2));  // horizontal line
                g.DrawLine(pen, new Point(local_width_height / 2, local_width_height / 2), new Point(local_width_height / 2, Total_Height + 5)); //vertical line
            }
            else
            {
                Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, Total_Height), Horizontal_Rectangle_Size);
                Rectangle Vertical_Rectangle = new Rectangle(new Point(0, 0), Vertical_Rectangle_Size);
                MyPath.AddRectangle(Vertical_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle);
                this.Region = new Region(MyPath);
                //g.Clear(Color.White);
                g = this.CreateGraphics();
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, new Point(local_width_height / 2, Total_Height + local_width_height / 2), new Point(Total_Width + 1, Total_Height + local_width_height / 2));  // horizontal line
                g.DrawLine(pen, new Point(local_width_height / 2,  0), new Point(local_width_height / 2, Total_Height + local_width_height/2)); //vertical line
            }
        }
        public void Points_Changed(Point Out, Point In)
        {
            Output_Point = Out;
            Input_Point = In;
            This_Load();
            This_Paint();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu menu = new ContextMenu();
                MenuItem menuitem = new MenuItem("Delete");
                menuitem.Click += Menuitem_Click;
                menu.MenuItems.Add(menuitem);
                this.ContextMenu = menu;
            }
        }

        private void Menuitem_Click(object sender, EventArgs e)
        {
            MyPanel.Delete_Wire(Output_Point, Input_Point);
        }
    }
}