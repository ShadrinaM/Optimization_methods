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
    public partial class WindowLab2 : Form
    {
        private Menu mainForm;

        public WindowLab2(Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += WindowLab2_FormClosed;
        }

        private void WindowLab2_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SteepestGradientDescentMethod window = new SteepestGradientDescentMethod(this);
            window.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewtonMethod window = new NewtonMethod(this);
            window.Show();
            this.Hide();
        }
    }
}
