using MongoDbGenericRepository;
using PolyStore.Data.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyStore.Data.Repository
{
    public interface IStoreRepository : IBaseMongoRepository
    {
        Guid AddStore(string StoreName, string StoreAddress);

        StoreDoc GetStore(Guid StoreId);
        IList<StoreDoc> GetAllStores();
    }
}
