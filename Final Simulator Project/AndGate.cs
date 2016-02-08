using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simulator_Project
{
     class AndGate : Logic_Gate
    {

        static int counter = 001; 
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
