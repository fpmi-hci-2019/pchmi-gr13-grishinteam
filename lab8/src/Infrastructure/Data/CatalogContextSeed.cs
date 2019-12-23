using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!catalogContext.CatalogBrands.Any())
                {
                    catalogContext.CatalogBrands.AddRange(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogTypes.Any())
                {
                    catalogContext.CatalogTypes.AddRange(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogItems.Any())
                {
                    catalogContext.CatalogItems.AddRange(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() { Brand = "Samsung"},
                new CatalogBrand() { Brand = "Apple" },
                new CatalogBrand() { Brand = "Xiaomi" },
                new CatalogBrand() { Brand = "Google" }, 
                new CatalogBrand() { Brand = "Other" }
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Type = "Smartphone"},
                new CatalogType() { Type = "Watch" },
                new CatalogType() { Type = "Other" },
                new CatalogType() { Type = "Laptop" }
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = "Iphone Xr", Name = "Iphone Xr", Price = 520, PictureUri = "http://catalogbaseurltobereplaced/images/products/1.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = "Iphone 5s", Name = "Iphone 5s", Price= 250, PictureUri = "http://catalogbaseurltobereplaced/images/products/2.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=3, Description = "Xiaomi 4c", Name = "Xiaomi 4c", Price = 155, PictureUri = "http://catalogbaseurltobereplaced/images/products/3.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = "Iphone 11 Pro Max", Name = "Iphone 11 Pro Max", Price = 1200, PictureUri = "http://catalogbaseurltobereplaced/images/products/4.png" },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=3, Description = "Xiaomi Mi Band 4", Name = "Xiaomi Mi Band 4", Price = 30M, PictureUri = "http://catalogbaseurltobereplaced/images/products/5.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = "Iphone 5s 64Gb", Name = "Iphone 5s 64Gb", Price = 299, PictureUri = "http://catalogbaseurltobereplaced/images/products/6.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=4, Description = "Google Pixel 4 128Gb", Name = "Google Pixel 4 128Gb", Price = 755, PictureUri = "http://catalogbaseurltobereplaced/images/products/7.png"  },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=4, Description = "Google Pixel 4 512Gb", Name = "Google Pixel 4 512Gb", Price = 1100, PictureUri = "http://catalogbaseurltobereplaced/images/products/8.png" },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=2, Description = "Apple watch series 4", Name = "Apple watch series 4", Price = 799, PictureUri = "http://catalogbaseurltobereplaced/images/products/9.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = "Iphone Xr 128Gb", Name = "Iphone Xr 128Gb", Price = 777, PictureUri = "http://catalogbaseurltobereplaced/images/products/10.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=1, Description = "Samsung watch 40mm", Name = "Samsung watch 40mm", Price = 300, PictureUri = "http://catalogbaseurltobereplaced/images/products/11.png" },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=3, Description = "Xiaomi Mi Band 4 Global Version", Name = "Xiaomi Mi Band 4 Global Version", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/12.png" }
            };
        }
    }
}
