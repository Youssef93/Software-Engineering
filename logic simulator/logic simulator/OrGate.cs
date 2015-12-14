using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class OrGate:Gate
    {
         static int counter = 100;
         int OrgateID;
        public OrGate()
        {
            counter++;
            OrgateID = counter;
            Console.WriteLine("from OrGate constructor .. OrgateId= " + OrgateID);
        }
        public int gateNumber() 
        {
         
            return OrgateID;
        }

        public override bool CalcOut()
        {
            if (input[0] == true || input[1] == true)
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
