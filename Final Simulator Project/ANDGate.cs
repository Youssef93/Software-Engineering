using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    class ANDGate
    {
        // x,y is the midpoint of the vertical line of the AND gate
        public static int width = 40; //width of gate
        public static int height = 40; //height of gate
        public int RectWidthAndHeight = 5; //Do NOT change this number , width and height of intersecting rectangles
        public ANDGate(Form Form1)
        {
            Drawing_Gates(Form1);
        }
        public virtual void Drawing_Gates(Form Form1)
        {
            int X, Y;
            X = GateContainer.ContainerScreenLocation.X + 40;
            Y = GateContainer.ContainerScreenLocation.Y + 10;
            Pen pen = new Pen(Color.Black, 1);
            SolidBrush sb = new SolidBrush(Color.Black);
            Graphics g = Form1.CreateGraphics();
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

            
        }
    }
}
