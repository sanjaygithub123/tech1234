using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pms.Core.Logging;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace ProductMicroservice.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize] 
  public class TestExceptionController : ControllerBase
  {

    private readonly IProductRepository _productRepository;

    public TestExceptionController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    
     [HttpGet(Name = "GetNullReferenceException")]
    public IActionResult Get()
    {
      Log.Information(LoggingEvent.Controller,"With in Get By ProductId method");
      _productRepository.RaiseNullReferenceException();
      return new OkObjectResult(null);
    }


    // POST: api/Product
    // [HttpPost]
    // public IActionResult Post([FromBody] Product product)
    // {
    //   using (var scope = new TransactionScope())
    //   {
    //     _productRepository.InsertProduct(product);
    //     scope.Complete();
    //     return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    //   }
    // }

    // PUT: api/Product/5
    // [HttpPut]
    // public IActionResult Put([FromBody] Product product)
    // {
    //   if (product != null)
    //   {
    //     using (var scope = new TransactionScope())
    //     {
    //       _productRepository.UpdateProduct(product);
    //       scope.Complete();
    //       return new OkResult();
    //     }
    //   }
    //   return new NoContentResult();
    // }

    // // DELETE: api/ApiWithActions/5
    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //   _productRepository.DeleteProduct(id);
    //   return new OkResult();
    // }
  }
}
