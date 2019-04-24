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
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        public IRestaurantData RestaurantData { get; }
        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = RestaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("../Shared/NotFound");
            }
            return Page();
        }
    }
}