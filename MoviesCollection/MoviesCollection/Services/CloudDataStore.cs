using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace MoviesCollection
{
    public class CloudDataStore : IDataStore<Genre>
    {

        private const string apiKey = "4e9132a7e19a3ba4d2b55ae1ff31a1ad";
        private const string baseUrl = "https://api.themoviedb.org/3";
        private const string searchMoviePath = "/search/movie";
        private const string moviePath = "/movie";
        private const string genreListPath = "/genre/list";

        private readonly string language;
        HttpClient client;
        List<Genre> genres;
        public CloudDataStore()
        {
            client = new HttpClient();
            language = CultureInfo.CurrentCulture.Name;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            genres = new List<Genre>();
        }

        public async Task<bool> AddItemAsync(Genre item)
        {
            genres.Add(item);

            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Genre>> GetGenreAsync(bool forceRefresh = false)
        {
            var restUrl = $"{baseUrl}{genreListPath}?api_key={apiKey}&language={language}";
            try
            {
                using (var response = await client.GetAsync(restUrl).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            var genreList = JsonConvert.DeserializeObject<GenreList>(await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false));
                            return genreList?.Genres;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            return null;
        }

        public Task<bool> UpdateItemAsync(Genre item)
        {
            throw new NotImplementedException();
        }
    }


}
