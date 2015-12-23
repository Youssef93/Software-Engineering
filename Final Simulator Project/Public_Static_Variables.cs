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
        public static bool DoThread = false;  // to prevent the flickering bug
        public static bool gatecontainer_created = false; // to prevent bug created when Panel1_mouseMove event is raised before any gate is created
        public static AndGateContainer[] gatecontainer = new AndGateContainer[50];// number of and gates
        public static int gatecontainer_counter = 0; // counter of and gates
        // gatecontainer_counter is always equal to the number of and gates EXACTLY
        public static int Reset_draw_rect = 0; // a variable to send back to the control to mofify the location
        public static Rectangle[] Connecting_Rectangles = new Rectangle[200]; // an array that holds all input/output nodes of all gates
        public static int Connecting_Rectangles_Counter = 1;
        // Connecting_Rectangles_Counter is always equal to = gatecontainer_counter*3 + 1
        public static List<int> Pair_Input_Output_Rectangles_Sorting = new List<int>(); // a list where every 2 numbers after each other are the numbers of rectangles to be connected to each other
        public static bool Deleted_Gate = false;
        public static bool Gate_Removed = false;
        public static bool DrawTempRectangle = false;
    }
}
