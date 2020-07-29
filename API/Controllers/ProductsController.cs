using API.Models.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.EntitySpecifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all products
        /// </summary>
        /// <returns>Mapped Dto List of products</returns>
        [HttpGet]
        public async Task<IReadOnlyList<ProductDto>> Index()
        {
            var specification = new ProductSpecification();
            var products = await _repository.ListAsync(specification);
            return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
        }


        /// <summary>
        /// Get single product
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Mapped Dto product</returns>`
        [HttpGet("{id}")]
        public async Task<ProductDto> Single(int id)
        {
            var specification = new ProductSpecification(id);
            var product = await _repository.GetEntityWithSpecification(specification);
            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
