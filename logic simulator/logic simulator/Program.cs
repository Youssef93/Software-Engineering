using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
           // float y;
           // int a = 90;
           // int* z = &a;
           //Console.WriteLine( y = Gate.number());
           //Console.WriteLine((int)z);
           //Console.WriteLine(*z);
           //Console.Read();
            
           // Gate x = new Gate();
           // Gate y = new Gate();
            AndGate z = new AndGate();
            OrGate k = new OrGate();
            AndGate L = new AndGate();
           // Console.WriteLine(L.L);
            
            z.input1 = true;
            z.input2 = false;
            z.CalcOut();
            k.input1 = true;
            k.input2 = true;
            k.CalcOut();
            L.input1 = true;
            L.input2 = true;
            L.CalcOut();
            Console.WriteLine("output of 1st and = " + z.output +" gate number is " + z.gatenumber() ); // there's a problem , wrong number
            Console.WriteLine("output of Or = " + k.output + " gate number is " + k.gatenumber());
            Console.WriteLine("output of 2nd and = " + L.output + " gate number is " + L.gatenumber());
            Console.Read();
            
        }
    }
}
