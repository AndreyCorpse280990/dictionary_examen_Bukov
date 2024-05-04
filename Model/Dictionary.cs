using dictionary_examen_Bukov;
using System.Collections.Generic;

namespace DictionaryExamenBukov.Model
{
    public class Dictionary
    {
        public List<Word> Words { get; set; }

        public Dictionary()
        {
            Words = new List<Word>();
        }

        public void AddWord(string originalWord, string[] translations)
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
