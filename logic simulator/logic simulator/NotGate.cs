using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class NotGate:Gate
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
        public override bool CalcOut()
        {
            output = !input[0];
            return output;
        }
    }
}
