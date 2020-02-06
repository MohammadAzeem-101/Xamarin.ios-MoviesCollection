using System;

namespace MoviesCollection
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Genre Item { get; set; }
        public ItemDetailViewModel(Genre item = null)
        {
            if (item != null)
            {
                Title = item.Name;
                Item = item;
            }
        }
    }
}
