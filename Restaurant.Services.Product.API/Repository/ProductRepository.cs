using System.Collections;
using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.Product.API.DbContext;
using Restaurant.Services.Product.API.Models.DTOs;

namespace Restaurant.Services.Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
        {
            Models.Product product = _mapper.Map<Models.Product>(productDTO);

            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Models.Product, ProductDTO>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Models.Product product = await _db.Products.FirstOrDefaultAsync(t => t.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            Models.Product product = await _db.Products.Where(t =>t.ProductId==productId).FirstOrDefaultAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            List <Models.Product> productsList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(productsList);
        }
    }
}
