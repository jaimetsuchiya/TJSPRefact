using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Seguranca.Domain.Models
{
    public partial class EFTJUserWeb
    {
        public EFTJUserWeb()
        {
            Varas = new List<decimal>();
            Acessos = new List<int>();
        }

        public int AcessoIndividual { get; set; }

        public string AcessoIndividualDES { get; set; }

        public string CategoriaDes { get; set; }

        public string OcupacaoDes { get; set; }

        public string ComarcaAlocacaoDes { get; set; }

        public string VaraAlocacaoDes { get; set; }

        public string AtivoDes { get; set; }

        public string Description { get; set; }

        public string AcessoAcervo { get; set; }

        public List<decimal> Varas { get; set; }

        public List<int> Acessos { get; set; }

        public string VarasXml { get; set; }

        public string AcessosXml { get; set; }

        public bool Ativar { get; set; }

        public int EFAccessID { get; set; }

        public decimal AccountID { get; set; }

        public int EFMenuID { get; set; }

        public string UsuarioClonado { get; set; }

        public string UsuarioModelo { get; set; }

        public string QueryString { get; set; }

        public string PassWordAnterior { get; set; }

        public int UserIDRequest { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public EFTJUserweb UsuarioVigencia { get; set; }

        public string AlterarSenhaDesc { get; set; }

        public string UserCodeFullName { get; set; }

        public string UnidadeDescricao { get; set; }

        public bool AcessoArquivamento { get; set; }

        public bool AcessoDesarquivamento { get; set; }

        public bool AcessoCatalogacao { get; set; }

        public string UsuarioColeta { get; set; }
    }
}
