using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Final_Simulator_Project
{
    [DataContract]
    class Save_Files
    {
        [DataMember]
        public int width = Public_Static_Variables.width;

        [DataMember]
        public int height = Public_Static_Variables.height;

        [DataMember]
        public int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;

        [DataMember]
        public int gatecontainer_counter = Public_Static_Variables.gatecontainer_counter;

        [DataMember]
        public int Reset_draw_rect = Public_Static_Variables.Reset_draw_rect;

        [DataMember]
        public List<int> Pair_Input_Output_Rectangles_Sorting = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting;

        [DataMember]
        public bool Deleted_Gate = Public_Static_Variables.Deleted_Gate;
    }
}
