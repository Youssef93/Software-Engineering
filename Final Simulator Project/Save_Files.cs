using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;

namespace Final_Simulator_Project
{
    public class Save_Files
    {
        public int width = Public_Static_Variables.width;
        public int height = Public_Static_Variables.height;
        public int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        public int gatecontainer_counter = Public_Static_Variables.gatecontainer_counter;
        public int Nandgatecontainer_counter = Public_Static_Variables.Nandgatecontainer_counter;
        public int Orgatecontainer_counter = Public_Static_Variables.Orgatecontainer_counter;
        public int Norgatecontainer_counter = Public_Static_Variables.Norgatecontainer_counter;
        public int XOrgatecontainer_counter = Public_Static_Variables.XOrgatecontainer_counter;
        public int XNorgatecontainer_counter = Public_Static_Variables.XNorgatecontainer_counter;
        public int Notgatecontainer_counter = Public_Static_Variables.Notgatecontainer_counter;

        public Point[] And_Gate_Locations = new Point[Public_Static_Variables.gatecontainer_counter];
        public Point[] Nand_Gate_Locations = new Point[Public_Static_Variables.Nandgatecontainer_counter];
        public Point[] Or_Gate_Locations = new Point[Public_Static_Variables.Orgatecontainer_counter];
        public Point[] Nor_Gate_Locations = new Point[Public_Static_Variables.Norgatecontainer_counter];
        public Point[] XOr_Gate_Locations = new Point[Public_Static_Variables.XOrgatecontainer_counter];
        public Point[] XNor_Gate_Locations = new Point[Public_Static_Variables.XNorgatecontainer_counter];
        public Point[] Not_Gate_Locations = new Point[Public_Static_Variables.Notgatecontainer_counter];


        public int Reset_draw_rect = Public_Static_Variables.Reset_draw_rect;
        public List<int> Pair_Input_Output_Rectangles_Sorting = Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting;
        public bool Deleted_Gate = Public_Static_Variables.Deleted_Gate;
        public Rectangle[] And_Connecting_Rectangles = new Rectangle[Public_Static_Variables.gatecontainer_counter*3 +1];
        public Rectangle[] Nand_Connecting_Rectangles = new Rectangle[Public_Static_Variables.Nandgatecontainer_counter * 3 + 1];
        public Rectangle[] Or_Connecting_Rectangles = new Rectangle[Public_Static_Variables.Orgatecontainer_counter * 3 + 1];
        public Rectangle[] Nor_Connecting_Rectangles = new Rectangle[Public_Static_Variables.Norgatecontainer_counter * 3 + 1];
        public Rectangle[] XOr_Connecting_Rectangles = new Rectangle[Public_Static_Variables.XOrgatecontainer_counter * 3 + 1];
        public Rectangle[] XNor_Connecting_Rectangles = new Rectangle[Public_Static_Variables.XNorgatecontainer_counter * 3 + 1];
        public Rectangle[] Not_Connecting_Rectangles = new Rectangle[Public_Static_Variables.Notgatecontainer_counter * 3 + 1];

        public void show()
        {
          for (int i=1; i< And_Connecting_Rectangles.Count(); i++)
            {
                MessageBox.Show(And_Connecting_Rectangles[i].ToString());
            }
        }
        public void Set_Connecting_Rectangles(Control panel1)
        {
            And_Connecting_Rectangles[0] = new Rectangle();
            Nand_Connecting_Rectangles[0] = new Rectangle();
            Or_Connecting_Rectangles[0] = new Rectangle();
            Nor_Connecting_Rectangles[0] = new Rectangle();
            XOr_Connecting_Rectangles[0] = new Rectangle();
            XNor_Connecting_Rectangles[0] = new Rectangle();
            Not_Connecting_Rectangles[0] = new Rectangle();
            for (int i=1; i<= Public_Static_Variables.gatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.gatecontainer[i]))
                {
                    And_Gate_Locations[i] = Public_Static_Variables.gatecontainer[i].Location;
                    And_Connecting_Rectangles[i*3-2] = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                    And_Connecting_Rectangles[i*3-1] = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                    And_Connecting_Rectangles[i*3] = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Nandgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Nandgatecontainer[i]))
                {
                    Nand_Gate_Locations[i] = Public_Static_Variables.Nandgatecontainer[i].Location;
                    Nand_Connecting_Rectangles[i * 3 - 2] = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_1;
                    Nand_Connecting_Rectangles[i * 3 - 1] = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_2;
                    Nand_Connecting_Rectangles[i * 3] = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Orgatecontainer[i]))
                {
                    Or_Gate_Locations[i] = Public_Static_Variables.Orgatecontainer[i].Location;
                    Or_Connecting_Rectangles[i * 3 - 2] = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_1;
                    Or_Connecting_Rectangles[i * 3 - 1] = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_2;
                    Or_Connecting_Rectangles[i * 3] = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.Norgatecontainer[i]))
                {
                    Nor_Gate_Locations[i] = Public_Static_Variables.Norgatecontainer[i].Location;
                    Nor_Connecting_Rectangles[i * 3 - 2] = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_1;
                    Nor_Connecting_Rectangles[i * 3 - 1] = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_2;
                    Nor_Connecting_Rectangles[i * 3] = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.XOrgatecontainer[i]))
                {
                    XOr_Gate_Locations[i] = Public_Static_Variables.XOrgatecontainer[i].Location;
                    XOr_Connecting_Rectangles[i * 3 - 2] = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_1;
                    XOr_Connecting_Rectangles[i * 3 - 1] = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_2;
                    XOr_Connecting_Rectangles[i * 3] = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_3;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter; i++)
            {
                if (panel1.Controls.Contains(Public_Static_Variables.XNorgatecontainer[i]))
                {
                    XNor_Gate_Locations[i] = Public_Static_Variables.XNorgatecontainer[i].Location;
                    XNor_Connecting_Rectangles[i * 3 - 2] = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_1;
                    XNor_Connecting_Rectangles[i * 3 - 1] = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_2;
                    XNor_Connecting_Rectangles[i * 3] = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_3;
                }
            }
        }
    }
}
