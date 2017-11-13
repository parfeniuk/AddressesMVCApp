using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Addresses.DAL;
using Addresses.BOL;

namespace Addresses.Repository
{
    public class StreetRepository : GenericRepository<Street, StreetDTO, DbContext>
    {
        public StreetRepository(DbContext context) : base(context)
        {
        }
    }
}
