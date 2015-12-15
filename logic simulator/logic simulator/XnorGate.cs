using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class XnorGate : Gate
    {
        static int counter = 600; 
        int XnorgateID;
        public XnorGate()
        {
            counter++;
            XnorgateID = counter;

            Console.WriteLine("from XnorGate constructor .. XnorgateId= " + XnorgateID);
        }
        public int gateNumber()       
        {
            return XnorgateID;
        }
        
        public override bool CalcOut()
        {

            if ((input[0] == true && input[1] == true) || (input[0] == false && input[1] == false))
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
