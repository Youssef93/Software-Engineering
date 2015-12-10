using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndGate._0._1
{
    public partial class AndGateee : UserControl
    {
        public AndGateee()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen p = new Pen(Color.DarkBlue);
            SolidBrush sb = new SolidBrush(Color.DarkBlue);
            Graphics g = this.CreateGraphics();
            Point[] line1 = { new Point(6, 25), new Point(20, 25) };
            Point[] line2 = { new Point(6, 40), new Point(20, 40) };
            Point[] line3 = { new Point(20, 20), new Point(20, 45) };
            Point[] line4 = { new Point(20, 20), new Point(35, 20) };
            Point[] line5 = { new Point(20, 45), new Point(35, 45) };
            Point[] line6 = { new Point(40, 33), new Point(60, 33) };
            Point[] curve = { new Point(55, 20), new Point(55, 45) };
            g.DrawLines(p, line1);
            g.DrawLines(p, line2);
            g.DrawLines(p, line3);
            g.DrawLines(p, line4);
            g.DrawLines(p, line5);
            g.DrawLines(p, line6);
            g.DrawArc(p, 25, 20, 15, 25, 270, 180);
            g.DrawEllipse(p, 0, 22, 6, 6);
            g.DrawEllipse(p, 0, 37, 6, 6);
            g.DrawEllipse(p, 60, 30, 6, 6);
           
           
        }

   }
}
