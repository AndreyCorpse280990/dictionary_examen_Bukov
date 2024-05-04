using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using dictionary_examen_Bukov.Models;
using dictionary_examen_Bukov.ViewModels;

namespace dictionary_examen_Bukov.Views
{
    public partial class DictionaryForm : Form
    {
        private readonly DictionaryViewModel _viewModel;
        private int pageSize = 10; // Количество слов на странице
        private int currentPage = 1; // Текущая страница
        private List<Word> _words; // Список слов

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

        private void ShowPage(int page)
        {
            int startIndex = (page - 1) * pageSize;
            int endIndex = startIndex + pageSize;

            originalTextBox.Clear();
            translationTextBox.Clear();

            for (int i = startIndex; i < endIndex && i < _words.Count; i++)
            {
                originalTextBox.AppendText(_words[i].OriginalWord + Environment.NewLine);
                translationTextBox.AppendText(string.Join(", ", _words[i].Translations) + Environment.NewLine);
            }
        }



        private void previous_Button_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowPage(currentPage);
            }
        }


        private void Next_Button_Click(object sender, EventArgs e)
        {
            if (currentPage < (_words.Count + pageSize - 1) / pageSize)
            {
                currentPage++;
                ShowPage(currentPage);
            }
        }
    }
}
