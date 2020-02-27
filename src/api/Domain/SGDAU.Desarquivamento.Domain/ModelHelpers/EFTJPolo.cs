using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Desarquivamento.Domain.Models
{
    public partial class EFTJPolo
    {
        public List<EFTJPoloAdvogado> Advogados { get; set; }
        public string AdvogadosXML { get; set; }
        public string Mascara { get; set; }
        public string DescricaoTipoDocumento { get; set; }
        public string DescricaoPoloTipo { get; set; }
        public int Posicao { get; set; }
        public string Operacao { get; set; }



        public string Codigo { get; set; }
        public string AdvogadoNome { get; set; }

        public bool? AdvogadoNaoHaInformacao { get; set; }
    }
}
