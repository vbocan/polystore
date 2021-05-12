using PolyStore.Data.Models;
using System.Collections.Generic;

namespace PolyStore.Data.ViewModels
{
    public class StoreViewModel
    {
        public string Id { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public IEnumerable<ProductBase> Products { get; set; }
    }
}
