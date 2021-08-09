using StarWarsApiCSharp;
using System.Collections.Generic;
using System.Linq;

namespace TalkingToServices
{
    public class StarWars
    {
        private readonly IRepository<Film> _FilmRepo;

        public StarWars(IRepository<Film> filmRepo)
        {
            _FilmRepo = filmRepo;
        }

        public List<Film> GetAllFilms()
        {
            var results = new List<Film>();
            const int pageSize = 10;
            int page = 1;

            var films = _FilmRepo.GetEntities(page, pageSize);
            results.AddRange(films);
            while (films.Count == pageSize)
            {
                films = _FilmRepo.GetEntities(++page, pageSize);
                results.AddRange(films);
            }

            return results;
        }
    }
}
