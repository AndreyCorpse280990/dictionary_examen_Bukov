using System.Collections.Generic;

namespace dictionary_examen_Bukov.Models
{
    // Класс Word представляет собой слово и его переводы.
    public class Word
    {
        public string OriginalWord { get; set; }
        // Список переводов слова.
        public List<Translation> Translations { get; set; }

        public Word(string originalWord)
        {
            OriginalWord = originalWord;
            Translations = new List<Translation>();
        }

        // Внутренний класс Translation представляет собой перевод слова.
        public class Translation
        {
            // Текст перевода.
            public string Text { get; set; }

            public Translation(string text)
            {
                Text = text;
            }

            // Переопределение метода ToString для возвращения текста перевода.
            public override string ToString()
            {
                return Text;
            }
        }
    }
}