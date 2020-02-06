using System;
using MoviesCollection.Models;

namespace MoviesCollection
{
    public class MovieDetailViewModel : BaseViewModel
    {
        public Movie Item { get; set; }
        public MovieDetailViewModel(Movie item = null)
        {
            if (item != null)
            {
                Title = item.Title;
                Item = item;
            }
        }
    }
}
