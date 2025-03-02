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
            Lab2();
        }
        private void BackToMenu_Click(object sender, EventArgs e)
        {
            // Показываем главное окно
            mainForm.Show();
            // Закрываем текущее окно
            this.Close();
        }
        private void WindowLab2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Показываем главное окно при закрытии текущего
            mainForm.Show();
        }

        void Lab2()
        {

        }
    }
}
