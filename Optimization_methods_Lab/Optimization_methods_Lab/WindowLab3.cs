using System;
using System.Windows.Forms;

namespace Optimization_methods_Lab
{
    public partial class WindowLab3 : Form
    {
        private Menu mainForm;
        private TextBox textBox1;

        public WindowLab3(Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += WindowLab3_FormClosed;
            Lab3();
        }

        private void WindowLab3_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        // Целевая функция f(x)
        private double F(double x1, double x2)
        {
            return x1 * x1 + 7 * x2 * x2 + x1 * x2 + x1;
        }

        // Ограничение g(x)
        private double G(double x1, double x2)
        {
            return x1 + x2 - 1;
        }

        // Штрафная функция P(x)
        private double P(double x1, double x2, double rk)
        {
            double g = G(x1, x2);
            return (rk / 2) * g * g;
        }

        // Вспомогательная функция F(x, rk)
        private double F_penalty(double x1, double x2, double rk)
        {
            return F(x1, x2) + P(x1, x2, rk);
        }

        // Градиент вспомогательной функции
        private double[] CalculateGradient(double x1, double x2, double rk)
        {
            double g = G(x1, x2);
            double df_dx1 = 2 * x1 + x2 + 1 + rk * g;
            double df_dx2 = 14 * x2 + x1 + rk * g;
            return new double[] { df_dx1, df_dx2 };
        }

        // Расчет оптимального шага (аналогично вашему методу)
        private double CalculateStep(double x1, double x2, double rk)
        {
            double[] gradient = CalculateGradient(x1, x2, rk);
            double gx1 = gradient[0];
            double gx2 = gradient[1];

            double numerator = gx1 * gx1 + gx2 * gx2;
            double denominator = 2 * gx1 * gx1 + 2 * gx1 * gx2 + 14 * gx2 * gx2 +
                                rk * (gx1 + gx2) * (gx1 + gx2);

            return numerator / denominator;
        }

        // Метод градиентного спуска для минимизации F(x, rk)
        private double[] GradientDescent(double x1, double x2, double rk, double epsilon)
        {
            double[] result = new double[2] { x1, x2 };
            double[] prevResult;
            int maxIterations = 1000;
            int k = 0;

            do
            {
                prevResult = (double[])result.Clone();
                double t_k = CalculateStep(result[0], result[1], rk);
                double[] gradient = CalculateGradient(result[0], result[1], rk);

                result[0] -= t_k * gradient[0];
                result[1] -= t_k * gradient[1];

                k++;

                // Проверка на сходимость
                double xDiffNorm = Math.Sqrt(Math.Pow(result[0] - prevResult[0], 2) +
                                  Math.Pow(result[1] - prevResult[1], 2));
                if (xDiffNorm < epsilon || k >= maxIterations) break;

            } while (true);

            return result;
        }

        void Lab3()
        {
            // Шаг 1. Инициализация параметров
            double epsilon = 0.0001;
            double rk = 1;  // Начальное значение штрафа
            int M = 20;       // Максимальное число итераций
            int k = 0;
            int C = 10;        // Множитель для увеличения штрафа

            // Начальная точка
            double[] xk = new double[2] { 0, 0 };

            // Вывод информации о задаче
            textBox1.AppendText($"Функция f(x) = x₁² + 7x₂² + x₁x₂ + x₁\r\n");
            textBox1.AppendText($"g(x)=x₁+x₂-1=0\r\n");
            textBox1.AppendText($"ε={epsilon}; C = {C}\r\n");
            textBox1.AppendText($"M={M}\r\n\r\n");

            // Заголовок таблицы
            textBox1.AppendText($"{"k",5} {"rk",15} {"x₁",15} {"x₂",20} {"F(x,rk)",15} {"P(x,rk)",15}  \r\n");
            textBox1.AppendText(new string('-', 95) + "\r\n");

            // Основной цикл алгоритма
            while (k < M)
            {
                try
                {
                    // Шаг 2-3: Найти точку минимума F(x, rk)
                    double[] x_star = GradientDescent(xk[0], xk[1], rk, epsilon);

                    // Вычисляем значения функций
                    double fx = F(x_star[0], x_star[1]);
                    double px = P(x_star[0], x_star[1], rk);
                    double Fx = F_penalty(x_star[0], x_star[1], rk);

                    // Вывод информации о текущей итерации
                    textBox1.AppendText($"{k,5} {rk,15} {x_star[0],15:F6} {x_star[1],15:F6} {Fx,15:F6} {px,15:F6}  \r\n");

                    // Шаг 4: Проверка условия окончания
                    if (px <= epsilon)
                    {
                        textBox1.AppendText($"\r\nУсловие окончания достигнуто: P(x) <= ε\r\n");
                        textBox1.AppendText($"Оптимальное решение: x₁ = {x_star[0]:F6}, x₂ = {x_star[1]:F6}\r\n");
                        textBox1.AppendText($"Значение функции: f(x*) = {fx:F6}\r\n");
                        break;
                    }

                    // Обновление параметров для следующей итерации
                    rk *= C;
                    xk = x_star;
                    k++;
                }
                catch (Exception ex)
                {
                    textBox1.AppendText($"Ошибка на итерации {k}: {ex.Message}\r\n");
                    break;
                }
            }

            if (k >= M)
            {
                textBox1.AppendText($"\r\nДостигнуто максимальное число итераций M = {M}\r\n");
            }
        }
    }
}


