using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
     class Program
    {
        static void Main(string[] args)
        {
            AndGate z = new AndGate();
            OrGate k = new OrGate();
            AndGate L = new AndGate();
            AndGate x = new AndGate();
            //AndGate y = new AndGate();
            z.input[0] = true;
            z.input[1] = false;
            z.CalcOut();
            //k.input1 = true;
            //k.input2 = true;
            //k.CalcOut();
            L.input[0] = true;
            L.input[1] = true;
            //L.CalcOut();
            //Console.WriteLine(z.gateNumber() );
            //Console.WriteLine(x.gateNumber());
            //Console.WriteLine(y.gateNumber());
            //Console.WriteLine("output of 1st and = " + z.output + " gate number is " + z.gateNumber());
            //Console.WriteLine("output of Or = " + k.output + " gate number is " + k.gatenumber());
            //Console.WriteLine("output of 2nd and = " + L.output + " gate number is " + L.gateNumber());
            
            Console.WriteLine(" before connection , AndGate Z input 1 = " + z.input[0] );
            Console.WriteLine(" before connection , AndGate Z input 2 = " + z.input[1] );
            Console.WriteLine(" before connection , AndGate Z Output = " + z.CalcOut() );
            Console.WriteLine(" before connection , AndGate L input 1 = " + L.input[0] );
            Console.WriteLine(" before connection , AndGate L input 2 = " + L.input[1] );
            Console.WriteLine(" before connection , AndGate L Output = " + L.CalcOut() );
            Connection c = new Connection(ref z,ref L);
       //     Gate.connect(z, L); ........... NOT WORKING YETTT
            Console.WriteLine(" After connection , AndGate Z input 1 = " + z.input[0] );
            Console.WriteLine(" After connection , AndGate Z input 2 = " + z.input[1] );
            Console.WriteLine(" After connection , AndGate Z Output = " + z.CalcOut() );
            Console.WriteLine(" After connection , AndGate L input 1 = " + L.input[0] );
            Console.WriteLine(" After connection , AndGate L input 2 = " + L.input[1] );
            Console.WriteLine(" After connection , AndGate L Output = " + L.CalcOut() );

            Console.Read();
            
        }
    }
}
