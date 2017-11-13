using Addresses.BOL;
using Addresses.DAL;
using Addresses.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Addresses.WebUI.Models;

namespace Addresses.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IGenericRepository<Subdivision, SubdivisionDTO> repositorySubdivision;
        IGenericRepository<Address, AddressDTO> repositoryAddress;

        public HomeController(IGenericRepository<Subdivision, SubdivisionDTO> repositorySubdivision,
            IGenericRepository<Address, AddressDTO> repositoryAddress)
        {
            this.repositorySubdivision = repositorySubdivision;
            this.repositoryAddress = repositoryAddress;
        }
        // GET: Subdivision
        public ActionResult Index()
        {
            IQueryable<SubdivisionDTO> subdivisions = repositorySubdivision.GetAll();
            return View(subdivisions);
        }

        public ActionResult SubdivisionStat(int id=1)
        {
            ViewBag.SubdivisionName = repositorySubdivision
                .GetOne(i => i.SubdivisionId == id)
                .SubdivisionName;
            VmUtilityServiceStat subdivisionStat = 
                new VmUtilityServiceStat(repositoryAddress,id);
            return PartialView(subdivisionStat);
        }
    }
}