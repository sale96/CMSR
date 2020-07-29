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
                .ForMember(dto => dto.Images, p => p.MapFrom(x => x.Images));
                //.ForMember(dto => dto.Images, p => p.MapFrom(x => x.ProductImages
                //    .Where(pi => pi.ProductId == x.Id)
                //    .Select(ob => new ImageDto {
                //        Alt = ob.Image.Alt, Location = ob.Image.Location
                //    })
                //));
        }
    }
}
