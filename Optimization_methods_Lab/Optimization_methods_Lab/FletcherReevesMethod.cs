using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Optimization_methods_Lab
{
    public partial class FletcherReevesMethod : Form
    {
        private WindowLab2 mainForm;
        private TextBox textBox1;

        public FletcherReevesMethod(WindowLab2 menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += FletcherReevesMethod_FormClosed;
            Lab2_FletcherReevesMethod();
        }

        private void FletcherReevesMethod_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        void Lab2_FletcherReevesMethod()
        {
            // Шаг 1. Инициализация параметров
            double epsilon1 = 0.1;
            double epsilon2 = 0.15;
            double[] x_k = { 1.1, 1.1 };
            int M = 10;
            int k = 0;
            string exitReason = "";
            bool smallChangesOnLastIteration = false;
            double[] d_k = new double[2];
            double[] x_prev = new double[2];
            double[] grad_prev = new double[2];

            // Выписка из формулировки задания
            textBox1.AppendText($"Функция f(x) = x₁² + 7x₂² + x₁x₂ + x₁\r\n");
            textBox1.AppendText($"x^0=({x_k[0]}; {x_k[1]})\r\n");
            textBox1.AppendText($"ε_1={epsilon1}; ε_2={epsilon2}\r\n");
            textBox1.AppendText($"M={M}\r\n\r\n");
            while (true)
            {
                textBox1.AppendText($"Итерация {k}\r\n");
                textBox1.AppendText($"x^{k} = ({x_k[0]}; {x_k[1]})\r\n");

                // Шаг 3. Вычислить градиент ∇f(x^k)
                double[] gradient = CalculateGradient(x_k);
                textBox1.AppendText($"∇f(x^{k}) = ({gradient[0]}; {gradient[1]})\r\n");
                
                // Шаг 4. Проверить критерий окончания по градиенту||∇f(x^k)|| ≤ ε1
                double gradNorm = Math.Sqrt(gradient[0] * gradient[0] + gradient[1] * gradient[1]);
                if (gradNorm <= epsilon1)
                {
                    textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} < {epsilon1} = ε1\r\n");
                    exitReason = $"Критерий окончания ||∇f(x^{k})|| < {epsilon1} = ε1";
                    break;
                }
                else
                {
                    textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} > {epsilon1} = ε1\r\n");
                }

                // Шаг 5. Проверка ограничения по числу итераций
                if (k >= M)
                {
                    exitReason = $"Превышено максимальное число итераций (k = {k} >= {M} = M)";
                    break;
                }
                else
                {
                    textBox1.AppendText($"k = {k} < {M} = M\r\n");
                }

                // Шаг 6,7,9. Определение направления d^k

                if (k == 0)
                {
                    d_k[0] = -gradient[0];
                    d_k[1] = -gradient[1];
                    textBox1.AppendText($"d_{0} = {d_k[0]},{d_k[1]}\r\n");
                }
                else
                {
                    double beta_k = (gradient[0] * gradient[0] + gradient[1] * gradient[1]) /
                                    (grad_prev[0] * grad_prev[0] + grad_prev[1] * grad_prev[1]);
                    textBox1.AppendText($"β_{k - 1} = ({gradient[0]} * {gradient[0]} + {gradient[1]} * {gradient[1]})/({grad_prev[0]} * {grad_prev[0]} + {grad_prev[1]} * {grad_prev[1]})\r\n");

                    d_k[0] = -gradient[0] + beta_k * d_k[0];
                    d_k[1] = -gradient[1] + beta_k * d_k[1];

                    textBox1.AppendText($"β_{k - 1} = {beta_k}\r\n");
                    textBox1.AppendText($"d_{k - 1} = ({d_k[0]},{d_k[1]})\r\n");
                }

                // Шаг 9. Линия поиска: найти t_k
                double t_k = CalculateStep(x_k, d_k);
                textBox1.AppendText($"t_{k} = {t_k}\r\n");

                // Шаг 10. Вычислить x^{k+1}
                x_prev[0] = x_k[0];
                x_prev[1] = x_k[1];
                x_k[0] += t_k * d_k[0];
                x_k[1] += t_k * d_k[1];
                textBox1.AppendText($"x^{k + 1} = ({x_k[0]}; {x_k[1]})\r\n");

                // Шаг 11. Проверка изменений
                double xDiffNorm = Math.Sqrt(Math.Pow(x_k[0] - x_prev[0], 2) + Math.Pow(x_k[1] - x_prev[1], 2));
                double fDiff = Math.Abs(CalculateFunction(x_k) - CalculateFunction(x_prev));
                bool smallChangesNow = (xDiffNorm < epsilon2) && (fDiff < epsilon2);

                if (xDiffNorm < epsilon2)
                {
                    textBox1.AppendText($"||x^{k + 1} - x^{k}|| = {xDiffNorm} < {epsilon2} = ε_2\r\n");
                    exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях\r\n" +
                        $"||x^{k + 1} - x^{k}|| < ε_2";
                }
                else
                {
                    textBox1.AppendText($"||x^{k + 1} - x^{k}|| = {xDiffNorm} > {epsilon2} = ε_2\r\n");
                }

                if (fDiff < epsilon2)
                {
                    textBox1.AppendText($"||f(x^{k + 1}) - f(x^{k})|| = {fDiff} < {epsilon2} = ε_2 \r\n");
                    exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях\r\n" +
                        $"||f(x^{k + 1}) - f(x^{k})|| < ε_2";
                }
                else
                {
                    textBox1.AppendText($"||f(x^{k + 1} ) - f(x^ {k})|| = {fDiff} > {epsilon2} = ε_2\r\n");
                }

                if (smallChangesNow && smallChangesOnLastIteration)
                {
                    break;
                }
                smallChangesOnLastIteration = smallChangesNow;

                // Подготовка к следующей итерации
                grad_prev[0] = gradient[0];
                grad_prev[1] = gradient[1];
                k++;
                textBox1.AppendText("\r\n");
            }

            // Вывод результатов
            textBox1.AppendText("\r\nРезультаты:\r\n");
            textBox1.AppendText($"x* = ({x_k[0]}; {x_k[1]})\r\n");
            textBox1.AppendText($"f(x*) = {CalculateFunction(x_k)}\r\n");
            textBox1.AppendText($"Количество итераций: {k + 1}\r\n");
            textBox1.AppendText($"Выход по условию: {exitReason}\r\n\r\n");
            textBox1.AppendText($"Аналитическое решение:\r\n");
            textBox1.AppendText($"x* = (-14/27;1/27) = ({(double)-14 / 27}; {(double)1 / 27})\r\n");
            textBox1.AppendText($"f(x*) = {CalculateFunction(new double[] { -14.0 / 27, 1.0 / 27 })}\r\n");
        }

        // Вычисление индивидуальной функции f(x) = x1^2 + 7x2^2 + x1x2 + x1
        private double CalculateFunction(double[] x)
        {
            return Math.Round(x[0] * x[0] + 7 * x[1] * x[1] + x[0] * x[1] + x[0], 10);
        }

        // Вычисление градиента функции ∇f(x)
        private double[] CalculateGradient(double[] x)
        {
            double df_dx1 = 2 * x[0] + x[1] + 1;
            double df_dx2 = 14 * x[1] + x[0];
            return new double[] { Math.Round(df_dx1, 10), Math.Round(df_dx2, 10) };
        }

        // Метод золотого сечения для поиска оптимального шага (такой т.к. формулировка а алгоритме не специфицирует метод).
        // Значит допустимы: Аналитическое решение и Численные методы: (золотое сечение, параболическая интерполяция, метод Фибоначчи, backtracking line search и др.)
        private double CalculateStep(double[] x, double[] d)
        {
            double a = 0;
            double b = 1;
            double tau = (Math.Sqrt(5) - 1) / 2; // Золотое сечение ≈ 0.618
            double epsilon = 1e-6;

            double x1 = b - tau * (b - a);
            double x2 = a + tau * (b - a);

            while (Math.Abs(b - a) > epsilon)
            {
                double[] point1 = { x[0] + x1 * d[0], x[1] + x1 * d[1] };
                double[] point2 = { x[0] + x2 * d[0], x[1] + x2 * d[1] };

                double f1 = CalculateFunction(point1);
                double f2 = CalculateFunction(point2);

                if (f1 < f2)
                {
                    b = x2;
                    x2 = x1;
                    x1 = b - tau * (b - a);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = a + tau * (b - a);
                }
            }

            return (a + b) / 2;
        }
    }
}
