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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.previous_Button = new System.Windows.Forms.Button();
            this.next_Button = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalTextBox
            // 
            this.originalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.originalTextBox.Location = new System.Drawing.Point(12, 38);
            this.originalTextBox.Multiline = true;
            this.originalTextBox.Name = "originalTextBox";
            this.originalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.originalTextBox.Size = new System.Drawing.Size(350, 388);
            this.originalTextBox.TabIndex = 0;
            // 
            // translationTextBox
            // 
            this.translationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.translationTextBox.Location = new System.Drawing.Point(368, 38);
            this.translationTextBox.Multiline = true;
            this.translationTextBox.Name = "translationTextBox";
            this.translationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.translationTextBox.Size = new System.Drawing.Size(418, 388);
            this.translationTextBox.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 470);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(997, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(127, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // previous_Button
            // 
            this.previous_Button.Location = new System.Drawing.Point(792, 371);
            this.previous_Button.Name = "previous_Button";
            this.previous_Button.Size = new System.Drawing.Size(98, 46);
            this.previous_Button.TabIndex = 5;
            this.previous_Button.Text = "<";
            this.previous_Button.UseVisualStyleBackColor = true;
            // 
            // next_Button
            // 
            this.next_Button.Location = new System.Drawing.Point(890, 371);
            this.next_Button.Name = "next_Button";
            this.next_Button.Size = new System.Drawing.Size(98, 46);
            this.next_Button.TabIndex = 6;
            this.next_Button.Text = ">";
            this.next_Button.UseVisualStyleBackColor = true;
            this.next_Button.Click += new System.EventHandler(this.Next_Button_Click);
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 470);
            this.Controls.Add(this.next_Button);
            this.Controls.Add(this.previous_Button);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.translationTextBox);
            this.Controls.Add(this.originalTextBox);
            this.Name = "DictionaryForm";
            this.Text = "DictionaryForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox originalTextBox;
        private System.Windows.Forms.TextBox translationTextBox;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button previous_Button;
        private System.Windows.Forms.Button next_Button;
    }
}
