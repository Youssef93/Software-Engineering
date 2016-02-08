using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Final_Simulator_Project
{
    public partial class Output : UserControl
    {
        public Rectangle intersecting_Rectangle = new Rectangle();
        public int Gate_Index;
        public int Gate_Type = 100;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        public bool On = false;
        Graphics g;
        public Thread t;
        public Output()
        {
            InitializeComponent();
        }

        private void Output_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            label2.Location = new Point(this.Width - 15, this.Height / 2 - 8);
            label1.Location = new Point(0, this.Height - 15);
            label1.Visible = false;
            Output_Letter();
            t = new Thread(Change_Back_Color);
            t.Start();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);
            SolidBrush sb = new SolidBrush(Color.Black);
            g = this.CreateGraphics();
            g.DrawEllipse(pen, this.Width - 30, this.Height / 2-5, 10, 10); // Circle
            g.DrawLine(pen, new Point(this.Width - 30, this.Height/2), new Point(this.Width - 77, this.Height / 2)); //Horizontal Line
            g.FillRectangle(sb, new Rectangle(0, this.Height / 2 - RectWidthAndHeight/2, RectWidthAndHeight, RectWidthAndHeight)); //Rectangle
            sb = new SolidBrush(Color.White);
            g.FillEllipse(sb, this.Width - 30, this.Height / 2 - 5, 10, 10);
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            intersecting_Rectangle.Location = new Point(this.Left, this.Top + this.Height / 2 - RectWidthAndHeight / 2);
            intersecting_Rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
        }
        public void Paint_Output()
        {
            Pen pen = new Pen(Color.Black, 1);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.Clear(Color.Beige);
            g = this.CreateGraphics();
            g.DrawEllipse(pen, this.Width - 30, this.Height / 2 - 5, 10, 10); // Circle
            g.DrawLine(pen, new Point(this.Width - 30, this.Height / 2), new Point(this.Width - 77, this.Height / 2)); //Horizontal Line
            g.FillRectangle(sb, new Rectangle(0, this.Height / 2 - RectWidthAndHeight / 2, RectWidthAndHeight, RectWidthAndHeight)); //Rectangle
            int num = 0;
            switch (On)
            {
                case true:
                    sb = new SolidBrush(Color.Green);
                    num = 1;
                    break;
                case false:
                    sb = new SolidBrush(Color.Red);
                    num = 0;
                    break;
            }
            g.FillEllipse(sb, this.Width - 30, this.Height / 2 - 5, 10, 10);
            label1.Visible = true;
            label1.Text = "Output is " + num.ToString();
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
            this.Parent.Controls.Remove(this);
            int index = Index_Of_This_Control();
            Reset_Connection_Bool(index);
            foreach (Output Temp_Output in Public_Static_Variables.Outputs_List)
            {
                Temp_Output.Output_Letter();
            }
        }

        public void Change_Location(Rectangle rectangle)
        {
            this.Location = new Point(rectangle.Left, rectangle.Top +RectWidthAndHeight +1 - this.Height/2);
        }
        public void Output_Letter()
        {
            int index = Index_Of_This_Control();
            label2.Text = "F" + index.ToString() + ")";
        }
        private int Index_Of_This_Control()
        {
            for (int i =0; i< Public_Static_Variables.Outputs_List.Count; i++)
            {
                if (Public_Static_Variables.Outputs_List.ElementAt(i).Location == this.Location)
                    return i;
            }
            return Public_Static_Variables.Outputs_List.Count;
        }
        public void Reset_Connection_Bool(int index)
        {
            t.Abort();
            Public_Static_Variables.Outputs_List.Remove(Public_Static_Variables.Outputs_List.ElementAt(index));
            if (Gate_Type == 0)
            {
                Public_Static_Variables.gatecontainer[Gate_Index].selectionRectangle3.Connected = false;
            }
            else if (Gate_Type == 1)
            {
                Public_Static_Variables.Nandgatecontainer[Gate_Index].selectionRectangle3.Connected = false;
            }
            else if (Gate_Type == 2)
            {
                Public_Static_Variables.Orgatecontainer[Gate_Index].selectionRectangle3.Connected = false;
            }
            else if (Gate_Type == 3)
            {
                Public_Static_Variables.Norgatecontainer[Gate_Index].selectionRectangle3.Connected = false;
            }
            else if (Gate_Type == 4)
            {
                Public_Static_Variables.XOrgatecontainer[Gate_Index].selectionRectangle3.Connected = false;
            }
            else if (Gate_Type == 5)
            {
                Public_Static_Variables.XNorgatecontainer[Gate_Index].selectionRectangle3.Connected = false;
            }
        }
        private void Change_Back_Color()
        {
            while (true)
            {
                if (Gate_Type == 0)
                {
                    for (;;)
                    {
                        if (Public_Static_Variables.gatecontainer[Gate_Index] != null)
                            this.BackColor = Public_Static_Variables.gatecontainer[Gate_Index].BackColor;
                    }
                }
                else if (Gate_Type == 1)
                {
                    for (;;)
                    {
                        if (Public_Static_Variables.Nandgatecontainer[Gate_Index] != null)
                            this.BackColor = Public_Static_Variables.Nandgatecontainer[Gate_Index].BackColor;
                    }
                }
                else if (Gate_Type == 2)
                {
                    for (;;)
                    {
                        if (Public_Static_Variables.Orgatecontainer[Gate_Index] != null)
                            this.BackColor = Public_Static_Variables.Orgatecontainer[Gate_Index].BackColor;
                    }
                }
                else if (Gate_Type == 3)
                {
                    for (;;)
                    {
                        if (Public_Static_Variables.Norgatecontainer[Gate_Index] != null)
                            this.BackColor = Public_Static_Variables.Norgatecontainer[Gate_Index].BackColor;
                    }
                }
                else if (Gate_Type == 4)
                {
                    for (;;)
                    {
                        if (Public_Static_Variables.XOrgatecontainer[Gate_Index] != null)
                            this.BackColor = Public_Static_Variables.XOrgatecontainer[Gate_Index].BackColor;
                    }
                }
                else if (Gate_Type == 5)
                {
                    for (;;)
                    {
                        if (Public_Static_Variables.XNorgatecontainer[Gate_Index] != null)
                            this.BackColor = Public_Static_Variables.XNorgatecontainer[Gate_Index].BackColor;
                    }
                }
            }
        }
    }
}
