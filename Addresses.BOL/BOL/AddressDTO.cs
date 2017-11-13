using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addresses.BOL
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public int StreetId { get; set; }
        public int SubdivisionId { get; set; }
        public string House { get; set; }
        public string Serial { get; set; }
        public int? СountFloor { get; set; }
        public int? СountEntrance { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string StreetName { get; set; }
    }
}
