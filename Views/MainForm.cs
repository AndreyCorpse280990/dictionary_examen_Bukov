using System;
using System.IO;
using System.Windows.Forms;
using dictionary_examen_Bukov.Services;
using dictionary_examen_Bukov.ViewModels;
using dictionary_examen_Bukov.Views;

namespace dictionary_examen_Bukov
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Load_dictionary_button_Click(object sender, EventArgs e)
        {
            // Создаем диалоговое окно для выбора файла 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы|*.txt";
            openFileDialog.Title = "Выберите файл словаря";
            openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionary");

            // Если пользователь выбрал файл и нажал "ОК", открываем этот файл
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //  путь к выбранному файлу
                string filePath = openFileDialog.FileName;

                //  сервис словаря и модель представления
                var dictionaryService = new DictionaryService();
                var viewModel = new DictionaryViewModel(dictionaryService);

                var dictionaryForm = new DictionaryForm(viewModel);

                // загрузка словаря и отображение формы
                dictionaryForm.LoadAndShow(filePath);

                // количество слов в словаре
                int wordCount = dictionaryService.GetWordCount(filePath);

                // значение счетчика слов в statusStrip1
                dictionaryForm.SetWordCountStatus(wordCount);
                dictionaryForm.SetNumberPage();

                dictionaryForm.LoadAndShow(filePath);


            }
        }

        private void Create_dictionary_button_Click(object sender, EventArgs e)
        {
            // Создаем диалоговое окно для выбора типа словаря
            using (var dialog = new ChooseDictionaryTypeDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Пользователь выбрал тип словаря
                    string dictionaryType = dialog.SelectedDictionaryType;

                    // Создаем диалоговое окно для ввода имени нового словаря
                    using (var nameDialog = new InputBox("Введите имя нового словаря", "Создание словаря", "Новый словарь"))
                    {
                        if (nameDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Пользователь ввел имя нового словаря
                            string dictionaryName = nameDialog.UserInput;

                            // Формируем путь к новому файлу словаря
                            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionary");
                            string filePath = Path.Combine(directoryPath, dictionaryName + ".txt");

                            // Проверяем, существует ли директория для словарей
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            // Создаем новый файл словаря
                            File.Create(filePath).Close();

                            // Создаем новый экземпляр DictionaryViewModel и DictionaryForm
                            var dictionaryService = new DictionaryService();
                            var viewModel = new DictionaryViewModel(dictionaryService);
                            var dictionaryForm = new DictionaryForm(viewModel);

                            // Загружаем и отображаем новый словарь
                            dictionaryForm.LoadAndShow(filePath);
                        }
                    }
                }
            }
        }



        private void Exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из приложения?", "Подтверждение выхода", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
