using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using dictionary_examen_Bukov.Models;
using dictionary_examen_Bukov.Services;
using System.Windows.Forms;


namespace dictionary_examen_Bukov.ViewModels
{
    // Класс DictionaryViewModel предоставляет данные и логику для представления словаря.
    public class DictionaryViewModel : INotifyPropertyChanged
    {
        private readonly DictionaryService _dictionaryService;
        private string _originalText;
        public static string _translationText;
        private List<Word> _words; // список слов

        // Событие, сигнализирующее об изменении свойства.
        public event PropertyChangedEventHandler PropertyChanged;

        public Dictionary Dictionary { get; set; }
        public string FilePath { get; set; }

        public TextBox TranslationTextBox { get; set; }


        // Свойство, представляющее текст оригинальных слов..
        public string OriginalText
        {
            get { return _originalText; }
            set
            {
                if (_originalText != value)
                {
                    _originalText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OriginalText)));
                }
            }
        }

        // Свойство, представляющее текст переводов.
        public string TranslationText
        {
            get { return _translationText; }
            set
            {
                if (_translationText != value)
                {
                    _translationText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TranslationText)));
                }
            }
        }

        // Свойство, представляющее список слов.
        public List<Word> Words
        {
            get { return _words; }
        }

        public DictionaryViewModel(DictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
            Dictionary = new Dictionary();
        }


        // Метод для обновления текстовых полей.
        private void UpdateTextBoxes(Dictionary dictionary)
        {
            OriginalText = string.Join(Environment.NewLine, dictionary.Words.Select(w => w.OriginalWord));
            TranslationText = string.Join(Environment.NewLine, dictionary.Words.Select(w => string.Join(", ", w.Translations)));
        }

        // Метод для получения списка слов из файла.
        public List<Word> GetWords(string filePath)
        {
            return _dictionaryService.LoadDictionary(filePath).Words;
        }

        // метож для сохранения словаря в файл
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

        // Метод для добавления слова и его переводов в словарь.
        public void AddWord(string originalWord, List<string> translations)
        {
            Dictionary.AddWord(originalWord, translations);
            UpdateTextBoxes(Dictionary);
        }

        // Метод для замены слова и его переводов в словаре.
        public void ReplaceWord(string originalWord, List<string> translations)
        {
            Dictionary.ReplaceWord(originalWord, translations);
            UpdateTextBoxes(Dictionary);
        }

        // Метод для удаления слова и его переводов из словаря.
        public void DeleteWord(string originalWord)
        {
            Dictionary.DeleteWord(originalWord);
            UpdateTextBoxes(Dictionary);
        }

        // Метод для удаления перевода слова из словаря.
        public void DeleteTranslation(string originalWord, string translation)
        {
            Dictionary.DeleteTranslation(originalWord, translation);
            UpdateTextBoxes(Dictionary);
        }




    }
}
