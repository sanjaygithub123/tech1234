using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductMicroservice.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly ProductContext _dbContext;

    public ProductRepository()
    {
      //_dbContext = dbContext;
    }

    // public void DeleteProduct(int productId)
    // {
    //   var product = _dbContext.Products.Find(productId);
    //   _dbContext.Products.Remove(product);
    //   Save();
    // }

    public Product GetProductByID(int productId)
    {
      Product product = new Product();
      product.CategoryId = 1;
      product.Description = "Lenovo Laptop - staging slot";
      product.Name = "Laptop";
      product.Id = 10;
      product.Price = 60000;
      return product;
      //return _dbContext.Products.Find(productId);
    }

    public void RaiseNullReferenceException()
    {
      
      throw new NullReferenceException();
    }

    public IEnumerable<Product> GetProducts()
    {
      List<Product> products = new List<Product>();
       Product product1 = new Product();
      product1.CategoryId = 1;
      product1.Description = "Lenovo Laptop";
      product1.Name = "Laptop";
      product1.Id = 10;
      product1.Price = 60000;
      products.Add(product1);

      Product product2 = new Product();
      product2.CategoryId = 1;
      product2.Description = "Mouse";
      product2.Name = "Mouse";
      product2.Id = 10;
      product2.Price = 100;
      products.Add(product2);
      
      return products;
      //return _dbContext.Products.ToList();
    }

    // public void InsertProduct(Product product)
    // {
    //   _dbContext.Add(product);
    //   Save();    }

    // public void Save()
    // {
    //   _dbContext.SaveChanges();
    // }

    // public void UpdateProduct(Product product)
    // {
    //   _dbContext.Entry(product).State = EntityState.Modified;
    //   Save();
    // }
  }
}
