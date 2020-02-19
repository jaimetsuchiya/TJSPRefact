using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGDAU.Common
{
    public class JwtData
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public int? GroupID { get; set; }
        public int? CategoryID { get; set; }
        public int? RegionID { get; set; }
        public int? BusinessUnitID { get; set; }
        public int? PrinterID { get; set; }
        public decimal? AllocatedVaraID { get; set; }
        public string ClientID { get; set; }
        public string Hash { get; set; }
    }
}
