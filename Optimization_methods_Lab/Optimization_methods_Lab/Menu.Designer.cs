namespace Optimization_methods_Lab
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe Print", 15.75F);
            button1.Location = new Point(42, 131);
            button1.Name = "button1";
            button1.Size = new Size(428, 71);
            button1.TabIndex = 0;
            button1.Text = "Лабораторная работа 1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe Print", 15.75F);
            button2.Location = new Point(42, 208);
            button2.Name = "button2";
            button2.Size = new Size(428, 71);
            button2.TabIndex = 1;
            button2.Text = "Лабораторная работа 2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe Print", 15.75F);
            button3.Location = new Point(42, 285);
            button3.Name = "button3";
            button3.Size = new Size(428, 71);
            button3.TabIndex = 2;
            button3.Text = "Лабораторная работа 3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 25F);
            label1.Location = new Point(31, 10);
            label1.Name = "label1";
            label1.Size = new Size(713, 118);
            label1.TabIndex = 3;
            label1.Text = "Лабораторные работы по предмету \r\n\"Методы оптимизации\"";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 15.75F);
            label2.Location = new Point(480, 131);
            label2.Name = "label2";
            label2.Size = new Size(272, 36);
            label2.TabIndex = 4;
            label2.Text = "Шадрина Марина 35/1";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe Print", 15.75F);
            button4.Location = new Point(42, 362);
            button4.Name = "button4";
            button4.Size = new Size(428, 71);
            button4.TabIndex = 5;
            button4.Text = "Лабораторная работа 4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(475, 169);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(314, 265);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Menu";
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Button button4;
        private PictureBox pictureBox1;
    }
}
