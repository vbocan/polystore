using PolyStore.Data.Repository;
using System;
using Xunit;

namespace PolyStore.Test
{
    [Collection("Repository collection")]
    public class StoreTests
    {
        const string StoreName = "Decathlon";
        const string StoreAddress = "Timișoara, Str. Ștefan Procopiu nr. 1";

        private readonly IStoreRepository storeRepository = null;        
        public StoreTests(RepositoryFixture fixture)
        {
            this.storeRepository = fixture.storeRepository;            
        }
        [Fact]
        public void CreateStore()
        {
            var storeId = storeRepository.AddStore(StoreName, StoreAddress);
            Assert.NotEqual(storeId, Guid.Empty);
        }

        [Fact]
        public void GetSpecificStore()
        {
            var storeId = storeRepository.AddStore(StoreName, StoreAddress);
            var dbStore = storeRepository.GetStore(storeId);
            Assert.Equal(StoreName, dbStore.StoreName);
            Assert.Equal(StoreAddress, dbStore.StoreAddress);
        }
    }
}
