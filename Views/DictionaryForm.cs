using System;
using System.IO;
using System.Threading.Tasks;
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

            // Привязка данных
            originalTextBox.DataBindings.Add("Text", _viewModel, "OriginalText");
            translationTextBox.DataBindings.Add("Text", _viewModel, "TranslationText");
        }

        public void LoadAndShow(string filePath)
        {
            try
            {
                _viewModel.LoadDictionary(filePath);
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetWordCountStatus(int wordCount)
        {
            toolStripStatusLabel1.Text = $"Количество слов: {wordCount}";
        }
    }
}
