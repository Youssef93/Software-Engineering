using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class Connection : Gate
    {

        public Connection(ref Gate x, ref Gate y)
        {
            y.input[0] =x.CalcOut();
        }
        public Connection(ref AndGate x, ref AndGate y)
        {
            y.input[0] = x.CalcOut();
        }
        public Connection(ref OrGate x, ref OrGate y)
        {
            y.input[0] = x.CalcOut();
        }
       
    }
}
