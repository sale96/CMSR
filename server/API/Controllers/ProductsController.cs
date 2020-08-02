using API.Errors;
using API.Models.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.EntitySpecifications;
using Core.Specifications.SpecificationParams;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts([FromQuery]ProductSpecificationParams productParams)
        {
            var specification = new ProductSpecification(productParams);
            var products = await _repository.ListAsync(specification);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }


        /// <summary>
        /// Get single product
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Mapped Dto product</returns>`
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var specification = new ProductSpecification(id);
            var product = await _repository.GetEntityWithSpecification(specification);

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
