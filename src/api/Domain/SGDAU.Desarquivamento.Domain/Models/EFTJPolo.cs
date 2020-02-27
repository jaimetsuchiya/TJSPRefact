using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Desarquivamento.Domain.Models
{
    public partial class EFTJPolo
    {
        public int EFTJPoloID { get; set; }
        public string Nome { get; set; }
        public int EFTJPoloTipoID { get; set; }

        public string ItemCode { get; set; }
        public int ItemSeq { get; set; }
        public int? EFTJPoloTipoDocumentoID { get; set; }
        public string Documento { get; set; }
        public string TipoDocumento { get; set; }

        public bool? NaoHaInformacao { get; set; }
        public DateTime NaoHaInformacaoDTime { get; set; }
        public string NaoHaInformacaoUserCode { get; set; }

        public DateTime CreateDTime { get; set; }
        public string CreateUserCode { get; set; }
        public DateTime UpdtDTime { get; set; }
        public string UpdtUserCode { get; set; }

    }
}
