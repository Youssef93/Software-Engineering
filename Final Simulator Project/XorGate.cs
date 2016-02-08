using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simulator_Project
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
        
        public override int CalcOut()
        {

            if ((input[0] == 1 && input[1] == 0) || (input[0] == 0 && input[1] == 1))
            {
                output = 1;
                return output;
            }
            else if (input[0] == 2 || input[1] == 2)
            {
                output = 2;
                return output;
            }
            else
            {
                output = 0;
                return output;
            }

        }
    }
}
