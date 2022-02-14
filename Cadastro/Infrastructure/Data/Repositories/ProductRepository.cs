using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Infrastructure.Data.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        protected readonly RegisterContext _productContext;
        public ProductRepository(RegisterContext dbContext) : base(dbContext) 
        {
            _productContext = dbContext;
        }

        public IEnumerable<Product> GetProductsWithClient()
        {
            return _productContext.Products.Include(a => a.Client);
        }
        public Product GetProductWithClient(int id)
        {
            return _productContext.Products.Include(a => a.Client).FirstOrDefault(a => a.Id == id);
        }
    }
}
