using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Final_Simulator_Project
{
    public partial class Form1 : Form
    {
        public static bool gatecontainer_created = false;
        GateContainer [] gatecontainer = new GateContainer[50];
        int gatecontainer_counter = 0;
        public static Point point;
        Graphics g;
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        public static int Reset_draw_rect = 0;
        int width = GateVariables.width;
        int height = GateVariables.height;
        int RectWidthAndHeight = GateVariables.RectWidthAndHeight;
        bool drawFirstGate = false;
        Rectangle[] GatesRectnagle = new Rectangle[50];
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < gatecontainer_counter; i++)
            {
                if (GatesRectnagle[i].Contains(new Point(e.X, e.Y)) && gatecontainer_created)
                {
                    gatecontainer[i].Visible = true;
                    Reset_draw_rect = i;
                    gatecontainer[i].LocationChanged += Reset_Draw_Rect;

                }
                else if (gatecontainer_created)
                {
                    gatecontainer[i].Visible = false;
                }
            }
        }

        private void Reset_Draw_Rect(object sender, EventArgs e)
        {
            GatesRectnagle[Reset_draw_rect] = GateContainer.ContainerRectangle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gatecontainer [gatecontainer_counter]= new GateContainer();
            panel1.Controls.Add(gatecontainer[gatecontainer_counter]);
            gatecontainer[gatecontainer_counter].Location = new Point(100, 100);
            gatecontainer_created = true;
            drawFirstGate = true;
            SaveGate();
            gatecontainer_counter++;
        }
        public void SaveGate()
        {
            GatesRectnagle[gatecontainer_counter] = GateContainer.ContainerRectangle;
        }

        public void Draw()
        {
            while (true)
            {
                if (drawFirstGate)
                {
                    
                    // drawing the and gate starts here
                    int X, Y;
                    // x,y is the top point of the vertical line of the AND gate
                    X = GateContainer.ContainerScreenLocation.X + 40;
                    Y = GateContainer.ContainerScreenLocation.Y + 10;
                    Rectangle inputRect1 = new Rectangle(X - 30 - RectWidthAndHeight, Y + RectWidthAndHeight / 2, RectWidthAndHeight, RectWidthAndHeight);// initialize first rectangle
                    Rectangle inputRect2 = new Rectangle(X - 30 - RectWidthAndHeight, Y + RectWidthAndHeight + height - 12, RectWidthAndHeight, RectWidthAndHeight);//initialize secind rectangle
                    Rectangle outputRect = new Rectangle(X + width / 2 + 30 - RectWidthAndHeight + 5, Y + height / 2 - RectWidthAndHeight + 3, RectWidthAndHeight, RectWidthAndHeight);
                    g.Clear(Color.FromKnownColor(KnownColor.Control));
                    g.DrawPie(pen, X - (width / 2), Y, width, height, 270, 180); //curve
                    g.DrawLine(pen, new Point(X, Y + 5), new Point(X - 30, Y + 5));// first horizontal line
                    g.DrawLine(pen, new Point(X, Y + width - 5), new Point(X - 30, Y + width - 5));// Second Horizontal line
                    g.DrawLine(pen, new Point(X + (width / 2), Y + (height / 2)), new Point(X + (width / 2) + 30, Y + (height / 2)));// last horizontal line
                    g.FillRectangle(sb, inputRect1); // first rectangle
                    g.FillRectangle(sb, inputRect2);// second rectangle
                    g.FillRectangle(sb, outputRect);//output rectangle
                    System.Threading.Thread.Sleep(300);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            Thread t = new Thread(Draw);
            t.Start();
        }
    }
}
