using Microsoft.AspNetCore.Mvc;
using test_project_products_category_csharp.ModelFunctions;

namespace test_project_products_category_csharp.Controllers
{
    public class IndexController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.CategoryUsing = CategoryFunctions.GetCategoryUsing();
            return View("~/Views/Index.cshtml", ProductFunctions.GetProductsCategory());
        }
    }
}
