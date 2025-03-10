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
            this.FormClosed += DichotomyMethod_FormClosed;
            Lab1_DichotomyMethod();
        }

        private void DichotomyMethod_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        void Lab1_DichotomyMethod()
        {
            // Исходные данные
            double delta = 0.2;  // Малое число для отступа
            double epsilon = 0.5;  // Точность
            double a = -3;        // Начало интервала
            double b = 7;         // Конец интервала
            
            // Функция f(x)
            Func<double, double> f = x => 2 * x * x + 2 * x + 5.0 / 2.0;

            // Создание модели для графика
            var plotModel = new PlotModel { Title = "График функции" };
            var functionSeries = new LineSeries { Title = "f(x)" };
            var pointsSeries = new ScatterSeries { Title = "Точки", MarkerType = MarkerType.Circle }; // Устанавливаем круглые точки
            pointsSeries.MarkerFill = OxyColors.Red;

            // Заполнение графика функции
            for (double x = a; x <= b; x += 0.1)
            {
                functionSeries.Points.Add(new OxyPlot.DataPoint(x, f(x)));
            }

            // Выписка из формулировки задания
            textBox1.AppendText($"Функция f(x) = 2x^2 + 2x + 5/2\r\n");
            textBox1.AppendText($"delta = 0.2; epsilon = 0.5;\r\n");
            textBox1.AppendText($"L_0=[{a},{b}]\r\n\r\n");

            // Метод дихотомии
            int k = 0;
            while (Math.Abs(b - a) > epsilon)
            {
                double y = (a + b - delta) / 2;
                double z = (a + b + delta) / 2;

                double f_y = f(y);
                double f_z = f(z);

                // Вывод информации о текущей итерации
                textBox1.AppendText($"Итерация {k}:\r\n");
                textBox1.AppendText($"Интервал L_{k*2} = [a,b] = [{a}, {b}]\r\n");
                textBox1.AppendText($"Точка y_{k} = {y}, f(y_{k}) = {f_y}\r\n");
                textBox1.AppendText($"Точка z_{k} = {z}, f(z_{k}) = {f_z}\r\n");             
                if (f_y <= f_z)
                {
                    b = z;
                    textBox1.AppendText($"f_y <= f_z => \r\na_{k + 1} = a_{k} = {a};\r\nb_{k+1} = z_{k} = {z}\r\n");
                }
                else
                {
                    a = y;
                    textBox1.AppendText($"f_y > f_z => \r\na_{k+1} = y_{k} = {y}; \r\nb_{k + 1} = b_{k} = {b}\r\n");
                }
                if (b-a>epsilon)
                    textBox1.AppendText($"|L_{k * 2}[{a},{b}]| > {epsilon}\r\n");
                else
                    textBox1.AppendText($"|L_{k * 2}[{a},{b}]| < {epsilon}\r\n");
                textBox1.AppendText("\r\n");

                // Добавление точек на график
                pointsSeries.Points.Add(new ScatterPoint(y, f_y));
                pointsSeries.Points.Add(new ScatterPoint(z, f_z));

                k++;
            }

            // Вычисление минимума функции
            double x_star = (a + b) / 2;
            double f_star = f(x_star);

            // Вывод финального результата
            textBox1.AppendText($"Результат:\r\n");
            textBox1.AppendText($"x* = {x_star}, f(x*) = {f_star}\r\n");
            textBox1.AppendText($"\r\nСходимость: \r\nR(N)={1 / Math.Pow(2,k/2)}\r\n");

            // Добавление серии на график
            plotModel.Series.Add(functionSeries);
            plotModel.Series.Add(pointsSeries);

            // Отображение графика
            plotView1.Model = plotModel;
        }
    }
}




// // ВЕРСИЯ ПО ЛЕКЦИЯМ
//using System;
//using System.Windows.Forms;
//using OxyPlot;
//using OxyPlot.Series;
//using OxyPlot.WindowsForms;

//namespace Optimization_methods_Lab
//{
//    public partial class DichotomyMethod : Form
//    {
//        private WindowLab1 mainForm;
//        private PlotView plotView1;
//        private TextBox textBox1;
//        private Button backToMenuButton;

