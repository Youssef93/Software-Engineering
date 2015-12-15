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
        
        public override bool CalcOut()
        {

            if (input[0] == false && input[1] == false)
            {
                output = true;
                return output;
            }
            else
            {
                output = false;
                return output;
            }
        }
    }
}
