using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Addresses.DAL;
using Addresses.BOL;
using AutoMapper;

namespace Addresses.Repository
{
    public class AddressRepository : GenericRepository<Address, AddressDTO, DbContext>
    {
        public AddressRepository(DbContext context) : base(context)
        {
        }
        protected override void Map()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Address, AddressDTO>()
            .ForMember("StreetName",opt=>opt.MapFrom(src=>src.Street.StreetName)));
        }
    }
}
