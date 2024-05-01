using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dictionary_examen_Bukov.Word;

namespace dictionary_examen_Bukov
{
    internal class Dictionary
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
