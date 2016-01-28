using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Final_Simulator_Project
{
    class Not_SelectionRectangle : And_SelectionRectangle
    {
        public Not_SelectionRectangle selectionRectangle1 = new Not_SelectionRectangle();
        public Not_SelectionRectangle selectionRectangle2 = new Not_SelectionRectangle();
        public Not_SelectionRectangle selectionRectangle3 = new Not_SelectionRectangle();

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
    }
}
