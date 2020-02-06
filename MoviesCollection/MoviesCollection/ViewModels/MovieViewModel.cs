using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MoviesCollection.Models;

namespace MoviesCollection
{
    public class MovieViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }

        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }
        public MovieViewModel()
        {
            Title = "Movies";
            Movies = new ObservableCollection<Movie>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            //AddItemCommand = new Command<Genre>(async (Genre item) => await AddItem(item));
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                Movies.Clear();
                var movies = await DataStore.GetMovieAsync(true);
                if (movies.Any())
                {
                    foreach (var item in movies)
                    {
                        Movies.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        //async Task AddItem(Genre item)
        //{
        //    //Genres.Add(item);
        //    await DataStore.AddItemAsync(item);
        //}
    }
}
