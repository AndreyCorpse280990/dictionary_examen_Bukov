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
        // originalWord: оригинальное слово, translations: список переводов.
        public void AddWord(string originalWord, List<string> translations)
        {
            Word word = new Word(originalWord);
            foreach (string translationText in translations)
            {
                word.Translations.Add(new Word.Translation(translationText));
            }
            Words.Add(word);
        }
    }
}