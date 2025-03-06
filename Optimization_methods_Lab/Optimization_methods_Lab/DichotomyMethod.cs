using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Optimization_methods_Lab
{
    public partial class DichotomyMethod : Form
    {
        private WindowLab1 mainForm;
        private PlotView plotView1;
        private TextBox textBox1;
        private Button backToMenuButton;

        public DichotomyMethod(WindowLab1 menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += WindowLab1_FormClosed;
            Lab1_DichotomyMethod();
        }

        private void WindowLab1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        void Lab1_DichotomyMethod()
        {
            // Исходные данные
            double epsilon = 0.2;
            double delta = 0.5;
            double a = -3;
            double b = 7;
            int k = 0;

            // Функция f(x)
            Func<double, double> f = x => 2 * x * x + 2 * x + 5.0 / 2.0;

            // Создаем модель для графика
            var plotModel = new PlotModel { Title = "График функции" };
            var functionSeries = new LineSeries { Title = "f(x)" };
            var pointsSeries = new ScatterSeries { Title = "Точки", MarkerType = MarkerType.Circle }; // Устанавливаем круглые точки
            pointsSeries.MarkerFill = OxyColors.Red;

            // Заполняем график функции
            for (double x = a; x <= b; x += 0.1)
            {
                functionSeries.Points.Add(new OxyPlot.DataPoint(x, f(x)));
            }

            // Выписка из формулировки задания
            textBox1.AppendText($"Функция f(x) = 2x^2 + 2x + 5/2\r\n");
            textBox1.AppendText($"epsilon = 0.2; delta = 0.5;\r\n");
            textBox1.AppendText($"L_0=[-3,7]\r\n\r\n");

            // Метод дихотомии
            while (Math.Abs(b - a) > delta)
            {
                double y = (a + b - epsilon) / 2;
                double z = (a + b + epsilon) / 2;

                double f_y = f(y);
                double f_z = f(z);

                // Вывод информации о текущей итерации
                textBox1.AppendText($"Итерация {k}:\r\n");
                textBox1.AppendText($"Интервал L_{k*2} = [a,b] = [{a}, {b}]\r\n");
                textBox1.AppendText($"Точка y = {y}, f(y) = {f_y}\r\n");
                textBox1.AppendText($"Точка z = {z}, f(z) = {f_z}\r\n");             
                if (f_y <= f_z)
                {
                    b = z;
                    textBox1.AppendText($"f_y <= f_z => a_{k + 1} = a_{k} = {a}; b_{k+1} = z_{k} = {z}\r\n");
                }
                else
                {
                    a = y;
                    textBox1.AppendText($"f_y > f_z => a_{k+1} = y_{k} = {y}; b_{k + 1} = b_{k} = {b}\r\n");
                }
                if (b-a>delta)
                    textBox1.AppendText($"L_{k * 2}[{a},{b}] > {delta}\r\n");
                else
                    textBox1.AppendText($"L_{k * 2}[{a},{b}] < {delta}\r\n");
                textBox1.AppendText("\r\n");

                // Добавляем точки на график
                pointsSeries.Points.Add(new ScatterPoint(y, f_y));
                pointsSeries.Points.Add(new ScatterPoint(z, f_z));

                k++;
            }

            // Вычисление минимума функции
            double x_star = (a + b) / 2;
            double f_star = f(x_star);

            // Выводим финальный результат
            textBox1.AppendText($"Результат:\r\n");
            textBox1.AppendText($"x* = {x_star}, f(x*) = {f_star}\r\n");

            // Добавляем серии на график
            plotModel.Series.Add(functionSeries);
            plotModel.Series.Add(pointsSeries);

            // Отображаем график
            plotView1.Model = plotModel;
        }
    }
}
