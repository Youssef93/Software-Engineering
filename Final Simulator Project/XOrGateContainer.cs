using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    class XOrGateContainer : Gates
    {
        public XOr_SelectionRectangle selectionRectangle1 = new XOr_SelectionRectangle();
        public XOr_SelectionRectangle selectionRectangle2 = new XOr_SelectionRectangle();
        public XOr_SelectionRectangle selectionRectangle3 = new XOr_SelectionRectangle();
        public Rectangle Connecting_Rectangle_1 = new Rectangle();
        public Rectangle Connecting_Rectangle_2 = new Rectangle();
        public Rectangle Connecting_Rectangle_3 = new Rectangle();
        protected override void OnLoad(EventArgs e)
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

            //value here changes for every gate
            Change_Location(4, panel1, Connecting_Rectangle_1, Connecting_Rectangle_2, Connecting_Rectangle_3);
            Set_Screen_Connecting_Rectangles(ref Connecting_Rectangle_1, ref Connecting_Rectangle_2, ref Connecting_Rectangle_3);

            foreach (INPUT Temp_input in Public_Static_Variables.Inputs_List)
            {
                if (Temp_input.Gate_Type == 4 && Temp_input.Gate_Index == Public_Static_Variables.Reset_draw_rect)
                {
                    switch (Temp_input.Rectangle_Index)
                    {
                        case 1:
                            Temp_input.Change_Location(Connecting_Rectangle_1);
                            break;
                        case 2:
                            Temp_input.Change_Location(Connecting_Rectangle_2);
                            break;
                    }
                    if (Temp_input.Left <= 0)
                    {
                        MessageBox.Show("Cannot place any input outside the panel");
                        this.Left = Temp_input.Width + 5;
                    }
                }
            }
            foreach (Output Temp_Output in Public_Static_Variables.Outputs_List)
            {
                if (Temp_Output.Gate_Type == 4 && Temp_Output.Gate_Index == Public_Static_Variables.Reset_draw_rect)
                {
                    Temp_Output.Change_Location(Connecting_Rectangle_3);
                    if (Temp_Output.Right >= panel1.Width)
                    {
                        MessageBox.Show("Cannot place any output outside the panel");
                        this.Left = this.Left - 30;
                    }
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
           
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
            X = 40;
            Y = 10;
            Graphics g = this.CreateGraphics();
            g.DrawArc(pen, X - 5, Y, 10, height, 270, 180); // small arc
            g.DrawArc(pen, X - 10, Y, 10, height, 270, 180); // shifted small arc
            g.DrawArc(pen, X - 20, Y, 40, height, 270, 180); // Big arc
            g.DrawLine(pen, new Point(X + 2, Y + 5), new Point(X - 25, Y + 5));// first horizontal line
            g.DrawLine(pen, new Point(X + 2, Y + width - 5), new Point(X - 25, Y + width - 5));// Second Horizontal line
            g.DrawLine(pen, new Point(X + (width / 2), Y + (height / 2)), new Point(X + width, Y + (height / 2)));// last horizontal line
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
            {
                if (Public_Static_Variables.XOrgatecontainer[i].Location == this.Location)
                {
                    Public_Static_Variables.Reset_draw_rect = i;
                    break;
                }
            }
            Change_Back_Color(Color.LightBlue, 4, Public_Static_Variables.Reset_draw_rect);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            Change_Back_Color(Color.White, 4, Public_Static_Variables.Reset_draw_rect);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            ContextMenu menu = new ContextMenu();
            MenuItem menuitem = new MenuItem("Delete");
            menuitem.Click += Menuitem_Click;
            menu.MenuItems.Add(menuitem);
            this.ContextMenu = menu;
        }
        private void Menuitem_Click(object sender, EventArgs e)
        {
            int num = Public_Static_Variables.Reset_draw_rect;

            //value is modified here for each gate
            Control panel1 = Public_Static_Variables.XOrgatecontainer[num].Parent;
            panel1.Controls.Remove(Public_Static_Variables.XOrgatecontainer[num]);

            int current_index = Public_Static_Variables.Reset_draw_rect;

            //value is modified here for each gate
            Do_My_Condition(panel1, 4, current_index);
            System.Threading.Thread.Sleep(10);

            //value is modified here for every Gate
            bool ResetNumberOfGates = true;
            foreach (Control Gate in panel1.Controls)
            {
                if (Gate.GetType() == typeof(XOrGateContainer))
                {
                    ResetNumberOfGates = false;
                    break;
                }
            }
            if (ResetNumberOfGates)
            {
                Public_Static_Variables.XOrgatecontainer_counter = 0;
                Array.Clear(Public_Static_Variables.XOrgatecontainer, 0, Public_Static_Variables.XOrgatecontainer.Length);
                Public_Static_Variables.XOrgatecontainer = new XOrGateContainer[50];
            }
        }
    }
}
