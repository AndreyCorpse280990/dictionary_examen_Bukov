using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using dictionary_examen_Bukov.Models;
using dictionary_examen_Bukov.Services;

namespace dictionary_examen_Bukov.ViewModels
{
    public class DictionaryViewModel : INotifyPropertyChanged
    {
        private readonly DictionaryService _dictionaryService;
        private string _originalText;
        private string _translationText;
        private List<Word> _words; // список слов

        public event PropertyChangedEventHandler PropertyChanged;

        public Dictionary Dictionary { get; set; }
        public string FilePath { get; set; }

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

        public List<Word> Words
        {
            get { return _words; }
        }

        public DictionaryViewModel(DictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
            Dictionary = new Dictionary();
        }

        public void LoadDictionary(string filePath)
        {
            Dictionary = _dictionaryService.LoadDictionary(filePath);
            _words = Dictionary.Words; // Сохраняю список слов
            UpdateTextBoxes(Dictionary);
            FilePath = filePath;
        }

        private void UpdateTextBoxes(Dictionary dictionary)
        {
            OriginalText = string.Join(Environment.NewLine, dictionary.Words.Select(w => w.OriginalWord));
            TranslationText = string.Join(Environment.NewLine, dictionary.Words.Select(w => string.Join(", ", w.Translations)));
        }

        public List<Word> GetWords(string filePath)
        {
            return _dictionaryService.LoadDictionary(filePath).Words;
        }

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
    }
}
