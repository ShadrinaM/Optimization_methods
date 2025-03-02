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
            // Показываем главное окно
            mainForm.Show();
            // Закрываем текущее окно
            this.Close();
        }
        private void WindowLab1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Показываем главное окно при закрытии текущего
            mainForm.Show();
        }

        void Lab1()
        {
            // Создаем кнопку для запуска метода дихотомии
            Button runButton = new Button();
            runButton.Text = "Run Dichotomy Method";
            runButton.Location = new System.Drawing.Point(10, 10);
            runButton.Click += RunButton_Click;
            this.Controls.Add(runButton);

            // Создаем PlotView для отображения графика
            PlotView plotView = new PlotView();
            plotView.Location = new System.Drawing.Point(10, 50);
            plotView.Size = new System.Drawing.Size(600, 400);
            this.Controls.Add(plotView);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            // Определяем функцию
            Func<double, double> f = x => 2 * x * x + 2 * x + 5.0 / 2.0;

            // Задаем параметры метода дихотомии
            double a = -10; // Начало интервала
            double b = 10;  // Конец интервала
            double epsilon = 0.2; // Точность
            double precision = 0.5; // Точность для остановки

            // Выполняем метод дихотомии
            double root = DichotomyMethod(f, a, b, epsilon, precision);

            // Выводим результат
            MessageBox.Show($"Root found: {root}");

            // Строим график функции
            PlotView plotView = this.Controls.OfType<PlotView>().FirstOrDefault();
            if (plotView != null)
            {
                var model = new PlotModel { Title = "Graph of f(x) = 2x^2 + 2x + 5/2" };
                var series = new LineSeries();

                for (double x = a; x <= b; x += 0.1)
                {
                    series.Points.Add(new OxyPlot.DataPoint(x, f(x)));
                }

                model.Series.Add(series);
                plotView.Model = model;
            }
        }

        private double DichotomyMethod(Func<double, double> f, double a, double b, double epsilon, double precision)
        {
            double c;
            while (Math.Abs(b - a) > precision)
            {
                c = (a + b) / 2;
                if (Math.Abs(f(c)) < epsilon)
                    return c;

                if (f(a) * f(c) < 0)
                    b = c;
                else
                    a = c;
            }
            return (a + b) / 2;
        }
    }
}
