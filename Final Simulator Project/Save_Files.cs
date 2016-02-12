using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
    public class Save_Files
    {
        public int gatecontainer_counter;
        public int Nandgatecontainer_counter;
        public int Orgatecontainer_counter;
        public int Norgatecontainer_counter;
        public int XOrgatecontainer_counter;
        public int XNorgatecontainer_counter ;
        public int Notgatecontainer_counter;

        public Point[] And_Gate_Locations;
        public Point[] Nand_Gate_Locations;
        public Point[] Or_Gate_Locations;
        public Point[] Nor_Gate_Locations;
        public Point[] XOr_Gate_Locations;
        public Point[] XNor_Gate_Locations;
        public Point[] Not_Gate_Locations;

        public Point[] Outputs_Locations;
        public Point[] Inputs_Location;

        public List<int> Pair_Input_Output_Rectangles_Sorting = new List<int>();
        public bool Deleted_Gate;

        public Size Form_Size = new Size();

        /* The next list holds the following :
        1- type of gate it's connected to
        2- Index of gate it's connected to
        */
        public List<int> Outputs_List = new List<int>();

        /*
        The next list holds the following :
        1- Type of gate it's connected to
        2- index of this gate
        3- which rectangle 
        4- which input was chosen
        */
        public List<int> Inputs_List = new List<int>();
     
        public void Load_Design(Control panel1)
        {
            // Resetting everyhting 
            Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
            Array.Clear(Public_Static_Variables.Nandgatecontainer, 0, Public_Static_Variables.Nandgatecontainer.Length);
            Array.Clear(Public_Static_Variables.Orgatecontainer, 0, Public_Static_Variables.Orgatecontainer.Length);
            Array.Clear(Public_Static_Variables.Norgatecontainer, 0, Public_Static_Variables.Norgatecontainer.Length);
            Array.Clear(Public_Static_Variables.XOrgatecontainer, 0, Public_Static_Variables.XOrgatecontainer.Length);
            Array.Clear(Public_Static_Variables.XNorgatecontainer, 0, Public_Static_Variables.XNorgatecontainer.Length);
            Array.Clear(Public_Static_Variables.Notgatecontainer, 0, Public_Static_Variables.Notgatecontainer.Length);

            Public_Static_Variables.gatecontainer = new AndGateContainer[50];
            Public_Static_Variables.Nandgatecontainer = new NandGateContainer[50];
            Public_Static_Variables.Orgatecontainer = new OrGateContainer[50];
            Public_Static_Variables.Norgatecontainer = new NorGateContainer[50];
            Public_Static_Variables.XOrgatecontainer = new XOrGateContainer[50];
            Public_Static_Variables.XNorgatecontainer = new XNorGateContainer[50];
            Public_Static_Variables.Notgatecontainer = new NotGateContainer[50];

            Public_Static_Variables.wires.Clear();
            Public_Static_Variables.Inputs_List.Clear();
            Public_Static_Variables.Outputs_List.Clear();

            panel1.Controls.Clear();
            panel1.FindForm().Size = Form_Size;
            System.Threading.Thread.Sleep(10);

            Public_Static_Variables.gatecontainer_counter = gatecontainer_counter;
            Public_Static_Variables.Nandgatecontainer_counter = Nandgatecontainer_counter;
            Public_Static_Variables.Orgatecontainer_counter = Orgatecontainer_counter;
            Public_Static_Variables.Norgatecontainer_counter = Norgatecontainer_counter;
            Public_Static_Variables.XOrgatecontainer_counter = XOrgatecontainer_counter;
            Public_Static_Variables.XNorgatecontainer_counter = XNorgatecontainer_counter;
            Public_Static_Variables.Notgatecontainer_counter = Notgatecontainer_counter;
            Public_Static_Variables.Deleted_Gate = Deleted_Gate;
            Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting = Pair_Input_Output_Rectangles_Sorting;
            Public_Static_Variables.Logic_Calculated = false;

            for (int i =1; i<= gatecontainer_counter; i++)
            {
                if (And_Gate_Locations[i] != new Point(0, 0))
                {
                    Public_Static_Variables.gatecontainer[i] = new AndGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.gatecontainer[i]);
                    Public_Static_Variables.gatecontainer[i].Location = And_Gate_Locations[i];
                }
                else // to overcome a bug
                {
                    Public_Static_Variables.gatecontainer[i] = new AndGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.gatecontainer[i]);
                    panel1.Controls.Remove(Public_Static_Variables.gatecontainer[i]);
                }
            }
            for (int i = 1; i <= Nandgatecontainer_counter; i++)
            {
                if (Nand_Gate_Locations[i] != new Point(0, 0))
                {
                    Public_Static_Variables.Nandgatecontainer[i] = new NandGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.Nandgatecontainer[i]);
                    Public_Static_Variables.Nandgatecontainer[i].Location = Nand_Gate_Locations[i];
                }
                else // to overcome a bug
                {
                    Public_Static_Variables.Nandgatecontainer[i] = new NandGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.Nandgatecontainer[i]);
                    panel1.Controls.Remove(Public_Static_Variables.Nandgatecontainer[i]);
                }
            }
            for (int i = 1; i <= Orgatecontainer_counter; i++)
            {
                if (Or_Gate_Locations[i] != new Point(0, 0))
                {
                    Public_Static_Variables.Orgatecontainer[i] = new OrGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.Orgatecontainer[i]);
                    Public_Static_Variables.Orgatecontainer[i].Location = Or_Gate_Locations[i];
                }
                else // to overcome a bug
                {
                    Public_Static_Variables.Orgatecontainer[i] = new OrGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.Orgatecontainer[i]);
                    panel1.Controls.Remove(Public_Static_Variables.Orgatecontainer[i]);
                }
            }
            for (int i = 1; i <= Norgatecontainer_counter; i++)
            {
                if (Nor_Gate_Locations[i] != new Point(0, 0))
                {
                    Public_Static_Variables.Norgatecontainer[i] = new NorGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.Norgatecontainer[i]);
                    Public_Static_Variables.Norgatecontainer[i].Location = Nor_Gate_Locations[i];
                }
                else // to overcome a bug
                {
                    Public_Static_Variables.Norgatecontainer[i] = new NorGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.Norgatecontainer[i]);
                    panel1.Controls.Remove(Public_Static_Variables.Norgatecontainer[i]);
                }
            }
            for (int i = 1; i <= XOrgatecontainer_counter; i++)
            {
                if (XOr_Gate_Locations[i] != new Point(0, 0))
                {
                    Public_Static_Variables.XOrgatecontainer[i] = new XOrGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.XOrgatecontainer[i]);
                    Public_Static_Variables.XOrgatecontainer[i].Location = XOr_Gate_Locations[i];
                }
                else // to overcome a bug
                {
                    Public_Static_Variables.XOrgatecontainer[i] = new XOrGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.XOrgatecontainer[i]);
                    panel1.Controls.Remove(Public_Static_Variables.XOrgatecontainer[i]);
                }
            }
            for (int i = 1; i <= XNorgatecontainer_counter; i++)
            {
                if (XNor_Gate_Locations[i] != new Point(0, 0))
                {
                    Public_Static_Variables.XNorgatecontainer[i] = new XNorGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.XNorgatecontainer[i]);
                    Public_Static_Variables.XNorgatecontainer[i].Location = XNor_Gate_Locations[i];
                }
                else // to overcome a bug
                {
                    Public_Static_Variables.XNorgatecontainer[i] = new XNorGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.XNorgatecontainer[i]);
                    panel1.Controls.Remove(Public_Static_Variables.XNorgatecontainer[i]);
                }
            }
            for (int i = 1; i <= Notgatecontainer_counter; i++)
            {
                if (Not_Gate_Locations[i] != new Point(0, 0))
                {
                    Public_Static_Variables.Notgatecontainer[i] = new NotGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.Notgatecontainer[i]);
                    Public_Static_Variables.Notgatecontainer[i].Location = Not_Gate_Locations[i];
                }
                else // to overcome a bug
                {
                    Public_Static_Variables.Notgatecontainer[i] = new NotGateContainer();
                    panel1.Controls.Add(Public_Static_Variables.Notgatecontainer[i]);
                    panel1.Controls.Remove(Public_Static_Variables.Notgatecontainer[i]);
                }
            }
            for (int i = 0; i < Outputs_Locations.Count(); i++)
            {
                Output Temp_output = new Output();
                Temp_output.Gate_Type = Outputs_List.ElementAt(i * 2);
                Temp_output.Gate_Index = Outputs_List.ElementAt(i * 2 + 1);
                panel1.Controls.Add(Temp_output);
                Temp_output.Location = Outputs_Locations[i];
                Temp_output.BringToFront();
                Public_Static_Variables.Outputs_List.Add(Temp_output);
            }
            for (int i = 0; i < Inputs_Location.Count(); i++)
            {
                INPUT Temp_input = new INPUT();
                Temp_input.Gate_Type = Inputs_List.ElementAt(i * 4);
                Temp_input.Gate_Index = Inputs_List.ElementAt(i * 4 + 1);
                Temp_input.Rectangle_Index = Inputs_List.ElementAt(i * 4 + 2);
                panel1.Controls.Add(Temp_input);
                Temp_input.Location = Inputs_Location[i];
                Temp_input.BringToFront();
                Public_Static_Variables.Inputs_List.Add(Temp_input);
                Temp_input.Change_Input(Inputs_List.ElementAt(i * 4 + 3));
            }
            for (int i=0; i<Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 6)
            {
                MyPanel.Add_Wires_To_Panel(Pair_Input_Output_Rectangles_Sorting.ElementAt(i), Pair_Input_Output_Rectangles_Sorting.ElementAt(i+1),
                    Pair_Input_Output_Rectangles_Sorting.ElementAt(i+2), Pair_Input_Output_Rectangles_Sorting.ElementAt(i+3),
                    Pair_Input_Output_Rectangles_Sorting.ElementAt(i+4), Pair_Input_Output_Rectangles_Sorting.ElementAt(i+5), panel1);
            }
          
        }
        public void Save_Design(Control panel1)
        {
            gatecontainer_counter = Public_Static_Variables.gatecontainer_counter;
            Nandgatecontainer_counter = Public_Static_Variables.Nandgatecontainer_counter;
            Orgatecontainer_counter = Public_Static_Variables.Orgatecontainer_counter;
            Norgatecontainer_counter = Public_Static_Variables.Norgatecontainer_counter;
            XOrgatecontainer_counter = Public_Static_Variables.XOrgatecontainer_counter;
            XNorgatecontainer_counter = Public_Static_Variables.XNorgatecontainer_counter;
            Notgatecontainer_counter = Public_Static_Variables.Notgatecontainer_counter;

            And_Gate_Locations = new Point[Public_Static_Variables.gatecontainer_counter + 1];
            Nand_Gate_Locations = new Point[Public_Static_Variables.Nandgatecontainer_counter + 1];
            Or_Gate_Locations = new Point[Public_Static_Variables.Orgatecontainer_counter + 1];
            Nor_Gate_Locations = new Point[Public_Static_Variables.Norgatecontainer_counter + 1];
            XOr_Gate_Locations = new Point[Public_Static_Variables.XOrgatecontainer_counter + 1];
            XNor_Gate_Locations = new Point[Public_Static_Variables.XNorgatecontainer_counter + 1];
            Not_Gate_Locations = new Point[Public_Static_Variables.Notgatecontainer_counter + 1];

            Outputs_Locations = new Point[Public_Static_Variables.Outputs_List.Count];
            Inputs_Location = new Point[Public_Static_Variables.Inputs_List.Count];

            Pair_Input_Output_Rectangles_Sorting = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting;
            Deleted_Gate = Public_Static_Variables.Deleted_Gate;

            for (int i=1; i<= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                    And_Gate_Locations[i] = Public_Static_Variables.gatecontainer[i].Location;
            }
            for (int i = 1; i <= Public_Static_Variables.Nandgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Nandgatecontainer[i]))
                    Nand_Gate_Locations[i] = Public_Static_Variables.Nandgatecontainer[i].Location;
            }
            for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Orgatecontainer[i]))
                    Or_Gate_Locations[i] = Public_Static_Variables.Orgatecontainer[i].Location;
            }
            for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Norgatecontainer[i]))
                    Nor_Gate_Locations[i] = Public_Static_Variables.Norgatecontainer[i].Location;
            }
            for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.XOrgatecontainer[i]))
                    XOr_Gate_Locations[i] = Public_Static_Variables.XOrgatecontainer[i].Location;
            }
            for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.XNorgatecontainer[i]))
                    XNor_Gate_Locations[i] = Public_Static_Variables.XNorgatecontainer[i].Location;
            }
            for (int i = 1; i <= Public_Static_Variables.Notgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Notgatecontainer[i]))
                    Not_Gate_Locations[i] = Public_Static_Variables.Notgatecontainer[i].Location;
            }
            for (int i =0; i<Public_Static_Variables.Outputs_List.Count; i++)
            {
                Outputs_Locations[i] = Public_Static_Variables.Outputs_List.ElementAt(i).Location;
                Outputs_List.Add(Public_Static_Variables.Outputs_List.ElementAt(i).Gate_Type);
                Outputs_List.Add(Public_Static_Variables.Outputs_List.ElementAt(i).Gate_Index);
            }
            for (int i =0; i <Public_Static_Variables.Inputs_List.Count; i++)
            {
                Inputs_Location[i] = Public_Static_Variables.Inputs_List.ElementAt(i).Location;
                Inputs_List.Add(Public_Static_Variables.Inputs_List.ElementAt(i).Gate_Type);
                Inputs_List.Add(Public_Static_Variables.Inputs_List.ElementAt(i).Gate_Index);
                Inputs_List.Add(Public_Static_Variables.Inputs_List.ElementAt(i).Rectangle_Index);
                Inputs_List.Add(Public_Static_Variables.Inputs_List.ElementAt(i).Check_Input());
            }
            Form_Size = panel1.FindForm().Size;
        }
    }
}
