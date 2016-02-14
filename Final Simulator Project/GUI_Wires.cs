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
    public partial class GUI_Wires : UserControl
    {
        int Total_Width; // width & height of the wires drawn
        int  Total_Height;
        int Total_Height_2;
        int Total_Width_2;
        int local_width_height = 3; // width and height of the control 
        public Point Output_Point = new Point();
        public Point Input_Point = new Point();
        Graphics g;
        WireCase Wire_case_state;
        enum WireCase : int
        {
            Normal_up, Normal_down, Backwards_up_small, Backwards_up_big, Backwards_down, Horizontal
        }
        public GUI_Wires()
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
            if (Input_Point.X >= Output_Point.X)
            {
                if (Output_Point.Y == Input_Point.Y || Output_Point.Y == Input_Point.Y+1 || Output_Point.Y == Input_Point.Y +2 || Output_Point.Y == Input_Point.Y+3
                    || Output_Point.Y == Input_Point.Y-1 || Output_Point.Y == Input_Point.Y-2 || Output_Point.Y == Input_Point.Y-3)
                {
                    Total_Height = 0;
                    Total_Width = Input_Point.X - Output_Point.X -8;
                    this.Location = new Point(Output_Point.X+10, Output_Point.Y+local_width_height/2);
                    Wire_case_state = WireCase.Horizontal;
                }
                else if (Output_Point.Y > Input_Point.Y)
                { 
                    this.Total_Height = Output_Point.Y - Input_Point.Y - local_width_height / 2 - 1;
                    this.Total_Width = Input_Point.X - Output_Point.X - local_width_height / 2 -3;
                    this.Location = new Point(Input_Point.X - Total_Width+2, Input_Point.Y - local_width_height / 2 +2);
                    Wire_case_state = WireCase.Normal_up;
                }
             
                else
                {
                    this.Total_Height = Input_Point.Y - Output_Point.Y - local_width_height / 2 - 5;
                    this.Total_Width = Input_Point.X - Output_Point.X - local_width_height / 2 - 4;
                    this.Location = new Point(Output_Point.X + 7, Output_Point.Y + 7);
                    Wire_case_state = WireCase.Normal_down;
                }
            }
            else
            {
                this.Total_Height = 40;
                this.Total_Width_2 = 20;
                 if (Input_Point.Y <= Output_Point.Y + Total_Height + local_width_height)
                {
                    if (Input_Point.Y >= Output_Point.Y)
                    {
                        this.Total_Height_2 = Output_Point.Y + Total_Height - Input_Point.Y + 2;
                        this.Total_Width = Output_Point.X - Input_Point.X + local_width_height + 4;
                        this.Location = new Point(Input_Point.X - local_width_height / 2 +2, Output_Point.Y + 7);
                        Wire_case_state = WireCase.Backwards_up_small;
                    }
                    else
                    {
                        this.Total_Height_2 = Output_Point.Y - Input_Point.Y + local_width_height / 2 - Total_Height - local_width_height;
                        this.Total_Width = Output_Point.X - Input_Point.X + local_width_height / 2 + Total_Width_2 + 7;
                        this.Location = new Point(Input_Point.X - local_width_height / 2 - 18, Input_Point.Y +2);
                        Wire_case_state = WireCase.Backwards_up_big;
                    }
                }
                else if (Input_Point.Y > Output_Point.Y + Total_Height + local_width_height)
                {
                    this.Total_Width = Output_Point.X + local_width_height / 2 - Input_Point.X + Total_Width_2 + 7;
                    this.Total_Height_2 = Input_Point.Y +local_width_height/2 - Output_Point.Y - Total_Height - local_width_height - 5;
                    this.Location = new Point(Input_Point.X - local_width_height / 2 - Total_Width_2 +2, Output_Point.Y+7);
                    Wire_case_state = WireCase.Backwards_down;
                }
            }
        }
        void This_Paint()
        {
            GraphicsPath MyPath = new GraphicsPath();
            Size Horizontal_Rectangle_Size = new Size(Total_Width, local_width_height);
            Size Horizontal_Rectangle_2_Size = new Size(Total_Width_2 - 2, local_width_height);
            Size Vertical_Rectangle_Size = new Size(local_width_height, Total_Height);
            Size Vertical_Rectangle_2_Size = new Size(local_width_height, Total_Height_2);
            if (Wire_case_state == WireCase.Normal_up)
            {
                Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, 0), Horizontal_Rectangle_Size);
                Rectangle Vertical_Rectangle = new Rectangle(new Point(0, local_width_height), Vertical_Rectangle_Size);
                MyPath.AddRectangle(Vertical_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle);
                this.Region = new Region(MyPath);
                Pen pen = new Pen(Color.Black);
                g = this.CreateGraphics();
                g.DrawLine(pen, new Point(local_width_height / 2, local_width_height / 2), new Point(Total_Width + 1, local_width_height / 2));  // horizontal line
                g.DrawLine(pen, new Point(local_width_height / 2, local_width_height / 2), new Point(local_width_height / 2, Total_Height + 5)); //vertical line
            }
            else if (Wire_case_state == WireCase.Normal_down)
            {
                Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, Total_Height), Horizontal_Rectangle_Size);
                Rectangle Vertical_Rectangle = new Rectangle(new Point(0, 0), Vertical_Rectangle_Size);
                MyPath.AddRectangle(Vertical_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle);
                this.Region = new Region(MyPath);
                g = this.CreateGraphics();
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, new Point(local_width_height / 2, Total_Height + local_width_height / 2), new Point(Total_Width + 1, Total_Height + local_width_height / 2));  // horizontal line
                g.DrawLine(pen, new Point(local_width_height / 2, 0), new Point(local_width_height / 2, Total_Height + local_width_height / 2)); //vertical line
            }
            else if (Wire_case_state == WireCase.Horizontal)
            {
                Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, 0), Horizontal_Rectangle_Size);
                MyPath.AddRectangle(Horizontal_Rectangle);
                this.Region = new Region(MyPath);
                Pen pen = new Pen(Color.Black);
                g = this.CreateGraphics();
                g.DrawLine(pen, new Point(0, local_width_height / 2), new Point(Total_Width, local_width_height / 2));
            }
            else if (Wire_case_state == WireCase.Backwards_up_small)
            {
                Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, Total_Height), Horizontal_Rectangle_Size);
                Rectangle Vertical_Output_Rectangle = new Rectangle(new Point(Total_Width - local_width_height, 0), Vertical_Rectangle_Size);
                Rectangle Vertical_Input_Rectangle = new Rectangle(new Point(0, Total_Height - Total_Height_2), Vertical_Rectangle_2_Size);
                MyPath.AddRectangle(Vertical_Input_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle);
                MyPath.AddRectangle(Vertical_Output_Rectangle);
                this.Region = new Region(MyPath);
                g = this.CreateGraphics();
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, new Point(local_width_height / 2, local_width_height / 2 + Total_Height), new Point(Total_Width + 1, local_width_height / 2 + Total_Height));  // horizontal line
                g.DrawLine(pen, new Point(Total_Width - local_width_height / 2, 0), new Point(Total_Width - local_width_height / 2, Total_Height + local_width_height / 2)); //Output vertical line
                g.DrawLine(pen, new Point(local_width_height / 2, Total_Height - Total_Height_2), new Point(local_width_height / 2, Total_Height + local_width_height / 2)); // input vertical line
            }
            else if (Wire_case_state == WireCase.Backwards_down)
            {
                Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, Total_Height), Horizontal_Rectangle_Size);
                Rectangle Horizontal_Rectangle_2 = new Rectangle(new Point(local_width_height, Total_Height + Total_Height_2), Horizontal_Rectangle_2_Size);
                Rectangle Vertical_Output_Rectangle = new Rectangle(new Point(Total_Width - local_width_height, 0), Vertical_Rectangle_Size);
                Rectangle Vertical_Input_Rectangle = new Rectangle(new Point(0,Total_Height+local_width_height), Vertical_Rectangle_2_Size);
                MyPath.AddRectangle(Vertical_Input_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle);
                MyPath.AddRectangle(Vertical_Output_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle_2);
                this.Region = new Region(MyPath);;
                g = this.CreateGraphics();
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, new Point(local_width_height / 2, local_width_height / 2 + Total_Height), new Point(Total_Width + 1, local_width_height / 2 + Total_Height));  // horizontal line
                g.DrawLine(pen, new Point(Total_Width - local_width_height / 2, 0), new Point(Total_Width - local_width_height / 2, Total_Height + local_width_height / 2)); //Output vertical line
                g.DrawLine(pen, new Point(local_width_height / 2, Total_Height+local_width_height/2), new Point(local_width_height / 2, Total_Height_2+100)); // input vertical line
                g.DrawLine(pen, new Point(local_width_height / 2, Total_Height + local_width_height + Total_Height_2 - local_width_height / 2), new Point(Total_Width_2, Total_Height + local_width_height + Total_Height_2 - local_width_height / 2)); //final horizontal line
            }
            else
            {
                Size Vertical_Rectangle_Size_adjusted = new Size(local_width_height, Total_Height-1);
                Rectangle Horizontal_Rectangle = new Rectangle(new Point(0, Total_Height_2), Horizontal_Rectangle_Size);
                Rectangle Horizontal_Rectangle_2 = new Rectangle(new Point(local_width_height, 0), Horizontal_Rectangle_2_Size);
                Rectangle Vertical_Output_Rectangle = new Rectangle(new Point(Total_Width - local_width_height,Total_Height_2+local_width_height), Vertical_Rectangle_Size_adjusted);
                Rectangle Vertical_Input_Rectangle = new Rectangle(new Point(0, 0), Vertical_Rectangle_2_Size);
                MyPath.AddRectangle(Vertical_Input_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle);
                MyPath.AddRectangle(Vertical_Output_Rectangle);
                MyPath.AddRectangle(Horizontal_Rectangle_2);
                this.Region = new Region(MyPath);
                g = this.CreateGraphics();
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, new Point(local_width_height / 2, local_width_height / 2 + Total_Height_2), new Point(Total_Width + 1, local_width_height / 2 + Total_Height_2));  // horizontal line
                g.DrawLine(pen, new Point(Total_Width - local_width_height / 2, Total_Height_2+local_width_height/2), new Point(Total_Width - local_width_height / 2, Total_Height_2 + local_width_height + Total_Height)); //Output vertical line
                g.DrawLine(pen, new Point(local_width_height / 2, 0), new Point(local_width_height / 2, Total_Height_2)); // input vertical line
                g.DrawLine(pen, new Point(local_width_height / 2, local_width_height/2-1), new Point(Total_Width_2, local_width_height/2-1)); //final horizontal line (width2)
            }
       
        }
        public void Points_Changed(Point Out, Point In)
        {
            Output_Point = Out;
            Input_Point = In;
            this.Invalidate();
            This_Load();
            This_Paint();
            this.Update();
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