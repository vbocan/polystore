using MongoDbGenericRepository;
using PolyStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyStore.Data.Repository
{
    public interface IProductRepository : IBaseMongoRepository
    {
        Guid AddProduct(Guid StoreId, ProductBase obj);
        void UpdateProduct(Guid StoreId, Guid ProductId, ProductBase obj);
        void DeleteProduct(Guid StoreId, Guid ProductId);
        IList<ProductBase> GetProducts(Guid StoreId);
        ProductBase GetProduct(Guid StoreId, Guid ProductId);
    }
}
