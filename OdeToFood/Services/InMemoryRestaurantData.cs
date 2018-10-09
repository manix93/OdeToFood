using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
	public class InMemoryRestaurantData  : IRestaurantData
	{
		private List<Restaurant> _restaurants;

		public InMemoryRestaurantData()
		{
			_restaurants = new List<Restaurant>
			{
				new Restaurant{Id = 1, Name = "Hawaii Pizza"},
				new Restaurant{Id = 2, Name = "BBQ Burger"},
				new Restaurant{Id = 3, Name = "Chicken Fingers"}
			};
		}

		public IEnumerable<Restaurant> GetAll()
		{
			return _restaurants.OrderBy(r => r.Name);
		}
	}
}
