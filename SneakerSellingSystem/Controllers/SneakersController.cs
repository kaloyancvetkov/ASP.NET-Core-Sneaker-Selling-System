using Microsoft.AspNetCore.Mvc;
using SneakerSellingSystem.Data;
using SneakerSellingSystem.Models.Sneakers;

namespace SneakerSellingSystem.Controllers
{
    public class SneakersController : Controller
    {
        private SneakerSellingSystemDbContext data;

        public SneakersController(SneakerSellingSystemDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View(new AddSneakerFormModel
        {
            Categories = this.GetCategories()
        });

        [HttpPost]
        public IActionResult Add(AddSneakerFormModel sneaker)
        {
            if (sneaker.Categories == null)
            {
                sneaker.Categories = this.GetCategories();
            }

            if (!ModelState.IsValid)
            {
                return View(sneaker);
            }

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<SneakerCategoryViewModel> GetCategories()
            => this.data
            .Categories
            .Select(c => new SneakerCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
    }
}
