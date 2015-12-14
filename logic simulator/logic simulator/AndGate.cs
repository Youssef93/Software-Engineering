using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
     class AndGate : Gate
    {

        static int counter = 0; 
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
        
        public override bool CalcOut()
        {

            if (input[0] == true && input[1] == true)
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

       /*
        public override void connect(ref AndGate x, ref AndGate y)  // trying to make a function automatically call connection
        {

            Connection c = new Connection(ref x, ref y);
        
        }
        */ 
          
    }
}
