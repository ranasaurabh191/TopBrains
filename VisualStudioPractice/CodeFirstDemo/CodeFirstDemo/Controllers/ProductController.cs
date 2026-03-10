using CodeFirstDemo.Models;
using CodeFirstDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetAll();
            return View(products);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // EDIT (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _repo.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // EDIT (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _repo.Update(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // DELETE (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var product = await _repo.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}