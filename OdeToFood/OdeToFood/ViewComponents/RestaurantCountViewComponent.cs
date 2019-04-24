using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IRestaurantData RestaurantData { get; }

        public IViewComponentResult Invoke()
        {
            var count = RestaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
