using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Final_Simulator_Project
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black, 1);
        SolidBrush sb = new SolidBrush(Color.Black);
        int width = Public_Static_Variables.width;
        int height = Public_Static_Variables.height;
        int RectWidthAndHeight = Public_Static_Variables.RectWidthAndHeight;
        Point MovingPoint = new Point();
        Point Input_PictureBox_Location;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Public_Static_Variables.gatecontainer[0] = null;
            MyPictureBox My_Andgate_PictrueBox = new MyPictureBox();
            NotPictureBox Not_PictureBox = new NotPictureBox();
            OrPictureBox Or_PictureBox = new OrPictureBox();
            NorPictureBox Nor_PictureBox = new NorPictureBox();
            XOrPictureBox XOr_PictureBox = new XOrPictureBox();
            XNorPictureBox XNOr_PictureBox = new XNorPictureBox();

            groupBox1.Controls.Add(My_Andgate_PictrueBox);
            My_Andgate_PictrueBox.Location =  AndGate_PictureBox2.Location;
            groupBox1.Controls.Add(Not_PictureBox);
            Not_PictureBox.Location = NotpictureBox2.Location;
            groupBox1.Controls.Add(Or_PictureBox);
            Or_PictureBox.Location = OrPictureBox_.Location;
            groupBox1.Controls.Add(Nor_PictureBox);
            Nor_PictureBox.Location = NorPictureBox_.Location;
            groupBox1.Controls.Add(XOr_PictureBox);
            XOr_PictureBox.Location = XOrPictureBox_.Location;
            groupBox1.Controls.Add(XNOr_PictureBox);
            XNOr_PictureBox.Location = XNorPictureBox_.Location;

            AndGate_PictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.JPG";
            NotpictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NotGate.JPG";
            OrPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\OrGate.JPG";
            NorPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NorGate.JPG";
            XOrPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\XOrGate.JPG";
            XNorPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\XNOrGate.JPG";

            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panel1.BackColor = Color.White;

            Input_pictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_pictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_PictureBox_Location = Input_pictureBox.Location;
           
        }  
        private void Input_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
            }
        }

        private void Input_pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Input_pictureBox.Location = new Point(Input_pictureBox.Left + (e.X - MovingPoint.X), Input_pictureBox.Top + (e.Y - MovingPoint.Y));
                if (Input_pictureBox.Right - 20 >= groupBox2.Width)
                {
                    Input_pictureBox.Parent = panel1;
                    Input_pictureBox.BringToFront();
                }
            }
        }

        private void Input_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //Resetting Everything
            Public_Static_Variables.gatecontainer_counter = 0;
            Public_Static_Variables.Notgatecontainer_counter = 0;
            Public_Static_Variables.Orgatecontainer_counter = 0;
            Public_Static_Variables.Norgatecontainer_counter = 0;
            Public_Static_Variables.XOrgatecontainer_counter = 0;
            Public_Static_Variables.XNorgatecontainer_counter = 0;

            Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
            Array.Clear(Public_Static_Variables.Notgatecontainer, 0, Public_Static_Variables.Notgatecontainer.Length);
            Array.Clear(Public_Static_Variables.Orgatecontainer, 0, Public_Static_Variables.Orgatecontainer.Length);
            Array.Clear(Public_Static_Variables.Norgatecontainer, 0, Public_Static_Variables.Norgatecontainer.Length);
            Array.Clear(Public_Static_Variables.XOrgatecontainer, 0, Public_Static_Variables.XOrgatecontainer.Length);
            Array.Clear(Public_Static_Variables.XNorgatecontainer, 0, Public_Static_Variables.XNorgatecontainer.Length);


            Public_Static_Variables.gatecontainer = new AndGateContainer[50];
            Public_Static_Variables.Notgatecontainer = new NotGateContainer[50];
            Public_Static_Variables.Orgatecontainer = new OrGateContainer[50];
            Public_Static_Variables.Norgatecontainer = new NorGateContainer[50];
            Public_Static_Variables.XOrgatecontainer = new XOrGateContainer[50];
            Public_Static_Variables.XNorgatecontainer = new XNorGateContainer[50];

            Public_Static_Variables.wires.Clear();
            Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Clear();
            MyPanel.Check_Connection(panel1);
        }
    }
}

