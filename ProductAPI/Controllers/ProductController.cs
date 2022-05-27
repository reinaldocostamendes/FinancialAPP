using AutoMapper;
using BuyRequest_Application.Interface;
using BuyRequestDomain.DTO;
using Infrastructure.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _iproductApplication;
        private readonly IMapper _imapper;

        public ProductController(IProductApplication iproductApplication, IMapper imapper)
        {
            _iproductApplication = iproductApplication;
            _imapper = imapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {
            Product productInserted = _imapper.Map<Product>(productDTO);
            try
            {
                await _iproductApplication.AddProduct(productInserted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(productInserted);
        }

        [HttpGet]
        public async Task<List<Product>> GetAll([FromQuery] PageParameters pageParameters)
        {
            return await _iproductApplication.GetAllProducts();
        }

        [HttpGet("GetById")]
        public async Task<Product> GetById(Guid Id)
        {
            return await _iproductApplication.getProductById(Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDTO productDTO)
        {
            Product productToUpdate = _imapper.Map<Product>(productDTO);
            try
            {
                await _iproductApplication.UpdateProduct(productToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(productToUpdate);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _iproductApplication.DeleteProduct(id);
            return Ok(true);
        }
    }
}