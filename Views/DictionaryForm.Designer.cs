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
            this.translationTextBox = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.previous_Button = new System.Windows.Forms.Button();
            this.next_Button = new System.Windows.Forms.Button();
            this.firstPageButton = new System.Windows.Forms.Button();
            this.endPageButton = new System.Windows.Forms.Button();
            this.threePageNextButton = new System.Windows.Forms.Button();
            this.threePagePreviousButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.Search_button = new System.Windows.Forms.Button();
            this.original_List_Box = new System.Windows.Forms.ListBox();
            this.originalTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitter1.Size = new System.Drawing.Size(3, 576);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(3, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1072, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(127, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(127, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel1";
            // 
            // previous_Button
            // 
            this.previous_Button.Location = new System.Drawing.Point(273, 467);
            this.previous_Button.Name = "previous_Button";
            this.previous_Button.Size = new System.Drawing.Size(98, 46);
            this.previous_Button.TabIndex = 5;
            this.previous_Button.Text = "<";
            this.previous_Button.UseVisualStyleBackColor = true;
            this.previous_Button.Click += new System.EventHandler(this.Previous_Button_Click);
            // 
            // next_Button
            // 
            this.next_Button.Location = new System.Drawing.Point(377, 467);
            this.next_Button.Name = "next_Button";
            this.next_Button.Size = new System.Drawing.Size(98, 46);
            this.next_Button.TabIndex = 6;
            this.next_Button.Text = ">";
            this.next_Button.UseVisualStyleBackColor = true;
            this.next_Button.Click += new System.EventHandler(this.Next_Button_Click);
            // 
            // firstPageButton
            // 
            this.firstPageButton.Location = new System.Drawing.Point(72, 467);
            this.firstPageButton.Name = "firstPageButton";
            this.firstPageButton.Size = new System.Drawing.Size(98, 46);
            this.firstPageButton.TabIndex = 8;
            this.firstPageButton.Text = "<<<";
            this.firstPageButton.UseVisualStyleBackColor = true;
            this.firstPageButton.Click += new System.EventHandler(this.firstPageButton_Click);
            // 
            // endPageButton
            // 
            this.endPageButton.Location = new System.Drawing.Point(585, 467);
            this.endPageButton.Name = "endPageButton";
            this.endPageButton.Size = new System.Drawing.Size(98, 46);
            this.endPageButton.TabIndex = 9;
            this.endPageButton.Text = ">>>";
            this.endPageButton.UseVisualStyleBackColor = true;
            this.endPageButton.Click += new System.EventHandler(this.endPageButton_Click);
            // 
            // threePageNextButton
            // 
            this.threePageNextButton.Location = new System.Drawing.Point(481, 467);
            this.threePageNextButton.Name = "threePageNextButton";
            this.threePageNextButton.Size = new System.Drawing.Size(98, 46);
            this.threePageNextButton.TabIndex = 10;
            this.threePageNextButton.Text = ">>";
            this.threePageNextButton.UseVisualStyleBackColor = true;
            this.threePageNextButton.Click += new System.EventHandler(this.ThreePageNextButton_Click);
            // 
            // threePagePreviousButton
            // 
            this.threePagePreviousButton.Location = new System.Drawing.Point(169, 467);
            this.threePagePreviousButton.Name = "threePagePreviousButton";
            this.threePagePreviousButton.Size = new System.Drawing.Size(98, 46);
            this.threePagePreviousButton.TabIndex = 11;
            this.threePagePreviousButton.Text = "<<";
            this.threePagePreviousButton.UseVisualStyleBackColor = true;
            this.threePagePreviousButton.Click += new System.EventHandler(this.threePagePreviousButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(715, 481);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox.TabIndex = 13;
            // 
            // Search_button
            // 
            this.Search_button.Location = new System.Drawing.Point(836, 481);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(75, 23);
            this.Search_button.TabIndex = 14;
            this.Search_button.Text = "Поиск";
            this.Search_button.UseVisualStyleBackColor = true;
            this.Search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // original_List_Box
            // 
            this.original_List_Box.FormattingEnabled = true;
            this.original_List_Box.Location = new System.Drawing.Point(0, 112);
            this.original_List_Box.Name = "original_List_Box";
            this.original_List_Box.Size = new System.Drawing.Size(324, 225);
            this.original_List_Box.TabIndex = 15;
            // 
            // originalTextBox
            // 
            this.originalTextBox.Location = new System.Drawing.Point(3, 58);
            this.originalTextBox.Name = "originalTextBox";
            this.originalTextBox.Size = new System.Drawing.Size(100, 20);
            this.originalTextBox.TabIndex = 18;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(130, 54);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 19;
            this.okButton.Text = "ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click_1);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(129, 371);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 20;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 576);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.originalTextBox);
            this.Controls.Add(this.original_List_Box);
            this.Controls.Add(this.Search_button);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.threePagePreviousButton);
            this.Controls.Add(this.threePageNextButton);
            this.Controls.Add(this.endPageButton);
            this.Controls.Add(this.firstPageButton);
            this.Controls.Add(this.next_Button);
            this.Controls.Add(this.previous_Button);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.translationTextBox);
            this.Name = "DictionaryForm";
            this.Text = "DictionaryForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox translationTextBox;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button previous_Button;
        private System.Windows.Forms.Button next_Button;
        private System.Windows.Forms.Button firstPageButton;
        private System.Windows.Forms.Button endPageButton;
        private System.Windows.Forms.Button threePageNextButton;
        private System.Windows.Forms.Button threePagePreviousButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button Search_button;
        private System.Windows.Forms.ListBox original_List_Box;
        private System.Windows.Forms.TextBox originalTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button EditButton;
    }
}