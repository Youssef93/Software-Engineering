using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_simulator
{
      class Gate
    {
        
       public int[] input = new int [2];
       public int output;       
           
      // input 0 => False 
      // input 1 => true
      // input 2 => Dont care 

         public Gate()
        {
            
        }

      
        public virtual int CalcOut()
        {
            return output;
        }

      
    }
}