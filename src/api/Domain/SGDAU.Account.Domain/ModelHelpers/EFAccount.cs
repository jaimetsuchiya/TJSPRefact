using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Account.Domain.Models
{
    public partial class EFAccount
    {
		public string ParamID_EFAccountID { get; set; }

		public decimal ComarcaID { get; set; }

		public int? EFRegiaoID { get; set; }

		public int RotaID { get; set; }

		public int ComarcaAlocacao { get; set; }

		public int Categoria { get; set; }

		public int MaloteTipoID { get; set; }

		public int EFUserID { get; set; }

		public bool SomenteAtiva { get; set; } = true;
	}
}
