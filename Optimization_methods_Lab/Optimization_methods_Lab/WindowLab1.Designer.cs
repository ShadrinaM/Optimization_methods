namespace Optimization_methods_Lab
{
    partial class WindowLab1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            BackToMenu = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe Print", 15.75F);
            button1.Location = new Point(189, 138);
            button1.Name = "button1";
            button1.Size = new Size(428, 71);
            button1.TabIndex = 1;
            button1.Text = "Метод Дихотомии";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe Print", 15.75F);
            button2.Location = new Point(189, 215);
            button2.Name = "button2";
            button2.Size = new Size(428, 71);
            button2.TabIndex = 2;
            button2.Text = "Метод Фибоначчи";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe Print", 15.75F);
            button3.Location = new Point(189, 292);
            button3.Name = "button3";
            button3.Size = new Size(428, 71);
            button3.TabIndex = 3;
            button3.Text = "Метод золотого сечения";
            button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 25F);
            label1.Location = new Point(165, 76);
            label1.Name = "label1";
            label1.Size = new Size(474, 59);
            label1.TabIndex = 4;
            label1.Text = "Лабораторная работа 1";
            // 
            // BackToMenu
            // 
            BackToMenu.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            BackToMenu.Location = new Point(12, 399);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(107, 39);
            BackToMenu.TabIndex = 5;
            BackToMenu.Text = "Back to menu";
            BackToMenu.UseVisualStyleBackColor = true;
            BackToMenu.Click += BackToMenu_Click;
            // 
            // WindowLab1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BackToMenu);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "WindowLab1";
            Text = "WindowLab3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Button BackToMenu;
    }
}