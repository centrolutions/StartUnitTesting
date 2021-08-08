using System;

namespace TheBasics
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //RunFizzBuzz();
            RunPigLatin();
        }



        //FizzBuzz:
        // if a number is divisible by 3, replace it with Fizz
        // if a number is divisible by 5, replace it with Buzz
        // if a number is divisible by both 3 and 5, replace it with FizzBuzz
        // if a number is not divisible by 3 or 5, return the number 
        static void RunFizzBuzz()
        {
            var fizzBuzz = new FizzBuzz();

            Console.WriteLine("Enter a number and press [Enter].");

            var enteredText = Console.ReadLine();
            int number;
            if (!int.TryParse(enteredText, out number))
            {
                Console.WriteLine("Please enter an integer.");
                return;
            }

            Console.WriteLine(fizzBuzz.Check(number));
        }





        //Pig Latin:
        // for words that start with a consonant, move all consonants (up to the first vowel) to the end and add "ay"
        // for words that start with a vowel, add "way" to the end of the word
        //
        // example: the quick brown fox jumped over the dog
        // becomes: ethay uickqay ownbray oxfay umpedjay overway ethay ogday
        //
        //
        // extra credit: handle punctuation and capitalization correctly so:
        //  The quick, brown fox jumped over the dog.
        // translates to:
        //  Ethay uickqay, ownbray oxfay umpedjay overway ethay ogday.
        static void RunPigLatin()
        {
            Console.WriteLine("Type a sentence followed by [Enter].");
            var sentence = Console.ReadLine();

            var pigLatinTranslator = new PigLatin();
            var pigLatinSentence = pigLatinTranslator.Translate(sentence);

            Console.WriteLine(pigLatinSentence);
        }
    }
}