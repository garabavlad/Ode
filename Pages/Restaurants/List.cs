using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Ode.Data;
using Ode.Core;

namespace ode.Pages.Restaurants
{
    public class RestaurantsListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Search { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public RestaurantsListModel(IConfiguration config, 
                                    IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
            this.config = config;
        }
        public void OnGet(string search)
        {
            Search = search;
            Restaurants = restaurantData.GetRestaurantsByName(search);
        }
    }
}
