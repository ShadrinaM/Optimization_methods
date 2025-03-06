using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Optimization_methods_Lab
{
    public partial class WindowLab1 : Form
    {
        private Menu mainForm;
        private PlotView plotView1;
        private TextBox textBox1;
        private Button backToMenuButton;

        public WindowLab1(Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += WindowLab1_FormClosed;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DichotomyMethod window = new DichotomyMethod(this);
            window.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FibonacciMethod window = new FibonacciMethod(this);
            window.Show();
            this.Hide();
        }
    }
}
