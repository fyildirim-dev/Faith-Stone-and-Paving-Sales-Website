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

namespace First.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ApplicationTypeController : Controller
    {
        private readonly IApplicationTypeRepository _appRepo;
        public ApplicationTypeController(IApplicationTypeRepository appRepo) {
            _appRepo = appRepo;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _appRepo.GetAll();
            return View(objList);
        }

        //GET - CREATE
		public IActionResult Create()
		{
			return View();
		}

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _appRepo.Add(obj);
                _appRepo.Save();
                TempData[WC.Success] = "Ürün Türü Başarıyla Eklendi";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _appRepo.Find(id.GetValueOrDefault());
            if (obj == null) return NotFound();

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _appRepo.Update(obj);
                _appRepo.Save();
                TempData[WC.Success] = "Ürün Türü Başarıyla Güncellendi";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _appRepo.Find(id.GetValueOrDefault());
            if (obj == null) return NotFound();

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _appRepo.Find(id.GetValueOrDefault());
            if (obj == null) return NotFound();
            _appRepo.Remove(obj);
            _appRepo.Save();
            TempData[WC.Success] = "Ürün Türü Başarıyla Silindi";
            return RedirectToAction("Index");
        }
    }
}
