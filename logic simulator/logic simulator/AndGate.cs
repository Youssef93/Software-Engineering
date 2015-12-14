using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class AndGate : Gate
    {
        public static int AndgateID = 100; // not perfect coz if u make 2 objects & display the ID of the first , it will be the 2nd's ID not 1st

        public AndGate()
        {
            AndgateID++;
           
            Console.WriteLine("from andGate constructor .. AndgateId= " + AndgateID);
        }
        public override int gatenumber()       // trying something bs nt effective there's a problem with holding gate num.
        {
          //  x = gateID;
            Console.WriteLine(gateID);
            return AndgateID;
        }
        
        public unsafe override void CalcOut()
        {

            if (input1 == true && input2 == true)
            {
                output = true;
            }
            else
            {
                output = false;
            }
        }
    }
}
