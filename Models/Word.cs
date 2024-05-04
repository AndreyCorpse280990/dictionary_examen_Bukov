﻿using System.Collections.Generic;

namespace dictionary_examen_Bukov.Models
{
    public class Word
    {
        public string OriginalWord { get; set; }
        public List<Translation> Translations { get; set; }

        public Word(string originalWord)
        {
            OriginalWord = originalWord;
            Translations = new List<Translation>();
        }

        public class Translation
        {
            public string Text { get; set; }

            public Translation(string text)
            {
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
