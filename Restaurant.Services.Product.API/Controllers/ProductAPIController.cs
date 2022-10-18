using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.Product.API.Models.DTOs;
using Restaurant.Services.Product.API.Repository;

namespace Restaurant.Services.Product.API.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDTO _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
                _productRepository = productRepository;
                this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ResponseDTO> GetProducts()
        {
            try
            {
                IEnumerable<ProductDTO> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
                _response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() {ex.ToString()};
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDTO> GetProduct(int id)
        {
            try
            {
                ProductDTO productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<ResponseDTO> PostProduct(ProductDTO productDTO)
        {
            try
            {
                var model = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = model;
                _response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() {ex.Message};
            }

            return _response;
        }

        [HttpPut]
        public async Task<ResponseDTO> Update([FromBody] ProductDTO productDTO)
        {
            try
            {
                var model = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = model;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }

            return _response;
        }

        [HttpDelete]
        public async Task<ResponseDTO> Delete(int id)
        {
            try
            {
                var IsSucess = await _productRepository.DeleteProduct(id);
                _response.Result = IsSucess;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() {ex.Message};
            }

            return _response;
        }
    }
}
