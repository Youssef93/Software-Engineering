using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simulator_Project
{
    class XnorGate : Logic_Gate
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
        
        public override int CalcOut()
        {

            if ((input[0] == 1 && input[1] == 1) || (input[0] == 0 && input[1] == 0))
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
