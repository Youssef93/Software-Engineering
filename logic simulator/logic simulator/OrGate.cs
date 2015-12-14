using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class OrGate:Gate
    {
         public static int OrgateID = 200;

        public OrGate()
        {
            OrgateID++;
            Console.WriteLine("from andGate constructor .. OrgateId= " + OrgateID);
        }
        public override int gatenumber() // trying something bs nt effective there's a problem 
        {
          //  x = gateID;
            return OrgateID;
        }
        public override void CalcOut()
        {
            if (input1 == true || input2 == true)
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
