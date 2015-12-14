using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
      class Gate
    {
        
       public bool[] input = new bool [2];
       public bool output;
       
         public Gate()
        {
          
        }

      
        public virtual bool CalcOut()
        {
            return output;
        }

      
    }
}