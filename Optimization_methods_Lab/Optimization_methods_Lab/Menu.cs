using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimization_methods_Lab
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void StartTask1_Click(object sender, EventArgs e)
        {
            WindowLab1 window = new WindowLab1(this);
            window.Show();
            this.Hide();
        }
    }
}
