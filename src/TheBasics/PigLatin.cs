using System.Collections.Generic;

namespace TheBasics
{
    public class PigLatin
    {
        public string Translate(string sentence)
        {
            List<string> translatedWords = TranslateAllWords(sentence);
            return CreateSentenceFromWords(translatedWords);
        }

        private static string CreateSentenceFromWords(List<string> translatedWords)
        {
            return string.Join(' ', translatedWords.ToArray());
        }

        private List<string> TranslateAllWords(string sentence)
        {
            var translatedWords = new List<string>();
            var words = sentence.Split(' ');
            foreach (var word in words)
            {
                translatedWords.Add(TranslateWord(word));
            }

            return translatedWords;
        }

        private string TranslateWord(string word)
        {
            var wasCapitalized = StartsWithUpperCase(word);
            var endingPunctuation = GetPunctuationFromEnd(word);
            if (endingPunctuation != default)
                word = word.Substring(0, word.Length - 1);

            if (StartsWithVowel(word))
                return word + "way";

            word = word.ToLower();
            var consonantsAtEnd = MoveConsonantsToEnd(word);
            var newWord = consonantsAtEnd + "ay";

            if (wasCapitalized)
                newWord = newWord.Substring(0, 1).ToUpper() + newWord.Substring(1);

            if (endingPunctuation != default)
                newWord += endingPunctuation;

            return newWord;
        }

        private string MoveConsonantsToEnd(string word)
        {
            if (StartsWithVowel(word))
                return word;

            var newWord = word.Substring(1) + word.Substring(0, 1);
            return MoveConsonantsToEnd(newWord);
        }

        private bool StartsWithVowel(string word)
        {
            word = word.ToLower();
            return word.StartsWith('a') || word.StartsWith('e')
                || word.StartsWith('i') || word.StartsWith('o')
                || word.StartsWith('u');
        }

        private bool StartsWithUpperCase(string word)
        {
            var firstLetter = word[0];
            return char.IsUpper(firstLetter);
        }

        private char GetPunctuationFromEnd(string word)
        {
            var lastCharacter = word[word.Length - 1];
            if (char.IsLetter(lastCharacter))
                return default;

            return lastCharacter;
        }
    }
}
