namespace TheBasics
{
    public class FizzBuzz
    {
        public string Check(int number)
        {
            string result = string.Empty;
            if (number % 3 == 0)
                result += "Fizz";

            if (number % 5 == 0)
                result += "Buzz";

            if (string.IsNullOrWhiteSpace(result))
                result = number.ToString();

            return result;
        }
    }
}
