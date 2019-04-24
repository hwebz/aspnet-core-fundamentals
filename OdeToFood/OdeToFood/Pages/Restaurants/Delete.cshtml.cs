using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IRestaurantData RestaurantData { get; }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = RestaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("../Shared/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = RestaurantData.Delete(restaurantId);
            RestaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("../Shared/NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted!";
            return RedirectToPage("./List");
        }
    }
}