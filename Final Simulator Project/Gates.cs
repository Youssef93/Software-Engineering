using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
    abstract class   Gates : UserControl
    {
        protected Point MovingPoint;
        protected Point CheckLocation;
        protected bool MoveGate = true;
        protected bool Activate_ToolTip = false;
        protected ToolTip tooltip1 = new ToolTip();
        protected bool First_Time_Created = true;
        protected int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        /* Not Implemented Functions are :
        Location CHanged, Mouse Move, Load, Paint, Set Connecting Rectangles, Mouse Click
        */
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
                CheckLocation = this.Location;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            MoveGate = true;
        }
        protected override void OnMouseHover(EventArgs e)
        {
            if (Activate_ToolTip)
            {
                tooltip1.Show("You cannot overlap 2 gates", this);
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        protected void Do_My_Condition (Control panel1 , int This_Gate_Type, int current_index)
        {
            bool Do_While_bool = false;
            do
            {
                Do_While_bool = false;

                for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 6)
                {
                    int Gate_Type_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                    int Gate_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                    int Rectangle_Index_1 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 2);
                    int Gate_Type_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3);
                    int Gate_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4);
                    int Rectangle_Index_2 = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5);

                    if ((Gate_Type_1 == This_Gate_Type && Gate_Index_1 == current_index) || (Gate_Type_2 == This_Gate_Type && current_index == Gate_Index_2))
                    {
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.RemoveRange(i, 6);
                        panel1.Controls.Remove(Public_Static_Variables.wires[i / 6]);
                        Public_Static_Variables.wires.RemoveAt(i / 6);
                        Do_While_bool = true;   
                        break;
                    }   
                }
            }
            while (Do_While_bool);

            if (panel1.Controls.Count == 0)
            {
                //Resetting Everything
                Public_Static_Variables.gatecontainer_counter = 0;
                Public_Static_Variables.Notgatecontainer_counter = 0;
                Public_Static_Variables.Orgatecontainer_counter = 0;
                Public_Static_Variables.Norgatecontainer_counter = 0;
                Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
                Array.Clear(Public_Static_Variables.Notgatecontainer, 0, Public_Static_Variables.Notgatecontainer.Length);
                Array.Clear(Public_Static_Variables.Orgatecontainer, 0, Public_Static_Variables.Orgatecontainer.Length);
                Array.Clear(Public_Static_Variables.Norgatecontainer, 0, Public_Static_Variables.Norgatecontainer.Length);
                Public_Static_Variables.gatecontainer = new AndGateContainer[50];
                Public_Static_Variables.Notgatecontainer = new NotGateContainer[50];
                Public_Static_Variables.Orgatecontainer = new OrGateContainer[50];
                Public_Static_Variables.Norgatecontainer = new NorGateContainer[50];
            }
        }
    }
}
