using SGDAU.Account.Domain.Models;
using SGDAU.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SGDAU.Account.Domain
{
    public interface IAccountRepository
    {
        ICollection<EFAccount> GetAllComarca(bool? somenteAtiva = null);
        ICollection<EFAccount> GetComarcaRegiao(EFAccount efAccount);
        ICollection<EFAccount> GetComararcaAlocacao(EFAccount efAccount);

        ICollection<EFAccount> GetVaraComarca(EFAccount efAccount);
        ICollection<EFAccount> GetVaraUsuario(EFAccount efAccount);
    }

    public class AccountRepository
    {
        private readonly IDatabaseQueryCommand databaseQueryCommand;

        public AccountRepository(IDatabaseQueryCommand databaseQueryCommand)
        {
            this.databaseQueryCommand = databaseQueryCommand;
        }

        public string Procedure
        {
            get { return "account_sgdai"; }
        }

        public ICollection<EFAccount> GetComarcaRegiao(EFAccount efAccount)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 1));
            parameters.Add(new SqlParameter("@veParametro", 4));
            parameters.Add(new SqlParameter("@veEFRegiaoID", efAccount.EFRegiaoID));
            parameters.Add(new SqlParameter("@veSomenteAtiva", efAccount.SomenteAtiva));

            return this.databaseQueryCommand.Select<EFAccount>(Procedure, parameters);

        }


        public ICollection<EFAccount> GetComararcaAlocacao(EFAccount efAccount)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 1));
            parameters.Add(new SqlParameter("@veParametro", 5));
            parameters.Add(new SqlParameter("@veComarcaAlocacaoID", efAccount.ComarcaAlocacao));
            parameters.Add(new SqlParameter("@veSomenteAtiva", efAccount.SomenteAtiva));

            return this.databaseQueryCommand.Select<EFAccount>(Procedure, parameters);

        }

        public ICollection<EFAccount> GetAllComarca(bool? somenteAtiva = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 1));
            parameters.Add(new SqlParameter("@veParametro", 3));
            parameters.Add(new SqlParameter("@veSomenteAtiva", somenteAtiva.HasValue ? somenteAtiva.Value : false));

            return this.databaseQueryCommand.Select<EFAccount>(Procedure, parameters);
        }

        public ICollection<EFAccount> GetVaraComarca(EFAccount efAccount)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 1));
            parameters.Add(new SqlParameter("@veParametro", 1));
            parameters.Add(new SqlParameter("@veComarcaID", efAccount.EFAccountID3));

            return this.databaseQueryCommand.Select<EFAccount>(Procedure, parameters);
        }
        public ICollection<EFAccount> GetVaraUsuario(EFAccount efAccount)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 1));
            parameters.Add(new SqlParameter("@veParametro", 7));
            parameters.Add(new SqlParameter("@veEFUserID", efAccount.EFUserID));

            return this.databaseQueryCommand.Select<EFAccount>(Procedure, parameters);

        }
    }
}
