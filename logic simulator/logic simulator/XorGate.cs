using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class XorGate : Gate
    {
        
        static int counter = 400; 
        int XorgateID;
        public XorGate()
        {
            counter++;
            XorgateID=counter;
           
            Console.WriteLine("from XorGate constructor .. XorgateId= " + XorgateID);
        }
        public int gateNumber()       
        {
            return XorgateID;
        }
        
        public override bool CalcOut()
        {

            if ((input[0] == true && input[1] == false) || (input[0] == false && input[1] == true))
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
