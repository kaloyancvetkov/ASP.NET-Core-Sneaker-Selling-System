using Microsoft.AspNetCore.Mvc;
using SneakerSellingSystem.Data;
using SneakerSellingSystem.Data.Models;
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
            if (!this.data.Categories.Any(c => c.Id == sneaker.CategoryId))
            {
                this.ModelState.AddModelError(nameof(sneaker.CategoryId), "Category doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                sneaker.Categories = this.GetCategories();

                return View(sneaker);
            }

            var sneakerData = new Sneaker
            {
                Brand = sneaker.Brand,
                Model = sneaker.Model,
                Color = sneaker.Color,
                Description = sneaker.Description,
                ImageUrl = sneaker.ImageUrl,
                CategoryId = sneaker.CategoryId,
            };

            this.data.Sneakers.Add(sneakerData);
            this.data.SaveChanges();

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
