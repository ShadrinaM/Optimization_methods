using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Optimization_methods_Lab
{
    public partial class NewtonRaphsonMethod : Form
    {
        private WindowLab2 mainForm;
        private TextBox textBox1;

        public NewtonRaphsonMethod(WindowLab2 menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += NewtonRaphsonMethod_FormClosed;
            Lab2_NewtonRaphsonMethod();
        }

        private void NewtonRaphsonMethod_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        void Lab2_NewtonRaphsonMethod()
        {
            // Шаг 1. Инициализация параметров
            double epsilon1 = 0.1;
            double epsilon2 = 0.15;
            double[] x_k = { 1.1, 1.1 };
            int M = 10;
            int k = 0;
            string exitReason = "";
            bool smallChangesOnLastIteration = false;

            // Выписка из формулировки задания
            textBox1.AppendText($"Функция f(x) = x₁² + 7x₂² + x₁x₂ + x₁\r\n");
            textBox1.AppendText($"x^0=({x_k[0]}; {x_k[1]})\r\n");
            textBox1.AppendText($"ε_1={epsilon1}; ε_2={epsilon2}\r\n");
            textBox1.AppendText($"M={M}\r\n\r\n");

            while (true)
            {
                textBox1.AppendText($"Итерация {k}:\r\n");
                textBox1.AppendText($"x^{k} = ({x_k[0]}; {x_k[1]})\r\n");
                textBox1.AppendText($"f(x^{k}) = {CalculateFunction(x_k)}\r\n");

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

                // Шаг 5. Проверить максимальное число итераций k ≥ M
                if (k >= M)
                {
                    exitReason = $"Превышено максимальное число итераций (k = {k} >= {M} = M)";
                    break;
                }
                else
                {
                    textBox1.AppendText($"k = {k} < {M} = M\r\n");
                }

                // Шаг 6. Вычислить матрицу Гессе H(x^k)
                double[,] hessian = ComputeHessian(x_k);
                textBox1.AppendText($"H(x^{k}) = \r\n");
                textBox1.AppendText($"         [{hessian[0, 0]} {hessian[0, 1]}]\r\n");
                textBox1.AppendText($"         [{hessian[1, 0]} {hessian[1, 1]}]\r\n");

                // Шаг 7. Вычислить обратную матрицу H^-1(x^k)
                double[,] hessianInverse = InvertMatrix(hessian);
                textBox1.AppendText($"H^-1(x^{k}) = \r\n");
                textBox1.AppendText($"         [{hessianInverse[0, 0]} {hessianInverse[0, 1]}]\r\n");
                textBox1.AppendText($"         [{hessianInverse[1, 0]} {hessianInverse[1, 1]}]\r\n");

                // Шаг 8. Проверить положительную определенность
                double[] d_k;
                if (IsPositiveDefinite(hessianInverse))
                {
                    d_k = MultiplyMatrixVector(hessianInverse, gradient);
                    d_k[0] = -d_k[0]; d_k[1] = -d_k[1];
                    textBox1.AppendText("Используем направление Ньютона\r\n");
                }
                else
                {
                    d_k = new double[] { -gradient[0], -gradient[1] };
                    textBox1.AppendText("Используем градиентное направление\r\n");
                }
                textBox1.AppendText($"d^{k} = ({d_k[0]}; {d_k[1]})\r\n");

                // Шаг 9-11. Вычисляем t_k и новый x
                double t_k = CalculateStep(x_k, d_k);
                double[] x_k_plus_1 = { x_k[0] + t_k * d_k[0], x_k[1] + t_k * d_k[1] };
                textBox1.AppendText($"t_{k} = {t_k}\r\n");
                textBox1.AppendText($"x^{k + 1} = ({x_k_plus_1[0]}; {x_k_plus_1[1]})\r\n");

                // Шаг 12. Проверить условия сходимости
                double xDiffNorm = Math.Sqrt(Math.Pow(x_k_plus_1[0] - x_k[0], 2) + Math.Pow(x_k_plus_1[1] - x_k[1], 2));
                double fDiff = Math.Abs(CalculateFunction(x_k_plus_1) - CalculateFunction(x_k));
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
                    textBox1.AppendText($"||f(x^{k + 1}) - f(x^{k})|| = {fDiff} < {epsilon2} = ε_2\r\n");
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

                // Обновляем переменные для следующей итерации
                x_k = x_k_plus_1;
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

        // Вычисление матрицы Гессе H(x)
        private double[,] ComputeHessian(double[] x)
        {
            // Для данной функции матрица Гессе постоянна
            return new double[,] { { 2, 1 }, { 1, 14 } };
        }

        // Проверка положительной определенности матрицы
        private bool IsPositiveDefinite(double[,] matrix)
        {
            // Проверяем условие Сильвестра: главные миноры должны быть положительны
            double det1 = matrix[0, 0];
            double det2 = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            return det1 > 0 && det2 > 0;
        }

        // Инверсия матрицы 2x2
        private double[,] InvertMatrix(double[,] matrix)
        {
            double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            return new double[,] {
                { matrix[1, 1]/det, -matrix[0, 1]/det },
                { -matrix[1, 0]/det, matrix[0, 0]/det }
            };
        }

        // Умножение матрицы 2x2 на вектор 1x2
        private double[] MultiplyMatrixVector(double[,] matrix, double[] vector)
        {
            return new double[] {
                matrix[0, 0] * vector[0] + matrix[0, 1] * vector[1],
                matrix[1, 0] * vector[0] + matrix[1, 1] * vector[1]
            };
        }

        //Аналитический метод только для моего уравнения
        private double CalculateStep(double[] x, double[] d)
        {
            // Аналитический расчет для f(x) = x₁² + 7x₂² + x₁x₂ + x₁
            // Раскрываем φ(t) = f(x + t*d) = (x₁ + t*d₁)² + 7(x₂ + t*d₂)² + (x₁ + t*d₁)(x₂ + t*d₂) + (x₁ + t*d₁)
            // Находим t_min: dφ/dt = 0
            double d1 = d[0], d2 = d[1];
            double x1 = x[0], x2 = x[1];

            // Коэффициенты квадратичной формы φ(t) = a*t² + b*t + c
            double a = d1 * d1 + 7 * d2 * d2 + d1 * d2;
            double b = 2 * x1 * d1 + 14 * x2 * d2 + x1 * d2 + x2 * d1 + d1;

            if (Math.Abs(a) < 1e-10) // Если направление линейно
                return (b < 0) ? 1.0 : 0.0; // Выбираем границу интервала

            return -b / (2 * a); // t_min = -b/(2a)
        }

        //// Метод золотого сечения для поиска оптимального шага (такой т.к. формулировка а алгоритме не специфицирует метод).
        //// Значит допустимы: Аналитическое решение и Численные методы: (золотое сечение, параболическая интерполяция, метод Фибоначчи, backtracking line search и др.)
        //private double CalculateStep(double[] x, double[] d)
        //{
        //    double a = 0;
        //    double b = 1;
        //    double tau = (Math.Sqrt(5) - 1) / 2; // Золотое сечение ≈ 0.618
        //    double epsilon = 1e-6;

        //    double x1 = b - tau * (b - a);
        //    double x2 = a + tau * (b - a);

        //    while (Math.Abs(b - a) > epsilon)
        //    {
        //        double[] point1 = { x[0] + x1 * d[0], x[1] + x1 * d[1] };
        //        double[] point2 = { x[0] + x2 * d[0], x[1] + x2 * d[1] };

        //        double f1 = CalculateFunction(point1);
        //        double f2 = CalculateFunction(point2);
        //        if (f1 < f2)
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
    }
}
