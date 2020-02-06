using System;

namespace MoviesCollection
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Movie Item { get; set; }
        public ItemDetailViewModel(Movie item = null)
        {
            if (item != null)
            {
                Title = item.Title;
                Item = item;
            }
        }
    }
}
