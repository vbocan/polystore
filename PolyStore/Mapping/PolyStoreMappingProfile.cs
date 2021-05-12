using AutoMapper;
using PolyStore.Data.Docs;
using PolyStore.Data.Models;
using PolyStore.Data.ViewModels;
using System;

namespace PolyStore.Mapping
{
    // Mappings for AutoMapper
    public class PolyStoreMappingProfile : Profile
    {
        public PolyStoreMappingProfile()
        {            
            CreateMap<ProductBase, GenericProductViewModel>();
            CreateMap<StoreDoc, StoreViewModel>();
        }
    }
}
