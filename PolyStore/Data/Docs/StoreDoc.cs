using MongoDbGenericRepository.Attributes;
using MongoDbGenericRepository.Models;
using PolyStore.Data.Models;
using System.Collections.Generic;

namespace PolyStore.Data.Docs
{
    [CollectionName("Stores")]
    public class StoreDoc : Document
    {
        public StoreDoc()
        {
            Version = 1;
            Products = new List<ProductBase>();
        }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public IList<ProductBase> Products { get; set; }
    }
}
