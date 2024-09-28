using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _TopAddressPartial : ViewComponent
	{
		private readonly IAddressService _address;

		public _TopAddressPartial(IAddressService address)
		{
			_address = address;
		}

		public IViewComponentResult Invoke()
		{
			var values = _address.GetListAll();
			return View(values);
		}
	}
}
