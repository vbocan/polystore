using System;

namespace PolyStore.Data.ViewModels
{
    public abstract class ProductBaseViewModel
    {
        public Guid Id { get; set; }

        public Type Type { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
    }
}
