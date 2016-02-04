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
    public partial class Output : UserControl
    {
        public Rectangle intersecting_Rectangle = new Rectangle();
        public int Gate_Index;
        public int Gate_Type;
        public int Rectangle_Index;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        public bool On = false;
        Graphics g;
        public Output()
        {
            InitializeComponent();
        }

        private void Output_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
            label2.Location = new Point(this.Width - 15, this.Height / 2 - 8);
            label1.Location = new Point(0, this.Height - 15);
            label1.Visible = false;
            label2.Visible = false;
            Output_Letter();
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
        public void Change_Location(Rectangle rectangle)
        {
        }
        public void Output_Letter()
        {
            int index = Index_Of_This_Control();
            index = 65 + index;
            char text = (char)index;
            label2.Text = text.ToString() + ")";
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
    }
}
