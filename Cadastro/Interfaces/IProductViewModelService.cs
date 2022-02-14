using Cadastro.ViewModels;
using System.Collections.Generic;

namespace Cadastro.Interfaces
{
    public interface IProductViewModelService
    {
        ProductViewModel GetProductWithClient(int id);
        IEnumerable<ProductViewModel> GetProductsWithClient();
        void Insert(ProductViewModel viewModel);
        void Update(ProductViewModel viewModel);
        void Delete(int id);
    }
}
