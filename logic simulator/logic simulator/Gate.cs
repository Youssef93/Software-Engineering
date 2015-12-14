using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    unsafe class Gate
    {
       public bool input1;
       public bool input2;
       public bool output;
       public static int gateID = 0;
       public int L = gateID;
        public Gate()
        {
            gateID++; // discriminating number of gate 
            Console.WriteLine("Gate constructor " + gateID + "called");
        }

        public virtual int gatenumber() // trying something bs nt effective there's a problem
        {
       //     x = gateID;
            return gateID;
        }

        public virtual void CalcOut()
        {

        }
    }
}