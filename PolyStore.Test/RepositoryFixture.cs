using Microsoft.Extensions.Configuration;
using PolyStore.Data.Repository;
using PolyStore.Helpers;
using System;

namespace PolyStore.Test
{
    /// <summary>
    /// Read more about text fixtures at https://xunit.github.io/docs/shared-context
    /// </summary>
    public class RepositoryFixture : IDisposable
    {
        private DatabaseContext Context { get; set; }
        public IStoreRepository storeRepository { get; private set; }
        public IProductRepository productRepository { get; private set; }

        public RepositoryFixture()
        {
            // Read test configuration settings            
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            // Build database context based on the connection string
            Context = new DatabaseContext(connectionString);
            // Build repositories
            storeRepository = new StoreRepository(Context);
            productRepository = new ProductRepository(Context, storeRepository);
        }

        public void Dispose()
        {

        }
    }
}