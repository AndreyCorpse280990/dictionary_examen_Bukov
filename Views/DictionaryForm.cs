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
                _words = _viewModel.GetWords(filePath);
                ShowPage(1);
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



        private void Previous_Button_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowPage(currentPage);
                SetNumberPage();
            }
        }


        private void Next_Button_Click(object sender, EventArgs e)
        {
            if (currentPage < (_words.Count + pageSize - 1) / pageSize)
            {
                currentPage++;
                ShowPage(currentPage);
                SetNumberPage();
            }
        }

        // перемещение на 3 страницы вперед
        private void ThreePageNextButton_Click(object sender, EventArgs e)
        {
            int totalPages = (_words.Count + pageSize - 1) / pageSize;
            if (currentPage + 3 <= totalPages) // Проверка, чтобы не выйти за пределы массива
            {
                currentPage += 3;
                ShowPage(currentPage);
                SetNumberPage();
            }
            else if (currentPage < totalPages)
            {
                currentPage = totalPages; // Если currentPage + 3 больше или равно totalPages, перемещаемся на последнюю страницу
                ShowPage(currentPage);
                SetNumberPage();
            }
        }


        // перемещение на 3 страницы назад
        private void threePagePreviousButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 3) // Проверка, чтобы не выйти за пределы массива
            {
                currentPage -= 3;
                ShowPage(currentPage);
                SetNumberPage();
            }
            else if (currentPage > 1)
            {
                currentPage = 1;
                ShowPage(currentPage);
                SetNumberPage();
            }
        }

        private void firstPageButton_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            ShowPage(currentPage);
            SetNumberPage();
        }

        private void endPageButton_Click(object sender, EventArgs e)
        {
            int totalPages = (_words.Count + pageSize - 1) / pageSize;
            currentPage = totalPages; // Переход на последнюю страницу
            ShowPage(currentPage);
            SetNumberPage();
        }

        public void SetNumberPage()
        {
            toolStripStatusLabel2.Text = $"Страница {currentPage}";
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            string seachWord = searchTextBox.Text;

            Word foundWord = null;
            foreach(Word word in _words)
            {
                if(word.OriginalWord.ToLower() == seachWord.ToLower())
                {
                    foundWord = word;
                    break;
                }
            }

            if (foundWord != null)
            {
                originalTextBox.Text = foundWord.OriginalWord;

                translationTextBox.Text = string.Join(", ", foundWord.Translations);
            }
        }
    }

}
