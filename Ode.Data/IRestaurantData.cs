using Ode.Core;
using System.Collections.Generic;
using System.Linq;

namespace Ode.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string Name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name="John's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant {Id=2, Name="Cinnamoin", Location="Washington", Cuisine=CuisineType.Indian},
                new Restaurant {Id=3, Name="La Costa", Location="Texas", Cuisine=CuisineType.Mexican},
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string Name = null)
        {
            return from r in restaurants
                where string.IsNullOrEmpty(Name) 
                || r.Name.ToLower().Contains(Name.ToLower())
                || r.Location.ToLower().Contains(Name.ToLower())
                orderby r.Name
                select r;
        }
    }
}