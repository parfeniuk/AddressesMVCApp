using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Addresses.WebUI.Models;
using Addresses.Repository;
using Addresses.DAL;
using Addresses.BOL;

namespace Addresses.WebUI.Controllers
{
    public class AddressController : Controller
    {
        IGenericRepository<Subdivision, SubdivisionDTO> repositorySubdivision;
        IGenericRepository<Address, AddressDTO> repositoryAddress;

        public AddressController(IGenericRepository<Subdivision, SubdivisionDTO> repositorySubdivision,
            IGenericRepository<Address, AddressDTO> repositoryAddress)
        {
            this.repositorySubdivision = repositorySubdivision;
            this.repositoryAddress = repositoryAddress;
        }
        // GET: Address
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Subdivisions()
        {
            VmSubdivisions model = new VmSubdivisions(repositorySubdivision);
            return View(model);
        }

        public ActionResult ListAddresses(int id, int CurrentPage = 1)
        {
            var addresses = new VmListAddresses()
            {
                SubdivisionId = id,
            };
            addresses.Paging.CurrentPage = CurrentPage;
            addresses.Addresses = repositoryAddress.GetAll(addresses.predicate);
            return PartialView(addresses);
        }

        public ActionResult Edit(int id)
        {
            AddressDTO address = repositoryAddress.GetOne(s => s.AddressId == id);
            return View(address);
        }
        [HttpPost]
        public ActionResult Edit(AddressDTO address)
        {
            if (ModelState.IsValid)
            {
                // Update DB here
            }
            return RedirectToAction("Subdivisions");
        }
        public ActionResult Details(int id)
        {
            AddressDTO address = repositoryAddress.GetOne(s => s.AddressId == id);
            return View(address);
        }
    }
}