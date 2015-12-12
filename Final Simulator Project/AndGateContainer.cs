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
    public partial class AndGateContainer : UserControl
    {
        Point MovingPoint;
        Point CheckLocation;
        public static bool MouseMove = false;
        bool MoveGate = true;
        bool Activate_ToolTip = false;
        ToolTip tooltip1 = new ToolTip();

        public AndGateContainer()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.Width = 55 + GateVariables.width; // Width of all gate
            this.Height = 20 + GateVariables.height; // height of all gate
            this.Visible = false;
           
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            
            Control panel1 = this.Parent;
            // initialized all intersection rectangles
            Rectangle inputRect1 = new Rectangle(this.Left + 10 - GateVariables.RectWidthAndHeight-2, this.Top + 15 - GateVariables.RectWidthAndHeight / 2-2, GateVariables.RectWidthAndHeight+2, GateVariables.RectWidthAndHeight+2);// initialize first rectangle
            Rectangle inputRect2 = new Rectangle(this.Left + 10 - GateVariables.RectWidthAndHeight-2, this.Top + 10+ GateVariables.height -5 - GateVariables.RectWidthAndHeight/2-2, GateVariables.RectWidthAndHeight+2, GateVariables.RectWidthAndHeight+2);//initialize secind rectangle
            Rectangle outputRect = new Rectangle(this.Left + 40 + GateVariables.width+10-2, this.Top + 10 + GateVariables.height / 2 - GateVariables.RectWidthAndHeight/2-2, GateVariables.RectWidthAndHeight+2, GateVariables.RectWidthAndHeight+2);
            if (!MouseMove)
            {
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;

                Form1.ContainerRectangle[Form1.gatecontainer_counter].Width = GateVariables.width; ;
                Form1.ContainerRectangle[Form1.gatecontainer_counter].Height = GateVariables.height;

                Form1.ContainerRectangle[Form1.gatecontainer_counter].Location = new Point(this.Left + 40, this.Top + 10);
                // created a rectangle at the same location of this container relative to the panel
                Form1.ContainerScreenLocation[Form1.gatecontainer_counter] = new Point(Form1.ContainerRectangle[Form1.gatecontainer_counter].X, Form1.ContainerRectangle[Form1.gatecontainer_counter].Y);
                // created a point of the location of the rectangle relative to the panel

                // making  the intersection rectangles
                Form1.Connecting_Rectangles[Form1.Connecting_Rectangles_Counter] = inputRect1;
                Form1.Connecting_Rectangles_Counter++;
                Form1.Connecting_Rectangles[Form1.Connecting_Rectangles_Counter] = inputRect2;
                Form1.Connecting_Rectangles_Counter++;
                Form1.Connecting_Rectangles[Form1.Connecting_Rectangles_Counter] = outputRect;
                Form1.Connecting_Rectangles_Counter++;
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
                    this.Left = panel1.Width - 80 - GateVariables.width;
                }
                else if (this.Bottom >= panel1.Height)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = panel1.Height - 50 - GateVariables.width;
                }  
            }
            else
            {
                // first, initialize a rectangle that contains the current location of the control before moving it
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;

                Form1.ContainerRectangle[Form1.Reset_draw_rect].Width = GateVariables.width;
                Form1.ContainerRectangle[Form1.Reset_draw_rect].Height = GateVariables.height;
                Form1.ContainerRectangle[Form1.Reset_draw_rect].Location = new Point(this.Left + 40, this.Top + 10);
                // created a rectangle at the same location of this container relative to the panel
                Form1.ContainerScreenLocation[Form1.Reset_draw_rect] = new Point(Form1.ContainerRectangle[Form1.Reset_draw_rect].X, Form1.ContainerRectangle[Form1.Reset_draw_rect].Y);
                //created a point of the location of the rectangle relative to the panel

                int Current_Reset = Form1.Reset_draw_rect * 3;
                Form1.Connecting_Rectangles[Current_Reset - 2] = inputRect1;
                Form1.Connecting_Rectangles[Current_Reset - 1] = inputRect2;
                Form1.Connecting_Rectangles[Current_Reset] = outputRect;
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
                for (int i = 1; i <= Form1.gatecontainer_counter; i++)
                {
                    if (i != Form1.Reset_draw_rect)
                    {
                        AndGateContainer local_Control = Form1.gatecontainer[i];
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
                Form1.DoThread = true;
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
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MoveGate)
            {
                this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
               
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            Form1.DoThread = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);
            Pen DashedPen = new Pen(Color.Black);
            float[] dashValues = { 2, 2, 2, 2 };
            DashedPen.DashPattern = dashValues;
            SolidBrush sb = new SolidBrush(Color.Black);
            int width = GateVariables.width;
            int height = GateVariables.height;
            int RectWidthAndHeight = GateVariables.RectWidthAndHeight;
            int X, Y;
            X = 40;
            Y = 10;
            Graphics g = this.CreateGraphics();
            g.DrawPie(pen, X - (width / 2), Y, width, height, 270, 180); //curve
            g.DrawLine(pen, new Point(X, Y + 5), new Point(X - 30, Y + 5));// first horizontal line
            g.DrawLine(pen, new Point(X, Y + width - 5), new Point(X - 30, Y + width - 5));// Second Horizontal line
            g.DrawLine(pen, new Point(X + (width / 2), Y + (height / 2)), new Point(X + (width / 2) + 30, Y + (height / 2)));// last horizontal line
            Rectangle inputRect1 = new Rectangle(X - 30 - RectWidthAndHeight, Y + RectWidthAndHeight / 2, RectWidthAndHeight, RectWidthAndHeight);// initialize first rectangle
            Rectangle inputRect2 = new Rectangle(X - 30 - RectWidthAndHeight, Y + RectWidthAndHeight + height - 12, RectWidthAndHeight, RectWidthAndHeight);//initialize secind rectangle
            Rectangle outputRect = new Rectangle(X + width / 2 + 30 - RectWidthAndHeight + 5, Y + height / 2 - RectWidthAndHeight + 3, RectWidthAndHeight, RectWidthAndHeight);
            g.FillRectangle(sb, inputRect1); // first rectangle
            g.FillRectangle(sb, inputRect2);// second rectangle
            g.FillRectangle(sb, outputRect);//output rectangle
            g.DrawRectangle(DashedPen, 0, 0, this.Width-1, this.Height-5);
        }

        private void AndGateContainer_MouseUp(object sender, MouseEventArgs e)
        {
            MoveGate = true;
        }

        private void AndGateContainer_MouseHover(object sender, EventArgs e)
        {
            if (Activate_ToolTip)
            {
                tooltip1.Show("You cannot overlap 2 gates", this);
            }
        }
    }
}
