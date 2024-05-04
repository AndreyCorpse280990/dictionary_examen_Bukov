namespace dictionary_examen_Bukov.Views
{
    partial class DictionaryForm
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
            this.originalTextBox = new System.Windows.Forms.TextBox();
            this.translationTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // originalTextBox
            // 
            this.originalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.originalTextBox.Location = new System.Drawing.Point(12, 38);
            this.originalTextBox.Multiline = true;
            this.originalTextBox.Name = "originalTextBox";
            this.originalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.originalTextBox.Size = new System.Drawing.Size(416, 192);
            this.originalTextBox.TabIndex = 0;
            // 
            // translationTextBox
            // 
            this.translationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.translationTextBox.Location = new System.Drawing.Point(482, 60);
            this.translationTextBox.Multiline = true;
            this.translationTextBox.Name = "translationTextBox";
            this.translationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.translationTextBox.Size = new System.Drawing.Size(416, 343);
            this.translationTextBox.TabIndex = 1;
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 470);
            this.Controls.Add(this.translationTextBox);
            this.Controls.Add(this.originalTextBox);
            this.Name = "DictionaryForm";
            this.Text = "DictionaryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox originalTextBox;
        private System.Windows.Forms.TextBox translationTextBox;
    }
}
