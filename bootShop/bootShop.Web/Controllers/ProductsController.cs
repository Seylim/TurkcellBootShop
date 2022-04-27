using bootShop.Business;
using bootShop.Dtos.Requests;
using bootShop.Dtos.Responses;
using bootShop.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootShop.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class ProductsController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> selectedItems = GetCategoriesForDropDown();

            ViewBag.Categories = selectedItems;
            return View();
        }

        private List<SelectListItem> GetCategoriesForDropDown()
        {
            var selectedItems = new List<SelectListItem>();

            categoryService.GetCategories().ToList().ForEach(cat => selectedItems.Add(new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }));
            return selectedItems;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                int addedProductId = await productService.AddProduct(request);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // TODO 1: Update ve Delete işlemleri yazılacak.
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await productService.IsExist(id))
            {
                ProductListResponse response = await productService.GetProductById(id);
                ViewBag.Categories = GetCategoriesForDropDown();
                return View(response);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                int affectedRowsCount = await productService.UpdateProduct(request);
                if (affectedRowsCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return BadRequest();
            }
            ViewBag.Categories = GetCategoriesForDropDown();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.IsExist(id))
            {
                var product = await productService.GetProductById(id);
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteOk(int id)
        {
            await productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
        // TODO 2: Authentication ve Authorization ele alınacak.
        // TODO 3: Sepet işlemleri üzerinden Session ele alınacak.
    }
}
