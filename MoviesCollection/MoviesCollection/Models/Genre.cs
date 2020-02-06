using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoviesCollection.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreList
    {
        [JsonProperty(PropertyName = "genres")]
        public List<Genre> Genres { get; set; }
    }
}
