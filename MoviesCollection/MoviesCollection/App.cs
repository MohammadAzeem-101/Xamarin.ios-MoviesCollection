using System;

namespace MoviesCollection
{
    public class App
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://api.themoviedb.org/3/discover/movie?api_key=4e9132a7e19a3ba4d2b55ae1ff31a1ad&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=true&page=1";

        public static void Initialize()
        {
            if (UseMockDataStore)
                ServiceLocator.Instance.Register<IDataStore<Item>, CloudDataStore>();
           // ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<Item>, CloudDataStore>();
        }
    }
}
