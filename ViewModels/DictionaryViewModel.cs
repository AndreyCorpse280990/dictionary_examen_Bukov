using System;
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

        public DictionaryViewModel(DictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        public void LoadDictionary(string filePath)
        {
            var dictionary = _dictionaryService.LoadDictionary(filePath);
            _words = dictionary.Words; // Сохраняю список слов
            UpdateTextBoxes(dictionary);
        }

        private void UpdateTextBoxes(Dictionary dictionary)
        {
            OriginalText = string.Join(Environment.NewLine, dictionary.Words.Select(w => w.OriginalWord));
            TranslationText = string.Join(Environment.NewLine, dictionary.Words.Select(w => string.Join(", ", w.Translations)));
        }
    }
}
