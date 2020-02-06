using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesCollection.Models;

namespace MoviesCollection
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetGenreAsync(bool forceRefresh = false);
        Task<List<Movie>> GetMovieAsync(bool forceRefresh = false);
    }
}
