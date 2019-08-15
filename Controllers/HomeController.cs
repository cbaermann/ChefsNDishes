using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            ChefsView viewModel = new ChefsView();
            viewModel.Chefs = dbContext.Chefs
                .Include(d=>d.CreatedDishes)
                .ToList();
            return View("Index", viewModel);
        }
        [HttpGet("NewChef")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("AddChef")]
        public IActionResult AddChef(NewChefView modelView)
        {
            if(ModelState.IsValid)
            {
                Chef newChef = modelView.newChef;
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NewChef");
            }
        }
       
        [HttpGet("Dishes")]
        public IActionResult Dishes ()
        {
            DishesView viewModel = new DishesView();
            viewModel.Dishes = dbContext.Dishes
                .Include(d=>d.Creator)
                .ToList();
            return View("Dishes", viewModel);
        }

       

        [HttpGet("NewDish")]
        public IActionResult NewDish()
        {
            NewDishView viewModel = new NewDishView();
            viewModel.Chefs = dbContext.Chefs.ToList();
            return View("NewDish", viewModel);
        }

        [HttpPost("AddDish")]
        public IActionResult AddDish(NewDishView modelView)
        {
            if(ModelState.IsValid)
            {
                Dish newDish = modelView.newDish;

                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return RedirectToAction("NewDish");
            }
        }
  
    }
}
