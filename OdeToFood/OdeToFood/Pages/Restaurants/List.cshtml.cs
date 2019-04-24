using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IConfiguration Configuration { get; }
        public IRestaurantData RestaurantData { get; }
        public ILogger<ListModel> Logger { get; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            Configuration = configuration;
            RestaurantData = restaurantData;
            Logger = logger;
        }

        public void OnGet()
        {
            Logger.LogError("Executing ListModel");
            Message = Configuration["Message"];
            Restaurants = RestaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}