using disability_map.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Testy
{
    public class TestWithSqlite : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly DbMainContext DbContext;

        protected TestWithSqlite()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<DbMainContext>()
                    .UseSqlite(_connection)
                    .Options;
            DbContext = new DbMainContext(options);
            DbContext.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _connection.Close();
        }
    }
}
