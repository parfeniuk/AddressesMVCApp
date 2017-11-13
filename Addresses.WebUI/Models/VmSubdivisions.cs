using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Addresses.Repository;
using Addresses.DAL;
using Addresses.BOL;
using System.Web.Mvc;

namespace Addresses.WebUI.Models
{
    public class VmSubdivisions
    {
        IGenericRepository<Subdivision,SubdivisionDTO> repositorySubdivision;
        public VmSubdivisions(IGenericRepository<Subdivision, SubdivisionDTO> repositorySubdivision)
        {
            this.repositorySubdivision = repositorySubdivision;
        }

        public SelectList SubdivisionId
        {
            get { return new SelectList(
                repositorySubdivision.GetAll().OrderBy(i=>i.SubdivisionId), 
                "SubdivisionId", "SubdivisionName",
                repositorySubdivision.GetAll().First()); }
        }
    }
}