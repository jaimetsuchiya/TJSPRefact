using Microsoft.Extensions.Configuration;
using SGDAU.Parametros.Domain.Models;
using SGDAU.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SGDAU.Parametros.Domain
{
    public interface IParametroAplicacaoRepository
    { 
        /// <summary>
      /// Obtem os parâmetros da aplicação de acordo com o filtro aplicado
      /// </summary>
      /// <param name="filtro"></param>
      /// <returns></returns>
        ICollection<EFConfig> GetParametros(EFConfig filtro);

        /// <summary>
        /// Grava Parâmetro
        /// </summary>
        /// <param name="efconfig"></param>
        /// <param name="databaseCommandCommit"></param>
        /// <returns></returns>
        bool GravarParametro(EFConfig efconfig, IDatabaseCommandCommit databaseCommandCommit);

        /// <summary>
        /// Obtem parametro conforme o ID informado
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        EFConfig GetConfig(EFConfig efconfig);
    }


	public class ParametroAplicacaoRepository : IParametroAplicacaoRepository
	{
		private readonly IDatabaseQueryCommand databaseQueryCommand;
		public string Procedure { get { return "parametro_aplicacao_sgdai"; } }

		public ParametroAplicacaoRepository(IDatabaseQueryCommand databaseQueryCommand)
		{
			this.databaseQueryCommand = databaseQueryCommand;
		}

		/// <summary>
		/// Obtem os parâmetros da aplicação de acordo com o filtro aplicado
		/// </summary>
		/// <param name="filtro"></param>
		/// <returns></returns>
		public ICollection<EFConfig> GetParametros(EFConfig filtro)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@veExecutor", 1));
			parameters.Add(new SqlParameter("@veParametro", 1));

			if (!string.IsNullOrEmpty(filtro.Description))
				parameters.Add(new SqlParameter("@veDescription", filtro.Description));

			return this.databaseQueryCommand.Select<EFConfig>(this.Procedure, parameters);
		}


		/// <summary>
		/// Grava Parâmetro
		/// </summary>
		/// <param name="efconfig"></param>
		/// <param name="databaseCommandCommit"></param>
		/// <returns></returns>
		public bool GravarParametro(EFConfig efconfig, IDatabaseCommandCommit databaseCommandCommit)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@veExecutor", 2));
			parameters.Add(new SqlParameter("@veParametro", 1));
			parameters.Add(new SqlParameter("@veEFConfigID", efconfig.EFConfigID));
			parameters.Add(new SqlParameter("@veActive", efconfig.Active));
			parameters.Add(new SqlParameter("@veValue", efconfig.Value));
			parameters.Add(new SqlParameter("@veUpdtUserCode", efconfig.UpdtUserCode));

			return databaseCommandCommit.Update(Procedure, parameters) > 0;
		}


		public EFConfig GetConfig(EFConfig efconfig)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@veExecutor", 1));
			parameters.Add(new SqlParameter("@veParametro", 2));
			parameters.Add(new SqlParameter("@veEFConfigID", efconfig.EFConfigID));

			return this.databaseQueryCommand.GetEntity<EFConfig>(this.Procedure, parameters);
		}
	}
}
