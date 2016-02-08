using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simulator_Project
{
      class Logic_Gate
    { 
       public int[] input = new int [2];
       public int output;       
           
      // input 0 => False 
      // input 1 => true
      // input 2 => Dont care 
         public Logic_Gate()
        {
            input[0] = 2;
            input[1] = 2;
        }
        public virtual int CalcOut()
        {
            return output;
        }     
    }
}