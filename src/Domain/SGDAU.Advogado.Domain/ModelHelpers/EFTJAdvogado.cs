using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGDAU.Advogado.Domain.Models
{
    public partial class EFTJAdvogado
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }

        public int PageStart { get; set; }
        public int PageFinish { get; set; }
        public int? AdvogadoAtivo { get; set; }
        public int EFTJPoloID { get; set; }

        public string Operacao { get; set; }
        public bool NaoHaInformacao { get; set; }
        public int QuantidadeRegistrosPorPagina { get; set; }
        public int QuantidadeTotalRegistros { get; set; }
        public int pagina { get; set; }
        public int TotalPaginas { get; set; }
        public List<EFTJAdvogado> OrigemList { get; set; }
        public List<EFTJAdvogado> Historico { get; set; }
        public string Situacao { get; set; }
    }
}
