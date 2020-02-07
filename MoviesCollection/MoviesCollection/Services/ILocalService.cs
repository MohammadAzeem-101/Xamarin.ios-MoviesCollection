using System;
using System.Threading.Tasks;
using MoviesCollection.Models;

namespace MoviesCollection.Services
{
    public interface ILocalService<T>
    {
        Task<bool> AddGenreAsync(T genre);

        Task<bool> AddFavoritesAsync(T genre);
    }
}
