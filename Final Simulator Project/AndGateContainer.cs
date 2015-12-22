﻿using System;
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
    public partial class AndGateContainer : UserControl
    {
        Point MovingPoint;
        Point CheckLocation;
        bool MoveGate = true;
        bool Activate_ToolTip = false;
        ToolTip tooltip1 = new ToolTip();
        bool First_Time_Created = true;
        public Point ContainerScreenLocation = new Point();
        public Rectangle ContainerRectangle = new Rectangle();
        bool Not_Selection_rectangle = true;
        int Connect_Lines_Intger1;
        bool Connect_Lines = false;
        public AndGateContainer()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.Width = 55 + Public_Static_Variables.width; // Width of all gate
            this.Height = 20 + Public_Static_Variables.height; // height of all gate
            //this.Visible = false;
            this.BackColor = Color.White;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            
            Control panel1 = this.Parent;
            // initialized all intersection rectangles
            Rectangle inputRect1 = new Rectangle(this.Left + 10, this.Top + 15 - Public_Static_Variables.RectWidthAndHeight / 2-2, Public_Static_Variables.RectWidthAndHeight+2, Public_Static_Variables.RectWidthAndHeight+2);// initialize first rectangle
            Rectangle inputRect2 = new Rectangle(this.Left + 10 , this.Top + 10+ Public_Static_Variables.height -5 - Public_Static_Variables.RectWidthAndHeight/2-2, Public_Static_Variables.RectWidthAndHeight+2, Public_Static_Variables.RectWidthAndHeight+2);//initialize secind rectangle
            Rectangle outputRect = new Rectangle(this.Left + 40 + Public_Static_Variables.width+10-2, this.Top + 10 + Public_Static_Variables.height / 2 - Public_Static_Variables.RectWidthAndHeight/2-2, Public_Static_Variables.RectWidthAndHeight+2, Public_Static_Variables.RectWidthAndHeight+2);
            if (First_Time_Created)
            {
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;

                ContainerRectangle.Width = this.Width; ;
                ContainerRectangle.Height = this.Height;
                ContainerRectangle.Location = this.Location;
                // created a rectangle at the same location of this container relative to the panel
                ContainerScreenLocation = new Point(ContainerRectangle.X, ContainerRectangle.Y);
                // created a point of the location of the rectangle relative to the panel

                // making  the intersection rectangles
                Public_Static_Variables.Connecting_Rectangles[Public_Static_Variables.Connecting_Rectangles_Counter] = inputRect1;
                Public_Static_Variables.Connecting_Rectangles_Counter++;
                Public_Static_Variables.Connecting_Rectangles[Public_Static_Variables.Connecting_Rectangles_Counter] = inputRect2;
                Public_Static_Variables.Connecting_Rectangles_Counter++;
                Public_Static_Variables.Connecting_Rectangles[Public_Static_Variables.Connecting_Rectangles_Counter] = outputRect;
                Public_Static_Variables.Connecting_Rectangles_Counter++;
                if (this.Left <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Left = 10;
                }
                else if (this.Top <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = 10;
                }
                else if (this.Right >= panel1.Width)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Left = panel1.Width - 80 - Public_Static_Variables.width;
                }
                else if (this.Bottom >= panel1.Height)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = panel1.Height - 50 - Public_Static_Variables.width;
                }
                First_Time_Created = false;
            }
            else
            {
                // first, initialize a rectangle that contains the current location of the control before moving it
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;

                ContainerRectangle.Location = this.Location;
                // created a rectangle at the same location of this container relative to the panel
                ContainerScreenLocation = new Point(ContainerRectangle.X,ContainerRectangle.Y);
                //created a point of the location of the rectangle relative to the panel

                int Current_Reset = Public_Static_Variables.Reset_draw_rect * 3;
                Public_Static_Variables.Connecting_Rectangles[Current_Reset - 2] = inputRect1;
                Public_Static_Variables.Connecting_Rectangles[Current_Reset - 1] = inputRect2;
                Public_Static_Variables.Connecting_Rectangles[Current_Reset] = outputRect;
                if (this.Left <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Left = 10;
                }
                else if (this.Top <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = 10;
                }
                else if (this.Right >= panel1.Width)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Left = this.Left - 10;
                }
                else if (this.Bottom >= panel1.Height)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = this.Top - 10;
                }
                if (!Public_Static_Variables.Deleted_Gate)
                {
                    for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                    {
                        if (i != Public_Static_Variables.Reset_draw_rect && this.Parent.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                        {
                            AndGateContainer local_Control = Public_Static_Variables.gatecontainer[i];
                            Rectangle Local_Rectangle = new Rectangle();
                            Local_Rectangle.Location = local_Control.Location;
                            Local_Rectangle.Width = local_Control.Width;
                            Local_Rectangle.Height = local_Control.Height;
                            if (current_location_Retangle.IntersectsWith(Local_Rectangle))
                            {
                                MoveGate = false;
                                Activate_ToolTip = true;
                                if (Local_Rectangle.Contains(current_location_Retangle.Location))
                                {
                                    this.Location = new Point(this.Left + 10, this.Top);
                                }
                                else if (Local_Rectangle.Contains(new Point(current_location_Retangle.Right, current_location_Retangle.Top)))
                                {
                                    this.Location = new Point(this.Left - 10, this.Top);
                                }
                            }
                        }
                    }
                }
                Public_Static_Variables.DoThread = true;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Rectangle inputRect1 = new Rectangle(1, 15 - Public_Static_Variables.RectWidthAndHeight / 2 - 2, Public_Static_Variables.RectWidthAndHeight + 2, Public_Static_Variables.RectWidthAndHeight + 2);// initialize first rectangle
            Rectangle inputRect2 = new Rectangle(1, 10 + Public_Static_Variables.height - 5 - Public_Static_Variables.RectWidthAndHeight / 2 - 2, Public_Static_Variables.RectWidthAndHeight + 2, Public_Static_Variables.RectWidthAndHeight + 2);//initialize secind rectangle
            Rectangle outputRect = new Rectangle(40 + Public_Static_Variables.width + 10 - 2, 10 + Public_Static_Variables.height / 2 - Public_Static_Variables.RectWidthAndHeight / 2 - 2, Public_Static_Variables.RectWidthAndHeight + 2, Public_Static_Variables.RectWidthAndHeight + 2);
            Point point = new Point(e.X, e.Y);
            if (inputRect1.Contains(point))
            {
                Not_Selection_rectangle = false;
                Connect_Lines = true;
                Connect_Lines_Intger1 = 1;
            }
            else if (inputRect2.Contains(point))
            {
                Connect_Lines_Intger1 = 2;
                Not_Selection_rectangle = false;
                Connect_Lines = true;
            }
            else if (outputRect.Contains(point))
            {
                Connect_Lines_Intger1 = 3;
                Not_Selection_rectangle = false;
                Connect_Lines = true;
            }
               else if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
                CheckLocation = this.Location;
                Not_Selection_rectangle = true;
                
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MoveGate && Not_Selection_rectangle)
            {
                this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
               
            }
            for (int i = 1; i<= Public_Static_Variables.gatecontainer_counter; i++)
            {
                AndGateContainer andgate = Public_Static_Variables.gatecontainer[i];
                if (this.Location == andgate.Location)
                {
                    Public_Static_Variables.Reset_draw_rect = i;
                    
                }
            }
 
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            Public_Static_Variables.DoThread = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);
            SolidBrush sb = new SolidBrush(Color.Black);
            int width = Public_Static_Variables.width;
            int height = Public_Static_Variables.height;
            int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
            int X, Y;
            X = 40;
            Y = 10;
            Graphics g = this.CreateGraphics();
            g.DrawPie(pen, X - (width / 2), Y, width, height, 270, 180); //curve
            g.DrawLine(pen, new Point(X, Y + 5), new Point(X - 30, Y + 5));// first horizontal line
            g.DrawLine(pen, new Point(X, Y + width - 5), new Point(X - 35, Y + width - 5));// Second Horizontal line
            g.DrawLine(pen, new Point(X + (width / 2), Y + (height / 2)), new Point(X + (width / 2) + 30, Y + (height / 2)));// last horizontal line
            Rectangle inputRect1 = new Rectangle (0, Y + RectWidthAndHeight / 2, RectWidthAndHeight, RectWidthAndHeight);// initialize first rectangle
            Rectangle inputRect2 = new Rectangle(0, Y + RectWidthAndHeight + height - 12, RectWidthAndHeight, RectWidthAndHeight);//initialize secind rectangle
            Rectangle outputRect = new Rectangle(X + width / 2 + 30 - RectWidthAndHeight + 5, Y + height / 2 - RectWidthAndHeight + 3, RectWidthAndHeight, RectWidthAndHeight);
            g.FillRectangle(sb, inputRect1); // first rectangle
            g.FillRectangle(sb, inputRect2);// second rectangle
            g.FillRectangle(sb, outputRect);//output rectangle
            g.DrawLine(pen, new Point(50 + width, 0), new Point(50 + width, this.Height));
            g.DrawLine(pen, new Point(0, 13+RectWidthAndHeight/2), new Point(15, 13+RectWidthAndHeight/2));
        }

        private void AndGateContainer_MouseUp(object sender, MouseEventArgs e)
        {
            MoveGate = true;
            if (Connect_Lines)
            {
                Point p = new Point();
                p = Cursor.Position;
                Control panel = this.Parent;
                p = panel.PointToClient(p);
                Form1.Add_Rectangles_To_List(p,Connect_Lines_Intger1);
                Connect_Lines = false;
            }
        }

        private void AndGateContainer_MouseHover(object sender, EventArgs e)
        {
            if (Activate_ToolTip)
            {
                tooltip1.Show("You cannot overlap 2 gates", this);
            }
        }

        private void AndGateContainer_MouseClick(object sender, MouseEventArgs e)
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
            Form1.Delete_gate(Public_Static_Variables.Reset_draw_rect);
        }

        public void ZeroRectangle()
        {
            ContainerRectangle.Width = 0;
            ContainerRectangle.Height = 0;
        }

        private void AndGateContainer_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void AndGateContainer_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
