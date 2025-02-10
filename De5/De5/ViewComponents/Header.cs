
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace De5.ViewComponents
{
	public class Header: ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Header");
		}
	}
}
