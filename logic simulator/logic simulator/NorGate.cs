using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class NorGate : Gate
    {
        
        static int counter = 500; 
        int NorgateID;
        public NorGate()
        {
            counter++;
            NorgateID=counter;
           
            Console.WriteLine("from NorGate constructor .. NorgateId= " + NorgateID);
        }
        public int gateNumber()       
        {
            return NorgateID;
        }
        
        public override int CalcOut()
        {

            if (input[0] == 1 || input[1] == 1)
            {
                output = 0;
                return output;
            }
            else if (input[0] == 0 && input[1] == 0)
            {
                output = 1;
                return output;
            }
            else
            {
                output = 2;                   // output is dont care
                return output;
            }

        }
    }
}
