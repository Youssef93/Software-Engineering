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

        public override int CalcOut()
        {
            if (input[0] == 1 && input[1] == 1)
            {
                output = 0;
                return output;
            }
            else if (input[0] == 0 || input[1] == 0)
            {
                output = 1;
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