﻿using OxyPlot.WindowsForms;

namespace Optimization_methods_Lab
{
    partial class FletcherReevesMethod
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
            SuspendLayout();
            // 
            // NewtonRaphsonMethod
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "FletcherReevesMethod";
            Text = "ЛР2 Метод Флетчера-Ривса";
            ResumeLayout(false);

            // Настройка textBox1
            this.textBox1 = new TextBox();
            this.textBox1.Dock = DockStyle.Fill;
            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new Size(800, 450); // Фиксированная ширина и высота
            this.textBox1.MinimumSize = new Size(400, 0); // Минимальная ширина
            this.textBox1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            this.Controls.Add(this.textBox1);

        }

        #endregion
    }
}