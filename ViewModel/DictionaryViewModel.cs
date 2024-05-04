using System;
using System.IO;
using System.Threading.Tasks;
using DictionaryExamenBukov.Model;

namespace DictionaryExamenBukov.ViewModel
{
    internal class DictionaryViewModel
    {
        public Dictionary Dictionary { get; }

        public DictionaryViewModel()
        {
            Dictionary = new Dictionary();
        }

        public async Task LoadDictionaryAsync(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // чтение файла построчно
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    string[] parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        string originalWord = parts[0].Trim('"');
                        string[] translations = parts[1].Trim('"').Split('|');

                        // добавление слова в словарь
                        Dictionary.AddWord(originalWord, translations);
                    }
                    else
                    {
                        throw new FormatException("Ошибка: неверный формат строки в файле.");
                    }
                }
            }
        }
    }
}
