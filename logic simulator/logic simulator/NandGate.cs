using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class NandGate : Gate
    {
        static int counter = 300;
        int NandgateID;

        public NandGate()
        {
            counter++;
            NandgateID = counter;
            Console.WriteLine("from NandGate constructor .. NandgateId= " + NandgateID);
        }

        public int gateNumber()
        {
            return NandgateID;
        }

        public override bool CalcOut()
        {

            if (input[0] == true && input[1] == true)
            {
                output = false;
                return output;
            }
            else
            {
                output = true;
                return output;
            }
        }
    }
}