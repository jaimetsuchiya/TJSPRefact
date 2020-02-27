using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Desarquivamento.Domain.Models
{
    public partial class EFTJPoloAdvogado
    {
        public EFTJAdvogado Advogado { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }
    }
}
