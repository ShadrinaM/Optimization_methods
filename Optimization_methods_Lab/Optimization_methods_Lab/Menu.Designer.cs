using System.Drawing;
using System.Windows.Forms;

namespace Optimization_methods_Lab
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.StartTask1 = new System.Windows.Forms.Button();
            this.StartTask2 = new System.Windows.Forms.Button();
            this.StartTask3_1 = new System.Windows.Forms.Button();
            this.StartTask3_2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartTask1
            // 
            this.StartTask1.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.StartTask1.Location = new System.Drawing.Point(328, 236);
            this.StartTask1.Name = "StartTask1";
            this.StartTask1.Size = new System.Drawing.Size(486, 58);
            this.StartTask1.TabIndex = 0;
            this.StartTask1.Text = "Лабораторная работа 1";
            this.StartTask1.UseVisualStyleBackColor = true;
            this.StartTask1.Click += new System.EventHandler(this.StartTask1_Click);
            // 
            // StartTask2
            // 
            this.StartTask2.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.StartTask2.Location = new System.Drawing.Point(328, 300);
            this.StartTask2.Name = "StartTask2";
            this.StartTask2.Size = new System.Drawing.Size(486, 58);
            this.StartTask2.TabIndex = 1;
            this.StartTask2.Text = "Лабораторная работа 2";
            this.StartTask2.UseVisualStyleBackColor = true;
            // 
            // StartTask3_1
            // 
            this.StartTask3_1.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.StartTask3_1.Location = new System.Drawing.Point(328, 364);
            this.StartTask3_1.Name = "StartTask3_1";
            this.StartTask3_1.Size = new System.Drawing.Size(486, 58);
            this.StartTask3_1.TabIndex = 2;
            this.StartTask3_1.Text = "Лабораторная работа 3";
            this.StartTask3_1.UseVisualStyleBackColor = true;
            // 
            // StartTask3_2
            // 
            this.StartTask3_2.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.StartTask3_2.Location = new System.Drawing.Point(328, 428);
            this.StartTask3_2.Name = "StartTask3_2";
            this.StartTask3_2.Size = new System.Drawing.Size(486, 58);
            this.StartTask3_2.TabIndex = 3;
            this.StartTask3_2.Text = "Лабораторная работа 4";
            this.StartTask3_2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 25F);
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(881, 148);
            this.label1.TabIndex = 6;
            this.label1.Text = "Лабораторные работы по предмету \r\n\"Методы оптимизации\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.label2.Location = new System.Drawing.Point(575, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 47);
            this.label2.TabIndex = 7;
            this.label2.Text = "Шадрина Марина 35/1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(974, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 598);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartTask3_2);
            this.Controls.Add(this.StartTask3_1);
            this.Controls.Add(this.StartTask2);
            this.Controls.Add(this.StartTask1);
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartTask1;
        private Button StartTask2;
        private Button StartTask3_1;
        private Button StartTask3_2;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}

