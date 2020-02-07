using System;
using System.Threading.Tasks;
using MoviesCollection.Models;

namespace MoviesCollection.Services
{
    public class LocalService : ILocalService<Genre>
    {
        public Task<bool> AddFavoritesAsync(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
