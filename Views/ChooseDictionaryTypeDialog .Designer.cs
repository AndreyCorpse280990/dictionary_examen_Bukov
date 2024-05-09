namespace dictionary_examen_Bukov.Views
{
    partial class ChooseDictionaryTypeDialog
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
            this.englishToRussianRadioButton = new System.Windows.Forms.RadioButton();
            this.russianToEnglishRadioButton = new System.Windows.Forms.RadioButton();
            this.button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // englishToRussianRadioButton
            // 
            this.englishToRussianRadioButton.AutoSize = true;
            this.englishToRussianRadioButton.Location = new System.Drawing.Point(42, 30);
            this.englishToRussianRadioButton.Name = "englishToRussianRadioButton";
            this.englishToRussianRadioButton.Size = new System.Drawing.Size(99, 17);
            this.englishToRussianRadioButton.TabIndex = 0;
            this.englishToRussianRadioButton.TabStop = true;
            this.englishToRussianRadioButton.Text = "Англо-русский";
            this.englishToRussianRadioButton.UseVisualStyleBackColor = true;
            // 
            // russianToEnglishRadioButton
            // 
            this.russianToEnglishRadioButton.AutoSize = true;
            this.russianToEnglishRadioButton.Location = new System.Drawing.Point(42, 72);
            this.russianToEnglishRadioButton.Name = "russianToEnglishRadioButton";
            this.russianToEnglishRadioButton.Size = new System.Drawing.Size(123, 17);
            this.russianToEnglishRadioButton.TabIndex = 1;
            this.russianToEnglishRadioButton.TabStop = true;
            this.russianToEnglishRadioButton.Text = "Русско-английский";
            this.russianToEnglishRadioButton.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(42, 125);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // ChooseDictionaryTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 195);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.russianToEnglishRadioButton);
            this.Controls.Add(this.englishToRussianRadioButton);
            this.Name = "ChooseDictionaryTypeDialog";
            this.Text = "Выберите тип словаря";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton englishToRussianRadioButton;
        private System.Windows.Forms.RadioButton russianToEnglishRadioButton;
        private System.Windows.Forms.Button button_ok;
    }
}