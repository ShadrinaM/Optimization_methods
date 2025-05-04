//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Optimization_methods_Lab
//{
//    public partial class WindowLab3 : Form
//    {
//        private Menu mainForm;
//        private TextBox textBox1;
//        public WindowLab3(Menu menushka)
//        {
//            InitializeComponent();
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.mainForm = menushka;
//            this.FormClosed += WindowLab3_FormClosed;
//            Lab3();
//        }
//        private void BackToMenu_Click(object sender, EventArgs e)
//        {
//            // Показываем главное окно
//            mainForm.Show();
//            // Закрываем текущее окно
//            this.Close();
//        }
//        private void WindowLab3_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            // Показываем главное окно при закрытии текущего
//            mainForm.Show();
//        }

//        void Lab3()
//        {
//            // Шаг 1. Инициализация параметров
//            double epsilon = 0.0001;
//            double rk = 1;
//            int M = 50; // Максимальное число итераций
//            int k = 0;
//            int C = 10;


//            // Выписка из формулировки задания
//            textBox1.AppendText($"Функция f(x) = x₁² + 7x₂² + x₁x₂ + x₁\r\n");
//            textBox1.AppendText($"g(x)=x₁+x₂-1=0\r\n");
//            textBox1.AppendText($"ε={epsilon}; C = {C}\r\n");
//            textBox1.AppendText($"M={M}\r\n\r\n");

//            // ЗДЕСЬ ДОПОЛНИ КОД
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void BackToMenu_Click(object sender, EventArgs e)
        {
            // Показываем главное окно
            mainForm.Show();
            // Закрываем текущее окно
            this.Close();
        }
        private void WindowLab3_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Показываем главное окно при закрытии текущего
            mainForm.Show();
        }

        // Целевая функция f(x)
        private double F(double x1, double x2)
        {
            return Math.Pow(x1, 2) + 7 * Math.Pow(x2, 2) + x1 * x2 + x1;
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
            return (rk / 2) * Math.Pow(g, 2);
        }

        // Вспомогательная функция F(x, rk)
        private double F_penalty(double x1, double x2, double rk)
        {
            return F(x1, x2) + P(x1, x2, rk);
        }

        // Метод градиентного спуска для минимизации F(x, rk)
        private double[] GradientDescent(double x1, double x2, double rk, double epsilon)
        {
            double learningRate = 0.01;
            int maxIterations = 1000;
            double[] result = new double[2] { x1, x2 };

            for (int i = 0; i < maxIterations; i++)
            {
                // Вычисляем градиент F_penalty
                double g = G(result[0], result[1]);

                // Производные по x1 и x2
                double df_dx1 = 2 * result[0] + result[1] + 1 + rk * g;
                double df_dx2 = 14 * result[1] + result[0] + rk * g;

                // Обновляем параметры
                double new_x1 = result[0] - learningRate * df_dx1;
                double new_x2 = result[1] - learningRate * df_dx2;

                // Проверка на сходимость
                if (Math.Abs(new_x1 - result[0]) < epsilon && Math.Abs(new_x2 - result[1]) < epsilon)
                {
                    break;
                }

                result[0] = new_x1;
                result[1] = new_x2;
            }

            return result;
        }

        void Lab3()
        {
            // Шаг 1. Инициализация параметров
            double epsilon = 0.0001;
            double rk = 1;
            int M = 20; // Максимальное число итераций
            int k = 0;
            int C = 2;

            // Начальная точка
            double[] xk = new double[2] { 0, 0 };

            // Выписка из формулировки задания
            textBox1.AppendText($"Функция f(x) = x₁² + 7x₂² + x₁x₂ + x₁\r\n");
            textBox1.AppendText($"g(x)=x₁+x₂-1=0\r\n");
            textBox1.AppendText($"ε={epsilon}; C = {C}\r\n");
            textBox1.AppendText($"M={M}\r\n\r\n");

            // Заголовок таблицы
            textBox1.AppendText($"{"k",5} {"rk",15} {"x₁",15} {"x₂",15} {"f(x)",15} {"P(x,rk)",15} {"F(x,rk)",15} \r\n");
            textBox1.AppendText(new string('-', 95) + "\r\n");

            // Основной цикл алгоритма
            while (k < M)
            {
                // Шаг 2-3: Найти точку минимума F(x, rk)
                double[] x_star = GradientDescent(xk[0], xk[1], rk, epsilon);

                // Вычисляем значения функций
                double fx = F(x_star[0], x_star[1]);
                double px = P(x_star[0], x_star[1], rk);
                double Fx = F_penalty(x_star[0], x_star[1], rk);

                // Вывод информации о текущей итерации
                textBox1.AppendText($"{k,5} {rk,15:F4} {x_star[0],15:F4} {x_star[1],15:F4} {fx,15:F4} {px,15:F4} {Fx,15:F4} \r\n");

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

            if (k >= M)
            {
                textBox1.AppendText($"\r\nДостигнуто максимальное число итераций M = {M}\r\n");
            }
        }
    }
}
