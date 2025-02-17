using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimization_methods_Lab
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var menu = new Menu();
            menu.FormClosed += (sender, args) => Application.Exit();  // Завершаем процесс, когда закрывается главное окно
            Application.Run(menu);
        }
    }
}