//        public DichotomyMethod(WindowLab1 menushka)
//        {
//            InitializeComponent();
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.mainForm = menushka;
//            this.FormClosed += DichotomyMethod_FormClosed;
//            Lab1_DichotomyMethod();
//        }

//        private void DichotomyMethod_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            mainForm.Show();
//        }

//        void Lab1_DichotomyMethod()
//        {
//            // Исходные данные
//            double delta = 0.2;  // Малое число для отступа
//            double epsilon = 0.5;  // Точность
//            double a = -3;        // Начало интервала
//            double b = 7;         // Конец интервала

//            // Функция f(x)
//            Func<double, double> f = x => 2 * x * x + 2 * x + 5.0 / 2.0;

//            // Создание модели для графика
//            var plotModel = new PlotModel { Title = "График функции" };
//            var functionSeries = new LineSeries { Title = "f(x)" };
//            var pointsSeries = new ScatterSeries { Title = "Точки", MarkerType = MarkerType.Circle }; // Устанавливаем круглые точки
//            pointsSeries.MarkerFill = OxyColors.Red;

//            // Заполнение графика функции
//            for (double x = a; x <= b; x += 0.1)
//            {
//                functionSeries.Points.Add(new OxyPlot.DataPoint(x, f(x)));
//            }

//            // Выписка из формулировки задания
//            textBox1.AppendText($"Функция f(x) = 2x^2 + 2x + 5/2\r\n");
//            textBox1.AppendText($"delta = 0.2; epsilon = 0.5;\r\n");
//            textBox1.AppendText($"L_0=[{a},{b}]\r\n\r\n");

//            // Метод дихотомии
//            int k = 0;
//            while (Math.Abs(b - a) > 2*epsilon)
//            {
//                double y = (a + b - delta) / 2;
//                double z = (a + b + delta) / 2;

//                double f_y = f(y);
//                double f_z = f(z);

//                // Вывод информации о текущей итерации
//                textBox1.AppendText($"Итерация {k}:\r\n");
//                textBox1.AppendText($"Интервал L_{k * 2} = [a,b] = [{a}, {b}]\r\n");
//                textBox1.AppendText($"Точка y_{k} = {y}, f(y_{k}) = {f_y}\r\n");
//                textBox1.AppendText($"Точка z_{k} = {z}, f(z_{k}) = {f_z}\r\n");
//                if (f_y <= f_z)
//                {
//                    b = z;
//                    textBox1.AppendText($"f_y <= f_z => \r\na_{k + 1} = a_{k} = {a};\r\nb_{k + 1} = z_{k} = {z}\r\n");
//                }
//                else
//                {
//                    a = y;
//                    textBox1.AppendText($"f_y > f_z => \r\na_{k + 1} = y_{k} = {y}; \r\nb_{k + 1} = b_{k} = {b}\r\n");
//                }
//                if (b - a > epsilon)
//                    textBox1.AppendText($"|L_{k * 2}[{a},{b}]| > {2*epsilon}\r\n");
//                else
//                    textBox1.AppendText($"|L_{k * 2}[{a},{b}]| < {2*epsilon}\r\n");
//                textBox1.AppendText("\r\n");

//                // Добавление точек на график
//                pointsSeries.Points.Add(new ScatterPoint(y, f_y));
//                pointsSeries.Points.Add(new ScatterPoint(z, f_z));

//                k++;
//            }

//            // Вычисление минимума функции
//            double x_star = (a + b) / 2;
//            double f_star = f(x_star);

//            // Вывод финального результата
//            textBox1.AppendText($"Результат:\r\n");
//            textBox1.AppendText($"x* = {x_star}, f(x*) = {f_star}\r\n");
//            textBox1.AppendText($"\r\nСходимость: \r\nR(N)={1 / Math.Pow(2, k / 2)}\r\n");

//            // Добавление серии на график
//            plotModel.Series.Add(functionSeries);
//            plotModel.Series.Add(pointsSeries);

//            // Отображение графика
//            plotView1.Model = plotModel;
//        }
//    }
//}

