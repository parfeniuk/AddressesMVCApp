using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Addresses.Repository;
using Addresses.DAL;
using Addresses.BOL;

namespace Addresses.WebUI.Controllers
{
    public class SubdivisionController : Controller
    {
        IGenericRepository<Subdivision, SubdivisionDTO> repositorySubdivision;

        public SubdivisionController(IGenericRepository<Subdivision, SubdivisionDTO> repositorySubdivision)
        {
            this.repositorySubdivision = repositorySubdivision;
        }
        // GET: Subdivision
        public ActionResult Index()
        {
            IQueryable<SubdivisionDTO> subdivisions = repositorySubdivision.GetAll();
            return View(subdivisions);
        }
        public ActionResult Edit(int id)
        {
            SubdivisionDTO subdivision = repositorySubdivision.GetOne(s => s.SubdivisionId == id);
            return View(subdivision);
        }
        [HttpPost]
        public ActionResult Edit(SubdivisionDTO subdivision)
        {
            if (ModelState.IsValid)
            {
                // Update DB here
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            SubdivisionDTO subdivision = repositorySubdivision.GetOne(s => s.SubdivisionId == id);
            return View(subdivision);
        }

        [HttpPost]
        public ActionResult Delete(SubdivisionDTO subdivision)
        {
            // Update DB here
            return RedirectToAction("Index");
        }
    }
}