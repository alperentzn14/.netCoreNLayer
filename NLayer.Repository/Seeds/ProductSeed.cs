using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, CategoryId=1,Name="pencil 1",Price=100,Stock=20,CreatedDate=DateTime.Now });
            builder.HasData(new Product { Id = 2, CategoryId = 1, Name = "pencil 2", Price = 300, Stock = 50, CreatedDate = DateTime.Now });
            builder.HasData(new Product { Id = 3, CategoryId = 1, Name = "pencil 3", Price = 500, Stock = 30, CreatedDate = DateTime.Now });

            builder.HasData(new Product { Id = 4, CategoryId = 2,Name="computer 1", Price = 10000, Stock = 20, CreatedDate = DateTime.Now });

            builder.HasData(new Product { Id = 5, CategoryId = 3,Name="Keyboard 1", Price = 200, Stock = 50, CreatedDate = DateTime.Now });
        }
    }
}
