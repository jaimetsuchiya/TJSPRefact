using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Unidade.Domain.Models
{
    public partial class EFTJPredio
    {
        public int EFTJUnidadePredioID { get; set; }
        public int EFTJUnidadeID { get; set; }
        public string Unidade { get; set; }
        public string Descricao { get; set; }
        public string CodigoSKP { get; set; }
        public DateTime CreateDTime { get; set; }
        public string CreateUserCode { get; set; }
        public DateTime UpdtDTime { get; set; }
        public string UpdtUserCode { get; set; }
    }

}
