using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Final_Simulator_Project
{
    class Public_Static_Variables
    {
        public static int width = 40; //width of gate
        public static int height = 40; //height of gate
        public static int RectWidthAndHeight = 5; //width and height of intersecting rectangles

        public static AndGateContainer[] gatecontainer = new AndGateContainer[50];// number of and gates
        public static int gatecontainer_counter = 0; // counter of and gates
        // gatecontainer_counter is always equal to the number of and gates EXACTLY
        public static int Reset_draw_rect = 0; // a variable to send back to the control to mofify the location

            /* In the next list, each 6 consectuive items (intgers) are related:
            1- Type of Gate ( and =0 , not = 1, etc)
            2- Index of this gate in the array
            3- Index of which Rectangle of this gate is connected
            4- Type of Second Gate 
            5- Index of the seocnd gate
            6- Index of which rectangle connected of the second gate
            */
        public static List<int> Pair_Input_Output_Rectangles_Sorting = new List<int>();
        public static bool Deleted_Gate = false;
        public static List<Non_Rectangular_Control> wires = new List<Non_Rectangular_Control>();
        // a list that holds all inputs 
        public static List<input> Inputs_List = new List<input>();
        // the first element of the next list is the index of the gate that the input connected to
        // the second element is the index of the rectangle it's connected to
        public static List<int> Input_Connected_Gates_Indexes = new List<int>();
        public static int Input_Counter = 0;

        public static NotGateContainer [] Notgatecontainer = new NotGateContainer[50];
        public static int Notgatecontainer_counter = 0;
        public static OrGateContainer[] Orgatecontainer = new OrGateContainer[50];
        public static int Orgatecontainer_counter = 0;
        public static NorGateContainer[] Norgatecontainer = new NorGateContainer[50];
        public static int Norgatecontainer_counter = 0;
        public static XOrGateContainer[] XOrgatecontainer = new XOrGateContainer[50];
        public static int XOrgatecontainer_counter = 0;
        public static XNorGateContainer[] XNorgatecontainer = new XNorGateContainer[50];
        public static int XNorgatecontainer_counter = 0;
    }
}
