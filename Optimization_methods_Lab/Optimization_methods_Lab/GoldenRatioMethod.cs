using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Optimization_methods_Lab
{
    public partial class GoldenRatioMethod : Form
    {
        private WindowLab1 mainForm;
        private PlotView plotView1;
        private TextBox textBox1;

        public GoldenRatioMethod(WindowLab1 menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += GoldenRatioMethod_FormClosed;
            Lab1_GoldenRatioMethod();
        }

        private void GoldenRatioMethod_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        void Lab1_GoldenRatioMethod()
        {
            // Исходные данные
            double delta = 0.2;  //малое число для отступа
            double epsilon = 0.5;  // Точность
            double a = -3;        // Начало интервала
            double b = 7;         // Конец интервала

            // Функция f(x)
            Func<double, double> f = x => 2 * x * x + 2 * x + 5.0 / 2.0;

            // Создание модели для графика
            var plotModel = new PlotModel { Title = "График функции" };
            var functionSeries = new LineSeries { Title = "f(x)" };
            var pointsSeries = new ScatterSeries { Title = "Точки", MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Red, TrackerFormatString = "X: {2:0.###}, Y: {4:0.###}" }; // Устанавливаем круглые точки

            // Заполнение графика функции
            for (double x = a; x <= b; x += 0.1)
            {
                functionSeries.Points.Add(new OxyPlot.DataPoint(x, f(x)));
            }

            // Выписка из формулировки задания
            textBox1.AppendText($"Функция f(x) = 2x^2 + 2x + 5/2\r\n");
            textBox1.AppendText($"delta = 0.2; epsilon = 0.5;\r\n");
            textBox1.AppendText($"L_0=[-3,7]\r\n\r\n");

            // Метод золотого сечения
            int NumCulcFun = 0;
            int k = 0;
            double y = 0, z = 0, f_y = 0, f_z = 0;
            while ((b - a) > epsilon)
            {
                textBox1.AppendText($"Итерация {k}:\r\n");
                textBox1.AppendText($"Интервал L_{NumCulcFun} = [a,b] = [{a}, {b}]\r\n");

                //Вычисление начальных значений
                if (k == 0)
                {
                    y = a + (3 - Math.Sqrt(5)) / 2 * (b - a);
                    z = a + b - y;
                    NumCulcFun += 1;
                }

                //Вычисление функций от полученных точек
                f_y = f(y);
                f_z = f(z);
                textBox1.AppendText($"Точка y_{k} = {y}, f(y_{k}) = {f_y}\r\n");
                textBox1.AppendText($"Точка z_{k} = {z}, f(z_{k}) = {f_z}\r\n");

                // Добавление точек на график
                pointsSeries.Points.Add(new ScatterPoint(y, f_y, 5));
                pointsSeries.Points.Add(new ScatterPoint(z, f_z, 5));

                if (f_y <= f_z)
                {
                    b = z;
                    textBox1.AppendText($"f_y <= f_z =>\r\na_{k + 1} = a_{k} = {a};\r\nb_{k + 1} = z_{k} = {z}\r\n");
                    z = y;
                    textBox1.AppendText($"z_{k + 1}=y_{k}\r\n");
                    y = Math.Round(a + b - z, 10);
                }
                else
                {
                    a = y;
                    textBox1.AppendText($"f_y > f_z =>\r\na_{k + 1} = y_{k} = {y};\r\nb_{k + 1} = b_{k} = {b}\r\n");
                    y = z;
                    textBox1.AppendText($"y_{k + 1}=z_{k}\r\n");
                    z = Math.Round(a + b - y, 10);
                }

                NumCulcFun++;

                if ((b - a) > 2 * epsilon)
                    textBox1.AppendText($"|L_{NumCulcFun}[{a}, {b}]| = {b - a} > {epsilon} => k={k + 1}\r\n");
                else
                    textBox1.AppendText($"|L_{NumCulcFun}[{a}, {b}]| = {b - a} < {epsilon}\r\n");

                textBox1.AppendText("\r\n");

                k++;
            }

            //Вывод последнего интервала
            textBox1.AppendText($"a={a}\r\n");
            textBox1.AppendText($"b={b}\r\n");

            // Вычисление минимума функции
            double x_star = (a + b) / 2;
            double f_star = f(x_star);

            // Вывод финальный результата
            textBox1.AppendText($"\r\nРезультат:\r\n");
            textBox1.AppendText($"x* = ({a}+{b})/{2} = {x_star}\r\nf(x*) = {f_star}\r\n");
            textBox1.AppendText($"\r\nСходимость: R(N)=({Math.Pow((1 - (3 - Math.Sqrt(5)) / 2), k - 1)})\r\n");

            // Добавление серии на график
            plotModel.Series.Add(functionSeries);
            plotModel.Series.Add(pointsSeries);

            // Отображение графика
            plotView1.Model = plotModel;
        }
    }
}



//using System;
//using System.Windows.Forms;
//using OxyPlot;
//using OxyPlot.Series;
//using OxyPlot.WindowsForms;

