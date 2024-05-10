using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using dictionary_examen_Bukov.Models;
using dictionary_examen_Bukov.Services;
using dictionary_examen_Bukov.ViewModels;
using static dictionary_examen_Bukov.Models.Word;



namespace dictionary_examen_Bukov.Views
{
    public partial class DictionaryForm : Form
    {
        private readonly DictionaryViewModel _viewModel;
        private readonly DictionaryService _dictionaryService;
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
            
            translatelistBox.DisplayMember = "TranslateWord";
            translatelistBox.DataSource = _viewModel.Words;
            //  обработчик события SelectedIndexChanged для original_List_Box
            original_List_Box.SelectedIndexChanged += original_List_Box_SelectedIndexChanged;
            translatelistBox.SelectedIndexChanged += translatelistBox_SelectedIndexChanged;
            translatelistBox.SelectedIndexChanged += translatelistBox_SelectedIndexChanged_Edit;

            Edit_Original_Button.Enabled = false;
            ok_original_Button.Enabled = false;
            originalTextBox.Enabled = false;

            Translate_Text_box.Enabled = false;
            ok_translate_button.Enabled = false;

        }


        // Метод для загрузки и отображения словаря
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

        // Метод для установки статуса количества слов
        public void SetWordCountStatus(int wordCount)
        {
            toolStripStatusLabel1.Text = $"Количество слов: {wordCount}";
        }

        // Метод для отображения страницы
        private void ShowPage(int page)
        {
            int startIndex = (page - 1) * pageSize;
            int endIndex = startIndex + pageSize;

            original_List_Box.Items.Clear();
            translatelistBox.Items.Clear(); // очистка предыдущих элементов

            for (int i = startIndex; i < endIndex && i < _words.Count; i++)
            {
                original_List_Box.Items.Add(_words[i]);
            }

            // выбор первого слова на странице
            if (original_List_Box.Items.Count > 0)
            {
                original_List_Box.SelectedIndex = 0;
                original_List_Box_SelectedIndexChanged(null, null);
            }
        }

