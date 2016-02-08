using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simulator_Project
{
    class NotGate : Gate
    {
        static int counter = 200;
        int NotgateID;

        public NotGate()
        {
            counter++;
            NotgateID = counter;
            Console.WriteLine("from NotGate constructor .. NotgateId= " + NotgateID);
        }
        public int gateNumber()
        {
            return NotgateID;
        }
        
       
        public override int CalcOut()
        {
            if (input[0] == 0)
            {
                output = 1;
                return output;
            }
            else if (input[0] == 1)
            {
                output = 0;
                return output;
            }
            else
            {
                output = 2;
                return output;
            }
           
        }
    }
}