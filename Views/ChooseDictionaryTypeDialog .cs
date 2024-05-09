using System;
using System.Windows.Forms;

namespace dictionary_examen_Bukov.Views
{
    public partial class ChooseDictionaryTypeDialog : Form
    {
        public string SelectedDictionaryType { get; private set; }

        public ChooseDictionaryTypeDialog()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (englishToRussianRadioButton.Checked)
            {
                SelectedDictionaryType = "Англо-русский";
            }
            else if (russianToEnglishRadioButton.Checked)
            {
                SelectedDictionaryType = "Русско-английский";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
