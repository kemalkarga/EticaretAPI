using EticaretAPI.Domain.Entities;
using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository  _productReadRepository;

        readonly IMediator _mediator;
       
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository,IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllProductQueryRequest  getAllProductQueryRequest)
        {
           GetAllProductQueryReesponse reesponse= await _mediator.Send(getAllProductQueryRequest);

           return Ok(reesponse);


        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> Get([FromRoute]GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest )
        {

         CreateProductCommandResponse response= await  _mediator.Send(createProductCommandRequest);
        
            return StatusCode((int)HttpStatusCode.Created);
           
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
          Product product= await  _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
      
    }
       
}
