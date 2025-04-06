using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Optimization_methods_Lab
{
    public partial class NewtonMethod : Form
    {
        private WindowLab2 mainForm;
        private TextBox textBox1;

        public NewtonMethod(WindowLab2 menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += NewtonMethod_FormClosed;
            Lab2_NewtonMethod();
        }

        private void NewtonMethod_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }


        //void Lab2_NewtonMethod()
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

        //    // ЗДЕСЬ НУЖНО ДОПИСАТЬ КОД

        //}


        //void Lab2_NewtonMethod()
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

        //    // Инициализация переменных
        //    double[] x_k = (double[])x_0.Clone();
        //    int k = 0;
        //    bool exitCondition = false;
        //    string exitReason = "";

        //    while (!exitCondition)
        //    {
        //        textBox1.AppendText($"Итерация {k}:\r\n");
        //        textBox1.AppendText($"x^{k} = ({x_k[0]}; {x_k[1]})\r\n");
        //        textBox1.AppendText($"f(x^{k}) = {CalculateFunction(x_k)}\r\n");

        //        // Шаг 3: Вычислить градиент ∇f(x^k)
        //        double[] gradient = ComputeGradient(x_k);
        //        textBox1.AppendText($"∇f(x^{k}) = ({gradient[0]}; {gradient[1]})\r\n");

        //        // Шаг 4: Проверить критерий окончания ||∇f(x^k)|| ≤ ε1
        //        double gradNorm = Math.Sqrt(gradient[0] * gradient[0] + gradient[1] * gradient[1]);

        //        if (gradNorm <= epsilon1)
        //        {
        //            textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} < {epsilon1} = ε1\r\n");
        //            exitReason = "Критерий окончания ||∇f(x^{k})|| ≤ ε1 выполнен";
        //            exitCondition = true;
        //            break;
        //        }
        //        else
        //        {
        //            textBox1.AppendText($"||∇f(x^{k})|| = {gradNorm} > {epsilon1} = ε1\r\n");
        //        }

        //        // Шаг 5: Проверить k ≥ M
        //        if (k >= M)
        //        {
        //            exitReason = "Достигнуто максимальное число итераций M";
        //            exitCondition = true;
        //            break;
        //        }

        //        // Шаг 6: Вычислить матрицу Гессе H(x^k)
        //        double[,] hessian = ComputeHessian(x_k);
        //        textBox1.AppendText("H(x^k) = \r\n");
        //        textBox1.AppendText($"[{hessian[0, 0]} {hessian[0, 1]}]\r\n");
        //        textBox1.AppendText($"[{hessian[1, 0]} {hessian[1, 1]}]\r\n");

        //        // Шаг 7: Вычислить обратную матрицу H^-1(x^k)
        //        double[,] hessianInverse = InvertMatrix(hessian);
        //        textBox1.AppendText("H^-1(x^k) = \r\n");
        //        textBox1.AppendText($"[{hessianInverse[0, 0]} {hessianInverse[0, 1]}]\r\n");
        //        textBox1.AppendText($"[{hessianInverse[1, 0]} {hessianInverse[1, 1]}]\r\n");

        //        // Шаг 8: Проверить H^-1(x^k) > 0
        //        bool isPositiveDefinite = IsPositiveDefinite(hessianInverse);
        //        double[] d_k;

        //        if (isPositiveDefinite)
        //        {
        //            // Шаг 9: Определить d^k = -H^-1(x^k)∇f(x^k)
        //            d_k = MultiplyMatrixVector(hessianInverse, gradient);
        //            d_k[0] = -d_k[0];
        //            d_k[1] = -d_k[1];
        //            textBox1.AppendText("H^-1(x^k) > 0, используем метод Ньютона\r\n");
        //        }
        //        else
        //        {
        //            // Шаг 10: Положить d^k = -∇f(x^k)
        //            d_k = new double[] { -gradient[0], -gradient[1] };
        //            textBox1.AppendText("H^-1(x^k) не положительно определена, используем градиентный спуск\r\n");
        //        }

        //        textBox1.AppendText($"d^k = ({d_k[0]}; {d_k[1]})\r\n");

        //        // Шаг 10: Найти точку x^{k+1}
        //        double[] x_k_plus_1;
        //        if (isPositiveDefinite)
        //        {
        //            // Используем шаг 1 для метода Ньютона
        //            x_k_plus_1 = new double[] { x_k[0] + d_k[0], x_k[1] + d_k[1] };
        //        }
        //        else
        //        {
        //            // Ищем подходящий шаг t_k для градиентного спуска
        //            double t_k = FindStepSize(x_k, d_k, gradient);
        //            x_k_plus_1 = new double[] { x_k[0] + t_k * d_k[0], x_k[1] + t_k * d_k[1] };
        //        }

        //        textBox1.AppendText($"x^{k + 1} = ({x_k_plus_1[0]}; {x_k_plus_1[1]})\r\n");

        //        // Шаг 11: Проверить условия выхода
        //        double xDiffNorm = Math.Sqrt(Math.Pow(x_k_plus_1[0] - x_k[0], 2) + Math.Pow(x_k_plus_1[1] - x_k[1], 2));
        //        double fDiff = Math.Abs(CalculateFunction(x_k_plus_1) - Math.Abs(CalculateFunction(x_k)));

        //        textBox1.AppendText($"||x^{k + 1} - x^{k}|| = {xDiffNorm} (ε2 = {epsilon2})\r\n");
        //        textBox1.AppendText($"|f(x^{k + 1}) - f(x^{k})| = {fDiff} (ε2 = {epsilon2})\r\n");

        //        if (xDiffNorm < epsilon2 && fDiff < epsilon2)
        //        {
        //            if (k > 0) // Проверяем, что это не первая итерация
        //            {
        //                exitReason = "Условия ||x^{k+1} - x^k|| < ε2 и |f(x^{k+1}) - f(x^k)| < ε2 выполнены";
        //                exitCondition = true;
        //            }
        //        }

        //        // Обновляем переменные для следующей итерации
        //        x_k = x_k_plus_1;
        //        k++;

        //        textBox1.AppendText("\r\n");
        //    }

        //    // Вывод результатов
        //    textBox1.AppendText("\r\nРезультаты:\r\n");
        //    textBox1.AppendText($"x* = ({x_k[0]}; {x_k[1]})\r\n");
        //    textBox1.AppendText($"f(x*) = {CalculateFunction(x_k)}\r\n");
        //    textBox1.AppendText($"Количество итераций: {k}\r\n");
        //    textBox1.AppendText($"Выход по условию: {exitReason}\r\n\r\n");
        //    textBox1.AppendText($"Аналитическое решение:\r\n");
        //    textBox1.AppendText($"x* = (-14/27;1/27) = ({(double)-14 / 27}; {(double)1 / 27})\r\n");
        //    textBox1.AppendText($"f(x^*) = {CalculateFunction(new double[] { -14.0 / 27, 1.0 / 27 })}\r\n");
        //}

        //// Вспомогательные методы

        //// Вычисление функции f(x) = x1^2 + 7x2^2 + x1x2 + x1
        //private double CalculateFunction(double[] x)
        //{
        //    return Math.Round(x[0] * x[0] + 7 * x[1] * x[1] + x[0] * x[1] + x[0], 10);
        //}

        //// Вычисление градиента ∇f(x)
        //private double[] ComputeGradient(double[] x)
        //{
        //    double df_dx1 = 2 * x[0] + x[1] + 1;
        //    double df_dx2 = 14 * x[1] + x[0];
        //    return new double[] { Math.Round(df_dx1,10), Math.Round(df_dx2,10) };
        //}

        //// Вычисление матрицы Гессе H(x)
        //private double[,] ComputeHessian(double[] x)
        //{
        //    // Для данной функции матрица Гессе постоянна
        //    return new double[,] { { 2, 1 }, { 1, 14 } };
        //}

        //// Проверка положительной определенности матрицы
        //private bool IsPositiveDefinite(double[,] matrix)
        //{
        //    // Проверяем условие Сильвестра: главные миноры должны быть положительны
        //    double det1 = matrix[0, 0];
        //    double det2 = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        //    return det1 > 0 && det2 > 0;
        //}

        //// Инверсия матрицы 2x2
        //private double[,] InvertMatrix(double[,] matrix)
        //{
        //    double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        //    return new double[,] {
        //        { matrix[1, 1]/det, -matrix[0, 1]/det },
        //        { -matrix[1, 0]/det, matrix[0, 0]/det }
        //    };
        //}

        //// Умножение матрицы на вектор
        //private double[] MultiplyMatrixVector(double[,] matrix, double[] vector)
        //{
        //    return new double[] {
        //        matrix[0, 0] * vector[0] + matrix[0, 1] * vector[1],
        //        matrix[1, 0] * vector[0] + matrix[1, 1] * vector[1]
        //    };
        //}

        //// Поиск размера шага для градиентного спуска
        //private double FindStepSize(double[] x, double[] d, double[] gradient)
        //{
        //    double t = 1.0;
        //    double c = 0.5; // Коэффициент уменьшения шага
        //    double rho = 0.5; // Коэффициент достаточного убывания

        //    double f_x = CalculateFunction(x);
        //    double[] x_new = new double[2];
        //    double f_x_new;
        //    double directionalDerivative = gradient[0] * d[0] + gradient[1] * d[1];

        //    do
        //    {
        //        x_new[0] = x[0] + t * d[0];
        //        x_new[1] = x[1] + t * d[1];
        //        f_x_new = CalculateFunction(x_new);

        //        if (f_x_new < f_x + rho * t * directionalDerivative)
        //            break;

        //        t *= c;
        //    } while (true);

        //    return t;
        //}






        void Lab2_NewtonMethod()
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

            // Инициализация переменных
            double[] x_k = (double[])x_0.Clone();
            int k = 0;
            string exitReason = "";
            bool smallChangesOnLastIteration = false;

            while (true)
            {
                textBox1.AppendText($"Итерация {k}:\r\n");
                textBox1.AppendText($"x^{k} = ({x_k[0]}; {x_k[1]})\r\n");
                textBox1.AppendText($"f(x^{k}) = {CalculateFunction(x_k)}\r\n");

                // Шаг 3: Вычислить градиент ∇f(x^k)
                double[] gradient = CalculateGradient(x_k);
                textBox1.AppendText($"∇f(x^{k}) = ({gradient[0]}; {gradient[1]})\r\n");

                // Шаг 4: Проверить критерий окончания ||∇f(x^k)|| ≤ ε1
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

                // Шаг 5: Проверить k ≥ M
                if (k >= M)
                {
                    exitReason = $"Превышено максимальное число итераций (k = {k} >= {M} = M)";
                    break;
                }
                else
                {
                    textBox1.AppendText($"k = {k} < {M} = M\r\n");
                }

                // Шаг 6: Вычислить матрицу Гессе H(x^k)
                double[,] hessian = ComputeHessian(x_k);
                textBox1.AppendText($"H(x^{k}) = \r\n");
                textBox1.AppendText($"         [{hessian[0, 0]} {hessian[0, 1]}]\r\n");
                textBox1.AppendText($"         [{hessian[1, 0]} {hessian[1, 1]}]\r\n");

                // Шаг 7: Вычислить обратную матрицу H^-1(x^k)
                double[,] hessianInverse = InvertMatrix(hessian);
                textBox1.AppendText($"H^-1(x^{k}) = \r\n");
                textBox1.AppendText($"         [{hessianInverse[0, 0]} {hessianInverse[0, 1]}]\r\n");
                textBox1.AppendText($"         [{hessianInverse[1, 0]} {hessianInverse[1, 1]}]\r\n");

                // Шаг 8: Проверить H^-1(x^k) > 0
                bool isPositiveDefinite = IsPositiveDefinite(hessianInverse);
                double[] d_k;


                if (isPositiveDefinite)
                {
                    // Шаг 9: Определить d^k = -H^-1(x^k)∇f(x^k)
                    d_k = MultiplyMatrixVector(hessianInverse, gradient);
                    d_k[0] = -d_k[0];
                    d_k[1] = -d_k[1];
                    textBox1.AppendText($"H^-1(x^{k}) > 0, используем метод Ньютона\r\n");
                }
                else
                {
                    // Шаг 10: Положить d^k = -∇f(x^k)
                    d_k = new double[] { -gradient[0], -gradient[1] };
                    textBox1.AppendText($"H^-1(x^{k}) не положительно определена, используем градиентный спуск\r\n");
                }

                textBox1.AppendText($"d^{k} = ({d_k[0]}; {d_k[1]})\r\n");

                // Шаг 10: Найти точку x^{k+1}
                double[] x_k_plus_1;
                if (isPositiveDefinite)
                {
                    // Используем шаг 1 для метода Ньютона
                    x_k_plus_1 = new double[] { x_k[0] + d_k[0], x_k[1] + d_k[1] };
                }
                else
                {
                    // Ищем подходящий шаг t_k для градиентного спуска
                    double t_k = FindStepSize(x_k, d_k, gradient);
                    x_k_plus_1 = new double[] { x_k[0] + t_k * d_k[0], x_k[1] + t_k * d_k[1] };
                }

                textBox1.AppendText($"x^{k + 1} = ({x_k_plus_1[0]}; {x_k_plus_1[1]})\r\n");

                // Шаг 11: Проверить условия выхода
                double xDiffNorm = Math.Sqrt(Math.Pow(x_k_plus_1[0] - x_k[0], 2) + Math.Pow(x_k_plus_1[1] - x_k[1], 2));
                double fDiff = Math.Abs(CalculateFunction(x_k_plus_1) - Math.Abs(CalculateFunction(x_k)));

                //textBox1.AppendText($"||x^{k + 1} - x^{k}|| = {xDiffNorm} (ε2 = {epsilon2})\r\n");
                //textBox1.AppendText($"|f(x^{k + 1}) - f(x^{k})| = {fDiff} (ε2 = {epsilon2})\r\n");

                bool smallChangesNow = (xDiffNorm < epsilon2) && (fDiff < epsilon2);




                if (xDiffNorm < epsilon2)
                {
                    textBox1.AppendText($"||x^{k + 1} - x^{k}|| = {xDiffNorm} < {epsilon2}\r\n");
                    exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях\r\n" +
                        $"||x^{k + 1} - x^{k}|| < ε_2";
                }
                else
                {
                    textBox1.AppendText($"||x^{k + 1} - x^{k}|| = {xDiffNorm} > {epsilon2}\r\n");
                }

                if (fDiff < epsilon2)
                {
                    textBox1.AppendText($"||f(x^{k + 1}) - f(x^{k})|| = {fDiff} < {epsilon2}\r\n");
                    exitReason = $"Условие сходимости по малым изменениям (ε_2 = {epsilon2}) на двух последовательных итерациях\r\n" +
                        $"||f(x^{k + 1}) - f(x^{k})|| < ε_2";
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

                // Обновляем переменные для следующей итерации
                x_k = x_k_plus_1;
                k++;

                textBox1.AppendText("\r\n");
            }

            // Вывод результатов
            textBox1.AppendText("\r\nРезультаты:\r\n");
            textBox1.AppendText($"x* = ({x_k[0]}; {x_k[1]})\r\n");
            textBox1.AppendText($"f(x*) = {CalculateFunction(x_k)}\r\n");
            textBox1.AppendText($"Количество итераций: {k}\r\n");
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

        // Поиск размера шага для градиентного спуска
        private double FindStepSize(double[] x, double[] d, double[] gradient)
        {
            double t = 1.0;
            double c = 0.5; // Коэффициент уменьшения шага
            double rho = 0.5; // Коэффициент достаточного убывания

            double f_x = CalculateFunction(x);
            double[] x_new = new double[2];
            double f_x_new;
            double directionalDerivative = gradient[0] * d[0] + gradient[1] * d[1];

            do
            {
                x_new[0] = x[0] + t * d[0];
                x_new[1] = x[1] + t * d[1];
                f_x_new = CalculateFunction(x_new);

                if (f_x_new < f_x + rho * t * directionalDerivative)
                    break;

                t *= c;
            } while (true);

            return t;
        }
    }
}
