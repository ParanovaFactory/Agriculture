using BusinessLayer.Abstract;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
	public class _AboutPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext c = new AgricultureContext();
			var values = c.Abouts.ToList();
			return View(values);
		}
	}
}
