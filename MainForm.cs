using System;
using System.IO;
using System.Windows.Forms;

namespace dictionary_examen_Bukov
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void Load_dictionary_button_Click(object sender, EventArgs e)
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

                // Создаем экземпляр DictionaryForm и передаем ему выбранный файл
                DictionaryForm dictionaryForm = new DictionaryForm();
                await dictionaryForm.LoadAndShowAsync(filePath);
            }
        }
    }
}
