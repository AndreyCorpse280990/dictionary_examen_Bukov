using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dictionary_examen_Bukov.Views
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }
        public string UserInput { get; private set; }
        public InputBox(string prompt, string title, string defaultValue = "")
        {
            InitializeComponent();

            this.Text = title;
            inputTextBox.Text = defaultValue;
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            UserInput = inputTextBox.Text;
            DialogResult = DialogResult.OK;
        }

    }
}
