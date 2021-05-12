using MongoDbGenericRepository;
using PolyStore.Helpers;
using PolyStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyStore.Data.Repository
{
    public class ProductRepository : BaseMongoRepository, IProductRepository
    {
        private readonly IStoreRepository storeRepository;
        public ProductRepository(DatabaseContext context, IStoreRepository storeRepository) : base(context.DbContext)
        {
            this.storeRepository = storeRepository;
        }
        public Guid AddProduct(Guid StoreId, ProductBase obj)
        {
            var store = storeRepository.GetStore(StoreId);
            store.Products.Add(obj);
            UpdateOne(store);
            return obj.Id;
        }
        public void UpdateProduct(Guid StoreId, Guid ProductId, ProductBase obj)
        {
            var store = storeRepository.GetStore(StoreId);           
            var product = store.Products.Single(w => w.Id == ProductId);
            var originalId = product.Id;
            store.Products.Remove(product);
            store.Products.Add(obj);
            obj.Id = originalId;
            UpdateOne(store);
        }
        public void DeleteProduct(Guid StoreId, Guid ProductId)
        {
            var store = storeRepository.GetStore(StoreId);
            var product = store.Products.Single(w => w.Id == ProductId);
            store.Products.Remove(product);
            UpdateOne(store);
        }

        public ProductBase GetProduct(Guid StoreId, Guid ProductId)
        {
            var store = storeRepository.GetStore(StoreId);
            var product = store.Products.Single(w => w.Id == ProductId);
            return product;
        }

        public IList<ProductBase> GetProducts(Guid StoreId)
        {
            var store = storeRepository.GetStore(StoreId);
            return store.Products;
        }

        
    }
}
