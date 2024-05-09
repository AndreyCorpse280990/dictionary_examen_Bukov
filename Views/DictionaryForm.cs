using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using dictionary_examen_Bukov.Models;
using dictionary_examen_Bukov.ViewModels;
using static dictionary_examen_Bukov.Models.Word;

namespace dictionary_examen_Bukov.Views
{
    public partial class DictionaryForm : Form
    {
        private readonly DictionaryViewModel _viewModel;
        private int pageSize = 20; // Количество слов на странице
        private int currentPage = 1; // Текущая страница
        private List<Word> _words; // Список слов
        private Word _selectedWord;
        private bool _isEditingOriginal;
        private bool _isEditingTranslation;

        public DictionaryForm(DictionaryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            // Привязка данных
            original_List_Box.DisplayMember = "OriginalWord"; // Установка свойства для отображения оригинального слова
            original_List_Box.DataSource = _viewModel.Words;
            // translationTextBox.DataBindings.Add("Text", _viewModel, "TranslationText");
            translatelistBox.DisplayMember = "TranslateWord";
            translatelistBox.DataSource = _viewModel.Words;
            // Добавляем обработчик события SelectedIndexChanged для original_List_Box
            original_List_Box.SelectedIndexChanged += original_List_Box_SelectedIndexChanged;
            translatelistBox.SelectedIndexChanged += translatelistBox_SelectedIndexChanged;
            translatelistBox.SelectedIndexChanged += translatelistBox_SelectedIndexChanged_Edit;

            // Скрываем текстовое поле и кнопку OK при инициализации формы
            Edit_Original_Button.Enabled = false;
            ok_original_Button.Enabled = false;
            originalTextBox.Enabled = false;

            Translate_Text_box.Enabled = false;
            ok_translate_button.Enabled = false;

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
            // Не нужно обнулять и очищать источник данных для translatelistBox
            translatelistBox.Items.Clear(); // Очищаем предыдущие элементы

            for (int i = startIndex; i < endIndex && i < _words.Count; i++)
            {
                original_List_Box.Items.Add(_words[i]);
            }

            // Выбираем первое слово на новой странице, если это возможно
            if (original_List_Box.Items.Count > 0)
            {
                original_List_Box.SelectedIndex = 0;
                // Убедитесь, что обработчик события вызывается с правильными аргументами
                original_List_Box_SelectedIndexChanged(null, null);
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
                translatelistBox.ClearSelected();
                MessageBox.Show("Слово не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox == original_List_Box)
            {
                // Если выбрано слово в original_List_Box, обновляем translatelistBox
                Word selectedWord = (Word)listBox.SelectedItem;
                translatelistBox.DataSource = selectedWord.Translations;
                translatelistBox.Refresh();
            }
            else if (listBox == translatelistBox)
            {
                // Если выбран перевод в translatelistBox, обновляем original_List_Box
                Word selectedWord = (Word)listBox.SelectedItem;
                original_List_Box.DataSource = selectedWord.OriginalWord;
                original_List_Box.Refresh();
            }
        }


        private void original_List_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, выбрано ли слово для редактирования и что _isEditing равно false
            if (!_isEditingOriginal && original_List_Box.SelectedItem != null)
            {
                // Получаем выбранное слово
                Word selectedWord = (Word)original_List_Box.SelectedItem;

                // Включаем кнопку EditButton
                Edit_Original_Button.Enabled = true;

                // Заполняем текстовое поле оригинального слова выбранным словом
                originalTextBox.Text = selectedWord.OriginalWord;

                // Очищаем translatelistBox перед обновлением
                translatelistBox.Items.Clear();

                // Обновляем translatelistBox с помощью выбранного слова
                if (selectedWord.Translations != null)
                {
                    foreach (var translation in selectedWord.Translations)
                    {
                        translatelistBox.Items.Add(translation);
                    }
                }
            }
        }


        private void translatelistBox_SelectedIndexChanged_Edit(object sender, EventArgs e)
        {
            // Получаем выбранное слово из списка
            Word selectedWord = (Word)original_List_Box.SelectedItem;

            // Обновляем translatelistBox с помощью выбранного слова
            translatelistBox.DataSource = selectedWord.Translations;
            translatelistBox.Refresh();
        }



        private void EditButton_Click(object sender, EventArgs e)
        {
            // Получаем выбранное слово из списка или другого элемента управления
            _selectedWord = original_List_Box.SelectedItem as Word;

            // Переключаемся в режим редактирования
            _isEditingOriginal = true;

            // Включаем режим редактирования элементов управления
            originalTextBox.Enabled = true;
            ok_original_Button.Enabled = true;

            // Очищаем translatelistBox перед редактированием
            translatelistBox.DataSource = null;
            translatelistBox.Refresh();

            // Фокусируемся на поле originalTextBox
            originalTextBox.Focus();
        }





        private void okButton_Click_1(object sender, EventArgs e)
        {
            if (_isEditingOriginal && _selectedWord != null)
            {
                // Обновляем оригинальное слово выбранным значением из текстового поля
                _selectedWord.OriginalWord = originalTextBox.Text;

                // Отключаем режим редактирования
                _isEditingOriginal = false;

                // Очищаем текстовое поле и скрываем кнопку OK
                originalTextBox.Clear();
                originalTextBox.Enabled = false;
                ok_original_Button.Enabled = false;

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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Очищаем текстовое поле и скрываем кнопку OK
            originalTextBox.Clear();
            originalTextBox.Enabled = false;
            ok_original_Button.Enabled = false;

            // Обновляем отображение списка слов
            ShowPage(currentPage);

            // Выключаем режим редактирования
            _isEditingOriginal = false;
        }

        private void translatelistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, находимся ли мы в режиме редактирования
            if (!_isEditingTranslation && translatelistBox.SelectedItem != null && translatelistBox.SelectedItem is Word selectedWord)
            {
                // Получаем выбранный перевод
                Translation selectedTranslation = (Translation)translatelistBox.SelectedItem;

                // Включаем кнопку редактирования
                edit_translate_button.Enabled = true;

                // Заполняем текстовое поле с переводом выбранным значением
                Translate_Text_box.Text = selectedTranslation.Text;

                // Очищаем original_List_Box
                original_List_Box.DataSource = null;
                original_List_Box.Refresh();
            }
        }


        private void edit_translate_button_Click(object sender, EventArgs e)
        {
            // Проверяем, находимся ли мы в режиме редактирования
            if (!_isEditingTranslation && translatelistBox.SelectedItem != null && translatelistBox.SelectedItem is Translation selectedTranslation)
            {
                // Включаем режим редактирования
                _isEditingTranslation = true;

                // Включаем элементы управления для редактирования
                Translate_Text_box.Enabled = true;
                ok_translate_button.Enabled = true;
                cancel_translate_button.Enabled = true;

                // Очищаем original_List_Box перед редактированием
                original_List_Box.DataSource = null;
                original_List_Box.Refresh();

                // Получаем выбранный перевод из списка
                Translate_Text_box.Text = selectedTranslation.Text;

                // Фокусируемся на поле Translate_Text_box
                Translate_Text_box.Focus();
            }
        }



        private void ok_translate_button_Click(object sender, EventArgs e)
        {
            if (_isEditingTranslation && translatelistBox.SelectedItem is Translation selectedTranslation)
            {
                // Обновляем текст перевода выбранным значением из текстового поля
                selectedTranslation.Text = Translate_Text_box.Text;

                // Отключаем режим редактирования
                _isEditingTranslation = false;

                // Очищаем текстовое поле и скрываем кнопки OK и Cancel
                Translate_Text_box.Clear();
                Translate_Text_box.Enabled = false;
                ok_translate_button.Enabled = false;
                cancel_translate_button.Enabled = false;

                // Отвязываем translatelistBox от источника данных
                translatelistBox.DataSource = null;

                // Обновляем отображение списка слов
                ShowPage(currentPage);
            }
        }



        private void cancel_translate_button_Click(object sender, EventArgs e)
        {
            // Очищаем текстовое поле и скрываем кнопки OK и Cancel
            Translate_Text_box.Clear();
            Translate_Text_box.Enabled = false;
            ok_translate_button.Enabled = false;
            cancel_translate_button.Enabled = false;

            // Обновляем отображение списка слов
            ShowPage(currentPage);

            // Выключаем режим редактирования
            _isEditingTranslation = false;
        }

        private void DictionaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите сохранить изменения перед выходом?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Сохраняем данные в файл
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить словарь перед выходом...";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Устанавливаем путь к файлу из диалогового окна
                    _viewModel.FilePath = saveFileDialog.FileName;

                    // Сохраняем данные в файл
                    SaveDictionary(_words, _viewModel.FilePath);
                }
                else
                {
                    // Если пользователь не выбрал файл, отменяем выход из приложения
                    e.Cancel = true;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                // Если пользователь отменил действие, отменяем выход из приложения
                e.Cancel = true;
            }
        }

        private void Exit_dictionary_form_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}