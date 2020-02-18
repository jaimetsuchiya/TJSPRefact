using Microsoft.Extensions.Configuration;
using SGDAU.Advogado.Domain.Models;
using SGDAU.Common;
using SGDAU.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SGDAU.Advogado.Domain
{
    public interface IAdvogadoRepository: IRepository
    {
        ICollection<EFTJAdvogado> Pesquisar(EFTJAdvogado advogado);
        int Inserir(IDatabaseCommandCommit databaseCommandCommit, EFTJAdvogado advogado);
        int Atualizar(IDatabaseCommandCommit databaseCommandCommit, EFTJAdvogado advogado);

        ICollection<EFTJAdvogado> PesquisarAdvogado(EFTJAdvogado advogado);
        ICollection<EFTJAdvogado> PesquisarRelatorio(EFTJAdvogado advogado);
        bool Incluir(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado);
        bool Alterar(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado);
        bool Excluir(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado);
        ICollection<EFTJAdvogado> PesquisarHistoricoAdvogado(EFTJAdvogado advogado);
    }

    public class AdvogadoRepository : IAdvogadoRepository
    {
        private readonly IDatabaseQueryCommand databaseQueryCommand;
        public AdvogadoRepository(IDatabaseQueryCommand databaseQueryCommand)
        {
            this.databaseQueryCommand = databaseQueryCommand;
        }


        public static string Procedure
        {
            get { return "advogado_sgdai"; }
        }

        public ICollection<EFTJAdvogado> Pesquisar(EFTJAdvogado advogado)
        {
            int pageStart = advogado.PageStart == 1 ? 1 : (advogado.PageStart - 1) * advogado.PageFinish + (1);
            int pageFinish = (pageStart + advogado.PageFinish) - 1;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 1));
            parameters.Add(new SqlParameter("@veCreateUserCode", advogado.CreateUserCode));

            if (advogado.EFTJAdvogadoID > 0)
                parameters.Add(new SqlParameter("@veEFTJAdvogadoID", advogado.EFTJAdvogadoID));

            if (!string.IsNullOrEmpty(advogado.Codigo))
                parameters.Add(new SqlParameter("@veCodigo", advogado.Codigo));

            if (!string.IsNullOrEmpty(advogado.Nome))
                parameters.Add(new SqlParameter("@veNome", advogado.Nome));

            if (pageStart > 0)
                parameters.Add(new SqlParameter("@vePageStart", pageStart));

            if (pageFinish > 0)
                parameters.Add(new SqlParameter("@vePageFinish", pageFinish));

            return this.databaseQueryCommand.Select<EFTJAdvogado>(Procedure, parameters);
        }

        public int Inserir(IDatabaseCommandCommit databaseCommandCommit, EFTJAdvogado advogado)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 2));
            parameters.Add(new SqlParameter("@veCreateUserCode", advogado.CreateUserCode));
            parameters.Add(new SqlParameter("@veCodigo", advogado.Codigo));
            parameters.Add(new SqlParameter("@veNome", advogado.Nome));
            parameters.Add(new SqlParameter("@veAtivo", advogado.Ativo));
            parameters.Add(new SqlParameter("@veOrigem", advogado.Origem));

            var tmpResult = databaseCommandCommit.UpdateReader<EFTJAdvogado>(Procedure, parameters);
            if (tmpResult != null && tmpResult.EFTJAdvogadoID > 0)
                return tmpResult.EFTJAdvogadoID;
            else
                return -1;
        }

        public int Atualizar(IDatabaseCommandCommit databaseCommandCommit, EFTJAdvogado advogado)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 3));
            parameters.Add(new SqlParameter("@veCreateUserCode", advogado.CreateUserCode));
            parameters.Add(new SqlParameter("@veCodigo", advogado.Codigo));
            parameters.Add(new SqlParameter("@veOrigem", advogado.Origem));
            parameters.Add(new SqlParameter("@veAtivo", advogado.Ativo));
            parameters.Add(new SqlParameter("@veNome", advogado.Nome));
            parameters.Add(new SqlParameter("@veEFTJAdvogadoID", advogado.EFTJAdvogadoID));

            return databaseCommandCommit.Update(Procedure, parameters);
        }

        public ICollection<EFTJAdvogado> PesquisarAdvogado(EFTJAdvogado advogado)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 4));

            if (!string.IsNullOrEmpty(advogado.Codigo))
                parameters.Add(new SqlParameter("@veCodigo", advogado.Codigo));
            if (!string.IsNullOrEmpty(advogado.Nome))
                parameters.Add(new SqlParameter("@veNome", advogado.Nome));
            if (advogado.EFTJAdvogadoID > 0)
                parameters.Add(new SqlParameter("@veEFTJAdvogadoID", advogado.EFTJAdvogadoID));
            if (advogado.AdvogadoAtivo != null)
                parameters.Add(new SqlParameter("@veAtivo", advogado.AdvogadoAtivo));

            if(advogado.OrigemList != null && advogado.OrigemList.Any())
            {
                if ((advogado.OrigemList.FirstOrDefault(x => x.Origem == "MANUAL") != null))
                    parameters.Add(new SqlParameter("@veOrigemManual", advogado.OrigemList.FirstOrDefault(x => x.Origem == "MANUAL").Origem));
                if ((advogado.OrigemList.FirstOrDefault(x => x.Origem == "IMPORTACAO") != null))
                    parameters.Add(new SqlParameter("@veOrigemImportacao", advogado.OrigemList.FirstOrDefault(x => x.Origem == "IMPORTACAO").Origem));
                if ((advogado.OrigemList.Where(x => x.Origem == "WEBSERVICE").FirstOrDefault() != null))
                    parameters.Add(new SqlParameter("@veOrigemWebService", advogado.OrigemList.FirstOrDefault(x => x.Origem == "WEBSERVICE").Origem));
            }

            parameters.Add(new SqlParameter("@vePaginaAtual", advogado.pagina));
            parameters.Add(new SqlParameter("@veQuantidadeRegistros", advogado.QuantidadeRegistrosPorPagina));

            return this.databaseQueryCommand.Select<EFTJAdvogado>(Procedure, parameters);
        }

        public bool Incluir(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 2));
            if (!string.IsNullOrEmpty(advogado.Codigo))
                parameters.Add(new SqlParameter("@veCodigo", advogado.Codigo.ToUpper()));
            if (!string.IsNullOrEmpty(advogado.Nome))
                parameters.Add(new SqlParameter("@veNome", advogado.Nome.ToUpper()));
            if (!string.IsNullOrEmpty(advogado.Origem))
                parameters.Add(new SqlParameter("@veOrigem", advogado.Origem));

            parameters.Add(new SqlParameter("@veAtivo", advogado.Ativo));
            parameters.Add(new SqlParameter("@veCreateUserCode", advogado.CreateUserCode));


            dataBaseCommandCommit.Update(Procedure, parameters);
            return true;
        }

        public bool Alterar(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 5));
            if (!string.IsNullOrEmpty(advogado.Codigo))
                parameters.Add(new SqlParameter("@veCodigo", advogado.Codigo.ToUpper()));
            if (!string.IsNullOrEmpty(advogado.Nome))
                parameters.Add(new SqlParameter("@veNome", advogado.Nome.ToUpper()));
            if (!string.IsNullOrEmpty(advogado.Origem))
                parameters.Add(new SqlParameter("@veOrigem", advogado.Origem));

            parameters.Add(new SqlParameter("@veAtivo", advogado.Ativo));
            parameters.Add(new SqlParameter("@veCreateUserCode", advogado.CreateUserCode));
            parameters.Add(new SqlParameter("@veEFTJAdvogadoID", advogado.EFTJAdvogadoID));


            dataBaseCommandCommit.Update(Procedure, parameters);
            return true;
        }

        public bool Excluir(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@veParametro", 6));
            parameters.Add(new SqlParameter("@veEFTJAdvogadoID", advogado.EFTJAdvogadoID));

            dataBaseCommandCommit.Delete(Procedure, parameters);
            return true;
        }

        public ICollection<EFTJAdvogado> PesquisarHistoricoAdvogado(EFTJAdvogado advogado)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 7));
            if (advogado.EFTJAdvogadoID > 0)
                parameters.Add(new SqlParameter("@veEFTJAdvogadoID", advogado.EFTJAdvogadoID));

            return this.databaseQueryCommand.Select<EFTJAdvogado>(Procedure, parameters);
        }

        public ICollection<EFTJAdvogado> PesquisarRelatorio(EFTJAdvogado advogado)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 8));
            if (!string.IsNullOrEmpty(advogado.Codigo))
                parameters.Add(new SqlParameter("@veCodigo", advogado.Codigo));
            if (!string.IsNullOrEmpty(advogado.Nome))
                parameters.Add(new SqlParameter("@veNome", advogado.Nome));
            if (advogado.EFTJAdvogadoID > 0)
                parameters.Add(new SqlParameter("@veEFTJAdvogadoID", advogado.EFTJAdvogadoID));
            if (advogado.AdvogadoAtivo != null)
                parameters.Add(new SqlParameter("@veAtivo", advogado.AdvogadoAtivo));
            if ((advogado.OrigemList.FirstOrDefault(x => x.Origem == "MANUAL") != null))
                parameters.Add(new SqlParameter("@veOrigemManual", advogado.OrigemList.FirstOrDefault(x => x.Origem == "MANUAL").Origem));
            if ((advogado.OrigemList.Where(x => x.Origem == "IMPORTACAO").FirstOrDefault() != null))
                parameters.Add(new SqlParameter("@veOrigemImportacao", advogado.OrigemList.FirstOrDefault(x => x.Origem == "IMPORTACAO").Origem));
            if ((advogado.OrigemList.Where(x => x.Origem == "WEBSERVICE").FirstOrDefault() != null))
                parameters.Add(new SqlParameter("@veOrigemWebService", advogado.OrigemList.FirstOrDefault(x => x.Origem == "WEBSERVICE").Origem));

            parameters.Add(new SqlParameter("@vePaginaAtual", advogado.pagina));
            parameters.Add(new SqlParameter("@veQuantidadeRegistros", advogado.QuantidadeRegistrosPorPagina));

            return this.databaseQueryCommand.Select<EFTJAdvogado>(Procedure, parameters);
        }
    }
}
