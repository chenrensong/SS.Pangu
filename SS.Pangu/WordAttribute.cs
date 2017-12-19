using System;

namespace SS.Pangu
{

    [Serializable]
    public class WordAttribute : IComparable<WordAttribute>
    {
        /// <summary>
        /// Word
        /// </summary>
        public String Word;

        /// <summary>
        /// Part of speech
        /// </summary>
        public POS Pos;

        /// <summary>
        /// Frequency for this word
        /// </summary>
        public double Frequency;

        public WordAttribute()
        {

        }

        public WordAttribute(string word, POS pos, double frequency)
        {
            this.Word = word;
            this.Pos = pos;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return Word;
        }


        #region IComparable<WordAttribute> Members

        public int CompareTo(WordAttribute other)
        {
            return this.Word.CompareTo(other.Word);
        }

        #endregion
    }

    [Serializable]
    public struct WordAttributeStruct
    {
        /// <summary>
        /// Word
        /// </summary>
        public String Word;

        /// <summary>
        /// Part of speech
        /// </summary>
        public POS Pos;

        /// <summary>
        /// Frequency for this word
        /// </summary>
        public double Frequency;

        public WordAttributeStruct(WordAttribute wa)
        {
            this.Word = wa.Word;
            this.Pos = wa.Pos;
            this.Frequency = wa.Frequency;
        }

        public WordAttributeStruct(string word, POS pos, double frequency)
        {
            this.Word = word;
            this.Pos = pos;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return Word;
        }

    }
}
