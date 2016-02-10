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
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Final_Simulator_Project
{
    public partial class Form1 : Form
    {
        Point MovingPoint = new Point();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Public_Static_Variables.gatecontainer[0] = null;
            MyPictureBox My_Andgate_PictrueBox = new MyPictureBox();
            NandPictureBox Nand_PictureBox = new NandPictureBox();
            OrPictureBox Or_PictureBox = new OrPictureBox();
            NorPictureBox Nor_PictureBox = new NorPictureBox();
            XOrPictureBox XOr_PictureBox = new XOrPictureBox();
            XNorPictureBox XNOr_PictureBox = new XNorPictureBox();
            Not_PictureBox Not_PictureBox = new Not_PictureBox();

            groupBox1.Controls.Add(My_Andgate_PictrueBox);
            My_Andgate_PictrueBox.Location =  AndGate_PictureBox2.Location;
            groupBox1.Controls.Add(Nand_PictureBox);
            Nand_PictureBox.Location = NandPictureBox2.Location;
            groupBox1.Controls.Add(Or_PictureBox);
            Or_PictureBox.Location = OrPictureBox_.Location;
            groupBox1.Controls.Add(Nor_PictureBox);
            Nor_PictureBox.Location = NorPictureBox_.Location;
            groupBox1.Controls.Add(XOr_PictureBox);
            XOr_PictureBox.Location = XOrPictureBox_.Location;
            groupBox1.Controls.Add(XNOr_PictureBox);
            XNOr_PictureBox.Location = XNorPictureBox_.Location;
            groupBox1.Controls.Add(Not_PictureBox);
            Not_PictureBox.Location = NotpictureBox_.Location;

            AndGate_PictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Andgate.JPG";
            NandPictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NandGate.JPG";
            OrPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\OrGate.JPG";
            NorPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NorGate.JPG";
            XOrPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\XOrGate.JPG";
            XNorPictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\XNOrGate.JPG";
            NotpictureBox_.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\NotGate.JPG";

            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panel1.BackColor = Color.White;

            Input_pictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";
            Input_pictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Input.JPG";           
            Output_pictureBox.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Output.JPG";
            Output_pictureBox2.ImageLocation = "C:\\Users\\roman\\Documents\\Visual Studio 2015\\Projects\\Final Simulator Project\\Final Simulator Project\\Gate Pictures\\Output.JPG";

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
                if (Input_pictureBox.Bottom >= groupBox2.Height)
                {
                    Input_pictureBox.Parent = panel1;
                    Input_pictureBox.BringToFront();
                }
            }
        }

        private void Input_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Input_pictureBox.Parent == panel1)
            {
                Point Control_Location = Input_pictureBox.Location;
                Input_pictureBox.Parent = groupBox2;
                Input_pictureBox.Location = Input_pictureBox2.Location;
                Input_pictureBox.BringToFront();

                INPUT Temp_Input = new INPUT();
                panel1.Controls.Add(Temp_Input);
                Temp_Input.Location = Control_Location;

                int Gate_Type = 0; // object sent as refernce to decide which type of gate connected
                Rectangle IntersectingRectangle = new Rectangle(); // Rectangle sent as reference to determine which Rectangle
                int Rectangle_Index = 0; // Intger sent as reference to determine the index of which rectangle
                int Gate_Index = Do_My_Condition(Temp_Input.intersecting_Rectangle, ref Gate_Type, ref IntersectingRectangle, ref Rectangle_Index);

                if (Gate_Index == 0)
                {
                    panel1.Controls.Remove(Temp_Input);
                    MessageBox.Show("Please drop the Input at a valid position" + Environment.NewLine + Environment.NewLine
                        + " Valid positions are 'only' input nodes that aren't connected to any other gate");
                }
                else if (Control_Location.X <= 0 || Control_Location.Y <= 0)
                {
                    panel1.Controls.Remove(Temp_Input);
                    MessageBox.Show("The input control cannot be placed outside the panel" + Environment.NewLine + Environment.NewLine +
                        "Please move the gate away from the panel's edges");
                }
                else if (Rectangle_Index == 3)
                {
                    panel1.Controls.Remove(Temp_Input);
                    MessageBox.Show("Cannot connect an input to an output node");
                }
                else
                {
                    Temp_Input.Gate_Type = Gate_Type;
                    Temp_Input.Gate_Index = Gate_Index;
                    Temp_Input.Rectangle_Index = Rectangle_Index;
                    Public_Static_Variables.Inputs_List.Add(Temp_Input);
                    Temp_Input.Change_Location(IntersectingRectangle);
                    Temp_Input.BringToFront();
                    MyPanel.Check_Connection(panel1);
                }
            }
            else
            {
                Input_pictureBox.Parent = groupBox2;
                Input_pictureBox.Location = Input_pictureBox2.Location;
                Input_pictureBox.BringToFront();
            }
        }
        private void Output_PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MovingPoint = e.Location;
            }
        }

        private void Output_PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Output_pictureBox.Location = new Point(Output_pictureBox.Left + (e.X - MovingPoint.X), Output_pictureBox.Top + (e.Y - MovingPoint.Y));
                if (Output_pictureBox.Bottom >= groupBox2.Height)
                {
                    Output_pictureBox.Parent = panel1;
                    Output_pictureBox.BringToFront();
                }
            }
        }
        private void Output_PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Output_pictureBox.Parent == panel1)
            {
                Point Control_Location = Output_pictureBox.Location;
                Output_pictureBox.Parent = groupBox2;
                Output_pictureBox.Location = Output_pictureBox2.Location;
                Output_pictureBox.BringToFront();

                Output Temp_Output = new Output();
                panel1.Controls.Add(Temp_Output);
                Temp_Output.Location = Control_Location;

                int Gate_Type = 0; // object sent as refernce to decide which type of gate connected
                Rectangle IntersectingRectangle = new Rectangle(); // Rectangle sent as reference to determine which Rectangle
                int Rectangle_Index = 0; // Intger sent as reference to determine the index of which rectangle
                int Gate_Index = Do_My_Condition(Temp_Output.intersecting_Rectangle, ref Gate_Type, ref IntersectingRectangle, ref Rectangle_Index);

                if (Gate_Index == 0)
                {
                    panel1.Controls.Remove(Temp_Output);
                    MessageBox.Show("Please drop the Output at a valid position" + Environment.NewLine + Environment.NewLine
                        + " Valid positions are 'only' output nodes that aren't connected to any other gate");
                }
                else if (Control_Location.X + Temp_Output.Width >= panel1.Width || Control_Location.Y + Temp_Output.Height >= panel1.Height)
                {
                    panel1.Controls.Remove(Temp_Output);
                    MessageBox.Show("The output control cannot be placed outside the panel" + Environment.NewLine + Environment.NewLine +
                        "Please move the gate away from the panel's edges");
                }
                else if (Rectangle_Index ==1 || Rectangle_Index == 2)
                {
                    panel1.Controls.Remove(Temp_Output);
                    MessageBox.Show("Cannt apply output to an input node");
                }
                else
                {
                    Temp_Output.Gate_Type = Gate_Type;
                    Temp_Output.Gate_Index = Gate_Index;
                    Public_Static_Variables.Outputs_List.Add(Temp_Output);
                    Temp_Output.Change_Location(IntersectingRectangle);
                    Temp_Output.BringToFront();
                    MyPanel.Check_Connection(panel1);
                }
            }
            else
            {
                Output_pictureBox.Parent = groupBox2;
                Output_pictureBox.Location = Output_pictureBox2.Location;
                Output_pictureBox.BringToFront();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure ?!" + Environment.NewLine + Environment.NewLine +
              " If the circuit is not saved all the work will be lost", "Clear", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //Resetting Everything
                Public_Static_Variables.gatecontainer_counter = 0;
                Public_Static_Variables.Nandgatecontainer_counter = 0;
                Public_Static_Variables.Orgatecontainer_counter = 0;
                Public_Static_Variables.Norgatecontainer_counter = 0;
                Public_Static_Variables.XOrgatecontainer_counter = 0;
                Public_Static_Variables.XNorgatecontainer_counter = 0;
                Public_Static_Variables.Notgatecontainer_counter = 0;

                Array.Clear(Public_Static_Variables.gatecontainer, 0, Public_Static_Variables.gatecontainer.Length);
                Array.Clear(Public_Static_Variables.Nandgatecontainer, 0, Public_Static_Variables.Nandgatecontainer.Length);
                Array.Clear(Public_Static_Variables.Orgatecontainer, 0, Public_Static_Variables.Orgatecontainer.Length);
                Array.Clear(Public_Static_Variables.Norgatecontainer, 0, Public_Static_Variables.Norgatecontainer.Length);
                Array.Clear(Public_Static_Variables.XOrgatecontainer, 0, Public_Static_Variables.XOrgatecontainer.Length);
                Array.Clear(Public_Static_Variables.XNorgatecontainer, 0, Public_Static_Variables.XNorgatecontainer.Length);
                Array.Clear(Public_Static_Variables.Notgatecontainer, 0, Public_Static_Variables.Notgatecontainer.Length);

                Public_Static_Variables.gatecontainer = new AndGateContainer[50];
                Public_Static_Variables.Nandgatecontainer = new NandGateContainer[50];
                Public_Static_Variables.Orgatecontainer = new OrGateContainer[50];
                Public_Static_Variables.Norgatecontainer = new NorGateContainer[50];
                Public_Static_Variables.XOrgatecontainer = new XOrGateContainer[50];
                Public_Static_Variables.XNorgatecontainer = new XNorGateContainer[50];
                Public_Static_Variables.Notgatecontainer = new NotGateContainer[50];

                Public_Static_Variables.wires.Clear();
                Public_Static_Variables.Pair_Input_Output_Rectangles_Sorting.Clear();
                Public_Static_Variables.Inputs_List.Clear();
                Public_Static_Variables.Outputs_List.Clear();
                panel1.Controls.Clear();
            }
        }
        /* 
        This function will return zero in the following cases :
        1- rectangle sent to it doesnt intersect with any node of any rectangle
        2- rectangle sent to it intersects with a connected node

            Otherwise it returns the index of the gate & modifies the "sent by reference" objects 
            to determine:
            1- The Gate type
            2- Which rectangle 
            3- The exact rectangle that this input is connected to
        */
        private int Do_My_Condition(Rectangle rectangle, ref int Gate_Type, ref Rectangle Return_Rectangle, ref int Rectangle_Index)
        {
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            Rectangle rectangle3 = new Rectangle();
            for (int i = 1; i <= Public_Static_Variables.gatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.gatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 0;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.gatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 0;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.gatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle3.IntersectsWith(rectangle))
                {
                    Gate_Type = 0;
                    Return_Rectangle = rectangle3;
                    Rectangle_Index = 3;
                    if (!Public_Static_Variables.gatecontainer[i].selectionRectangle3.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Nandgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Nandgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 1;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.Nandgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 1;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.Nandgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle3.IntersectsWith(rectangle))
                {
                    Gate_Type = 1;
                    Return_Rectangle = rectangle3;
                    Rectangle_Index = 3;
                    if (!Public_Static_Variables.Nandgatecontainer[i].selectionRectangle3.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Orgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Orgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 2;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.Orgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 2;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.Orgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle3.IntersectsWith(rectangle))
                {
                    Gate_Type = 2;
                    Return_Rectangle = rectangle3;
                    Rectangle_Index = 3;
                    if (!Public_Static_Variables.Orgatecontainer[i].selectionRectangle3.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Notgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_1;
                rectangle3 = Public_Static_Variables.Notgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 6;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.Notgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle3.IntersectsWith(rectangle))
                {
                    Gate_Type = 6;
                    Return_Rectangle = rectangle3;
                    Rectangle_Index = 3;
                    if (!Public_Static_Variables.Notgatecontainer[i].selectionRectangle3.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.Norgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.Norgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 3;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.Norgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 3;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.Norgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle3.IntersectsWith(rectangle))
                {
                    Gate_Type = 3;
                    Return_Rectangle = rectangle3;
                    Rectangle_Index = 3;
                    if (!Public_Static_Variables.Norgatecontainer[i].selectionRectangle3.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XOrgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.XOrgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 4;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.XOrgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 4;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.XOrgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle3.IntersectsWith(rectangle))
                {
                    Gate_Type = 4;
                    Return_Rectangle = rectangle3;
                    Rectangle_Index = 3;
                    if (!Public_Static_Variables.XOrgatecontainer[i].selectionRectangle3.Connected)
                        return i;
                    else return 0;
                }
            }
            for (int i = 1; i <= Public_Static_Variables.XNorgatecontainer_counter; i++)
            {
                rectangle1 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_1;
                rectangle2 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_2;
                rectangle3 = Public_Static_Variables.XNorgatecontainer[i].Connecting_Rectangle_3;
                if (rectangle1.IntersectsWith(rectangle))
                {
                    Gate_Type = 5;
                    Return_Rectangle = rectangle1;
                    Rectangle_Index = 1;
                    if (!Public_Static_Variables.XNorgatecontainer[i].selectionRectangle1.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle2.IntersectsWith(rectangle))
                {
                    Gate_Type = 5;
                    Return_Rectangle = rectangle2;
                    Rectangle_Index = 2;
                    if (!Public_Static_Variables.XNorgatecontainer[i].selectionRectangle2.Connected)
                        return i;
                    else return 0;
                }
                else if (rectangle3.IntersectsWith(rectangle))
                {
                    Gate_Type = 5;
                    Return_Rectangle = rectangle3;
                    Rectangle_Index = 3;
                    if (!Public_Static_Variables.XNorgatecontainer[i].selectionRectangle3.Connected)
                        return i;
                    else return 0;
                }
            }
            return 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Logic_Run logic = new Logic_Run(panel1);
        }
        private void loadDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Activate = true;
            if (panel1.Controls.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure ?!" + Environment.NewLine + Environment.NewLine +
               " Loading a new design will remove the current one.", "Load Design", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    Activate = false;
            }
            if (Activate)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var path = ofd.FileName;
                    XmlSerializer serial = new XmlSerializer(typeof(Save_Files));
                    Save_Files variables = new Save_Files();
                    StreamReader reader = new StreamReader(path);
                    variables = (Save_Files)serial.Deserialize(reader);
                    reader.Close();
                    variables.Load(panel1);
                }
            }
        }

        private void saveDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                XmlSerializer serial = new XmlSerializer(typeof(Save_Files));
                Save_Files variables = new Save_Files();
                variables.Save_Design(panel1);
                System.Threading.Thread.Sleep(10);
                StreamWriter writer = new StreamWriter(path);
                serial.Serialize(writer, variables);
                writer.Close();
            }
        }
    }
}

