using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using dictionary_examen_Bukov.Models;

namespace dictionary_examen_Bukov.Services
{
    public class DictionaryService
    {
        public async Task<Dictionary> LoadDictionaryAsync(string filePath)
        {
            Dictionary dictionary = new Dictionary();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    string[] parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        string originalWord = parts[0].Trim('"');
                        string[] translations = parts[1].Trim('"').Split('|');

                        // Преобразуем массив строк в список строк
                        List<string> translationList = new List<string>(translations);

                        // Передаем список строк методу AddWord
                        dictionary.AddWord(originalWord, translationList);
                    }
                    else
                    {
                        throw new FormatException("Ошибка: неверный формат строки в файле.");
                    }
                }
            }

            return dictionary;
        }
    }
}
