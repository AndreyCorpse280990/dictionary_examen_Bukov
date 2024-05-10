using System.Collections.Generic;

namespace dictionary_examen_Bukov.Models
{
    public class Dictionary
    {
        public List<Word> Words { get; set; }

        public Dictionary()
        {
            Words = new List<Word>();
        }

        // Метод AddWord добавляет новое слово в словарь.
        public void AddWord(string originalWord, List<string> translations)
        {
            Word word = new Word(originalWord);
            foreach (string translationText in translations)
            {
                word.Translations.Add(new Word.Translation(translationText));
            }
            Words.Add(word);
        }

        // Метод ReplaceWord заменяет слово и его переводы в словаре.
        public void ReplaceWord(string originalWord, List<string> translations)
        {
            DeleteWord(originalWord);
            AddWord(originalWord, translations);
        }

        // Метод DeleteWord удаляет слово и его переводы из словаря.
        public void DeleteWord(string originalWord)
        {
            Word wordToRemove = Words.Find(word => word.OriginalWord == originalWord);
            if (wordToRemove != null)
            {
                Words.Remove(wordToRemove);
            }
        }

        // Метод DeleteTranslation удаляет перевод слова из словаря.
        public void DeleteTranslation(string originalWord, string translation)
        {
            Word word = Words.Find(w => w.OriginalWord == originalWord);
            if (word != null)
            {
                word.Translations.RemoveAll(t => t.Text == translation);
            }
        }
    }
}