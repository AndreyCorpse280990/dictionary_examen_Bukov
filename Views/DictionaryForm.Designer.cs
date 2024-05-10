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
            this.ok_original_Button = new System.Windows.Forms.Button();
            this.Edit_Original_Button = new System.Windows.Forms.Button();
            this.translatelistBox = new System.Windows.Forms.ListBox();
            this.cancel_Original_Button = new System.Windows.Forms.Button();
            this.Translate_Text_box = new System.Windows.Forms.TextBox();
            this.ok_translate_button = new System.Windows.Forms.Button();
            this.cancel_translate_button = new System.Windows.Forms.Button();
            this.edit_translate_button = new System.Windows.Forms.Button();
            this.Exit_dictionary_form = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 725);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(3, 703);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1182, 22);
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
            this.previous_Button.Location = new System.Drawing.Point(244, 654);
            this.previous_Button.Name = "previous_Button";
            this.previous_Button.Size = new System.Drawing.Size(98, 46);
            this.previous_Button.TabIndex = 5;
            this.previous_Button.Text = "<";
            this.previous_Button.UseVisualStyleBackColor = true;
            this.previous_Button.Click += new System.EventHandler(this.Previous_Button_Click);
            // 
            // next_Button
            // 
            this.next_Button.Location = new System.Drawing.Point(348, 654);
            this.next_Button.Name = "next_Button";
            this.next_Button.Size = new System.Drawing.Size(98, 46);
            this.next_Button.TabIndex = 6;
            this.next_Button.Text = ">";
            this.next_Button.UseVisualStyleBackColor = true;
            this.next_Button.Click += new System.EventHandler(this.Next_Button_Click);
            // 
            // firstPageButton
            // 
            this.firstPageButton.Location = new System.Drawing.Point(36, 654);
            this.firstPageButton.Name = "firstPageButton";
            this.firstPageButton.Size = new System.Drawing.Size(98, 46);
            this.firstPageButton.TabIndex = 8;
            this.firstPageButton.Text = "<<<";
            this.firstPageButton.UseVisualStyleBackColor = true;
            this.firstPageButton.Click += new System.EventHandler(this.firstPageButton_Click);
            // 
            // endPageButton
            // 
            this.endPageButton.Location = new System.Drawing.Point(556, 654);
            this.endPageButton.Name = "endPageButton";
            this.endPageButton.Size = new System.Drawing.Size(98, 46);
            this.endPageButton.TabIndex = 9;
            this.endPageButton.Text = ">>>";
            this.endPageButton.UseVisualStyleBackColor = true;
            this.endPageButton.Click += new System.EventHandler(this.endPageButton_Click);
            // 
            // threePageNextButton
            // 
            this.threePageNextButton.Location = new System.Drawing.Point(452, 654);
            this.threePageNextButton.Name = "threePageNextButton";
            this.threePageNextButton.Size = new System.Drawing.Size(98, 46);
            this.threePageNextButton.TabIndex = 10;
            this.threePageNextButton.Text = ">>";
            this.threePageNextButton.UseVisualStyleBackColor = true;
            this.threePageNextButton.Click += new System.EventHandler(this.ThreePageNextButton_Click);
            // 
            // threePagePreviousButton
            // 
            this.threePagePreviousButton.Location = new System.Drawing.Point(140, 654);
            this.threePagePreviousButton.Name = "threePagePreviousButton";
            this.threePagePreviousButton.Size = new System.Drawing.Size(98, 46);
            this.threePagePreviousButton.TabIndex = 11;
            this.threePagePreviousButton.Text = "<<";
            this.threePagePreviousButton.UseVisualStyleBackColor = true;
            this.threePagePreviousButton.Click += new System.EventHandler(this.threePagePreviousButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.Location = new System.Drawing.Point(810, 591);
            this.searchTextBox.Multiline = true;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(244, 38);
            this.searchTextBox.TabIndex = 13;
            // 
            // Search_button
            // 
            this.Search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search_button.Location = new System.Drawing.Point(1060, 591);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(105, 38);
            this.Search_button.TabIndex = 14;
            this.Search_button.Text = "Search";
            this.Search_button.UseVisualStyleBackColor = true;
            this.Search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // original_List_Box
            // 
            this.original_List_Box.Font = new System.Drawing.Font("Book Antiqua", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.original_List_Box.FormattingEnabled = true;
            this.original_List_Box.ItemHeight = 24;
            this.original_List_Box.Location = new System.Drawing.Point(6, 110);
            this.original_List_Box.Name = "original_List_Box";
            this.original_List_Box.Size = new System.Drawing.Size(440, 460);
            this.original_List_Box.TabIndex = 15;
            // 
            // originalTextBox
            // 
            this.originalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.originalTextBox.Location = new System.Drawing.Point(6, 74);
            this.originalTextBox.Name = "originalTextBox";
            this.originalTextBox.Size = new System.Drawing.Size(100, 30);
            this.originalTextBox.TabIndex = 18;
            // 
            // ok_original_Button
            // 
            this.ok_original_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok_original_Button.Location = new System.Drawing.Point(109, 73);
            this.ok_original_Button.Name = "ok_original_Button";
            this.ok_original_Button.Size = new System.Drawing.Size(97, 31);
            this.ok_original_Button.TabIndex = 19;
            this.ok_original_Button.Text = "ok";
            this.ok_original_Button.UseVisualStyleBackColor = true;
            this.ok_original_Button.Click += new System.EventHandler(this.okButton_Click_1);
            // 
            // Edit_Original_Button
            // 
            this.Edit_Original_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Edit_Original_Button.Location = new System.Drawing.Point(12, 588);
            this.Edit_Original_Button.Name = "Edit_Original_Button";
            this.Edit_Original_Button.Size = new System.Drawing.Size(91, 41);
            this.Edit_Original_Button.TabIndex = 20;
            this.Edit_Original_Button.Text = "Edit";
            this.Edit_Original_Button.UseVisualStyleBackColor = true;
            this.Edit_Original_Button.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // translatelistBox
            // 
            this.translatelistBox.Font = new System.Drawing.Font("Book Antiqua", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.translatelistBox.FormattingEnabled = true;
            this.translatelistBox.ItemHeight = 24;
            this.translatelistBox.Location = new System.Drawing.Point(452, 110);
            this.translatelistBox.Name = "translatelistBox";
            this.translatelistBox.Size = new System.Drawing.Size(713, 460);
            this.translatelistBox.TabIndex = 21;
            // 
            // cancel_Original_Button
            // 
            this.cancel_Original_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_Original_Button.Location = new System.Drawing.Point(212, 73);
            this.cancel_Original_Button.Name = "cancel_Original_Button";
            this.cancel_Original_Button.Size = new System.Drawing.Size(81, 31);
            this.cancel_Original_Button.TabIndex = 22;
            this.cancel_Original_Button.Text = "cancel";
            this.cancel_Original_Button.UseVisualStyleBackColor = true;
            this.cancel_Original_Button.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Translate_Text_box
            // 
            this.Translate_Text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Translate_Text_box.Location = new System.Drawing.Point(452, 71);
            this.Translate_Text_box.Name = "Translate_Text_box";
            this.Translate_Text_box.Size = new System.Drawing.Size(100, 30);
            this.Translate_Text_box.TabIndex = 23;
            // 
            // ok_translate_button
            // 
            this.ok_translate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok_translate_button.Location = new System.Drawing.Point(558, 69);
            this.ok_translate_button.Name = "ok_translate_button";
            this.ok_translate_button.Size = new System.Drawing.Size(97, 32);
            this.ok_translate_button.TabIndex = 24;
            this.ok_translate_button.Text = "ok";
            this.ok_translate_button.UseVisualStyleBackColor = true;
            this.ok_translate_button.Click += new System.EventHandler(this.ok_translate_button_Click);
            // 
            // cancel_translate_button
            // 
            this.cancel_translate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_translate_button.Location = new System.Drawing.Point(661, 69);
            this.cancel_translate_button.Name = "cancel_translate_button";
            this.cancel_translate_button.Size = new System.Drawing.Size(81, 33);
            this.cancel_translate_button.TabIndex = 25;
            this.cancel_translate_button.Text = "cancel";
            this.cancel_translate_button.UseVisualStyleBackColor = true;
            this.cancel_translate_button.Click += new System.EventHandler(this.cancel_translate_button_Click);
            // 
            // edit_translate_button
            // 
            this.edit_translate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit_translate_button.Location = new System.Drawing.Point(452, 588);
            this.edit_translate_button.Name = "edit_translate_button";
            this.edit_translate_button.Size = new System.Drawing.Size(98, 41);
            this.edit_translate_button.TabIndex = 26;
            this.edit_translate_button.Text = "Edit";
            this.edit_translate_button.UseVisualStyleBackColor = true;
            this.edit_translate_button.Click += new System.EventHandler(this.edit_translate_button_Click);
            // 
            // Exit_dictionary_form
            // 
            this.Exit_dictionary_form.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit_dictionary_form.Location = new System.Drawing.Point(1055, 56);
            this.Exit_dictionary_form.Name = "Exit_dictionary_form";
            this.Exit_dictionary_form.Size = new System.Drawing.Size(110, 48);
            this.Exit_dictionary_form.TabIndex = 27;
            this.Exit_dictionary_form.Text = "Exit";
            this.Exit_dictionary_form.UseVisualStyleBackColor = true;
            this.Exit_dictionary_form.Click += new System.EventHandler(this.Exit_dictionary_form_Click);
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 725);
            this.Controls.Add(this.Exit_dictionary_form);
            this.Controls.Add(this.edit_translate_button);
            this.Controls.Add(this.cancel_translate_button);
            this.Controls.Add(this.ok_translate_button);
            this.Controls.Add(this.Translate_Text_box);
            this.Controls.Add(this.cancel_Original_Button);
            this.Controls.Add(this.translatelistBox);
            this.Controls.Add(this.Edit_Original_Button);
            this.Controls.Add(this.ok_original_Button);
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
            this.Name = "DictionaryForm";
            this.Text = "DictionaryForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DictionaryForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Button ok_original_Button;
        private System.Windows.Forms.Button Edit_Original_Button;
        private System.Windows.Forms.ListBox translatelistBox;
        private System.Windows.Forms.Button cancel_Original_Button;
        private System.Windows.Forms.TextBox Translate_Text_box;
        private System.Windows.Forms.Button ok_translate_button;
        private System.Windows.Forms.Button cancel_translate_button;
        private System.Windows.Forms.Button edit_translate_button;
        private System.Windows.Forms.Button Exit_dictionary_form;
    }
}