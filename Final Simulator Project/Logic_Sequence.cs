using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    class Mini_Gate
    {
        public int Gate_Type=100;
        public int Gate_Index=100;
        // 0 means connected to input/ output
        // 100 means not yet assigned
        // any other number is the index of the gate it's connected to
        public int Input_Rectangle_1 = 100;
        public int Input_Rectangle_2 = 100;
        public int Output_Rectangle = 100;
       
    }
    class Logic_Sequence
    {
        public Logic_Sequence()
        {
            // w make a list that holds gate connected to inputs
            List<Mini_Gate> Input_Gates = new List<Mini_Gate>();
            for (int i=0; i< Public_Static_Variables.Inputs_List.Count; i++)
            {
                Mini_Gate miniGate = new Mini_Gate();
                input Temp_Input = Public_Static_Variables.Inputs_List.ElementAt(i);
                miniGate.Gate_Type = Temp_Input.Gate_Type;
                miniGate.Gate_Index = Temp_Input.Gate_Index;
                switch (Temp_Input.Rectangle_Index)
                {
                    case 1: miniGate.Input_Rectangle_1 = 0;
                        break;
                    case 2: miniGate.Input_Rectangle_2 = 0;
                        break;
                }
                Input_Gates.Add(miniGate);
            }
            bool Do_While_Bool = false;
            // if there are 2 inputs connected to the same gate, the problem is resolved here
            do
            {
                Do_While_Bool = false;
                for (int i = 0; i < Input_Gates.Count; i++)
                {
                    for (int j = 0; j < Input_Gates.Count; j++)
                    {
                        if (i != j && Input_Gates.ElementAt(i).Gate_Type == Input_Gates.ElementAt(j).Gate_Type
                            && Input_Gates.ElementAt(i).Gate_Index == Input_Gates.ElementAt(j).Gate_Index)
                        {
                            if (Input_Gates.ElementAt(i).Input_Rectangle_1 == 100)
                            {
                                Input_Gates.ElementAt(i).Input_Rectangle_1 = Input_Gates.ElementAt(j).Input_Rectangle_1;
                                Do_While_Bool = true;
                            }
                            else if (Input_Gates.ElementAt(i).Input_Rectangle_2 == 100)
                            {
                                Input_Gates.ElementAt(i).Input_Rectangle_2 = Input_Gates.ElementAt(j).Input_Rectangle_2;
                                Do_While_Bool = true;
                            }
                            Input_Gates.RemoveAt(j);
                            break;
                        }
                    }
                    if (Do_While_Bool)
                        break;
                }
            } while (Do_While_Bool);

            foreach (Mini_Gate miniGate in Input_Gates)
            {
                MessageBox.Show(miniGate.Gate_Type.ToString() + " " + miniGate.Gate_Index.ToString() + " " +
                miniGate.Input_Rectangle_1.ToString() + " " + miniGate.Input_Rectangle_2.ToString());
            }
           
        }
    }
    
}
