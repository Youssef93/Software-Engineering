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
    public partial class input : UserControl
    {
        public Rectangle intersecting_Rectangle = new Rectangle();
        public int Gate_Index;
        public int Gate_Type;
        public int Rectangle_Index;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        public input()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.BackColor = Color.White;
            intersecting_Rectangle.Location = new Point(this.Right - RectWidthAndHeight, this.Bottom - this.Height / 2 - RectWidthAndHeight / 2);
            intersecting_Rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
            radioButton1.Select();
            Input_Letter();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.DrawLine(pen, new Point(radioButton1.Right, radioButton1.Top + radioButton1.Height / 2), new Point(radioButton1.Right + 10, radioButton1.Top + radioButton1.Height / 2)); // first horizontal line
            g.DrawLine(pen, new Point(radioButton2.Right, radioButton2.Top + radioButton2.Height / 2), new Point(radioButton2.Right + 10, radioButton2.Top + radioButton2.Height / 2)); //second horizontal line
            g.DrawLine(pen, new Point(radioButton1.Right + 10, radioButton1.Top + radioButton1.Height / 2), new Point(radioButton2.Right + 10, radioButton2.Top + radioButton2.Height / 2)); // vertical line
            int y = this.Height/2;
            g.DrawLine(pen, new Point(radioButton1.Right + 10, y), new Point(this.Width, y)); //last horizontal line
            Rectangle rectangle = new Rectangle();
            rectangle.Location = new Point(this.Width- RectWidthAndHeight, y - RectWidthAndHeight/2);
            rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
            g.FillRectangle(sb, rectangle);
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            intersecting_Rectangle.Location = new Point(this.Right - RectWidthAndHeight, this.Bottom - this.Height / 2 - RectWidthAndHeight / 2);
            intersecting_Rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
            //if (this.Left <= 0)
            //{
            //    MessageBox.Show("Cannot place any control outside the panel");
            //    Rectangle rectangle = new Rectangle();
            //    rectangle = intersecting_Rectangle;
            //    rectangle.Location = new Point(10+this.Width, rectangle.Location.Y);
            //    Change_Location(rectangle);
            //}
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            ContextMenu menu = new ContextMenu();
            MenuItem menuitem = new MenuItem("Delete");
            menuitem.Click += Menuitem_Click;
            menu.MenuItems.Add(menuitem);
            this.ContextMenu = menu;
        }
        public void Input_Letter()
        {
            int index = Index_Of_This_Control();
            index = 65 + index;
            char text = (char)index;
            label1.Text = text.ToString() + ")";
        }
        private void Menuitem_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            int index = Index_Of_This_Control();
            Reset_Connection_Bool(index);
            foreach (input Temp_Input in Public_Static_Variables.Inputs_List)
            {
                Temp_Input.Input_Letter();
            }
        }
        public void Change_Location (Rectangle rectangle)
        {
            this.Location = new Point(rectangle.Left + RectWidthAndHeight +5 - this.Width, rectangle.Top + this.Height / 2 + RectWidthAndHeight - this.Height);
        }
        private int Index_Of_This_Control()
        {
            for (int i = 0; i< Public_Static_Variables.Inputs_List.Count; i++)
            {
                if (Public_Static_Variables.Inputs_List.ElementAt(i).Location == this.Location)
                {
                    return i;
                }
            }
            return Public_Static_Variables.Inputs_List.Count;
        }
        public void Reset_Connection_Bool(int index)
        {
                Public_Static_Variables.Inputs_List.Remove(Public_Static_Variables.Inputs_List.ElementAt(index));
                if (Gate_Type == 0)
                {
                    switch (Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.gatecontainer[Gate_Index].selectionRectangle1.Connected = false;
                            break;
                        case 2:
                            Public_Static_Variables.gatecontainer[Gate_Index].selectionRectangle2.Connected = false;
                            break;
                    }
                }
                else if (Gate_Type == 1)
                {
                    switch (Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.Notgatecontainer[Gate_Index].selectionRectangle1.Connected = false;
                            break;
                        case 2:
                            Public_Static_Variables.Notgatecontainer[Gate_Index].selectionRectangle2.Connected = false;
                            break;
                    }
                }
                else if (Gate_Type == 2)
                {
                    switch (Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.Orgatecontainer[Gate_Index].selectionRectangle1.Connected = false;
                            break;
                        case 2:
                            Public_Static_Variables.Orgatecontainer[Gate_Index].selectionRectangle2.Connected = false;
                            break;
                    }
                }
                else if (Gate_Type == 3)
                {
                    switch (Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.Norgatecontainer[Gate_Index].selectionRectangle1.Connected = false;
                            break;
                        case 2:
                            Public_Static_Variables.Norgatecontainer[Gate_Index].selectionRectangle2.Connected = false;
                            break;
                    }
                }
                else if (Gate_Type == 4)
                {
                    switch (Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.XOrgatecontainer[Gate_Index].selectionRectangle1.Connected = false;
                            break;
                        case 2:
                            Public_Static_Variables.XOrgatecontainer[Gate_Index].selectionRectangle2.Connected = false;
                            break;
                    }
                }
                else if (Gate_Type == 5)
                {
                    switch (Rectangle_Index)
                    {
                        case 1:
                            Public_Static_Variables.XNorgatecontainer[Gate_Index].selectionRectangle1.Connected = false;
                            break;
                        case 2:
                            Public_Static_Variables.XNorgatecontainer[Gate_Index].selectionRectangle2.Connected = false;
                            break;
                    }
                }
            }
        }
}