        // Обработчик нажатия кнопки "Предыдущая страница"
        private void Previous_Button_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowPage(currentPage);
                SetNumberPage();
            }
        }

        // Обработчик нажатия кнопки "Следующая страница"
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
            if (currentPage + 3 <= totalPages) 
            {
                currentPage += 3;
                ShowPage(currentPage);
                SetNumberPage();
            }
            else if (currentPage < totalPages)
            {
                currentPage = totalPages; // Если currentPage + 3 больше или равно totalPages, то перемещение на посл страницу
                ShowPage(currentPage);
                SetNumberPage();
            }
        }

        // Обработчик нажатия кнопки "Переместиться на 3 страницы назад"
        private void threePagePreviousButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 3) 
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

        // Обработчик нажатия кнопки "Первая страница"
        private void firstPageButton_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            ShowPage(currentPage);
            SetNumberPage();
        }

        // обработчик нажатия кнопки "последняя страница"
        private void endPageButton_Click(object sender, EventArgs e)
        {
            int totalPages = (_words.Count + pageSize - 1) / pageSize;
            currentPage = totalPages; // Переход на последнюю страницу
            ShowPage(currentPage);
            SetNumberPage();
        }

        // Метод для установки номера текущей страницы
        public void SetNumberPage()
        {
            toolStripStatusLabel2.Text = $"Страница {currentPage}";
        }

        // Обработчик нажатия кнопки "Поиск"
        private void Search_button_Click(object sender, EventArgs e)
        {
            string searchWord = searchTextBox.Text.ToLower();

            // поиск слова в списке слов
            Word foundWord = _words.FirstOrDefault(word => word.OriginalWord.ToLower() == searchWord);

            if (foundWord != null)
            {
                // поиск индекса найденного слова в списке _words
                int index = _words.IndexOf(foundWord);
          
                int page = index / pageSize + 1;

                // установка текущей страницы
                currentPage = page;

                ShowPage(currentPage);

                SetNumberPage();

                // выбор найденноого слово в original_List_Box
                original_List_Box.SelectedItem = foundWord;
            }
            else
            {
                // Если слово не найдено, то очистка original_List_Box и translationTextBox
                original_List_Box.ClearSelected();
                translatelistBox.ClearSelected();
                MessageBox.Show("Слово не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик события выбора элемента в списке listBox
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox == original_List_Box)
            {
                // Если выбрано слово в original_List_Box, то обновление translatelistBox
                Word selectedWord = (Word)listBox.SelectedItem;
                translatelistBox.DataSource = selectedWord.Translations;
                translatelistBox.Refresh();
            }
            else if (listBox == translatelistBox)
            {
                // Если выбран перевод в translatelistBox, то обновление original_List_Box
                Word selectedWord = (Word)listBox.SelectedItem;
                original_List_Box.DataSource = selectedWord.OriginalWord;
                original_List_Box.Refresh();
            }
        }

        // Обработчик события выбора элемента в original_List_Box
        private void original_List_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            // проверка, выбрано ли слово для редактирования и что _isEditing равно false
            if (!_isEditingOriginal && original_List_Box.SelectedItem != null)
            {
                // получение выбранного слова
                Word selectedWord = (Word)original_List_Box.SelectedItem;

                Edit_Original_Button.Enabled = true;

                // заполнение текстового поля оригинального слова выбранным словом
                originalTextBox.Text = selectedWord.OriginalWord;

                // очистка translatelistBox перед обновлением
                translatelistBox.Items.Clear();

                // обновление translatelistBox с помощью выбранного слова
                if (selectedWord.Translations != null)
                {
                    foreach (var translation in selectedWord.Translations)
                    {
                        translatelistBox.Items.Add(translation);
                    }
                }
            }
        }

        // Обработчик события изменения выбранного элемента в translatelistBox
        private void translatelistBox_SelectedIndexChanged_Edit(object sender, EventArgs e)
        {
            // получение выбранного слова из списка
            Word selectedWord = (Word)original_List_Box.SelectedItem;

            // обновление translatelistBox с помощью выбранного слова
            translatelistBox.DataSource = selectedWord.Translations;
            translatelistBox.Refresh();
        }

        // Обработчик события нажатия кнопки редактирования оригинального слова
        private void EditButton_Click(object sender, EventArgs e)
        {
            // получение выбранного слова из списка или другого элемента управления
            _selectedWord = original_List_Box.SelectedItem as Word;

            _isEditingOriginal = true;
            
            originalTextBox.Enabled = true;
            ok_original_Button.Enabled = true;

            // очищение translatelistBox перед редактированием
            translatelistBox.DataSource = null;
            translatelistBox.Refresh();

            originalTextBox.Focus();
        }

        // Обработчик события нажатия кнопки OK оригинального слова
        private void okButton_Click_1(object sender, EventArgs e)
        {
            if (_isEditingOriginal && _selectedWord != null)
            {
                // обновление оригинального слова выбранным значением из текстового поля
                _selectedWord.OriginalWord = originalTextBox.Text;

                _isEditingOriginal = false;

                originalTextBox.Clear();
                originalTextBox.Enabled = false;
                ok_original_Button.Enabled = false;

                ShowPage(currentPage);
            }
        }

        // обработчик нажатия кнопки cancel оригинального слова
        private void cancelButton_Click(object sender, EventArgs e)
        {          
            originalTextBox.Clear();
            originalTextBox.Enabled = false;
            ok_original_Button.Enabled = false;

            // обновление отображение списка слов
            ShowPage(currentPage);

            _isEditingOriginal = false;
        }

        private void translatelistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // проверка, включен ли  режим редактирования
            if (!_isEditingTranslation && translatelistBox.SelectedItem != null && translatelistBox.SelectedItem is Word selectedWord)
            {
                // получение  перевода
                Translation selectedTranslation = (Translation)translatelistBox.SelectedItem;

                edit_translate_button.Enabled = true;

                Translate_Text_box.Text = selectedTranslation.Text;

                original_List_Box.DataSource = null;
                original_List_Box.Refresh();
            }
        }

        // Обработчик события нажатия кнопки редактирования перевода
        private void edit_translate_button_Click(object sender, EventArgs e)
        {
            // проверка, находимся ли мы в режиме редактирования
            if (!_isEditingTranslation && translatelistBox.SelectedItem != null && translatelistBox.SelectedItem is Translation selectedTranslation)
            {
                _isEditingTranslation = true;

                Translate_Text_box.Enabled = true;
                ok_translate_button.Enabled = true;
                cancel_translate_button.Enabled = true;

                original_List_Box.DataSource = null;
                original_List_Box.Refresh();

                Translate_Text_box.Text = selectedTranslation.Text;
            
                Translate_Text_box.Focus();
            }
        }

        // Обработчик события нажатия кнопки OK перевода
        private void ok_translate_button_Click(object sender, EventArgs e)
        {
            if (_isEditingTranslation && translatelistBox.SelectedItem is Translation selectedTranslation)
            {
                // обновление  текста перевода выбранным значением из текстового поля
                selectedTranslation.Text = Translate_Text_box.Text;

                _isEditingTranslation = false;

                Translate_Text_box.Clear();
                Translate_Text_box.Enabled = false;
                ok_translate_button.Enabled = false;
                cancel_translate_button.Enabled = false;

                translatelistBox.DataSource = null;

                // обвноление отображения списка слов
                ShowPage(currentPage);
            }
        }

        // обработчик нажатия кнопки cancel перевода
        private void cancel_translate_button_Click(object sender, EventArgs e)
        {         
            Translate_Text_box.Clear();
            Translate_Text_box.Enabled = false;
            ok_translate_button.Enabled = false;
            cancel_translate_button.Enabled = false;

            ShowPage(currentPage);

            _isEditingTranslation = false;
        }

        // обработчик закрытия формы
        private void DictionaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите сохранить изменения перед выходом?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // сохранение данныых в файл
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить словарь перед выходом...";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _viewModel.FilePath = saveFileDialog.FileName;
                    _viewModel.SaveDictionary(_words, _viewModel.FilePath);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        // обработчик кнопки выхода из формы
        private void Exit_dictionary_form_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}