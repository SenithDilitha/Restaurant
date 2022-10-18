using AutoMapper;
using Microsoft.IdentityModel.Protocols;
using Restaurant.Services.Product.API.Models.DTOs;

namespace Restaurant.Services.Product.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Models.Product>();
                config.CreateMap<Models.Product, ProductDTO>();
            });

            return mappingConfig;
        }
    }
}
