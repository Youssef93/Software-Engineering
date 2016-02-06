using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
     class AndGate : Gate
    {

        static int counter = 000; 
        int AndgateID;
        public AndGate()
        {
            counter++;
            AndgateID=counter;
           
            Console.WriteLine("from andGate constructor .. AndgateId= " + AndgateID);
        }
        public int gateNumber()       
        {
            return AndgateID;
        }
        
        public override int CalcOut()
        {

            if (input[0] == 1 && input[1] == 1)
            {
                output = 1;
                return output;
            }
            else if (input[0] == 0 || input[1] == 0)
            {
                output = 0;
                return output;

            }
            else
            {

                output = 2;              // output is dont care 
                return output;
            }
        } 
          
    }
}
