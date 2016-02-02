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
            // assigning the index of this control in the list
            //index = Public_Static_Variables.Input_Counter;
            Input_Letter();
            label1.Visible = false;
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
        void Input_Letter()
        {
            //int mynumber = (int)'A' + index;
            //char text = (char)mynumber;
            //label1.Text = text.ToString() + ")";
        }
        private void Menuitem_Click(object sender, EventArgs e)
        {

        }
        public void Change_Location (Rectangle rectangle)
        {
            this.Location = new Point(rectangle.Left + RectWidthAndHeight +5 - this.Width, rectangle.Top + this.Height / 2 + RectWidthAndHeight - this.Height);
        }
    }
}
