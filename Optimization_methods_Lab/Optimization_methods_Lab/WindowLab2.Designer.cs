﻿namespace Optimization_methods_Lab
{
    partial class WindowLab2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 25F);
            label1.Location = new Point(161, 48);
            label1.Name = "label1";
            label1.Size = new Size(474, 59);
            label1.TabIndex = 8;
            label1.Text = "Лабораторная работа 2";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe Print", 15.75F);
            button3.Location = new Point(116, 265);
            button3.Name = "button3";
            button3.Size = new Size(565, 71);
            button3.TabIndex = 7;
            button3.Text = "Метод Ньютона Рафсона";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe Print", 15.75F);
            button2.Location = new Point(116, 188);
            button2.Name = "button2";
            button2.Size = new Size(565, 71);
            button2.TabIndex = 6;
            button2.Text = "Метод Ньютона с матрицей Гессе";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe Print", 15.75F);
            button1.Location = new Point(116, 111);
            button1.Name = "button1";
            button1.Size = new Size(565, 71);
            button1.TabIndex = 5;
            button1.Text = "Метод наискорейшего градиентного спуска";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe Print", 15.75F);
            button4.Location = new Point(116, 342);
            button4.Name = "button4";
            button4.Size = new Size(565, 71);
            button4.TabIndex = 9;
            button4.Text = "Метод Флетчера-Ривса";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // WindowLab2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "WindowLab2";
            Text = "WindowLab2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button4;
    }
}