using System;
using SQLite;

namespace MoviesCollection.Services
{
    public interface ISqLiteServie
    {
        SQLiteConnection GetConnection();
    }
}
