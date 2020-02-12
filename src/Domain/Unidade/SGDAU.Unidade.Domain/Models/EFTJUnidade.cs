using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Unidade.Domain.Models
{
    public partial class EFTJUnidade
    {
        public int EFTJUnidadeID { get; set; }

        public string Description { get; set; }

        public DateTime CreateDTime { get; set; }

        public string CreateUserCode { get; set; }

        public DateTime UpdtDTime { get; set; }

        public string UpdtUserCode { get; set; }

        public bool Arquivamento { get; set; }

        public bool Desarquivamento { get; set; }

        public bool Catalogacao { get; set; }

        public int EFTJUnidadePredioID { get; set; }
        public List<EFTJPredio> prediosList { get; set; }
        public string CodigoRequest { get; set; }
        public string CodigoSKP { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
