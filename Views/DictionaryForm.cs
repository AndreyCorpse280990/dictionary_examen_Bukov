using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using dictionary_examen_Bukov.Models;
using dictionary_examen_Bukov.Services;
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

            // Привязка данных
            originalTextBox.DataBindings.Add("Text", _viewModel, "OriginalText");
            translationTextBox.DataBindings.Add("Text", _viewModel, "TranslationText");
        }

        public async Task LoadAndShowAsync(string filePath)
        {
            try
            {
                await _viewModel.LoadDictionaryAsync(filePath);
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
