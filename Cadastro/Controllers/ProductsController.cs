using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Cadastro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductViewModelService _productViewModelService;
        private readonly IClientViewModelService _clientViewModelService;

        public ProductsController(IProductViewModelService productViewModelService, IClientViewModelService clientViewModelService)
        {
            _productViewModelService = productViewModelService;
            _clientViewModelService = clientViewModelService;
        }

        // GET: Products
        public ActionResult Index()
        {
            var viewModel = _productViewModelService.GetProductsWithClient();
            return View(viewModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _productViewModelService.GetProductWithClient(id);
            return View(viewModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel()
            {
                Clients = _clientViewModelService.GetClientsName().Select(a => new SelectListItem()
                {
                    Value = a.Item1.ToString(),
                    Text = a.Item2
                })
            };

            return View(viewModel);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _productViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = _productViewModelService.GetProductWithClient(id);
            viewModel.Clients = _clientViewModelService.GetClientsName().Select(a => new SelectListItem()
            {
                Value = a.Item1.ToString(),
                Text = a.Item2
            });

            return View(viewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.GetProductWithClient(id);
            return View(viewModel);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _productViewModelService.GetProductWithClient(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _productViewModelService.GetProductWithClient(id);
                return View(viewModel);
            }
        }
    }
}
