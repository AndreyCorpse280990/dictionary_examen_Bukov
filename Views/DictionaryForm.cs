using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private Word _selectedWord;
        private bool _isEditing;

        public DictionaryForm(DictionaryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            // Привязка данных
            original_List_Box.DisplayMember = "OriginalWord"; // Установка свойства для отображения оригинального слова
            original_List_Box.DataSource = _viewModel.Words;
            translationTextBox.DataBindings.Add("Text", _viewModel, "TranslationText");
            // Добавляем обработчик события SelectedIndexChanged для original_List_Box
            original_List_Box.SelectedIndexChanged += original_List_Box_SelectedIndexChanged;

            // Скрываем текстовое поле и кнопку OK при инициализации формы
            EditButton.Enabled = false;
            okButton.Enabled = false;
            originalTextBox.Enabled = false;
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

            original_List_Box.Items.Clear();
            translationTextBox.Clear();

            for (int i = startIndex; i < endIndex && i < _words.Count; i++)
            {
                original_List_Box.Items.Add(_words[i]);
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
            string searchWord = searchTextBox.Text.ToLower();

            // Находим слово в списке слов
            Word foundWord = _words.FirstOrDefault(word => word.OriginalWord.ToLower() == searchWord);

            if (foundWord != null)
            {
                // Находим индекс найденного слова в списке _words
                int index = _words.IndexOf(foundWord);

                // Вычисляем страницу, на которой находится найденное слово
                int page = index / pageSize + 1;

                // Устанавливаем текущую страницу
                currentPage = page;

                // Показываем страницу, на которой находится найденное слово
                ShowPage(currentPage);

                // Устанавливаем номер страницы
                SetNumberPage();

                // Выбираем найденное слово в original_List_Box
                original_List_Box.SelectedItem = foundWord;
            }
            else
            {
                // Если слово не найдено, очищаем original_List_Box и translationTextBox
                original_List_Box.ClearSelected();
                translationTextBox.Clear();
                MessageBox.Show("Слово не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void original_List_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, выбрано ли слово для редактирования и что _isEditing равно false
            if (!_isEditing && original_List_Box.SelectedItem != null)
            {
                // Получаем выбранное слово
                Word selectedWord = (Word)original_List_Box.SelectedItem;

                // Включаем кнопку EditButton
                EditButton.Enabled = true;

                // Заполняем текстовое поле оригинального слова выбранным словом
                originalTextBox.Text = selectedWord.OriginalWord;

                // Обновляем TranslationText с помощью выбранного слова
                translationTextBox.Text = string.Join(", ", selectedWord.Translations);
            }
        }



        private void EditButton_Click(object sender, EventArgs e)
        {
            // Получаем выбранное слово из списка или другого элемента управления
            _selectedWord = original_List_Box.SelectedItem as Word;


                // Переключаемся в режим редактирования
                _isEditing = true;

                // Включаем режим редактирования элементов управления
                originalTextBox.Enabled = true;
                okButton.Enabled = true;

                // Фокусируемся на поле originalTextBox
                originalTextBox.Focus();
            
        }




        private void okButton_Click_1(object sender, EventArgs e)
        {
            // Проверяем, находимся ли мы в режиме редактирования и что _selectedWord не равен null
            if (_isEditing && _selectedWord != null)
            {
                // Обновляем оригинальное слово выбранным значением из текстового поля
                _selectedWord.OriginalWord = originalTextBox.Text;

                // Проверяем, что путь к файлу не пуст
                if (string.IsNullOrEmpty(_viewModel.FilePath))
                {
                    // Если путь к файлу пуст, предлагаем пользователю выбрать файл с помощью SaveFileDialog
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    saveFileDialog.Title = "Сохранить словарь как...";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _viewModel.FilePath = saveFileDialog.FileName;
                    }
                    else
                    {
                        // Если пользователь не выбрал файл, отменяем сохранение
                        return;
                    }
                }

                // Запрашиваем согласие пользователя на сохранение изменений
                DialogResult result = MessageBox.Show("Вы хотите сохранить изменения в файл?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Сохраняем изменения в файл
                    SaveDictionary(_words, _viewModel.FilePath);
                }

                // Выключаем режим редактирования
                _isEditing = false;

                // Очищаем текстовое поле и скрываем кнопку OK
                originalTextBox.Clear();
                originalTextBox.Enabled = false;
                okButton.Enabled = false;

                // Обновляем отображение списка слов
                ShowPage(currentPage);
            }
        }


        public void SaveDictionary(List<Word> words, string filePath)
        {
            List<string> lines = new List<string>();
            foreach (var word in words)
            {
                string translations = string.Join("|", word.Translations);
                lines.Add($"\"{word.OriginalWord}\";\"{translations}\"");
            }
            File.WriteAllLines(filePath, lines);
        }

    }
    }

