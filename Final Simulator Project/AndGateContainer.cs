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
       
        public static Point [] ContainerScreenLocation = new Point[50];
        Point MovingPoint;
        Point CheckLocation;
        public static bool MouseMove = false;
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
            // initialized all intersection rectangles
            Rectangle inputRect1 = new Rectangle(this.Left + 40 - 30 - GateVariables.RectWidthAndHeight, this.Left + 40 + GateVariables.RectWidthAndHeight / 2, GateVariables.RectWidthAndHeight, GateVariables.RectWidthAndHeight);// initialize first rectangle
            Rectangle inputRect2 = new Rectangle(this.Left + 40 - 30 - GateVariables.RectWidthAndHeight, this.Left + 40 + GateVariables.RectWidthAndHeight + GateVariables.height - 12, GateVariables.RectWidthAndHeight, GateVariables.RectWidthAndHeight);//initialize secind rectangle
            Rectangle outputRect = new Rectangle(this.Left + 40 + GateVariables.width / 2 + 30 - GateVariables.RectWidthAndHeight + 5, this.Left + 40 + GateVariables.height / 2 - GateVariables.RectWidthAndHeight + 3, GateVariables.RectWidthAndHeight, GateVariables.RectWidthAndHeight);
            if (!MouseMove)
            {
                Control panel1 = this.Parent;
                Form1.ContainerRectangle[Form1.gatecontainer_counter].Width = GateVariables.width; ;
                Form1.ContainerRectangle[Form1.gatecontainer_counter].Height = GateVariables.height;

                Form1.ContainerRectangle[Form1.gatecontainer_counter].Location = new Point(this.Left + 40, this.Top + 10);
                // created a rectangle at the same location of this container relative to the panel
                ContainerScreenLocation[Form1.gatecontainer_counter] = new Point(Form1.ContainerRectangle[Form1.gatecontainer_counter].X, Form1.ContainerRectangle[Form1.gatecontainer_counter].Y);
                // created a point of the location of the rectangle relative to the panel

                // making  the intersection rectangles
                Form1.Connecting_Rectangles[Form1.Connecting_Rectangles_Counter] = inputRect1;
                Form1.Connecting_Rectangles_Counter++;
                Form1.Connecting_Rectangles[Form1.Connecting_Rectangles_Counter] = inputRect2;
                Form1.Connecting_Rectangles_Counter++;
                Form1.Connecting_Rectangles[Form1.Connecting_Rectangles_Counter] = outputRect;
                Form1.Connecting_Rectangles_Counter++;
                MessageBox.Show("Here");
            }
            else
            {
                Control panel1 = this.Parent;
                Form1.ContainerRectangle[Form1.Reset_draw_rect].Width = GateVariables.width;
                Form1.ContainerRectangle[Form1.Reset_draw_rect].Height = GateVariables.height;

                Form1.ContainerRectangle[Form1.Reset_draw_rect].Location = new Point(this.Left + 40, this.Top + 10);
                // created a rectangle at the same location of this container relative to the panel
                ContainerScreenLocation[Form1.Reset_draw_rect] = new Point(Form1.ContainerRectangle[Form1.Reset_draw_rect].X, Form1.ContainerRectangle[Form1.Reset_draw_rect].Y);
                //created a point of the location of the rectangle relative to the panel
                int Current_Reset = Form1.Reset_draw_rect * 3;
                Form1.Connecting_Rectangles[Current_Reset - 2] = inputRect1;
                Form1.Connecting_Rectangles[Current_Reset - 1] = inputRect2;
                Form1.Connecting_Rectangles[Current_Reset] = outputRect;
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
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(this.Left + (e.X - MovingPoint.X), this.Top + (e.Y - MovingPoint.Y));
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
    }
}
