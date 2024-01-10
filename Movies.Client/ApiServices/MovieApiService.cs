using Movies.Client.Models;
using Newtonsoft.Json;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        public MovieApiService()
        {
           
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return new List<Movie>();
        }

        public Task<Movie> GetMovie(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}
