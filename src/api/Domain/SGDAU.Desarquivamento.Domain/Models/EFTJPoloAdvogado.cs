using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Desarquivamento.Domain.Models
{
    public partial class EFTJPoloAdvogado
    {
        public int EFTJPoloID { get; set; }
        public int? EFTJAdvogadoID { get; set; }


        public bool? NaoHaInformacao { get; set; }
        public DateTime NaoHaInformacaoDTime { get; set; }
        public string NaoHaInformacaoUserCode { get; set; }

        public DateTime CreateDTime { get; set; }
        public string CreateUserCode { get; set; }
        public DateTime UpdtDTime { get; set; }
        public string UpdtUserCode { get; set; }
    }
}
