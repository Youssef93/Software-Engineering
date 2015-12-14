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
        bool MoveGate = true;
        bool Activate_ToolTip = false;
        ToolTip tooltip1 = new ToolTip();
        public AndGateContainer()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.Width = 55 + Public_Static_Variables.width; // Width of all gate
            this.Height = 20 + Public_Static_Variables.height; // height of all gate
            this.Visible = false;
           
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            
            Control panel1 = this.Parent;
            // initialized all intersection rectangles
            Rectangle inputRect1 = new Rectangle(this.Left + 10 - Public_Static_Variables.RectWidthAndHeight-2, this.Top + 15 - Public_Static_Variables.RectWidthAndHeight / 2-2, Public_Static_Variables.RectWidthAndHeight+2, Public_Static_Variables.RectWidthAndHeight+2);// initialize first rectangle
            Rectangle inputRect2 = new Rectangle(this.Left + 10 - Public_Static_Variables.RectWidthAndHeight-2, this.Top + 10+ Public_Static_Variables.height -5 - Public_Static_Variables.RectWidthAndHeight/2-2, Public_Static_Variables.RectWidthAndHeight+2, Public_Static_Variables.RectWidthAndHeight+2);//initialize secind rectangle
            Rectangle outputRect = new Rectangle(this.Left + 40 + Public_Static_Variables.width+10-2, this.Top + 10 + Public_Static_Variables.height / 2 - Public_Static_Variables.RectWidthAndHeight/2-2, Public_Static_Variables.RectWidthAndHeight+2, Public_Static_Variables.RectWidthAndHeight+2);
            if (!Public_Static_Variables.MouseMove)
            {
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;

                Public_Static_Variables.ContainerRectangle[Public_Static_Variables.gatecontainer_counter].Width = Public_Static_Variables.width; ;
                Public_Static_Variables.ContainerRectangle[Public_Static_Variables.gatecontainer_counter].Height = Public_Static_Variables.height;
                Public_Static_Variables.ContainerRectangle[Public_Static_Variables.gatecontainer_counter].Location = new Point(this.Left + 40, this.Top + 10);
                // created a rectangle at the same location of this container relative to the panel
                Public_Static_Variables.ContainerScreenLocation[Public_Static_Variables.gatecontainer_counter] = new Point(Public_Static_Variables.ContainerRectangle[Public_Static_Variables.gatecontainer_counter].X, Public_Static_Variables.ContainerRectangle[Public_Static_Variables.gatecontainer_counter].Y);
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
            }
            else
            {
                // first, initialize a rectangle that contains the current location of the control before moving it
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;

                Public_Static_Variables.ContainerRectangle[Public_Static_Variables.Reset_draw_rect].Width = Public_Static_Variables.width;
                Public_Static_Variables.ContainerRectangle[Public_Static_Variables.Reset_draw_rect].Height = Public_Static_Variables.height;
                Public_Static_Variables.ContainerRectangle[Public_Static_Variables.Reset_draw_rect].Location = new Point(this.Left + 40, this.Top + 10);
                // created a rectangle at the same location of this container relative to the panel
                Public_Static_Variables.ContainerScreenLocation[Public_Static_Variables.Reset_draw_rect] = new Point(Public_Static_Variables.ContainerRectangle[Public_Static_Variables.Reset_draw_rect].X, Public_Static_Variables.ContainerRectangle[Public_Static_Variables.Reset_draw_rect].Y);
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
                        if (i != Public_Static_Variables.Reset_draw_rect)
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
            Public_Static_Variables.DoThread = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);
            Pen DashedPen = new Pen(Color.Black);
            float[] dashValues = { 2, 2, 2, 2 };
            DashedPen.DashPattern = dashValues;
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
            Delete_Gate(Public_Static_Variables.Reset_draw_rect);
        }
        void Delete_Gate(int num)
        {
            // this for loop deletes the lines connected with the deleted gate
            for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 2)
            {
                int number1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                int number2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                int local_comparisor = num * 3;
                if (number1 == local_comparisor || number1 == local_comparisor - 1 || number1 == local_comparisor - 2 || number2 == local_comparisor || number2 == local_comparisor - 1 || number2 == local_comparisor - 2)
                {
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i, 2);
                }
            }
            // this for loop deletes the gate itself
            for (int i = num; i < Public_Static_Variables.gatecontainer_counter; i++)
                {
                    Public_Static_Variables.Deleted_Gate = true;
                    Public_Static_Variables.gatecontainer[i].Location = Public_Static_Variables.gatecontainer[i + 1].Location;
                }
                Public_Static_Variables.Connecting_Rectangles_Counter = Public_Static_Variables.Connecting_Rectangles_Counter - 3;
                Public_Static_Variables.Deleted_Gate = false;
                Public_Static_Variables.gatecontainer_counter--;
                Public_Static_Variables.DoThread = true;
        }
    }
}
