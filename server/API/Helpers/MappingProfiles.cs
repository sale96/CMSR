using API.Models.Dto;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.ProductBrand, p => p.MapFrom(x => x.ProductBrand.Name))
                .ForMember(dto => dto.ProductType, p => p.MapFrom(x => x.ProductType.Name))
                .ForMember(dto => dto.Images, p => p.MapFrom(x => x.ProductImages.Select(s => new ImageDto { Location = s.Image.Location, Alt = s.Image.Alt }).ToArray()));
        }
    }
}
