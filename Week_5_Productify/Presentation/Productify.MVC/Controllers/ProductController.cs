using Microsoft.AspNetCore.Mvc;
using Productify.Domain.Entities;
using Productify.Persistence.Contexts;

namespace Productify.MVC.Controllers
{
    public class ProductController : Controller
    {

        ProductifyDbContext _context;

        public ProductController()
        {
            _context = new();   
        }


        public IActionResult GetAll()
        {
            return View(_context.Products.ToList());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(string productName)
        {
            _context.Products.Add(new(productName));

            _context.SaveChanges();

            return View();
        }







    }


    
        










}