//namespace Optimization_methods_Lab
//{
//    public partial class GoldenRatioMethod : Form
//    {
//        private WindowLab1 mainForm;
//        private PlotView plotView1;
//        private TextBox textBox1;

//        public GoldenRatioMethod(WindowLab1 menushka)
//        {
//            InitializeComponent();
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.mainForm = menushka;
//            this.FormClosed += GoldenRatioMethod_FormClosed;
//            Lab1_GoldenRatioMethod();
//        }

//        private void GoldenRatioMethod_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            mainForm.Show();
//        }

//        void Lab1_GoldenRatioMethod()
//        {
//            // Исходные данные
//            double delta = 0.2;  //малое число для отступа
//            double epsilon = 0.5;  // Точность
//            double a = -3;        // Начало интервала
//            double b = 7;         // Конец интервала

//            // Функция f(x)
//            Func<double, double> f = x => 2 * x * x + 2 * x + 5.0 / 2.0;

//            // Создание модели для графика
//            var plotModel = new PlotModel { Title = "График функции" };
//            var functionSeries = new LineSeries { Title = "f(x)" };
//            var pointsSeries = new ScatterSeries { Title = "Точки", MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Red, TrackerFormatString = "X: {2:0.###}, Y: {4:0.###}" }; // Устанавливаем круглые точки

//            // Заполнение графика функции
//            for (double x = a; x <= b; x += 0.1)
//            {
//                functionSeries.Points.Add(new OxyPlot.DataPoint(x, f(x)));
//            }

//            // Выписка из формулировки задания
//            textBox1.AppendText($"Функция f(x) = 2x^2 + 2x + 5/2\r\n");
//            textBox1.AppendText($"delta = 0.2; epsilon = 0.5;\r\n");
//            textBox1.AppendText($"L_0=[-3,7]\r\n\r\n");

//            // Метод золотого сечения
//            int NumCulcFun = 0;
//            int k = 0;
//            double y = 0, z = 0, f_y = 0, f_z = 0;
//            while ((b - a) > 2 * epsilon)
//            {
//                textBox1.AppendText($"Итерация {k}:\r\n");
//                textBox1.AppendText($"Интервал L_{NumCulcFun} = [a,b] = [{a}, {b}]\r\n");

//                //Вычисление начальных значений
//                if (k == 0)
//                {
//                    y = a + (3 - Math.Sqrt(5)) / 2 * (b - a);
//                    z = a + b - y;
//                    NumCulcFun += 1;
//                }

//                //Вычисление функций от полученных точек
//                f_y = f(y);
//                f_z = f(z);
//                textBox1.AppendText($"Точка y_{k} = {y}, f(y_{k}) = {f_y}\r\n");
//                textBox1.AppendText($"Точка z_{k} = {z}, f(z_{k}) = {f_z}\r\n");

//                // Добавление точек на график
//                pointsSeries.Points.Add(new ScatterPoint(y, f_y, 5));
//                pointsSeries.Points.Add(new ScatterPoint(z, f_z, 5));

//                if (f_y <= f_z)
//                {
//                    b = z;
//                    textBox1.AppendText($"f_y <= f_z =>\r\na_{k + 1} = a_{k} = {a};\r\nb_{k + 1} = z_{k} = {z}\r\n");
//                    z = y;
//                    textBox1.AppendText($"z_{k + 1}=y_{k}\r\n");
//                    y = Math.Round(a + b - z, 10);
//                }
//                else
//                {
//                    a = y;
//                    textBox1.AppendText($"f_y > f_z =>\r\na_{k + 1} = y_{k} = {y};\r\nb_{k + 1} = b_{k} = {b}\r\n");
//                    y = z;
//                    textBox1.AppendText($"y_{k + 1}=z_{k}\r\n");
//                    z = Math.Round(a + b - y, 10);
//                }

//                NumCulcFun++;

//                if ((b - a) > 2 * delta)
//                    textBox1.AppendText($"|L_{NumCulcFun}[{a}, {b}]| = {b - a} > {2 * epsilon} => k={k + 1}\r\n");
//                else
//                    textBox1.AppendText($"|L_{NumCulcFun}[{a}, {b}]| = {b - a} < {2 * epsilon}\r\n");

//                textBox1.AppendText("\r\n");

//                k++;
//            }

//            //Вывод последнего интервала
//            textBox1.AppendText($"a={a}\r\n");
//            textBox1.AppendText($"b={b}\r\n");

//            // Вычисление минимума функции
//            double x_star = (a + b) / 2;
//            double f_star = f(x_star);

//            // Вывод финальный результата
//            textBox1.AppendText($"\r\nРезультат:\r\n");
//            textBox1.AppendText($"x* = ({a}+{b})/{2} = {x_star}\r\nf(x*) = {f_star}\r\n");
//            textBox1.AppendText($"\r\nСходимость: R(N)=({Math.Pow((1 - (3 - Math.Sqrt(5)) / 2), k - 1)})\r\n");

//            // Добавление серии на график
//            plotModel.Series.Add(functionSeries);
//            plotModel.Series.Add(pointsSeries);

//            // Отображение графика
//            plotView1.Model = plotModel;
//        }
//    }
//}
