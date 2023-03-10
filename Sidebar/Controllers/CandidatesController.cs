using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sidebar.Data;
using Sidebar.Models;
using Sidebar.Services;

namespace Sidebar.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly CandidateService _service;
        public CandidatesController(CandidateService service)
        {
            _service = service;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int id)
        {
            MyDTO myDTO = await _service.Get(id);
            ViewBag.Message = myDTO.Message;
            if (myDTO.View == "Index")
            {
                return View($"{myDTO.View}", myDTO.Candidates);
            }
            return View($"{myDTO.View}", myDTO.Candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,FirstName,MiddleName,LastName,Gender,NativeLanguage,CountryOfResidence," +
            "Birthdate,Email,LandlineNumber,MobileNumber,Address1,Address2,PostalCode,Town,Province,PhotoIdType,PhotoIdNumber," +
            "PhotoIdDate")] Candidate candidate)
        {
            MyDTO myDTO = await _service.AddOrUpdate(id, candidate);
            ViewBag.Message = myDTO.Message;
            if (myDTO.View == "Index")
            {
                return View($"{myDTO.View}", myDTO.Candidates);
            }
            return View($"{myDTO.View}", myDTO.Candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            MyDTO myDTO = await _service.GetForUpdate(id);
            ViewBag.Message = myDTO.Message;
            if (myDTO.View == "Index")
            {
                return View($"{myDTO.View}", myDTO.Candidates);
            }
            return View($"{myDTO.View}", myDTO.Candidate);
        }

        // POST: Candidates/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Gender,NativeLanguage,CountryOfResidence,Birthdate,Email,LandlineNumber,MobileNumber,Address1,Address2,PostalCode,Town,Province,PhotoIdType,PhotoIdNumber,PhotoIdDate")] Candidate candidate)
        {
            MyDTO myDTO = await _service.AddOrUpdate(id, candidate);
            ViewBag.Message = myDTO.Message;
            if (myDTO.View == "Index")
            {
                return View($"{myDTO.View}", myDTO.Candidates);
            }
            return View($"{myDTO.View}", myDTO.Candidates);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            MyDTO myDTO = await _service.GetForDelete(id);
            ViewBag.Message = myDTO.Message;
            if (myDTO.View == "Index")
            {
                return View($"{myDTO.View}", myDTO.Candidates);
            }
            return View($"{myDTO.View}", myDTO.Candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            MyDTO myDTO = await _service.Delete(id);
            ViewBag.Message = myDTO.Message;
            return View($"{myDTO.View}", myDTO.Candidates);
        }        
    }
}
