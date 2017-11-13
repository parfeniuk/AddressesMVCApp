using Addresses.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Addresses.WebUI.Models
{
    public class VmListAddresses
    {
        public PagingInfo Paging { get; set; }
        public int SubdivisionId { get; set; }

        IQueryable<AddressDTO> m_addresses;

        public IQueryable<AddressDTO> Addresses
        {
            get
            {
                return m_addresses;
            }
            set
            {
                m_addresses = value;
                Paging.TotalItems = (m_addresses == null) ? 0 : m_addresses.Count();
            }
        }

        public IEnumerable<AddressDTO> CounterByPage
        {
            get
            {
                return Addresses
                    .OrderBy(c => c.StreetName)
                    .Skip((Paging.CurrentPage - 1) * Paging.ItemsPerPage)
                    .Take(Paging.ItemsPerPage);
            }
        }

        public Expression<Func<AddressDTO, bool>> predicate
        {
            get
            {
                return c => c.SubdivisionId == SubdivisionId;
            }
        }

        public VmListAddresses()
        {
            Paging = new PagingInfo() { CurrentPage = 1, ItemsPerPage = 10 };
        }
    }
}