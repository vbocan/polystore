using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PolyStore.Data.Repository;
using PolyStore.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolyStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly IStoreRepository storeRepository;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<StoreViewModel> Stores = null;
        public IndexModel(IStoreRepository storeRepository, IMapper mapper, ILogger<IndexModel> logger)
        {
            this.mapper = mapper;
            this.storeRepository = storeRepository;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Retrieving stores from the database");
            // Get stores from the database
            var stores = storeRepository.GetAllStores();
            // Transform data transfer objects (DTOs) to view objects (models)
            // Using LINQ (compare to the AutoMapper approach below)
            Stores = stores.Select(s => new StoreViewModel { Id = s.Id.ToString(), StoreName = s.StoreName, StoreAddress = s.StoreAddress, Products = s.Products });
            // Using AutoMapper
            // Stores = mapper.Map<IEnumerable<StoreViewModel>>(stores);
        }

        private string[] StoreNames = new string[] { "Hervis", "Intersport", "Sports Vision", "Decathlon", "Sports Direct" };
        private string[] StoreAddresses = new string[] { "Timișoara, Str. Ștefan Procopiu nr. 1", "București, Bd. Aviatorilor nr. 45", "Cluj, Al. Teatrului nr. 1", "Brașov, Str. Lungă nr. 104" };

        public RedirectToPageResult OnPostGenerateRandomStore()
        {
            var rand = new Random();
            storeRepository.AddStore(
                StoreNames[rand.Next(0, StoreNames.Length)],
                StoreAddresses[rand.Next(0, StoreAddresses.Length)]
                );
            return RedirectToPage("Index");
        }
    }
}
