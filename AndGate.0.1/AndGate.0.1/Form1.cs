

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndGate._0._1
{
    public partial class Form1 : Form
    {
       
        int a, b, z;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.panel1.AllowDrop = true;
            foreach (Control c in this.panel1.Controls)
            {
                c.MouseDown += new MouseEventHandler(c_MouseDown);
            }
            this.panel1.DragOver += new DragEventHandler(panel1_DragOver);
            this.panel1.DragDrop += new DragEventHandler(panel1_DragDrop);
        }

        void c_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            if (c != null)
            {
                c.Location = this.panel1.PointToClient(new Point(e.X, e.Y));
                this.panel1.Controls.Add(c);
            }
        }

        void panel1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

          try{

            int s = int.Parse(textBox1.Text);
            if (s == 1)
            {
              
                a = 1;
                MessageBox.Show("this is 1");
            }
            else if (s == 0)
            {
               
                a = 0;
                MessageBox.Show("this is 0");

            }

            else
            {
                textBox1.Clear();
                MessageBox.Show("you entered a wrong value");
                

            }
          }
              catch
          {

              textBox1.Clear();
              MessageBox.Show("you used a wrong button");
          }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int s = int.Parse(textBox2.Text);

                if (s == 1)
                {
                   
                    b = 1;
                    MessageBox.Show("this is 1");
                }
                else if (s == 0)
                {
                    
                    b = 0;
                    MessageBox.Show("this is 0");

                }

                else
                {

                    textBox2.Clear();
                    MessageBox.Show("you entered a wrong value");

                }
            }

            catch
            {

                textBox2.Clear();
                MessageBox.Show("you used a wrong button");
            }
        }

        int Andresult(int x, int y)
        {

            if (x == 1 && y == 1)
            {
                z = 1;

            }
            else
            {
                z = 0;
            }
            textBox3.Text = z.ToString();
            return z;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Andresult(a, b);

        }




    }
}