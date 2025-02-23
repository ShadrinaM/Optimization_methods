namespace Optimization_methods_Labs
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            StartTask1 = new Button();
            StartTask2 = new Button();
            StartTask3_1 = new Button();
            StartTask3_2 = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // StartTask1
            // 
            StartTask1.Font = new Font("Segoe Print", 15.75F);
            StartTask1.Location = new Point(14, 174);
            StartTask1.Margin = new Padding(3, 4, 3, 4);
            StartTask1.Name = "StartTask1";
            StartTask1.Size = new Size(551, 72);
            StartTask1.TabIndex = 0;
            StartTask1.Text = "Лабораторная работа 1";
            StartTask1.UseVisualStyleBackColor = true;
            StartTask1.Click += StartTask1_Click;
            // 
            // StartTask2
            // 
            StartTask2.Font = new Font("Segoe Print", 15.75F);
            StartTask2.Location = new Point(14, 254);
            StartTask2.Margin = new Padding(3, 4, 3, 4);
            StartTask2.Name = "StartTask2";
            StartTask2.Size = new Size(551, 72);
            StartTask2.TabIndex = 1;
            StartTask2.Text = "Лабораторная работа 2";
            StartTask2.UseVisualStyleBackColor = true;
            // 
            // StartTask3_1
            // 
            StartTask3_1.Font = new Font("Segoe Print", 15.75F);
            StartTask3_1.Location = new Point(14, 334);
            StartTask3_1.Margin = new Padding(3, 4, 3, 4);
            StartTask3_1.Name = "StartTask3_1";
            StartTask3_1.Size = new Size(551, 72);
            StartTask3_1.TabIndex = 2;
            StartTask3_1.Text = "Лабораторная работа 3";
            StartTask3_1.UseVisualStyleBackColor = true;
            // 
            // StartTask3_2
            // 
            StartTask3_2.Font = new Font("Segoe Print", 15.75F);
            StartTask3_2.Location = new Point(14, 414);
            StartTask3_2.Margin = new Padding(3, 4, 3, 4);
            StartTask3_2.Name = "StartTask3_2";
            StartTask3_2.Size = new Size(551, 72);
            StartTask3_2.TabIndex = 3;
            StartTask3_2.Text = "Лабораторная работа 4";
            StartTask3_2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 25F);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(881, 148);
            label1.TabIndex = 6;
            label1.Text = "Лабораторные работы по предмету \r\n\"Методы оптимизации\"";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 15.75F);
            label2.Location = new Point(575, 139);
            label2.Name = "label2";
            label2.Size = new Size(354, 47);
            label2.TabIndex = 7;
            label2.Text = "Шадрина Марина 35/1";
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleRole = AccessibleRole.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(625, 190);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(237, 296);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 500);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(StartTask3_2);
            Controls.Add(StartTask3_1);
            Controls.Add(StartTask2);
            Controls.Add(StartTask1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Menu";
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
