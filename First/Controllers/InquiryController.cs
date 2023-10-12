using First_Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using First_Utility;
using First_DataAccess;
using First_DataAccess.Repository.IRepository;
using First_Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace First.Controllers
{
	[Authorize(Roles=WC.AdminRole)]
	public class InquiryController : Controller
	{
		private readonly IInquiryDetailRepository _inqDRepo;
		private readonly IInquiryHeaderRepository _inqHRepo;
		public static int personId;
		private readonly ApplicationDbContext _db;
		[BindProperty]
		public InquiryVM InquiryVM { get; set; }

		public InquiryController(IInquiryDetailRepository inqDRepo, IInquiryHeaderRepository inqHRepo, ApplicationDbContext db)
		{
			_inqDRepo = inqDRepo;
			_inqHRepo = inqHRepo;
			_db = db;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details(int id)
		{

			InquiryVM = new InquiryVM()
			{
				InquiryHeader = _inqHRepo.FirstOrDefault(x => x.Id == id),
				InquiryDetail = _inqDRepo.GetAll(u => u.InquiryHeaderId == id, includeProperties: "Product")
			};
			personId = id;
			return View(InquiryVM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Details()
		{
			List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
			InquiryVM.InquiryDetail = _inqDRepo.GetAll(u => u.InquiryHeaderId == personId);
		
			foreach (var detail in InquiryVM.InquiryDetail)
			{
				ShoppingCart shoppingCart = new ShoppingCart()
				{
					ProductId = detail.ProductId,
				};
				shoppingCartList.Add(shoppingCart);
			}

			HttpContext.Session.Clear();
			HttpContext.Session.Set(WC.SessionCart, shoppingCartList);
			HttpContext.Session.Set(WC.SessionInquiryId, personId);
            TempData[WC.Success] = "Başarıyla Sepete Eklendi";
            return RedirectToAction("Index", "Cart");
		}

		[HttpPost]
		public IActionResult Delete()
		{
			InquiryHeader inquiryHeader = _inqHRepo.FirstOrDefault(u => u.Id == personId);
			IEnumerable<InquiryDetail> inquiryDetails = _inqDRepo.GetAll(u => u.InquiryHeaderId == personId);

			_inqDRepo.RemoveRange(inquiryDetails);
			_inqHRepo.Remove(inquiryHeader);
            TempData[WC.Success] = "Sorgu Başarıyla Silindi";
            _inqHRepo.Save();


			return RedirectToAction("Index");
		}
		#region API CALLS
		[HttpGet]
		public IActionResult GetInquiryList()
		{
			return Json(new { data = _inqHRepo.GetAll() });
		}

		#endregion
	}
}
