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
        bool First_Time_Created = true;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        public bool Input_Connected_1 = false;
        public bool Input_Connected_2 = false;
        public int Input_Index_1;
        public int Input_Index_2;
        public AndGateContainer()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.Width = 30 + Public_Static_Variables.width; // Width of all gate
            this.Height = 20 + Public_Static_Variables.height; // height of all gate
            this.BackColor = Color.White;
        }

        protected override void OnLocationChanged(EventArgs e)
        {

            Control panel1 = this.Parent;
            // initialized all intersection rectangles
            Rectangle inputRect1 = new Rectangle(this.Left - 3 - Public_Static_Variables.RectWidthAndHeight, this.Top + 15 - Public_Static_Variables.RectWidthAndHeight / 2-2, Public_Static_Variables.RectWidthAndHeight+3, Public_Static_Variables.RectWidthAndHeight+2);// initialize first rectangle
            Rectangle inputRect2 = new Rectangle(this.Left - 8, this.Top + 10+ Public_Static_Variables.height -5 - Public_Static_Variables.RectWidthAndHeight/2-2, Public_Static_Variables.RectWidthAndHeight+3, Public_Static_Variables.RectWidthAndHeight+2);//initialize secind rectangle
            Rectangle outputRect = new Rectangle(this.Right -1, this.Top + 10 + Public_Static_Variables.height / 2 - Public_Static_Variables.RectWidthAndHeight/2-2, Public_Static_Variables.RectWidthAndHeight+3, Public_Static_Variables.RectWidthAndHeight+2);
            if (First_Time_Created)
            {
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;
                // created a rectangle at the same location of this container relative to the panel

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
                    this.Left = 15;
                }
                else if (this.Top <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = 10;
                }
                else if (this.Right >= panel1.Width)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Left = panel1.Width - 90 - Public_Static_Variables.width;
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

                int Current_Reset = Public_Static_Variables.Reset_draw_rect * 3;
                Public_Static_Variables.Connecting_Rectangles[Current_Reset - 2] = inputRect1;
                Public_Static_Variables.Connecting_Rectangles[Current_Reset - 1] = inputRect2;
                Public_Static_Variables.Connecting_Rectangles[Current_Reset] = outputRect;
                if (this.Left - 10 <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Left = 15;
                }
                else if (this.Top <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = 10;
                }
                else if (this.Right + 10 >= panel1.Width)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Left = this.Left - 20;
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
                if (Input_Connected_1)
                {
                    Public_Static_Variables.Inputs_List[Input_Index_1].Location = new Point(this.Left - Public_Static_Variables.Inputs_List[Input_Index_1].Width - 2, this.Top-1);
                }
                if (Input_Connected_2)
                {
                    Public_Static_Variables.Inputs_List[Input_Index_2].Location = new Point(this.Left - Public_Static_Variables.Inputs_List[Input_Index_2].Width - 2, this.Top +29);
                }
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
            Public_Static_Variables.DrawTempRectangle = false;
            for  (int i = 1; i<= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (Public_Static_Variables.gatecontainer[i].Location == this.Location)
                    Public_Static_Variables.Reset_draw_rect = i;
            }
            if (e.Button == MouseButtons.Left && MoveGate)
            {
                this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);
            int width = Public_Static_Variables.width;
            int height = Public_Static_Variables.height;
            int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
            int X, Y;
            X = 27;
            Y = 10;
            Graphics g = this.CreateGraphics();
            g.DrawPie(pen, X - (width / 2), Y, width, height, 270, 180); //curve
            g.DrawLine(pen, new Point(X, Y + 5), new Point(0, Y + 5));// first horizontal line
            g.DrawLine(pen, new Point(X, Y + width - 5), new Point(0, Y + width - 5));// Second Horizontal line
            g.DrawLine(pen, new Point(X + (width / 2), Y + (height / 2)), new Point(this.Width, Y + (height / 2)));// last horizontal line
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
            MyPanel.Delete_gate(Public_Static_Variables.Reset_draw_rect);
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
