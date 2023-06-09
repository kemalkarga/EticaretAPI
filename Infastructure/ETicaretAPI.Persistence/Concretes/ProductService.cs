﻿using EticaretAPI.Domain.Entities;
using ETicaretAPI.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
       => new() { 
         
           new() { Id=Guid.NewGuid(), Name="Product 1", Price=10,Stock=100},
           new() { Id=Guid.NewGuid(), Name="Product 2", Price=500,Stock=20},
           new() { Id=Guid.NewGuid(), Name="Product 3", Price=400,Stock=40},
           new() { Id=Guid.NewGuid(), Name="Product 4", Price=200,Stock=60},


       };
    }
}
