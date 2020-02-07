using System;
using System.IO;
using MoviesCollection.Services;
using SQLite;


namespace MoviesCollection.iOS.Renderer
{
    public class GetSqlLiteConnection : ISqLiteServie
    {
        public GetSqlLiteConnection()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var fileName = "MoviesCollectionDB";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}
