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
            ApplicationConfiguration.Initialize();
            var menu = new Menu();
            menu.FormClosed += (sender, args) => Application.Exit();  // ��������� �������, ����� ����������� ������� ����
            Application.Run(menu);
        }
    }
}