using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PolyStore.Data.Docs;
using PolyStore.Data.Models;

namespace PolyStore.Helpers
{
    public class DatabaseContext
    {
        #region Public constructors
        public DatabaseContext(IOptions<DatabaseSettings> settings) : this(settings.Value.ConnectionString) { }

        public DatabaseContext(string ConnectionString)
        {
            var databaseName = MongoUrl.Create(ConnectionString).DatabaseName;

            var client = new MongoClient(ConnectionString);
            if (client != null)
                DbContext = client.GetDatabase(databaseName);
        }
        #endregion

        public IMongoDatabase DbContext { get; private set; }

        public IMongoCollection<StoreDoc> Products
        {
            get
            {
                return DbContext.GetCollection<StoreDoc>("Products");
            }
        }
    }
}
