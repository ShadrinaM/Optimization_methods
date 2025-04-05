using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Optimization_methods_Lab
{
    public partial class SteepestGradientDescentMethod : Form
    {
        private WindowLab2 mainForm;
        private TextBox textBox1;

        public SteepestGradientDescentMethod(WindowLab2 menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += SteepestGradientDescentMethod_FormClosed;
            Lab1_SteepestGradientDescentMethod();
        }

        private void SteepestGradientDescentMethod_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }













        //void Lab1_SteepestGradientDescentMethod()
        //{
        //    double epsilon1 = 0.1;
        //    double epsilon2 = 0.15;
        //    double[] x_0 = [1.1, 1.1];

        //    // Выписка из формулировки задания
        //    textBox1.AppendText($"Функция f(x) = x_1^2 + 7_x^2 + x_1x_2 + x_1\r\n");
        //    textBox1.AppendText($"x^0=({x_0[0]}; {x_0[1]})\r\n");
        //    textBox1.AppendText($"ε_1={epsilon1}; ε_2={epsilon2}\r\n\r\n");
        //    textBox1.AppendText($"ε_1={epsilon1}; ε_2={epsilon2}\r\n\r\n");


        //    // ЗДЕ

        //}























        //void Lab1_SteepestGradientDescentMethod()
        //{
        //    double epsilon1 = 0.1;
        //    double epsilon2 = 0.15;
        //    double[] x_0 = { 1.1, 1.1 };
        //    int M = 10; // Максимальное число итераций

        //    // Выписка из формулировки задания
        //    textBox1.AppendText($"Функция f(x) = x_1^2 + 7x_2^2 + x_1x_2 + x_1\r\n");
        //    textBox1.AppendText($"x^0=({x_0[0]}; {x_0[1]})\r\n");
        //    textBox1.AppendText($"ε_1={epsilon1}; ε_2={epsilon2}\r\n\r\n");
        //    textBox1.AppendText($"M={M}\r\n\r\n");

        //    double[] x_k = (double[])x_0.Clone();
        //    double[] x_prev = new double[2];
        //    int k = 0;
        //    string exitReason = "";
        //    bool smallChangesOnLastIteration = false;

        //    while (true)
        //    {
        //        // Вычисляем градиент
        //        double[] grad = CalculateGradient(x_k);
        //        double gradNorm = Math.Sqrt(grad[0] * grad[0] + grad[1] * grad[1]);

        //        // Выводим информацию о текущей итерации
        //        textBox1.AppendText($"Итерация {k}:\r\n");
        //        textBox1.AppendText($"x^k = ({x_k[0]}; {x_k[1]})\r\n");
        //        textBox1.AppendText($"f(x^k) = {CalculateFunction(x_k)}\r\n");
        //        textBox1.AppendText($"∇f(x^k) = ({grad[0]}; {grad[1]})\r\n");
        //        textBox1.AppendText($"||∇f(x^k)|| = {gradNorm}\r\n");

        //        // Проверка условий остановки
        //        if (gradNorm < epsilon1)
        //        {
        //            exitReason = $"Критерий сходимости по градиенту (||∇f(x^k)|| < {epsilon1})";
        //            break;
        //        }

        //        if (k > M)
        //        {
        //            exitReason = $"Превышено максимальное число итераций ({M})";
        //            break;
        //        }

        //        if (k > 0)
        //        {
        //            double xDiffNorm = Math.Sqrt(Math.Pow(x_k[0] - x_prev[0], 2) + Math.Pow(x_k[1] - x_prev[1], 2));
        //            double fDiff = Math.Abs(CalculateFunction(x_k) - CalculateFunction(x_prev));
        //            textBox1.AppendText($"||x^k - x^(k-1)|| = {xDiffNorm}\r\n");
        //            textBox1.AppendText($"|f(x^k) - f(x^(k-1))| = {fDiff}\r\n");

        //            bool smallChangesNow = (xDiffNorm < epsilon2) && (fDiff < epsilon2);
        //            if (smallChangesNow && smallChangesOnLastIteration)
        //            {
        //                exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях";
        //                break;
        //            }
        //            smallChangesOnLastIteration = smallChangesNow;
        //        }

        //        // Оптимизация шага (здесь используется метод золотого сечения)
        //        double t_k = GoldenSectionSearch(x_k, grad);

        //        // Сохраняем предыдущее значение x перед обновлением
        //        x_prev = (double[])x_k.Clone();

        //        // Обновление точки
        //        x_k[0] = x_k[0] - t_k * grad[0];
        //        x_k[1] = x_k[1] - t_k * grad[1];

        //        textBox1.AppendText($"t_k = {t_k}\r\n");
        //        textBox1.AppendText($"x^(k+1) = ({x_k[0]}; {x_k[1]})\r\n\r\n");

        //        k++;
        //    }

        //    // Вывод результатов
        //    textBox1.AppendText($"\r\nРезультаты:\r\n");
        //    textBox1.AppendText($"x^* = ({x_k[0]}; {x_k[1]})\r\n");
        //    textBox1.AppendText($"f(x^*) = {CalculateFunction(x_k)}\r\n");
        //    textBox1.AppendText($"Количество итераций: {k}\r\n");
        //    textBox1.AppendText($"Условие выхода: {exitReason}\r\n");
        //}

        //// Функция для вычисления
        //private double CalculateFunction(double[] x)
        //{
        //    return x[0] * x[0] + 7 * x[1] * x[1] + x[0] * x[1] + x[0];
        //}

        //// Градиент функции
        //private double[] CalculateGradient(double[] x)
        //{
        //    double df_dx1 = 2 * x[0] + x[1] + 1;
        //    double df_dx2 = 14 * x[1] + x[0];
        //    return new double[] { df_dx1, df_dx2 };
        //}

        //// Метод золотого сечения для поиска оптимального шага
        //private double GoldenSectionSearch(double[] x, double[] grad)
        //{
        //    double a = 0;
        //    double b = 1;
        //    double tau = (Math.Sqrt(5) - 1) / 2; // 0.618
        //    double epsilon = 1e-6;

        //    double x1 = b - tau * (b - a);
        //    double x2 = a + tau * (b - a);

        //    while (Math.Abs(b - a) > epsilon)
        //    {
        //        double[] x1_point = { x[0] - x1 * grad[0], x[1] - x1 * grad[1] };
        //        double[] x2_point = { x[0] - x2 * grad[0], x[1] - x2 * grad[1] };

        //        double f_x1 = CalculateFunction(x1_point);
        //        double f_x2 = CalculateFunction(x2_point);

        //        if (f_x1 < f_x2)
        //        {
        //            b = x2;
        //            x2 = x1;
        //            x1 = b - tau * (b - a);
        //        }
        //        else
        //        {
        //            a = x1;
        //            x1 = x2;
        //            x2 = a + tau * (b - a);
        //        }
        //    }

        //    return (a + b) / 2;
        //}






















        //void Lab1_SteepestGradientDescentMethod()
        //{
        //    double epsilon1 = 0.1;
        //    double epsilon2 = 0.15;
        //    double[] x_0 = { 1.1, 1.1 };
        //    int M = 10; // Максимальное число итераций

        //    // Выписка из формулировки задания
        //    textBox1.AppendText($"Функция f(x) = x_1^2 + 7x_2^2 + x_1x_2 + x_1\r\n");
        //    textBox1.AppendText($"x^0=({x_0[0]}; {x_0[1]})\r\n");
        //    textBox1.AppendText($"ε_1={epsilon1}; ε_2={epsilon2}\r\n");
        //    textBox1.AppendText($"M={M}\r\n\r\n");

        //    double[] x_k = (double[])x_0.Clone();
        //    double[] x_prev = new double[2];
        //    int k = 0;
        //    string exitReason = "";
        //    bool smallChangesOnLastIteration = false;

        //    while (true)
        //    {
        //        // Вычисляем градиент
        //        double[] grad = CalculateGradient(x_k);
        //        double gradNorm = Math.Sqrt(grad[0] * grad[0] + grad[1] * grad[1]);

        //        // Выводим информацию о текущей итерации
        //        textBox1.AppendText($"Итерация {k}:\r\n");
        //        textBox1.AppendText($"x^{k} = ({x_k[0]}; {x_k[1]})\r\n");
        //        textBox1.AppendText($"f(x^{k}) = {CalculateFunction(x_k)}\r\n");
        //        textBox1.AppendText($"∇f(x^{k}) = ({grad[0]}; {grad[1]})\r\n");

        //        // Проверка условий остановки
        //        if (gradNorm < epsilon1)
        //        {
        //            exitReason = $"Критерий сходимости по градиенту (||∇f(x^{k})|| < {epsilon1})";
        //            break;
        //        }
        //        else
        //        {
        //            textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} > {epsilon1}\r\n");
        //        }

        //        if (k >= M)
        //        {
        //            exitReason = $"Превышено максимальное число итераций (k = {k} >= {M} = M)";
        //            break;
        //        }
        //        else
        //        {
        //            textBox1.AppendText($"k = {k} < {M} = M\r\n");
        //        }

        //        if (k > 0)
        //        {
        //            double xDiffNorm = Math.Sqrt(Math.Pow(x_k[0] - x_prev[0], 2) + Math.Pow(x_k[1] - x_prev[1], 2));
        //            double fDiff = Math.Abs(CalculateFunction(x_k) - CalculateFunction(x_prev));

        //            bool smallChangesNow = (xDiffNorm < epsilon2) && (fDiff < epsilon2);
        //            if (xDiffNorm < epsilon2)
        //            {
        //                textBox1.AppendText($"||x^{k} - x^{k - 1}|| = {xDiffNorm} < {epsilon2}\r\n");
        //                exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях\r\n" +
        //                    $"||x^{k} - x^{k - 1}|| < ε_2";
        //            }
        //            else
        //            {
        //                textBox1.AppendText($"||x^{k} - x^{k - 1}|| = {xDiffNorm} > {epsilon2}\r\n");
        //            }

        //            if (fDiff < epsilon2)
        //            {
        //                textBox1.AppendText($"||f(x^{k}) - f(x^{k - 1})|| = {fDiff} < {epsilon2}\r\n");
        //                exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях\r\n" +
        //                    $"||f(x^{k}) - f(x^{k - 1})|| < ε_2";
        //            }
        //            else
        //            {
        //                textBox1.AppendText($"||f(x^{k}) - f(x^{k - 1})|| = {fDiff} > {epsilon2}\r\n");
        //            }

        //            if (smallChangesNow && smallChangesOnLastIteration)
        //            {                       
        //                break;
        //            }
        //            smallChangesOnLastIteration = smallChangesNow;
        //        }

        //        // Вычисление шага t_k по заданной формуле
        //        double t_k = CalculateStep(x_k[0], x_k[1]);

        //        // Сохраняем предыдущее значение x перед обновлением
        //        x_prev = (double[])x_k.Clone();

        //        // Обновление точки
        //        x_k[0] = x_k[0] - t_k * grad[0];
        //        x_k[1] = x_k[1] - t_k * grad[1];

        //        textBox1.AppendText($"t_{k} = {t_k}\r\n");
        //        textBox1.AppendText($"x^{k+1} = ({x_k[0]}; {x_k[1]})\r\n\r\n");

        //        k++;
        //    }

        //    // Вывод результатов
        //    textBox1.AppendText($"\r\nРезультаты:\r\n");
        //    textBox1.AppendText($"x^* = ({x_k[0]}; {x_k[1]})\r\n");
        //    textBox1.AppendText($"f(x^*) = {CalculateFunction(x_k)}\r\n");
        //    textBox1.AppendText($"Количество итераций: {k}\r\n");
        //    textBox1.AppendText($"Условие выхода: {exitReason}\r\n");
        //}

        //// Функция для вычисления
        //private double CalculateFunction(double[] x)
        //{
        //    return x[0] * x[0] + 7 * x[1] * x[1] + x[0] * x[1] + x[0];
        //}

        //// Градиент функции
        //private double[] CalculateGradient(double[] x)
        //{
        //    double df_dx1 = 2 * x[0] + x[1] + 1;
        //    double df_dx2 = 14 * x[1] + x[0];
        //    return new double[] { df_dx1, df_dx2 };
        //}

        //// Расчет шага по заданной формуле
        //private double CalculateStep(double x_k, double y_k)
        //{  
        //    double denominator = 2 * (13 * Math.Pow(x_k, 2) + 229 * x_k * y_k + 5 * x_k + 1387 * Math.Pow(y_k, 2) + 16 * y_k + 1);
        //    double numerator = 5 * Math.Pow(x_k, 2) + 32 * x_k * y_k + 4 * x_k + 197 * Math.Pow(y_k, 2) + 2 * y_k + 1;
        //    return numerator / denominator;
        //}






        void Lab1_SteepestGradientDescentMethod()
        {
            double epsilon1 = 0.1;
            double epsilon2 = 0.15;
            double[] x_0 = { 1.1, 1.1 };
            int M = 10; // Максимальное число итераций

            // Выписка из формулировки задания
            textBox1.AppendText($"Функция f(x) = x_1^2 + 7x_2^2 + x_1x_2 + x_1\r\n");
            textBox1.AppendText($"x^0=({x_0[0]}; {x_0[1]})\r\n");
            textBox1.AppendText($"ε_1={epsilon1}; ε_2={epsilon2}\r\n");
            textBox1.AppendText($"M={M}\r\n\r\n");

            double[] x_k = (double[])x_0.Clone();
            double[] x_prev = new double[2];
            int k = 0;
            string exitReason = "";
            bool smallChangesOnLastIteration = false;

            while (true)
            {
                // Вычисляем градиент
                double[] grad = CalculateGradient(x_k);
                double gradNorm = Math.Sqrt(grad[0] * grad[0] + grad[1] * grad[1]);

                // Выводим информацию о текущей итерации
                textBox1.AppendText($"Итерация {k}:\r\n");
                textBox1.AppendText($"x^{k} = ({x_k[0]}; {x_k[1]})\r\n");
                textBox1.AppendText($"f(x^{k}) = {CalculateFunction(x_k)}\r\n");
                textBox1.AppendText($"∇f(x^{k}) = ({grad[0]}; {grad[1]})\r\n");

                // Проверка условий остановки
                if (gradNorm < epsilon1)
                {
                    textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} < {epsilon1}\r\n");
                    exitReason = $"Критерий сходимости по градиенту (||∇f(x^{k})|| < {epsilon1})";
                    break;
                }
                else
                {
                    textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} > {epsilon1}\r\n");
                }

                if (k >= M)
                {
                    exitReason = $"Превышено максимальное число итераций (k = {k} >= {M} = M)";
                    break;
                }
                else
                {
                    textBox1.AppendText($"k = {k} < {M} = M\r\n");
                }

                // Вычисление шага t_k по заданной формуле
                double t_k = CalculateStep(x_k[0], x_k[1]);

                // Сохраняем предыдущее значение x перед обновлением
                x_prev = (double[])x_k.Clone();

                // Обновление точки
                x_k[0] = x_k[0] - t_k * grad[0];
                x_k[1] = x_k[1] - t_k * grad[1];

                textBox1.AppendText($"t_{k} = {t_k}\r\n");
                textBox1.AppendText($"x^{k + 1} = ({x_k[0]}; {x_k[1]})\r\n");

                if (k >= 0)
                {
                    double xDiffNorm = Math.Sqrt(Math.Pow(x_k[0] - x_prev[0], 2) + Math.Pow(x_k[1] - x_prev[1], 2));
                    double fDiff = Math.Abs(CalculateFunction(x_k) - CalculateFunction(x_prev));

                    bool smallChangesNow = (xDiffNorm < epsilon2) && (fDiff < epsilon2);
                    if (xDiffNorm < epsilon2)
                    {
                        textBox1.AppendText($"||x^{k+1} - x^{k}|| = {xDiffNorm} < {epsilon2}\r\n");
                        exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях\r\n" +
                            $"||x^{k+1} - x^{k}|| < ε_2";
                    }
                    else
                    {
                        textBox1.AppendText($"||x^{k+1} - x^{k}|| = {xDiffNorm} > {epsilon2}\r\n");
                    }

                    if (fDiff < epsilon2)
                    {
                        textBox1.AppendText($"||f(x^{k+1}) - f(x^{k})|| = {fDiff} < {epsilon2}\r\n");
                        exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях\r\n" +
                            $"||f(x^{k+1}) - f(x^{k})|| < ε_2";
                    }
                    else
                    {
                        textBox1.AppendText($"||f(x^{k + 1} ) - f(x^ {k})|| = {fDiff} > {epsilon2}\r\n");
                    }

                    if (smallChangesNow && smallChangesOnLastIteration)
                    {
                        break;
                    }
                    smallChangesOnLastIteration = smallChangesNow;
                }

                textBox1.AppendText($"\r\n");
                k++;
            }

            // Вывод результатов
            textBox1.AppendText($"\r\nРезультаты:\r\n");
            textBox1.AppendText($"x* = ({x_k[0]}; {x_k[1]})\r\n");
            textBox1.AppendText($"f(x*) = {CalculateFunction(x_k)}\r\n");
            textBox1.AppendText($"Количество итераций: {k+1}\r\n");
            textBox1.AppendText($"Условие выхода: {exitReason}\r\n\r\n");
            textBox1.AppendText($"Аналитическое решение:\r\n");
            textBox1.AppendText($"x* = (-14/27;1/27) = ({(double)-14/27}; {(double)1 /27})\r\n");
            textBox1.AppendText($"f(x^*) = {CalculateFunction(new double[] { -14.0 / 27, 1.0 / 27 })}\r\n");
        }

        // Функция для вычисления
        private double CalculateFunction(double[] x)
        {
            return x[0] * x[0] + 7 * x[1] * x[1] + x[0] * x[1] + x[0];
        }

        // Градиент функции
        private double[] CalculateGradient(double[] x)
        {
            double df_dx1 = 2 * x[0] + x[1] + 1;
            double df_dx2 = 14 * x[1] + x[0];
            return new double[] { df_dx1, df_dx2 };
        }

        // Расчет шага по заданной формуле
        private double CalculateStep(double x_k, double y_k)
        {
            double denominator = 2 * (13 * Math.Pow(x_k, 2) + 229 * x_k * y_k + 5 * x_k + 1387 * Math.Pow(y_k, 2) + 16 * y_k + 1);
            double numerator = 5 * Math.Pow(x_k, 2) + 32 * x_k * y_k + 4 * x_k + 197 * Math.Pow(y_k, 2) + 2 * y_k + 1;
            return numerator / denominator;
        }




    }
}
