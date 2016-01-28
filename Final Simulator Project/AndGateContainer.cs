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
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        public And_SelectionRectangle selectionRectangle1 = new And_SelectionRectangle();
        public And_SelectionRectangle selectionRectangle2 = new And_SelectionRectangle();
        public And_SelectionRectangle selectionRectangle3 = new And_SelectionRectangle();
        public Rectangle Connecting_Rectangle_1 = new Rectangle();
        public Rectangle Connecting_Rectangle_2 = new Rectangle();
        public Rectangle Connecting_Rectangle_3 = new Rectangle();
        public AndGateContainer()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.Width = 50 + Public_Static_Variables.width; // Width of all gate
            this.Height = 20 + Public_Static_Variables.height; // height of all gate
            this.BackColor = Color.White;
            this.Controls.Add(selectionRectangle1);
            this.Controls.Add(selectionRectangle2);
            this.Controls.Add(selectionRectangle3);
            selectionRectangle1.Location = new Point(15 - selectionRectangle1.Width, 15 - selectionRectangle1.Height / 2);
            selectionRectangle2.Location = new Point(15 - selectionRectangle2.Width, 5 - selectionRectangle2.Height / 2 + Public_Static_Variables.height);
            selectionRectangle3.Location = new Point(40 + Public_Static_Variables.width - 2, 10 + Public_Static_Variables.height / 2 - 6);
            selectionRectangle3.right = false;
            this.SendToBack();
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            Control panel1 = this.Parent;
            if (First_Time_Created)
            {
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;
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
                Set_Screen_Connecting_Rectangles();
                System.Threading.Thread.Sleep(10);
                First_Time_Created = false;
            }
            else
            {
                // first, initialize a rectangle that contains the current location of the control before moving it
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;

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
                else if (this.Right  >= panel1.Width)
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
                            MyAndGate local_Control = Public_Static_Variables.gatecontainer[i];
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
                for (int i =0; i< Public_Static_Variables.Input_Connected_Gates_Indexes.Count; i = i + 2)
                {
                
                    int index = Public_Static_Variables.Input_Connected_Gates_Indexes.ElementAt(i);
                    if (index == Public_Static_Variables.Reset_draw_rect)
                    {
                        if (Public_Static_Variables.Input_Connected_Gates_Indexes.ElementAt(i + 1) == 1)
                        {
                            Public_Static_Variables.Inputs_List[i / 2].Location = new Point(this.Left - Public_Static_Variables.Inputs_List[i / 2].Width + 9, this.Top - 1);
                          
                        }
                        else
                        {
                            Public_Static_Variables.Inputs_List[i / 2].Location = new Point(this.Left - Public_Static_Variables.Inputs_List[i / 2].Width + 10, this.Top + Public_Static_Variables.Inputs_List[i / 2].Height - 3);
                        }
                    }
                    if (Public_Static_Variables.Inputs_List[i / 2].Left -1<= 0)
                    {
                        MessageBox.Show("Cannot put the input outisde the panel");
                        this.Location = new Point(this.Location.X + 10, this.Location.Y);
                    }
                }
                Set_Screen_Connecting_Rectangles();
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
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
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
            SolidBrush sb = new SolidBrush(Color.Black);
            int width = Public_Static_Variables.width;
            int height = Public_Static_Variables.height;
            int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
            int X, Y;
            X = 40;
            Y = 10;
            Graphics g = this.CreateGraphics();
            g.DrawPie(pen, X - (width / 2), Y, width, height, 270, 180); //curve
            g.DrawLine(pen, new Point(X, Y + 5), new Point(X - 25, Y + 5));// first horizontal line
            g.DrawLine(pen, new Point(X, Y + width - 5), new Point(X - 25, Y + width - 5));// Second Horizontal line
            g.DrawLine(pen, new Point(X + (width / 2), Y + (height / 2)), new Point(X + width, Y + (height / 2)));// last horizontal line
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            MoveGate = true;
        }
        protected override void OnMouseHover(EventArgs e)
        {
            if (Activate_ToolTip)
            {
                tooltip1.Show("You cannot overlap 2 gates", this);
            }
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

            int num = Public_Static_Variables.Reset_draw_rect;
            Control panel1 = Public_Static_Variables.gatecontainer[num].Parent;
            panel1.Controls.Remove(Public_Static_Variables.gatecontainer[num]);

            bool Do_While_bool = false;
            int current_index = Public_Static_Variables.Reset_draw_rect;
            do
            {
                Do_While_bool = false;

                for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 4)
                {
                    int Gate_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                    int Rectangle_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                    int Gate_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 2);
                    int Rectangle_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3);
                    if (current_index == Gate_Index_1 || current_index == Gate_Index_2)
                    {
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i, 4);
                        panel1.Controls.Remove(Public_Static_Variables.wires[i / 4]);
                        Public_Static_Variables.wires.RemoveAt(i / 4);
                        Do_While_bool = true;
                        switch (Rectangle_Index_1)
                        {
                            case 1:
                                Public_Static_Variables.gatecontainer[Gate_Index_1].selectionRectangle1.Connected = false;
                                break;
                            case 2:
                                Public_Static_Variables.gatecontainer[Gate_Index_1].selectionRectangle2.Connected = false;
                                break;
                            case 3:
                                Public_Static_Variables.gatecontainer[Gate_Index_1].selectionRectangle3.Connected = false;
                                break;
                        }
                        switch (Rectangle_Index_2)
                        {
                            case 1:
                                Public_Static_Variables.gatecontainer[Gate_Index_2].selectionRectangle1.Connected = false;
                                break;
                            case 2:
                                Public_Static_Variables.gatecontainer[Gate_Index_2].selectionRectangle2.Connected = false;
                                break;
                            case 3:
                                Public_Static_Variables.gatecontainer[Gate_Index_2].selectionRectangle3.Connected = false;
                                break;
                        }
                        break;
                    }
                }
            }
            while (Do_While_bool);

            if (panel1.Controls.Count == 0)
            {
                Public_Static_Variables.gatecontainer_counter = 0;
                Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
                Public_Static_Variables.gatecontainer = new MyAndGate[50];
                Public_Static_Variables.gatecontainer_created = false;
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            selectionRectangle1.Enter_Color();
            selectionRectangle2.Enter_Color();
            selectionRectangle3.Enter_Color();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.White;
            selectionRectangle1.Leave_color();
            selectionRectangle2.Leave_color();
            selectionRectangle3.Leave_color();
        }
        void Set_Screen_Connecting_Rectangles()
        {
             Connecting_Rectangle_1 = new Rectangle(15 - selectionRectangle1.Width, 15 - selectionRectangle1.Height / 2, selectionRectangle1.Width, selectionRectangle1.Height);// initialize first rectangle
             Connecting_Rectangle_2 = new Rectangle(15 - selectionRectangle2.Width, 5 - selectionRectangle2.Height / 2 + Public_Static_Variables.height, selectionRectangle1.Width, selectionRectangle1.Height);//initialize secind rectangle
             Connecting_Rectangle_3 = new Rectangle(40 + Public_Static_Variables.width - 2, 10 + Public_Static_Variables.height / 2 - 6, selectionRectangle1.Width, selectionRectangle1.Height);
            int index;
            if (First_Time_Created)
            {
                index = Public_Static_Variables.gatecontainer_counter;
            }
            else
            {
                index = Public_Static_Variables.Reset_draw_rect;
            }
            Control panel1 = this.Parent;
            Connecting_Rectangle_1 = RectangleToScreen(Connecting_Rectangle_1);
            Connecting_Rectangle_2 = RectangleToScreen(Connecting_Rectangle_2);
            Connecting_Rectangle_3 = RectangleToScreen(Connecting_Rectangle_3);

            Connecting_Rectangle_1 = panel1.RectangleToClient(Connecting_Rectangle_1);
            Connecting_Rectangle_2 = panel1.RectangleToClient(Connecting_Rectangle_2);
            Connecting_Rectangle_3 = panel1.RectangleToClient(Connecting_Rectangle_3);
        }
    }
}
