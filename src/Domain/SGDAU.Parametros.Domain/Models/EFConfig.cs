using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Parametros.Domain.Models
{
    public partial class EFConfig
    {
		public int EFConfigID { get; set; }
		public Nullable<decimal> EFAccountID { get; set; }
		public string Description { get; set; }
		public string Value { get; set; }
		public string Active { get; set; }
		public DateTime CreateDTime { get; set; }
		public string UpdtUserCode { get; set; }
		public Nullable<DateTime> UpdtDTime { get; set; }
		public string Detail { get; set; }

	}
}
