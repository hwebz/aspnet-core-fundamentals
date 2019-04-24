using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            RestaurantData = restaurantData;
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
        }

        public IRestaurantData RestaurantData { get; }

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue) Restaurant = RestaurantData.GetById(restaurantId.Value);
            else Restaurant = new Restaurant();
            if (Restaurant == null)
            {
                return RedirectToPage("../Shared/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (Restaurant.Id > 0)
            {
                TempData["Message"] = "Restaurant updated!";
                Restaurant = RestaurantData.Update(Restaurant);
            } else
            {
                TempData["Message"] = "Restaurant added!";
                Restaurant = RestaurantData.Add(Restaurant);
            }
            
            RestaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}