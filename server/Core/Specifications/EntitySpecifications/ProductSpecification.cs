using Core.Entities;
using Core.Specifications.SpecificationParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Specifications.EntitySpecifications
{
    public class ProductSpecification : BaseSpecifications<Product>
    {
        public ProductSpecification(ProductSpecificationParams productParams)
            : base(x =>
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddInclude("ProductImages.Image");
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            AddOrderBy(x => x.Name);

            if (!String.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(x => x.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDesc(x => x.Name);
                        break;
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddInclude("ProductImages.Image");
        }
    }
}
