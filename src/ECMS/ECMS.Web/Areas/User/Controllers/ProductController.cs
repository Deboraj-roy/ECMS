using Autofac;
using ECMS.Web.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECMS.Web.Areas.User.Controllers
{
    public class ProductController : Controller
    {

        private readonly ILifetimeScope _scope;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILifetimeScope scope,
            ILogger<ProductController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<ProductListModel>();
            var products = await model.GetAllProductAsync();
            if (products != null)
            {
                _logger.LogInformation("ProductController: Index: Products found: {Count}", products.Count);
                return View(products);
            }
            else
            {
                _logger.LogWarning("ProductController: Index: No products found");
                return View();
            }
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<ProductCreateModel>();
            _logger.LogInformation("ProductController: Create: Product create requested");
            return View(model);

        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CreateProductAsync();
                    _logger.LogInformation("ProductController: Create: Product created");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError("ProductController: Create: Error creating product: {Message}", ex.Message);
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }

            }
            return View(model);

        }
        public async Task<IActionResult> Details(int id)
        {
            var model = _scope.Resolve<ProductDetailsModel>();
            var product = await model.GetProductByIdAsync(id);
            if (product != null)
            {
                _logger.LogInformation("ProductController: Details: Product found: {Name}", product.Name);
                return View(product);
            }
            else
            {
                _logger.LogWarning("ProductController: Details: No product found");
                return View("_NotFoundPartial");
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = _scope.Resolve<ProductUpdateModel>();
            model.product = await model.LoadProductAsync(id);
            if (model.product != null)
            {
                _logger.LogInformation("ProductController: Edit: Product found: {Name}", model.product.Name);
                return View(model);
            }
            else
            {
                _logger.LogWarning("ProductController: Edit: No product found");
                return View("_NotFoundPartial");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateModel productUpdate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    productUpdate.Resolve(_scope);
                    await productUpdate.UpdateProductAsync(productUpdate.product);
                    _logger.LogInformation("ProductController: Update: Product updated");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError("ProductController: Update: Error updating product: {Message}", ex.Message);
                    ModelState.AddModelError("", ex.Message);
                    return View(productUpdate);
                }
            }
            else
            {
                _logger.LogWarning("ProductController: Update: No product found");
                return View(productUpdate);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var model = _scope.Resolve<ProductDeleteModel>();

            try
            {
                _logger.LogInformation("ProductController: Delete: Product found: {id}", id);
                await model.DeleteProductAsync(id);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductController: Delete: Error deleting product: {Message}", ex.Message);
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
    }
}
