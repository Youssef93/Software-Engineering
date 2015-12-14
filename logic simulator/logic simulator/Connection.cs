using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    class Connection : Gate
    {

        public Connection(ref AndGate x, ref AndGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref OrGate x, ref OrGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref AndGate x, ref OrGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref OrGate x, ref AndGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
    }
}
