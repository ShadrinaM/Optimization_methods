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
            Lab2_SteepestGradientDescentMethod();
        }

        private void SteepestGradientDescentMethod_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        void Lab2_SteepestGradientDescentMethod()
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


                // Выводим информацию о текущей итерации
                textBox1.AppendText($"Итерация {k}:\r\n");
                textBox1.AppendText($"x^{k} = ({x_k[0]}; {x_k[1]})\r\n");
                textBox1.AppendText($"f(x^{k}) = {CalculateFunction(x_k)}\r\n");

                // Вычисляем градиент
                double[] gradient = CalculateGradient(x_k);
                textBox1.AppendText($"∇f(x^{k}) = ({gradient[0]}; {gradient[1]})\r\n");

                double gradNorm = Math.Sqrt(gradient[0] * gradient[0] + gradient[1] * gradient[1]);

                // Проверка условий остановки
                if (gradNorm < epsilon1)
                {
                    textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} < {epsilon1} = ε1\r\n");
                    exitReason = $"Критерий сходимости по градиенту (||∇f(x^{k})|| < {epsilon1} = ε1)";
                    break;
                }
                else
                {
                    textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} > {epsilon1} = ε1\r\n");
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

                // Найти точку x^{k+1}
                x_k[0] = x_k[0] - t_k * gradient[0];
                x_k[1] = x_k[1] - t_k * gradient[1];

                textBox1.AppendText($"t_{k} = {t_k}\r\n");
                textBox1.AppendText($"x^{k + 1} = ({x_k[0]}; {x_k[1]})\r\n");

                // Проверить условия выхода
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
                                
                k++;
                textBox1.AppendText($"\r\n");
            }

            // Вывод результатов
            textBox1.AppendText($"\r\nРезультаты:\r\n");
            textBox1.AppendText($"x* = ({x_k[0]}; {x_k[1]})\r\n");
            textBox1.AppendText($"f(x*) = {CalculateFunction(x_k)}\r\n");
            textBox1.AppendText($"Количество итераций: {k+1}\r\n");
            textBox1.AppendText($"Выход по условию: {exitReason}\r\n\r\n");
            textBox1.AppendText($"Аналитическое решение:\r\n");
            textBox1.AppendText($"x* = (-14/27;1/27) = ({(double)-14/27}; {(double)1 /27})\r\n");
            textBox1.AppendText($"f(x*) = {CalculateFunction(new double[] { -14.0 / 27, 1.0 / 27 })}\r\n");
        }

        // Вычисление индивидуальной функции f(x) = x1^2 + 7x2^2 + x1x2 + x1
        private double CalculateFunction(double[] x)
        {
            return Math.Round(x[0] * x[0] + 7 * x[1] * x[1] + x[0] * x[1] + x[0],10);
        }

        // Вычисление градиента функции ∇f(x)
        private double[] CalculateGradient(double[] x)
        {
            double df_dx1 = 2 * x[0] + x[1] + 1;
            double df_dx2 = 14 * x[1] + x[0];
            return new double[] { Math.Round(df_dx1, 10), Math.Round(df_dx2, 10) };
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
