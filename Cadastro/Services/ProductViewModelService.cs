using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using System.Collections.Generic;

namespace Cadastro.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductViewModelService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public ProductViewModel GetProductWithClient(int id)
        {
            var entity = _productRepository.GetProductWithClient(id);
            if (entity == null)
                return null;

            var viewModel = new ProductViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Value = entity.Value,
                Active = entity.Active,
                ClientName = $"{entity.Client.Name} {entity.Client.LastName}"
            };

            return viewModel;
        }

        public IEnumerable<ProductViewModel> GetProductsWithClient()
        {
            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();
            var productList = _productRepository.GetProductsWithClient();
            if (productList == null)
                return productViewModelList;

            foreach(var product in productList)
            {
                productViewModelList.Add(new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Value = product.Value,
                    Active = product.Active,
                    ClientName = $"{product.Client.Name} {product.Client.LastName}"
                });
            }

            return productViewModelList;
        }

        public void Insert(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Insert(entity);
        }

        public void Update(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Update(entity);
        }
    }
}
