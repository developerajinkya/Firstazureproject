using Firstazureproject.Models;
using Firstazureproject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Firstazureproject.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;



        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();

        }
    }
}