using Ode.Core;
using System.Collections.Generic;

namespace Ode.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name="John's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant {Id=2, Name="Cinnamoin", Location="Washington", Cuisine=CuisineType.Indian},
                new Restaurant {Id=3, Name="La Costa", Location="Texas", Cuisine=CuisineType.Mexican},
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                orderby r.Name
                select r;
        }
    }
}