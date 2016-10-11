using System;
using System.Collections.Generic;
using System.Linq;

namespace Lost
{
    public class WordsCounter
    {
        private string text;
        private Dictionary<string, int> wordsFrequency;


        public WordsCounter(string textForCount)
        {
            text = textForCount;
        }


        public void Count()
        {
            var separators = GetSeparators(text);
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            wordsFrequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordsFrequency.ContainsKey(word.ToLower()))
                    wordsFrequency[word.ToLower()]++;
                else
                    wordsFrequency.Add(word.ToLower(), 1);
            }
        }


        private char[] GetSeparators(string text)
        {
            HashSet<char> separators = new HashSet<char>();
            foreach (var ch in text)
            {
                if (char.IsSeparator(ch) || char.IsPunctuation(ch))
                    separators.Add(ch);
            }
            return separators.ToArray();
        }

        public void ShowWordsFrequency(SortParameter sort)
        {
            if (wordsFrequency == null)
                throw new NullReferenceException("Word's frequency wasn't count yet");

            switch (sort)
            {
                case SortParameter.None:
                    {
                        foreach (var item in wordsFrequency)
                            Console.WriteLine($"{item.Key,12}  -  {item.Value}");
                        break;
                    }
                case SortParameter.ByFrequency:
                    {
                        var sortedWordsFrequency = from item in wordsFrequency
                                                   orderby item.Value descending
                                                   select item;
                        foreach (var item in sortedWordsFrequency)
                            Console.WriteLine($"{item.Key,12}  -  {item.Value}");
                        break;
                    }
                case SortParameter.ByAlphabet:
                    {
                        foreach (var item in wordsFrequency.OrderBy(item=>item.Key))
                            Console.WriteLine($"{item.Key,12}  -  {item.Value}");
                        break;
                    }
            }
        }
    }
}
