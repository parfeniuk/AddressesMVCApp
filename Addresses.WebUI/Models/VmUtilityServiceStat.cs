using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Addresses.Repository;
using Addresses.DAL;
using Addresses.BOL;

namespace Addresses.WebUI.Models
{
    public class VmUtilityServiceStat
    {
        IGenericRepository<Address, AddressDTO> addressRepository;
        public VmUtilityServiceStat(IGenericRepository<Address, AddressDTO> addressRepository, int id)
        {
            this.addressRepository = addressRepository;
            UtilityServiceId = id;
        }
        public int UtilityServiceId { get; set; }
        public int StreetsNumber
        {
            get
            {
                return addressRepository
                    .GetAll(a => a.SubdivisionId == UtilityServiceId)
                    .Select(s =>  s.StreetId)
                    .Distinct()
                    .Count();
            }
        }
        public int HousesNumber
        {
            get
            {
                return addressRepository
                    .GetAll(a => a.SubdivisionId == UtilityServiceId)
                    .Select(s => s.House)
                    .Distinct()
                    .Count();
            }
        }
        public int EntrancesNumber
        {
            get
            {
                return addressRepository
                    .GetAll(a => a.SubdivisionId == UtilityServiceId)
                    .Select(s => s.СountEntrance)
                    .Where(s=>s.HasValue)
                    .Count();
            }
        }
        public int FloorsNumber
        {
            get
            {
                return addressRepository
                    .GetAll(a => a.SubdivisionId == UtilityServiceId)
                    .Select(s => s.СountFloor)
                    .Where(s=>s.HasValue)
                    .Count();
            }
        }
    }
}