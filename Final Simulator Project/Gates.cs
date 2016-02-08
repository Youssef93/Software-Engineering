using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
   class   Gates : UserControl
    {
        protected Point MovingPoint;
        protected Point CheckLocation;
        protected bool MoveGate = true;
        protected bool Activate_ToolTip = false;
        protected ToolTip tooltip1 = new ToolTip();
        protected int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        protected bool BackColorGrey = false;
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
            if (!BackColorGrey)
            {
                this.BackColor = Color.White;
            }
            else
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

            do
            {
                Do_While_bool = false;
                for (int i =0; i< Public_Static_Variables.Inputs_List.Count; i++)
                {
                    INPUT Temp_Input = Public_Static_Variables.Inputs_List.ElementAt(i);
                    if (Temp_Input.Gate_Type==This_Gate_Type && Temp_Input.Gate_Index == current_index)
                    {
                        panel1.Controls.Remove(Public_Static_Variables.Inputs_List.ElementAt(i));
                        Temp_Input.Reset_Connection_Bool(i);
                        Do_While_bool = true;
                    }
                }
            }
            while (Do_While_bool);

            foreach (INPUT Temp_Input in Public_Static_Variables.Inputs_List)
            {
                Temp_Input.Input_Letter();
            }
            for (int i=0; i< Public_Static_Variables.Outputs_List.Count; i++)
            {
                Output Temp_Output = Public_Static_Variables.Outputs_List.ElementAt(i);
                if (Temp_Output.Gate_Type == This_Gate_Type && Temp_Output.Gate_Index == current_index)
                {
                    panel1.Controls.Remove(Public_Static_Variables.Outputs_List.ElementAt(i));
                    Temp_Output.Reset_Connection_Bool(i);
                    break;
                }
            }

            foreach (Output Temp_Output in Public_Static_Variables.Outputs_List)
            {
                Temp_Output.Output_Letter();
            }
            if (panel1.Controls.Count == 0)
            {
                //Resetting Everything
                Public_Static_Variables.gatecontainer_counter = 0;
                Public_Static_Variables.Nandgatecontainer_counter = 0;
                Public_Static_Variables.Orgatecontainer_counter = 0;
                Public_Static_Variables.Norgatecontainer_counter = 0;
                Public_Static_Variables.XOrgatecontainer_counter = 0;
                Public_Static_Variables.XNorgatecontainer_counter = 0;

                Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
                Array.Clear(Public_Static_Variables.Nandgatecontainer, 0, Public_Static_Variables.Nandgatecontainer.Length);
                Array.Clear(Public_Static_Variables.Orgatecontainer, 0, Public_Static_Variables.Orgatecontainer.Length);
                Array.Clear(Public_Static_Variables.Norgatecontainer, 0, Public_Static_Variables.Norgatecontainer.Length);
                Array.Clear(Public_Static_Variables.XOrgatecontainer, 0, Public_Static_Variables.XOrgatecontainer.Length);
                Array.Clear(Public_Static_Variables.XNorgatecontainer, 0, Public_Static_Variables.XNorgatecontainer.Length);


                Public_Static_Variables.gatecontainer = new AndGateContainer[50];
                Public_Static_Variables.Nandgatecontainer = new NandGateContainer[50];
                Public_Static_Variables.Orgatecontainer = new OrGateContainer[50];
                Public_Static_Variables.Norgatecontainer = new NorGateContainer[50];
                Public_Static_Variables.XOrgatecontainer = new XOrGateContainer[50];
                Public_Static_Variables.XNorgatecontainer = new XNorGateContainer[50];
            }
        }
        protected void Change_Location(int Gate_Type, Control panel1, Rectangle Connecting_Rectangle_1, Rectangle Connecting_Rectangle_2, Rectangle Connecting_Rectangle_3)
        {
                 // first, initialize a rectangle that contains the current location of the control before moving it
                Rectangle current_location_Retangle = new Rectangle();
                current_location_Retangle.Location = this.Location;
                current_location_Retangle.Width = this.Width;
                current_location_Retangle.Height = this.Height;

                if (this.Left - 10 <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Left = 15;
                }
                else if (this.Top <= 0)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = 10;
                }
                else if (this.Right >= panel1.Width)
                {
                MessageBox.Show("Cannot put a gate outside the panel");
                this.Left = this.Left - 20;
                }
                else if (this.Bottom >= panel1.Height)
                {
                    MessageBox.Show("Cannot put a gate outside the panel");
                    this.Top = this.Top - 10;
                }
                if (!Public_Static_Variables.Deleted_Gate)
                {
                    Rectangle This_Rectangle = new Rectangle();
                    This_Rectangle.Location = this.Location;
                    This_Rectangle.Width = this.Width;
                    This_Rectangle.Height = this.Height;
                    foreach (Control Gate in panel1.Controls)
                    {
                        Rectangle Gate_Rectangle = new Rectangle();
                        Gate_Rectangle.Location = Gate.Location;
                        Gate_Rectangle.Height = Gate.Height;
                        Gate_Rectangle.Width = Gate.Width;
                        if (Gate.GetType() != typeof(Non_Rectangular_Control) && Gate.GetType() != typeof(Output) && Gate.GetType() != typeof(INPUT) && Gate_Rectangle.IntersectsWith(This_Rectangle))
                        {
                            if (Gate != this)
                            {
                                MoveGate = false;
                                Activate_ToolTip = true;
                            }
                        }
                    }
                }
            }
        }
    }
