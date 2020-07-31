using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Dto
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }

        public ImageDto[] Images { get; set; }
    }
}
