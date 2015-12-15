﻿using System;
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
            OrGate x = new OrGate();
            NotGate y = new NotGate();
            NandGate q = new NandGate();
            y.input[0] = true;
            Console.WriteLine(y.output);
           
            z.input[0] = true;
            z.input[1] = false;
          
            k.input[0] = true;
            k.input[1] =false;
            
            L.input[0] = true;
            L.input[1] = false;

            x.input[0] = false;
            x.input[1] = false;

            q.input[0] = true;
            q.input[1] = true;
            
            Console.WriteLine(" before connection , AndGate Z input 1 = " + z.input[0] );
            Console.WriteLine(" before connection , AndGate Z input 2 = " + z.input[1] );
            Console.WriteLine(" before connection , AndGate Z Output = " + z.CalcOut() );
            Console.WriteLine(" before connection , AndGate L input 1 = " + L.input[0] );
            Console.WriteLine(" before connection , AndGate L input 2 = " + L.input[1] );
            Console.WriteLine(" before connection , AndGate L Output = " + L.CalcOut() );
            Connection one = new Connection(ref z,ref L, 1 );
      
            Console.WriteLine(" After connection , AndGate Z input 1 = " + z.input[0] );
            Console.WriteLine(" After connection , AndGate Z input 2 = " + z.input[1] );
            Console.WriteLine(" After connection , AndGate Z Output = " + z.CalcOut() );
            Console.WriteLine(" After connection , AndGate L input 1 = " + L.input[0] );
            Console.WriteLine(" After connection , AndGate L input 2 = " + L.input[1] );
            Console.WriteLine(" After connection , AndGate L Output = " + L.CalcOut() );
            Connection v = new Connection(ref z, ref L, 0);
            Console.WriteLine(" before connection , OrGate k input 1 = " + k.input[0]);
            Console.WriteLine(" before connection , AndGate k input 2 = " + k.input[1]);
            Console.WriteLine(" before connection , AndGate k Output = " + k.CalcOut());
            Console.WriteLine(" before connection , AndGate x input 1 = " + x.input[0]);
            Console.WriteLine(" before connection , AndGate x input 2 = " + x.input[1]);
            Console.WriteLine(" before connection , AndGate x Output = " + x.CalcOut());
            Connection two = new Connection(ref k, ref x,0);

            Console.WriteLine(" After connection , AndGate k input 1 = " + k.input[0]);
            Console.WriteLine(" After connection , AndGate k input 2 = " + k.input[1]);
            Console.WriteLine(" After connection , AndGate k Output = " + k.CalcOut());
            Console.WriteLine(" After connection , AndGate x input 1 = " + x.input[0]);
            Console.WriteLine(" After connection , AndGate x input 2 = " + x.input[1]);
            Console.WriteLine(" After connection , AndGate x Output = " + x.CalcOut());
           
            Console.WriteLine(" before connection , AndGate Z input 1 = " + z.input[0]);
            Console.WriteLine(" before connection , AndGate Z input 2 = " + z.input[1]);
            Console.WriteLine(" before connection , AndGate Z Output = " + z.CalcOut());
        //    Connection three = new Connection(ref z, ref k,0);

            Console.WriteLine(" After connection three ,Output should be false = " + k.CalcOut());

            Console.WriteLine(" before connection , NandGate q input 1 = " + q.input[0]);
            Console.WriteLine(" before connection , NandGate q input 2 = " + q.input[1]);
            Console.WriteLine(" before connection , NandGate q Output = " + q.CalcOut());
            Console.WriteLine(" before connection , OrGate k input 1 = " + k.input[0]);
            Console.WriteLine(" before connection , OrGate k input 2 = " + k.input[1]);
            Console.WriteLine(" before connection , OrGate k Output = " + k.CalcOut());
            Connection four = new Connection(ref q, ref k, 0);

            Console.WriteLine(" before connection , NandGate q input 1 = " + q.input[0]);
            Console.WriteLine(" before connection , NandGate q input 2 = " + q.input[1]);
            Console.WriteLine(" before connection , NandGate q Output = " + q.CalcOut());
            Console.WriteLine(" before connection , OrGate k input 1 = " + k.input[0]);
            Console.WriteLine(" before connection , OrGate k input 2 = " + k.input[1]);
            Console.WriteLine(" before connection , OrGate k Output = " + k.CalcOut());

            Console.Read();
            
        }
    }
}