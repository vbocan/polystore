using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PolyStore.Data.Models;
using PolyStore.Data.Repository;
using PolyStore.Data.ViewModels;

namespace PolyStore.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IStoreRepository storeRepository = null;
        private readonly IProductRepository productRepository = null;
        private readonly IMapper mapper;
        private readonly ILogger<ProductsModel> _logger;
        public IEnumerable<object> Products = null;

        [BindProperty]
        public string StoreId { get; set; }
        public ProductsModel(IStoreRepository storeRepository, IProductRepository productRepository, IMapper mapper, ILogger<ProductsModel> logger)
        {
            this.storeRepository = storeRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
            _logger = logger;
        }
        public void OnGet(string id)
        {
            _logger.LogInformation(@"Retrieving products for store {id}.");
            StoreId = id;
            var products = productRepository.GetProducts(Guid.Parse(id));
            Products = mapper.Map<IEnumerable<object>>(products);
        }

        private string[] Brands = new string[] { "Adidas", "Puma", "Nike", "Under Armour", "New Balance", "Asics", "Brooks" };
        private string[] Colors = new string[] { "White", "Silver", "Red", "Green", "Gray", "Black" };
        private string[] FootSizes = new string[] { "42", "42½", "43", "43½", "44", "44½", "45", "45½" };
        private string[] Sizes = new string[] { "S", "M", "L", "XL", "2XL", "3XL", "4XL" };

        public IActionResult OnPostGenerateRandomProduct()
        {
            ProductBase product = null;
            var rand = new Random();
            var r = rand.Next();
            switch (r % 3)
            {
                case 0:
                    product = new RunningGear
                    {
                        Brand = Brands[rand.Next(0, Brands.Length)],
                        Color = Colors[rand.Next(0, Colors.Length)],
                        FootSize = FootSizes[rand.Next(0, FootSizes.Length)],
                        SKU = string.Format("SKU{0}", rand.Next(1000, 9999))
                    };
                    break;
                case 1:
                    product = new CampingGear
                    {
                        CeilingColor = Colors[rand.Next(0, Colors.Length)],
                        WallColor = Colors[rand.Next(0, Colors.Length)],
                        Brand = Brands[rand.Next(0, Brands.Length)],
                        TentSize = Sizes[rand.Next(0, Sizes.Length)],
                        NumberOfRooms = rand.Next(1, 4),
                        SKU = string.Format("SKU{0}", rand.Next(1000, 9999))
                    };
                    break;
                case 2:
                    product = new SwimmingGear
                    {                        
                        Brand = Brands[rand.Next(0, Brands.Length)],
                        Color = Colors[rand.Next(0, Colors.Length)],
                        Size = Sizes[rand.Next(0, Sizes.Length)],
                        SKU = string.Format("SKU{0}", rand.Next(1000, 9999))
                    };
                    break;
            }
            productRepository.AddProduct(Guid.Parse(StoreId), product);
            return RedirectToPage("Products", new { id = StoreId });
        }
    }
}
