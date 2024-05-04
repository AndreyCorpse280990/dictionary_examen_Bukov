using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dictionary_examen_Bukov.Models;

namespace dictionary_examen_Bukov.Services
{
    public class DictionaryService
    {
        public Dictionary LoadDictionary(string filePath)
        {
            Dictionary dictionary = new Dictionary();

            // Чтение всех строк из файла
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Разделение строки на части по символу ';'
                string[] parts = line.Split(';');

                // Проверка на корректное количество частей
                if (parts.Length == 2)
                {
                    string originalWord = parts[0].Trim('"'); // Оригинальное слово
                    string[] translations = parts[1].Trim('"').Split('|'); // Переводы

                    // Создание списка переводов
                    List<string> translationList = new List<string>(translations);

                    // Добавление слова и его переводов в словарь
                    dictionary.AddWord(originalWord, translationList);
                }
                else
                {
                    throw new FormatException("Ошибка: неверный формат строки в файле.");
                }
            }

            return dictionary;
        }

        public int GetWordCount(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines.Length;
        }
    }
}
