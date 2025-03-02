namespace Optimization_methods_Lab
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowLab1 window = new WindowLab1(this);
            window.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowLab2 window = new WindowLab2(this);
            window.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowLab3 window = new WindowLab3(this);
            window.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowLab4 window = new WindowLab4(this);
            window.Show();
            this.Hide();
        }
    }
}
