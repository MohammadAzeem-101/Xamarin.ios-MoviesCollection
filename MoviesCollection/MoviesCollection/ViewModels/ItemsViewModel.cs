using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCollection
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Genre> Genres { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }
        public ItemsViewModel()
        {
            Title = "Genre";
            Genres = new ObservableCollection<Genre>();
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
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task AddItem(Genre item)
        {
            Genres.Add(item);
            await DataStore.AddItemAsync(item);
        }
    }
}
