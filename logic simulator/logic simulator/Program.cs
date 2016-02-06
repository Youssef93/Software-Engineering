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
            OrGate x = new OrGate();
            NotGate y = new NotGate();
            NandGate q = new NandGate();
            NandGate w = new NandGate();
            NandGate w1 = new NandGate();
            y.input[0] = 1;
            Console.WriteLine(y.output);
            XorGate p = new XorGate();
            NorGate p1 = new NorGate();
            NorGate p3 = new NorGate();
            XnorGate p2 = new XnorGate();
            XnorGate w2 = new XnorGate();
            p.input[0] = 1;
            p.input[1] = 1;

            p3.input[0] = 1;
            p3.input[1] = 1;

            p1.input[0] = 0;
            p1.input[1] = 0;

            p2.input[0] = 0;
            p2.input[1] = 0;
            Console.WriteLine(" before connection , p input 1 = " + p.input[0]);
            Console.WriteLine(" before connection , p input 2 = " + p.input[1]);
            Console.WriteLine(" before connection , p Output = " + p.CalcOut());
            Console.WriteLine(" before connection , p1 input 1 = " + p1.input[0]);
            Console.WriteLine(" before connection , p1 input 2 = " + p1.input[1]);
            Console.WriteLine(" before connection , p1 Output = " + p1.CalcOut());
            Console.WriteLine(" before connection , p2 input 1 = " + p2.input[0]);
            Console.WriteLine(" before connection , p2 input 2 = " + p2.input[1]);
            Console.WriteLine(" before connection , p2 Output = " + p2.CalcOut());
            Connection c1 = new Connection(ref p1, ref p2, 1);
            Console.WriteLine(" After connection , Xnor p2 input 1 = " + p2.input[0]);
            Console.WriteLine(" After connection , Xnor p2 input 2 = " + p2.input[1]);
            Console.WriteLine(" After connection , Xnor p2 Output = " + p2.CalcOut());
            Console.WriteLine("");

            Console.WriteLine(" before connection , p input 1 = " + p.input[0]);
            Console.WriteLine(" before connection , p input 2 = " + p.input[1]);
            Console.WriteLine(" before connection , p Output = " + p.CalcOut());
            Console.WriteLine(" before connection , p3 input 1 = " + p3.input[0]);
            Console.WriteLine(" before connection , p3 input 2 = " + p3.input[1]);
            Console.WriteLine(" before connection , p3 Output = " + p3.CalcOut());
            Connection c2 = new Connection(ref p3, ref p, 0);
            Console.WriteLine(" After connection , Xor p input 1 = " + p.input[0]);
            Console.WriteLine(" After connection , Xor p input 2 = " + p.input[1]);
            Console.WriteLine(" After connection , Xor p Output = " + p.CalcOut());
            
            z.input[0] = 1;
            z.input[1] = 0;
          
            k.input[0] = 2;
            k.input[1] = 0;
            
            L.input[0] = 1;
            L.input[1] = 0;

            x.input[0] = 0;
            x.input[1] = 0;

            q.input[0] = 1;
            q.input[1] = 1;
            

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
