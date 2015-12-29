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
    public partial class SelectionRectangle : UserControl
    {
        
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        Rectangle Inner_Rectangle;
        public bool right = true;
        Graphics g;
        int Temp_Counter;
        public bool Connected = false;
        public SelectionRectangle()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.Width = 13;
            this.Height =13;
            Inner_Rectangle = new Rectangle();
            Inner_Rectangle.Location = new Point(4, 4);
            Inner_Rectangle.Size = new Size(RectWidthAndHeight, RectWidthAndHeight);
            this.BackColor = Color.White;
            g = this.CreateGraphics();
        }
        //protected override void WndProc(ref Message m)    //disables all events
        //{
        //    const int WM_NCHITTEST = 0x0084;
        //    const int HTTRANSPARENT = (-1);

        //    if (m.Msg == WM_NCHITTEST)
        //    {
        //        m.Result = (IntPtr)HTTRANSPARENT;
        //    }
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);
            g.FillRectangle(sb, Inner_Rectangle);
            if (right)
            {
                g.DrawLine(pen, new Point(9, this.Height / 2), new Point(this.Width, this.Height / 2));
            }
            else
            {
                g.DrawLine(pen, new Point(8, this.Height / 2), new Point(0, this.Height / 2));
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightGreen;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Add_Wires_To_List();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!this.ClientRectangle.Contains(new Point(e.X, e.Y)) && e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                p = PointToScreen(p);
                Control andgate = this.Parent;
                Control panel1 = andgate.Parent;
                p = panel1.PointToClient(MousePosition);
                
                for  (int i =1; i<=Public_Static_Variables.gatecontainer_counter*3; i++)
                {
                    if (Public_Static_Variables.Screen_Connecting_Rectangles[i].Contains(p))
                    {
                       if(i%3 == 0)
                        {
                            Public_Static_Variables.gatecontainer[i / 3].selectionRectangle3.BackColor = Color.LightGreen;
                        }
                       else if (i%3 == 1)
                        {
                            Public_Static_Variables.gatecontainer[i / 3 +1].selectionRectangle1.BackColor = Color.LightGreen;
                        }
                       else
                        {
                            Public_Static_Variables.gatecontainer[i / 3 + 1].selectionRectangle2.BackColor = Color.LightGreen;
                        }
                        Temp_Counter = i;
                    }
                    //else
                    //{
                    //    Public_Static_Variables.gatecontainer[i / 3 + 1].selectionRectangle1.BackColor = Color.White;
                    //    Public_Static_Variables.gatecontainer[i / 3 + 1].selectionRectangle2.BackColor = Color.White;
                    //    //Public_Static_Variables.gatecontainer[i / 3 ].selectionRectangle3.BackColor = Color.White;
                    //}
                }
            }

        }
       
        public void Enter_Color()
        {
            this.BackColor = Color.LightBlue;
        }
        public void Leave_color()
        {
            this.BackColor = Color.White;
        }
        void Add_Wires_To_List()
        {
            int Current_Index;
            Control andgate = this.Parent;
            Control panel1 = andgate.Parent;
            Rectangle rectangle = new Rectangle();
            rectangle = this.ClientRectangle;
            rectangle = RectangleToScreen(rectangle);
            rectangle = panel1.RectangleToClient(rectangle);
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter * 3; i++)
            {
                if (Public_Static_Variables.Screen_Connecting_Rectangles[i].IntersectsWith(rectangle))
                {
                    Current_Index = i;
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Current_Index);
                    Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Add(Temp_Counter);
                    MyPanel.Add_Wires_To_Panel(Current_Index, Temp_Counter,panel1);
                    this.Connected = true;
                    if (i%3 == 0)
                    {
                        Public_Static_Variables.gatecontainer[i / 3].selectionRectangle3.Connected = true;
                    }
                    else if (i%3 == 1)
                    {
                        Public_Static_Variables.gatecontainer[i / 3 + 1].selectionRectangle1.Connected = true;
                    }
                    else
                    {
                        Public_Static_Variables.gatecontainer[i / 3 + 1].selectionRectangle2.Connected = true;
                    }
                    break;
                }
            }
        }
    }
}
