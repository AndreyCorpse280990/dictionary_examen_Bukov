using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dictionary_examen_Bukov
{
    public partial class DictionaryForm : Form
    {
        public DictionaryForm()
        {
            InitializeComponent();
        }

        public async Task LoadAndShowAsync(string filePath)
        {
            try
            {
                Dictionary dictionary = await LoadDictionaryAsync(filePath);
                DisplayDictionary(dictionary);
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Dictionary> LoadDictionaryAsync(string filePath)
        {
            Dictionary dictionary = new Dictionary();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (StreamReader reader = new StreamReader(fileStream))
            {
                // Читаем файл построчно
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    string[] parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        string originalWord = parts[0].Trim('"');
                        string[] translations = parts[1].Trim('"').Split('|');

                        // Добавляем слово в словарь
                        dictionary.AddWord(originalWord, translations);
                    }
                    else
                    {
                        throw new FormatException("Ошибка: неверный формат строки в файле.");
                    }
                }
            }

            return dictionary;
        }

        private void DisplayDictionary(Dictionary dictionary)
        {
            foreach (var word in dictionary.Words)
            {
                originalTextBox.AppendText(word.OriginalWord + Environment.NewLine);
                translationTextBox.AppendText(string.Join(", ", word.Translations) + Environment.NewLine);
            }
        }
    }
}
