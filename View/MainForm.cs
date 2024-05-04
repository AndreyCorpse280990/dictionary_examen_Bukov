using System;
using System.IO;
using System.Windows.Forms;
using DictionaryExamenBukov.ViewModel;

namespace DictionaryExamenBukov.View
{
    public partial class MainForm : Form
    {
        private readonly DictionaryViewModel _viewModel;

        public MainForm(DictionaryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private async void Load_dictionary_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы|*.txt";
            openFileDialog.Title = "Выберите файл словаря";
            openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionary");

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                DictionaryForm dictionaryForm = new DictionaryForm(_viewModel);
                dictionaryForm.LoadAndShowAsync(filePath);
            }
        }
    }
}
