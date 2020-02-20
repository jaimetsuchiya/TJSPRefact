using Microsoft.Extensions.Configuration;
using SGDAU.Repository.Infrastructure;
using SGDAU.Seguranca.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SGDAU.Seguranca.Domain
{
    public interface ISegurancaRepository
    {
        EFTJUserweb ConsultaUsuario(EFTJUserweb userWeb);
        EFTJUserweb Login(EFTJUserweb userWeb);
        ICollection<EFTJMenu> GetUserAccess(EFTJUserweb userWeb);
    }

    public class SegurancaRepository : ISegurancaRepository
    {
        private readonly IDatabaseQueryCommand databaseQueryCommand;
        public SegurancaRepository(IDatabaseQueryCommand databaseQueryCommand)
        {
            this.databaseQueryCommand = databaseQueryCommand;
        }

        public string Procedure
        {
            get { return "usuario_sgdai"; }
        }

        public EFTJUserweb ConsultaUsuario(EFTJUserweb userWeb)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 1));
            parameters.Add(new SqlParameter("@veParametro", 2));
            parameters.Add(new SqlParameter("@veCPF", userWeb.CPF));
            parameters.Add(new SqlParameter("@veEmail", userWeb.Email));
            parameters.Add(new SqlParameter("@veEFUserID", userWeb.EFUserID));
            parameters.Add(new SqlParameter("@veLogin", userWeb.Login));
            parameters.Add(new SqlParameter("@veToken", userWeb.Token));

            return this.databaseQueryCommand.GetEntity<EFTJUserweb>(Procedure, parameters);
        }

        public EFTJUserweb Login(EFTJUserweb userWeb)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 2));
            parameters.Add(new SqlParameter("@veParametro", 7));
            parameters.Add(new SqlParameter("@veLogin", userWeb.Login));
            parameters.Add(new SqlParameter("@vePassWord", userWeb.PassWord));

            return this.databaseQueryCommand.GetEntity<EFTJUserweb>(Procedure, parameters);
        }

        public ICollection<EFTJMenu> GetUserAccess(EFTJUserweb userWeb)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veCreateUserCode", userWeb.Login));
            return this.databaseQueryCommand.Select<EFTJMenu>("menu2_sgdai", parameters);
        }
    }
}
