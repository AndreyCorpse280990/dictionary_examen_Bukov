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
                // Получаем путь к выбранному файлу
                string filePath = openFileDialog.FileName;

                // Создаем сервис словаря и модель представления
                var dictionaryService = new DictionaryService();
                var viewModel = new DictionaryViewModel(dictionaryService);

                // Создаем экземпляр DictionaryForm и передаем ему модель представления
                var dictionaryForm = new DictionaryForm(viewModel);

                // Загружаем словарь и отображаем форму
                dictionaryForm.LoadAndShow(filePath);

                // Получаем количество слов в словаре
                int wordCount = dictionaryService.GetWordCount(filePath);

                // Устанавливаем значение счетчика слов в statusStrip1
                dictionaryForm.SetWordCountStatus(wordCount);
                dictionaryForm.SetNumberPage();

                dictionaryForm.LoadAndShow(filePath);

            }
        }
    }
}
