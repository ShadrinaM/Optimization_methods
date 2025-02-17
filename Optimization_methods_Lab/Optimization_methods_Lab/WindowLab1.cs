using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimization_methods_Lab
{
    public partial class WindowLab1 : Form
    {
        private Menu mainForm;

        public WindowLab1(Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += WindowLab1_FormClosed;
            Lab1();

        }
        private void BackToMenu_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
        private void WindowLab1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        private void Lab1()
        {
            //лаба
        }
    }
}
