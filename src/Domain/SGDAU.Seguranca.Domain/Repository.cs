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

    }

    public class SegurancaRepository : DatabaseQueryCommand, ISegurancaRepository
    {
        public SegurancaRepository(IConfiguration config) : base(config)
        {
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

            return base.GetEntity<EFTJUserweb>(Procedure, parameters);
        }

        public EFTJUserweb Login(EFTJUserweb userWeb)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 2));
            parameters.Add(new SqlParameter("@veParametro", 7));
            parameters.Add(new SqlParameter("@veLogin", userWeb.Login));
            parameters.Add(new SqlParameter("@vePassWord", userWeb.PassWord));

            return base.GetEntity<EFTJUserweb>(Procedure, parameters);
        }

    }
}
