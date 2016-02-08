using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    class Logic_Run
    {
        // remember to add function that re-arranges the list
        // Adjust nand instead of not
        // add the rest of the gates to this code 
        // serialization
        AndGate[] MyAndGates = new AndGate[50];
        OrGate [] MyOrGates = new OrGate[50];
        public Logic_Run(Control panel1)
        {
            bool Logic = true;
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                {
                    if (!Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected ||
                        !Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected ||
                        !Public_Static_Variables.gatecontainer[i].selectionRectangle3.Connected)
                    {
                        Logic = false;
                    }
                }
            }
            if (Logic)
            {
                MyAndGates[0] = new AndGate();
                MyOrGates[0] = new OrGate();
                for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
                {
                    MyAndGates[i] = new AndGate();
                }
                for (int i = 1; i<= Public_Static_Variables.Orgatecontainer_counter; i++)
                {
                    MyOrGates[i] = new OrGate();
                }
                for (int i=0; i< Public_Static_Variables.Inputs_List.Count; i++)
                {
                    INPUT Temp_Input = Public_Static_Variables.Inputs_List.ElementAt(i);
                    int Zero_Or_One = Temp_Input.Check_Input();
                    if (Temp_Input.Gate_Type == 0)
                    {
                        switch (Temp_Input.Rectangle_Index)
                        {
                            case 1: Connection c = new Connection(ref Zero_Or_One, ref MyAndGates[Temp_Input.Gate_Index], 0);
                                break;
                            case 2: Connection c1 = new Connection(ref Zero_Or_One, ref MyAndGates[Temp_Input.Gate_Index], 1);
                                break;
                        }
                        MyAndGates[Temp_Input.Gate_Index].CalcOut();
                    }
                    else if (Temp_Input.Gate_Type == 2)
                    {
                        switch (Temp_Input.Rectangle_Index)
                        {
                            case 1:
                                Connection c = new Connection(ref Zero_Or_One, ref MyOrGates[Temp_Input.Gate_Index], 0);
                                break;
                            case 2:
                                Connection c1 = new Connection(ref Zero_Or_One, ref MyOrGates[Temp_Input.Gate_Index], 1);
                                break;
                        }
                        MyOrGates[Temp_Input.Gate_Index].CalcOut();
                    }
                }
                for (int i =0; i<Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Count; i = i + 6)
                {
                    if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 2) == 3)
                    { 
                        switch (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i))
                        {
                            case 0:
                                if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i+3) ==0)
                                {
                                    switch (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5))
                                    {
                                        case 1:
                                            Connection c = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], 0);
                                            MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                            break;
                                        case 2:
                                            Connection c1 = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], 1);
                                            MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                            break;
                                    }
                                }
                                else if (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 3) == 2)
                                {
                                    switch (Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 5))
                                    {
                                        case 1:
                                            Connection c = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], 0);
                                            MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                            break;
                                        case 2:
                                            Connection c1 = new Connection(ref MyAndGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 1)], ref MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)], 1);
                                            MyOrGates[Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.ElementAt(i + 4)].CalcOut();
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                    // change arramngment in sorting list so that output is listed first 
                    else
                    {

                    }
                }
                MessageBox.Show(MyAndGates[1].input[0].ToString() + MyAndGates[1].input[1].ToString() + MyAndGates[1].output.ToString());
                MessageBox.Show(MyAndGates[2].input[0].ToString() + MyAndGates[2].input[1].ToString() + MyAndGates[2].output.ToString());
                MessageBox.Show(MyOrGates[1].input[0].ToString() + MyOrGates[1].input[1].ToString() + MyOrGates[1].output.ToString());
               
            }
        }

        //    Console.WriteLine(" before connection , NandGate q input 1 = " + q.input[0]);
        //    Console.WriteLine(" before connection , NandGate q input 2 = " + q.input[1]);
        //    Console.WriteLine(" before connection , NandGate q Output = " + q.CalcOut());
        //    Console.WriteLine(" before connection , OrGate k input 1 = " + k.input[0]);
        //    Console.WriteLine(" before connection , OrGate k input 2 = " + k.input[1]);
        //    Console.WriteLine(" before connection , OrGate k Output = " + k.CalcOut());

        //    Console.Read();

        //}
    }
}
