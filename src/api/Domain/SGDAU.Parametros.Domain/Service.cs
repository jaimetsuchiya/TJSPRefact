using SGDAU.Common;
using SGDAU.Parametros.Domain.Models;
using SGDAU.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Parametros.Domain
{
	public interface IParametroAplicacaoService
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

		// <summary>
		/// Obtem parametro conforme o ID informado
		/// </summary>
		/// <param name="filtro"></param>
		/// <returns></returns>
		EFConfig GetConfig(EFConfig efconfig);

	}

	public class ParametroAplicacaoService : IParametroAplicacaoService
	{
		private readonly IParametroAplicacaoRepository parametroAplicacaoRepository;
		private readonly IContextIronMountain context;

		public ParametroAplicacaoService(IContextIronMountain context, IParametroAplicacaoRepository parametroAplicacaoRepository)
		{
			this.parametroAplicacaoRepository = parametroAplicacaoRepository;
			this.context = context;
		}


		#region IParametroAplicacaoService Members

		/// <summary>
		/// Obtem os parâmetros da aplicação de acordo com o filtro aplicado
		/// </summary>
		/// <param name="filtro"></param>
		/// <returns></returns>
		public ICollection<EFConfig> GetParametros(EFConfig filtro)
		{
			if (filtro == null)
				throw new ArgumentException("Dados Inválidos!");

			return parametroAplicacaoRepository.GetParametros(filtro);
		}


		/// <summary>
		/// Grava Parâmetro
		/// </summary>
		/// <param name="efconfig"></param>
		/// <param name="databaseCommandCommit"></param>
		/// <returns></returns>
		public bool GravarParametro(EFConfig efconfig, IDatabaseCommandCommit databaseCommandCommit)
		{
			if (efconfig == null)
				throw new ArgumentException("Dados Inválidos!");

			if (string.IsNullOrEmpty(efconfig.Value))
				throw new ArgumentException("Valor do parâmetro não informado!");

			if (efconfig.EFAccountID == 0)
				throw new ArgumentException("Código do parâmetro inválido!");

			if (efconfig.Active != "S" && efconfig.Active != "N")
				throw new ArgumentException("Informe se o parâmetro está ativo ou inativo!");

			if (string.IsNullOrEmpty(efconfig.UpdtUserCode))
				throw new ArgumentException("Usuário não informado!");

			return parametroAplicacaoRepository.GravarParametro(efconfig, databaseCommandCommit);
		}

		#endregion


		public EFConfig GetConfig(EFConfig efconfig)
		{
			if (efconfig == null)
				throw new ArgumentException("Dados Inválidos!");

			return parametroAplicacaoRepository.GetConfig(efconfig);
		}
	}
}
