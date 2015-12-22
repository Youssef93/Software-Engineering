using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simulator_Project
{
    public partial class SelectionRectangle : UserControl
    {
        public SelectionRectangle()
        {
            InitializeComponent();
        }

        private void SelectionRectangle_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Hello");
        }
    }
}
