using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SeedData
    {
        public static async Task Initialize(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    context.ProductBrands.AddRange(
                        new ProductBrand
                        {
                            Name = "Adidas",
                        },

                        new ProductBrand
                        {
                            Name = "Nike",
                        },

                        new ProductBrand
                        {
                            Name = "Pumma",
                        }
                    );
                }

                if (!context.ProductTypes.Any())
                {
                    context.ProductTypes.AddRange(
                        new ProductType
                        {
                            Name = "Shoes",
                        },

                        new ProductType
                        {
                            Name = "T-Shirt",
                        },

                        new ProductType
                        {
                            Name = "Sweat suit",
                        }
                    );
                }

                if (!context.Images.Any())
                {
                    context.Images.Add(new Image
                    {
                        Alt = "No image",
                        Location = "~/Media/Images/Product/noimage.png"
                    });
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Name = "T-Shirt 1",
                            Description = "Just a regular T-shirt",
                            Price = 2.20M,
                            Barcode = "901237128931",
                            ProductTypeId = 2,
                            ProductBrandId = 2
                        },
                        new Product
                        {
                            Name = "Shoe 1",
                            Description = "Just a regular shoe",
                            Price = 2.90M,
                            Barcode = "89123jhasdas",
                            ProductTypeId = 1,
                            ProductBrandId = 1
                        },
                        new Product
                        {
                            Name = "Sweat suit 1",
                            Description = "Just a regular Sweat suit",
                            Price = 1.80M,
                            Barcode = "218372jkmasidi",
                            ProductTypeId = 3,
                            ProductBrandId = 3
                        }
                    );
                }

                if (!context.ProductImages.Any())
                {
                    context.ProductImages.AddRange(
                        new ProductImage
                        {
                            ProductId = 1,
                            ImageId = 1
                        },

                        new ProductImage
                        {
                            ProductId = 2,
                            ImageId = 1
                        },

                        new ProductImage
                        {
                            ProductId = 3,
                            ImageId = 1
                        }
                    );
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedData>();
                logger.LogError(ex.Message);
            }
        }
    }
}
