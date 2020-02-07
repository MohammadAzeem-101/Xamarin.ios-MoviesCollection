using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MoviesCollection.Models;

namespace MoviesCollection.ViewModels
{
    /// <summary>
    /// Triggers when genre data load
    /// </summary>
    /// <author>Mohammad Azeem</author>
    public class GenreListViewModel : BaseViewModel
    {
        public ObservableCollection<Genre> Genres { get; set; }
        public Command LoadItemsCommand { get; set; }

        public GenreListViewModel()
        {
            Title = "Genre";
            Genres = new ObservableCollection<Genre>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadGenreCommand());
        }
        private async Task ExecuteLoadGenreCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                Genres.Clear();
                var genres = await DataStore.GetGenreAsync(true);
                if (genres.Any())
                {
                    foreach (var item in genres)
                    {
                        Genres.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
