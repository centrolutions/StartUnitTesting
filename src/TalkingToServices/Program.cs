using StarWarsApiCSharp;
using System;

namespace TalkingToServices
{
    class Program
    {
        static void Main(string[] args)
        {
            var starWars = new StarWars();
            var allFilms = starWars.GetAllFilms();

            foreach (var film in allFilms)
            {
                Console.WriteLine(film.Title);
            }
        }
    }
}
