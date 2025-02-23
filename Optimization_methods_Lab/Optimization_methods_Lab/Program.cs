using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            Application.EnableVisualStyles();

            // ������������� ����� ���������� ������
            Application.SetCompatibleTextRenderingDefault(false);

            var menu = new Menu();
            menu.FormClosed += (sender, args) => Application.Exit();  // ��������� �������, ����� ����������� ������� ����

            // ��������� ������� �����
            Application.Run(menu);

        }
    }
}