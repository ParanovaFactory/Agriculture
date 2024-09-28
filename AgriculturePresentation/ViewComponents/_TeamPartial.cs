using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _TeamPartial : ViewComponent
	{
		private readonly ITeamService _service;

		public _TeamPartial(ITeamService service)
		{
			_service = service;
		}

		public IViewComponentResult Invoke()
		{
			var values = _service.GetListAll();
			return View(values);
		}
	}
}
