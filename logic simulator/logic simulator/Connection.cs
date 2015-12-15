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
        public Connection(ref AndGate x, ref NotGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NotGate x, ref AndGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NotGate x, ref NotGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref OrGate x, ref NotGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NotGate x, ref OrGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref AndGate x, ref NandGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NandGate x, ref AndGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref OrGate x, ref NandGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NandGate x, ref OrGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NandGate x, ref NandGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NotGate x, ref NandGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NandGate x, ref NotGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
    }
}
