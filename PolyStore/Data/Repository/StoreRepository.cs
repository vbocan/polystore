using MongoDbGenericRepository;
using PolyStore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using PolyStore.Data.Docs;

namespace PolyStore.Data.Repository
{
    public class StoreRepository : BaseMongoRepository, IStoreRepository
    {
        public StoreRepository(DatabaseContext context) : base(context.DbContext)
        {

        }

        public Guid AddStore(string StoreName, string StoreAddress)
        {
            var newStore = new StoreDoc { StoreName = StoreName, StoreAddress = StoreAddress };
            AddOne(newStore);
            return newStore.Id;
        }

        public IList<StoreDoc> GetAllStores()
        {
            return GetAll<StoreDoc>(s => true);
        }

        public StoreDoc GetStore(Guid StoreId)
        {
            return GetAllStores().SingleOrDefault(w => w.Id == StoreId);
        }
    }
}
