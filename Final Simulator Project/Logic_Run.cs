using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Final_Simulator_Project
{
    class Logic_Run
    {
        // add the rest of the gates to this code 
        // serialization
        AndGate[] MyAndGates = new AndGate[50];
        NandGate[] MyNandGates = new NandGate[50];
        OrGate [] MyOrGates = new OrGate[50];
        NorGate[] MyNorGates = new NorGate[50];
        XorGate[] MyXorGates = new XorGate[50];
        XnorGate[] MyXnorGates = new XnorGate[50];

        public Logic_Run(Control panel1)
        {
            bool Logic = true;
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                {
                    MyAndGates[i] = new AndGate();
                    if (!Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected ||
                        !Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected ||
                        !Public_Static_Variables.gatecontainer[i].selectionRectangle3.Connected)
                    {
                        Logic = false;
                    }
                }
            }
            for (int i =1; i<=Public_Static_Variables.Nandgatecontainer_counter && Logic; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Nandgatecontainer[i]))
                {
                    MyNandGates[i] = new NandGate();
                    if (!Public_Static_Variables.Nandgatecontainer[i].selectionRectangle1.Connected ||
                    !Public_Static_Variables.Nandgatecontainer[i].selectionRectangle2.Connected ||
                    !Public_Static_Variables.Nandgatecontainer[i].selectionRectangle3.Connected)
                    {
                        Logic = false;
                    }
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter && Logic; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Orgatecontainer[i]))
                {
                    MyOrGates[i] = new OrGate();
                    if (!Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.Connected ||
                    !Public_Static_Variables.Orgatecontainer[i].selectionRectangle2.Connected ||
                    !Public_Static_Variables.Orgatecontainer[i].selectionRectangle3.Connected)
                    {
                        Logic = false;
                    }
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter && Logic; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Norgatecontainer[i]))
                {
                    MyNorGates[i] = new NorGate();
                    if (!Public_Static_Variables.Norgatecontainer[i].selectionRectangle1.Connected ||
                    !Public_Static_Variables.Norgatecontainer[i].selectionRectangle2.Connected ||
                    !Public_Static_Variables.Norgatecontainer[i].selectionRectangle3.Connected)
                    {
                        Logic = false;
                    }
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter && Logic; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.XOrgatecontainer[i]))
                {
                    MyXorGates[i] = new XorGate();
                    if (!Public_Static_Variables.XOrgatecontainer[i].selectionRectangle1.Connected ||
                    !Public_Static_Variables.XOrgatecontainer[i].selectionRectangle2.Connected ||
                    !Public_Static_Variables.XOrgatecontainer[i].selectionRectangle3.Connected)
                    {
                        Logic = false;
                    }
                }
            }
          
            for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter && Logic; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.XNorgatecontainer[i]))
                {
                    MyXnorGates[i] = new XnorGate();
                    if (!Public_Static_Variables.XNorgatecontainer[i].selectionRectangle1.Connected ||
                    !Public_Static_Variables.XNorgatecontainer[i].selectionRectangle2.Connected ||
                    !Public_Static_Variables.XNorgatecontainer[i].selectionRectangle3.Connected)
                    {
                        Logic = false;
                    }
                }
            }

            if (!Logic)
            {
                MessageBox.Show("Cannot run while there are any nodes that aren't connected");
            }
            else
            {
                Public_Static_Variables.Logic_Calculated = true;
                // Re-arranging the List
                for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 6)
                {
                    if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 2) != 3)
                    {
                        int Temp_Gate_Type = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i);
                        int Temp_Gate_Index = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1);
                        int Temp_Rectangle_Index = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 2);

                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting[i] = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting[i + 1] = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4);
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting[i + 2] = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5);

                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting[i + 3] = Temp_Gate_Type;
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting[i + 4] = Temp_Gate_Index;
                        Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting[i + 5] = Temp_Rectangle_Index;
                    }
                }
                // assigning inputs
                for (int i = 0; i < Public_Static_Variables.Inputs_List.Count; i++)
                {
                    INPUT Temp_Input = Public_Static_Variables.Inputs_List.ElementAt(i);
                    int Zero_Or_One = Temp_Input.Check_Input();
                    if (Temp_Input.Gate_Type == 0)
                    {
                        Connection c = new Connection(ref Zero_Or_One, ref MyAndGates[Temp_Input.Gate_Index], Temp_Input.Rectangle_Index - 1);
                        MyAndGates[Temp_Input.Gate_Index].CalcOut();
                    }
                    else if (Temp_Input.Gate_Type == 1)
                    {
                        Connection c = new Connection(ref Zero_Or_One, ref MyNandGates[Temp_Input.Gate_Index], Temp_Input.Rectangle_Index - 1);
                        MyNandGates[Temp_Input.Gate_Index].CalcOut();
                    }
                    else if (Temp_Input.Gate_Type == 2)
                    {
                        Connection cc = new Connection(ref Zero_Or_One, ref MyOrGates[Temp_Input.Gate_Index], Temp_Input.Rectangle_Index - 1);
                        MyOrGates[Temp_Input.Gate_Index].CalcOut();
                    }
                    else if (Temp_Input.Gate_Type == 3)
                    {
                        Connection cc = new Connection(ref Zero_Or_One, ref MyNorGates[Temp_Input.Gate_Index], Temp_Input.Rectangle_Index - 1);
                        MyNorGates[Temp_Input.Gate_Index].CalcOut();
                    }
                    else if (Temp_Input.Gate_Type == 4)
                    {
                        Connection cc = new Connection(ref Zero_Or_One, ref MyXorGates[Temp_Input.Gate_Index], Temp_Input.Rectangle_Index - 1);
                        MyXorGates[Temp_Input.Gate_Index].CalcOut();
                    }
                    else if (Temp_Input.Gate_Type == 5)
                    {
                        Connection cc = new Connection(ref Zero_Or_One, ref MyXnorGates[Temp_Input.Gate_Index], Temp_Input.Rectangle_Index - 1);
                        MyXnorGates[Temp_Input.Gate_Index].CalcOut();
                    }
                }
                // connections between gates
                bool Do_While_Bool = false;
                int counter = 0;
                do
                {
                    Do_While_Bool = false;
                    for (int i = 0; i < Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 6)
                    {
                        switch (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i))
                        {
                            case 0:
                                if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 0)
                                {
                                    Connection c = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 1)
                                {
                                    Connection c = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 2)
                                {
                                    Connection c = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 3)
                                {
                                    Connection c = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 4)
                                {
                                    Connection c = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 5)
                                {
                                    Connection c = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                break;
                            case 1:
                                if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 0)
                                {
                                    Connection c = new Connection(ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 1)
                                {
                                    Connection c = new Connection(ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 2)
                                {
                                    Connection c = new Connection(ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 3)
                                {
                                    Connection c = new Connection(ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 4)
                                {
                                    Connection c = new Connection(ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 5)
                                {
                                    Connection c = new Connection(ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                break;
                            case 2:
                                if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 0)
                                {
                                    Connection c = new Connection(ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 1)
                                {
                                    Connection c = new Connection(ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 2)
                                {
                                    Connection c = new Connection(ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 3)
                                {
                                    Connection c = new Connection(ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 4)
                                {
                                    Connection c = new Connection(ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 5)
                                {
                                    Connection c = new Connection(ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                break;
                            case 3:
                                if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 0)
                                {
                                    Connection c = new Connection(ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 1)
                                {
                                    Connection c = new Connection(ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 2)
                                {
                                    Connection c = new Connection(ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 3)
                                {
                                    Connection c = new Connection(ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 4)
                                {
                                    Connection c = new Connection(ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 5)
                                {
                                    Connection c = new Connection(ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                break;
                            case 4:
                                if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 0)
                                {
                                    Connection c = new Connection(ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 1)
                                {
                                    Connection c = new Connection(ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 2)
                                {
                                    Connection c = new Connection(ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 3)
                                {
                                    Connection c = new Connection(ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 4)
                                {
                                    Connection c = new Connection(ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 5)
                                {
                                    Connection c = new Connection(ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                break;
                            case 5:
                                if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 0)
                                {
                                    Connection c = new Connection(ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 1)
                                {
                                    Connection c = new Connection(ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNandGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 2)
                                {
                                    Connection c = new Connection(ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 3)
                                {
                                    Connection c = new Connection(ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyNorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 4)
                                {
                                    Connection c = new Connection(ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 5)
                                {
                                    Connection c = new Connection(ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5) - 1);
                                    MyXnorGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                }
                                break;
                        }
                    }
                    for (int i = 1; i<= Public_Static_Variables.gatecontainer_counter; i++)
                    {
                        if (panel1.Controls.Contains(Public_Static_Variables.gatecontainer[i]) && (
                            MyAndGates[i].input[0]==2 || MyAndGates[i].input[1]==2 || MyAndGates[i].output ==2))
                        {
                            Do_While_Bool = true;
                            break;
                        }
                    }
                    for (int i = 1; i<= Public_Static_Variables.Nandgatecontainer_counter && !Do_While_Bool; i++)
                    {
                        if (panel1.Controls.Contains(Public_Static_Variables.Nandgatecontainer[i]) && (
                           MyNandGates[i].input[0] == 2 || MyNandGates[i].input[1] == 2 || MyNandGates[i].output == 2))
                        {
                            Do_While_Bool = true;
                            break;
                        }
                    }
                    for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter && !Do_While_Bool; i++)
                    {
                        if (panel1.Controls.Contains(Public_Static_Variables.Orgatecontainer[i]) && (
                           MyOrGates[i].input[0] == 2 || MyOrGates[i].input[1] == 2 || MyOrGates[i].output == 2))
                        {
                            Do_While_Bool = true;
                            break;
                        }
                    }
                    for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter && !Do_While_Bool; i++)
                    {
                        if (panel1.Controls.Contains(Public_Static_Variables.Norgatecontainer[i]) && (
                           MyNorGates[i].input[0] == 2 || MyNorGates[i].input[1] == 2 || MyNorGates[i].output == 2))
                        {
                            Do_While_Bool = true;
                            break;
                        }
                    }
                    for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter && !Do_While_Bool; i++)
                    {
                        if (panel1.Controls.Contains(Public_Static_Variables.XOrgatecontainer[i]) && (
                           MyXorGates[i].input[0] == 2 || MyXorGates[i].input[1] == 2 || MyXorGates[i].output == 2))
                        {
                            Do_While_Bool = true;
                            break;
                        }
                    }
                    for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter && !Do_While_Bool; i++)
                    {
                        if (panel1.Controls.Contains(Public_Static_Variables.XNorgatecontainer[i]) && (
                           MyXnorGates[i].input[0] == 2 || MyXnorGates[i].input[1] == 2 || MyXnorGates[i].output == 2))
                        {
                            Do_While_Bool = true;
                            break;
                        }
                    }
                    counter++;
                    if (counter > 50)
                    {
                        MessageBox.Show("There's a feedback in the circuit. The presence of a feedback will cause wrong results");
                        Do_While_Bool = false;
                    }
                }
                while (Do_While_Bool);

                foreach (Output Temp_Output in Public_Static_Variables.Outputs_List)
                {
                    switch (Temp_Output.Gate_Type)
                    {
                        case 0: Temp_Output.Paint_Output(MyAndGates[Temp_Output.Gate_Index].output);
                            break;
                        case 1:
                            Temp_Output.Paint_Output(MyNandGates[Temp_Output.Gate_Index].output);
                            break;
                        case 2:
                            Temp_Output.Paint_Output(MyOrGates[Temp_Output.Gate_Index].output);
                            break;
                        case 3:
                            Temp_Output.Paint_Output(MyNorGates[Temp_Output.Gate_Index].output);
                            break;
                        case 4:
                            Temp_Output.Paint_Output(MyXorGates[Temp_Output.Gate_Index].output);
                            break;
                        case 5:
                            Temp_Output.Paint_Output(MyXnorGates[Temp_Output.Gate_Index].output);
                            break;
                    }
                }
            }
        }
    }
}
