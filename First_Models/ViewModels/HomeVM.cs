using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace First_Models.ViewModels
{
	public class HomeVM
	{
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Category> Categories { get; set; }

	}
}
