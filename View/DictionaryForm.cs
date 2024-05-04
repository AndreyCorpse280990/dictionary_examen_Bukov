using System;
using System.IO;
using System.Windows.Forms;
using dictionary_examen_Bukov.ViewModels;

namespace dictionary_examen_Bukov.Views
{
    public partial class DictionaryForm : Form
    {
        private readonly DictionaryViewModel _viewModel;

        public DictionaryForm(DictionaryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        public async Task LoadAndShowAsync(string filePath)
        {
            try
            {
                var dictionary = await _viewModel.LoadDictionaryAsync(filePath);
                DisplayDictionary(dictionary);
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayDictionary(Models.Dictionary dictionary)
        {
            foreach (var word in dictionary.Words)
            {
                originalTextBox.AppendText(word.OriginalWord + Environment.NewLine);
                translationTextBox.AppendText(string.Join(", ", word.Translations) + Environment.NewLine);
            }
        }
    }
}