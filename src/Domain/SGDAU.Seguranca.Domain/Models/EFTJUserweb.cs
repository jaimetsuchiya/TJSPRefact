using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Seguranca.Domain.Models
{
    public partial class EFTJUserweb
    {
        public int EFUserID { get; set; }

        public string Login { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Matricula { get; set; }

        public int Categoria { get; set; }

        public int Ocupacao { get; set; }

        public int ComarcaAlocacao { get; set; }

        public decimal VaraAlocacao { get; set; }

        public string Token { get; set; }

        public int Ativo { get; set; }

        public DateTime? StatusDTime { get; set; }

        public DateTime CreateDTime { get; set; }

        public string CreateUserCode { get; set; }

        public DateTime? UpdtDTime { get; set; }

        public int? EFGrupoID { get; set; }

        public int? EFRegiaoID { get; set; }

        public string UpdtUserCode { get; set; }

        public DateTime? DataUltimoAcesso { get; set; }

        public bool AlterarSenha { get; set; }

        public DateTime? DataAlteracaoSenha { get; set; }

        public string Observacao { get; set; }

        public string PassWord { get; set; }

        public string pwdKey { get; set; }

        public int? EFTJUnidadeID { get; set; }

        public int? EFTJImpressoraID { get; set; }
       
    }
}
