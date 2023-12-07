﻿using APPDATA.Models;
using APPVIEW.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace APPVIEW.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class MaterialController : Controller
    {
        private Getapi<Material> getapi;
        public MaterialController()
        {
            getapi = new Getapi<Material>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Material");
            return View(obj);
        }
        public async Task<IActionResult> Search(string searchTerm)
        {
            var lstMaterial = getapi.GetApi("Material").ToList();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View("GetList", lstMaterial);
            }
            var searchResult = lstMaterial
                .Where(v =>
                    v.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    v.Status.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            if (searchResult.Any())
            {
                return View("GetList", searchResult);
            }

            return NotFound("Material không tồn tại");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Material obj)
        {
            try
            {
                getapi.CreateObj(obj, "Material");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]


        public async Task<IActionResult> Edit(Guid id)
        {

            var lst = getapi.GetApi("Material");
            return View(lst.Find(c => c.Id == id));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Material obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Material");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            getapi.DeleteObj(id, "Material");
            return RedirectToAction("GetList");

        }
    }
}
