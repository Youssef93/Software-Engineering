using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    class Connection : Logic_Gate
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
        public Connection(ref AndGate x, ref XorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XorGate x, ref AndGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref OrGate x, ref XorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XorGate x, ref OrGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NotGate x, ref XorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XorGate x, ref NotGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NandGate x, ref XorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XorGate x, ref NandGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XorGate x, ref XorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref AndGate x, ref NorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NorGate x, ref AndGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref OrGate x, ref NorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NorGate x, ref OrGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NotGate x, ref NorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NorGate x, ref NotGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NandGate x, ref NorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NorGate x, ref NandGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XorGate x, ref NorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NorGate x, ref XorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NorGate x, ref NorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref AndGate x, ref XnorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XnorGate x, ref AndGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref OrGate x, ref XnorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XnorGate x, ref OrGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NotGate x, ref XnorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XnorGate x, ref NotGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NandGate x, ref XnorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XnorGate x, ref NandGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XorGate x, ref XnorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XnorGate x, ref XorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref NorGate x, ref XnorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XnorGate x, ref NorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection(ref XnorGate x, ref XnorGate y, int i)
        {
            y.input[i] = x.CalcOut();
        }
        public Connection (ref int One_Or_Zero , ref AndGate x, int i)
        {
            x.input[i] = One_Or_Zero;
        }
        public Connection(ref int One_Or_Zero, ref OrGate x, int i)
        {
            x.input[i] = One_Or_Zero;
        }
        public Connection(ref int One_Or_Zero, ref NandGate x, int i)
        {
            x.input[i] = One_Or_Zero;
        }
        public Connection(ref int One_Or_Zero, ref NorGate x, int i)
        {
            x.input[i] = One_Or_Zero;
        }
        public Connection(ref int One_Or_Zero, ref XorGate x, int i)
        {
            x.input[i] = One_Or_Zero;
        }
        public Connection(ref int One_Or_Zero, ref XnorGate x, int i)
        {
            x.input[i] = One_Or_Zero;
        }
        public Connection(ref int One_Or_Zero, ref NotGate x, int i)
        {
            x.input[i] = One_Or_Zero;
        }
    }
}
