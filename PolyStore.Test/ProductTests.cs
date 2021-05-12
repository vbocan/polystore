using PolyStore.Data.Models;
using PolyStore.Data.Repository;
using System;
using Xunit;

namespace PolyStore.Test
{
    [Collection("Repository collection")]
    public class ProductTests
    {
        const string StoreName = "Decathlon";
        const string StoreAddress = "Timișoara, Str. Ștefan Procopiu nr. 1";
        const string AnotherBrand = "Puma";
        private readonly RunningGear product1 = new RunningGear { SKU = "ABC100", Brand = "Adidas", Color = "White with blue stripes", FootSize = "44 1/2" };
        private readonly CampingGear product2 = new CampingGear { SKU = "ABC100", Brand = "Quechua", TentSize = "XXL", WallColor = "Gray", CeilingColor = "Silver", NumberOfRooms = 2 };

        private readonly IStoreRepository storeRepository = null;
        private readonly IProductRepository productRepository = null;
        
        public ProductTests(RepositoryFixture fixture)
        {
            this.storeRepository = fixture.storeRepository;
            this.productRepository = fixture.productRepository;
        }
        
        [Fact]
        public void AddProducts()
        {
            var storeId = storeRepository.AddStore(StoreName, StoreAddress);
            var countBefore = productRepository.GetProducts(storeId).Count;
            productRepository.AddProduct(storeId, product1);
            productRepository.AddProduct(storeId, product2);
            var countAfter = productRepository.GetProducts(storeId).Count;
            Assert.Equal(countBefore + 2, countAfter);
        }

        [Fact]
        public void GetRunningGearProduct()
        {
            var storeId = storeRepository.AddStore(StoreName, StoreAddress);            
            var productId = productRepository.AddProduct(storeId, product1);
            var dbProduct = productRepository.GetProduct(storeId, productId);            
            Assert.True(dbProduct is RunningGear);            
        }

        [Fact]
        public void GetCampingGearProduct()
        {
            var storeId = storeRepository.AddStore(StoreName, StoreAddress);
            var productId = productRepository.AddProduct(storeId, product2);
            var dbProduct = productRepository.GetProduct(storeId, productId);            
            Assert.True(dbProduct is CampingGear);
        }

        [Fact]
        public void AddProductAndCheckContents()
        {
            var storeId = storeRepository.AddStore(StoreName, StoreAddress);
            var productId = productRepository.AddProduct(storeId, product1);
            var dbProduct = productRepository.GetProduct(storeId, productId) as RunningGear;            
            Assert.Equal(dbProduct.SKU, product1.SKU);
            Assert.Equal(dbProduct.FootSize, product1.FootSize);
            Assert.Equal(dbProduct.Brand, product1.Brand);
            Assert.Equal(dbProduct.Color, product1.Color);
        }

        [Fact]
        public void UpdateProduct()
        {
            var storeId = storeRepository.AddStore(StoreName, StoreAddress);
            var productId = productRepository.AddProduct(storeId, product1);
            var updProduct = product1;
            updProduct.Brand = AnotherBrand;
            productRepository.UpdateProduct(storeId, productId, updProduct);
            var dbProduct = productRepository.GetProduct(storeId, productId) as RunningGear;
            Assert.Equal(dbProduct.SKU, product1.SKU);
            Assert.Equal(dbProduct.FootSize, product1.FootSize);
            Assert.Equal(AnotherBrand, dbProduct.Brand);
            Assert.Equal(dbProduct.Color, product1.Color);
        }

        [Fact]
        public void DeleteProduct()
        {
            var storeId = storeRepository.AddStore(StoreName, StoreAddress);
            var countBefore = productRepository.GetProducts(storeId).Count;
            var productId1 = productRepository.AddProduct(storeId, product1);
            var productId2 = productRepository.AddProduct(storeId, product2);
            productRepository.DeleteProduct(storeId, productId1);
            var countAfter1 = productRepository.GetProducts(storeId).Count;
            productRepository.DeleteProduct(storeId, productId2);
            var countAfter2 = productRepository.GetProducts(storeId).Count;

            Assert.Equal(countBefore + 1, countAfter1);
            Assert.Equal(countBefore, countAfter2);
        }
    }
}
