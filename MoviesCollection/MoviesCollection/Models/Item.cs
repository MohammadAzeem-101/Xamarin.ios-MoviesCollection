using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MoviesCollection
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Movie
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty(PropertyName = "video")]
        public bool Video { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public float VoteAverage { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "popularity")]
        public float Popularity { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty(PropertyName = "original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty(PropertyName = "original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty(PropertyName = "genres")]
        public Genre[] Genres { get; set; }

        [JsonProperty(PropertyName = "genre_ids")]
        public int?[] GenreIds { get; set; }

        [JsonIgnore]
        public string GenresNames
        {
            get
            {
                return (Genres != null && Genres.Count() > 0) ?
                    Genres.Select(g => g.Name).Aggregate((first, second) => $"{first}, {second}") :
                    "Undefined";
            }
        }

        [JsonProperty(PropertyName = "backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty(PropertyName = "adult")]
        public bool Adult { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonIgnore]
        public bool HasOverview { get => !string.IsNullOrWhiteSpace(Overview); }

        [JsonProperty(PropertyName = "release_date")]
        public DateTimeOffset? ReleaseDate { get; set; }
    }


    public class GenreList
    {
        [JsonProperty(PropertyName = "genres")]
        public List<Genre> Genres { get; set; }
    }



    public class ResponseModel
    {
        public string Status { get; set; }

        public Codes Code { get; set; }

        public object Body { get; set; }

        public string Message { get; set; }

        public string AccessToken { get; set; }
    }

    public enum Codes
    {
        SuccessCode = 200,
        FailureCode = 400
    }
}
