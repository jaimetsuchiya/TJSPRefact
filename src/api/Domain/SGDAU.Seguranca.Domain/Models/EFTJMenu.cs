using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Seguranca.Domain.Models
{
    public class EFTJMenu
    {
		public int	EFMenuID	{ get; set; }
		public int? EFMenuID2	{ get; set; }
		public string Description { get; set; }
		public string URL { get; set; }
		public bool Internal { get; set; }
		public int TabOrder { get; set; }
	}
}
