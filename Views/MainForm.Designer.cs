namespace dictionary_examen_Bukov
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTitle = new System.Windows.Forms.Label();
            this.Load_dictionary_button = new System.Windows.Forms.Button();
            this.Create_dictionary_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTitle
            // 
            this.nameTitle.AutoSize = true;
            this.nameTitle.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTitle.ForeColor = System.Drawing.Color.Blue;
            this.nameTitle.Location = new System.Drawing.Point(99, 58);
            this.nameTitle.Name = "nameTitle";
            this.nameTitle.Size = new System.Drawing.Size(152, 39);
            this.nameTitle.TabIndex = 0;
            this.nameTitle.Text = "Словари";
            // 
            // Load_dictionary_button
            // 
            this.Load_dictionary_button.Font = new System.Drawing.Font("Consolas", 15F);
            this.Load_dictionary_button.Location = new System.Drawing.Point(93, 130);
            this.Load_dictionary_button.Name = "Load_dictionary_button";
            this.Load_dictionary_button.Size = new System.Drawing.Size(158, 77);
            this.Load_dictionary_button.TabIndex = 1;
            this.Load_dictionary_button.Text = "Загрузить словарь";
            this.Load_dictionary_button.UseVisualStyleBackColor = true;
            this.Load_dictionary_button.Click += new System.EventHandler(this.Load_dictionary_button_Click);
            // 
            // Create_dictionary_button
            // 
            this.Create_dictionary_button.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Create_dictionary_button.Location = new System.Drawing.Point(93, 252);
            this.Create_dictionary_button.Name = "Create_dictionary_button";
            this.Create_dictionary_button.Size = new System.Drawing.Size(158, 72);
            this.Create_dictionary_button.TabIndex = 2;
            this.Create_dictionary_button.Text = "Создать новый словарь";
            this.Create_dictionary_button.UseVisualStyleBackColor = true;
            // 
            // Exit_button
            // 
            this.Exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit_button.Location = new System.Drawing.Point(93, 350);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(158, 64);
            this.Exit_button.TabIndex = 3;
            this.Exit_button.Text = "Выход";
            this.Exit_button.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 461);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Create_dictionary_button);
            this.Controls.Add(this.Load_dictionary_button);
            this.Controls.Add(this.nameTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(370, 500);
            this.Name = "MainForm";
            this.Text = "Словарь";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameTitle;
        private System.Windows.Forms.Button Load_dictionary_button;
        private System.Windows.Forms.Button Create_dictionary_button;
        private System.Windows.Forms.Button Exit_button;
    }
}

