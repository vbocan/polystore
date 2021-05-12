using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyStore.Data.Models
{
    [BsonDiscriminator(Required = true, RootClass = true)]
    [BsonKnownTypes(
        typeof(RunningGear),
        typeof(CampingGear),
        typeof(SwimmingGear)
    )]
    public abstract class ProductBase
    {
        public ProductBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
    }
}
