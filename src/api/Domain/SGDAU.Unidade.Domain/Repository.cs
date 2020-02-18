using Microsoft.Extensions.Configuration;
using SGDAU.Common;
using SGDAU.Repository.Infrastructure;
using SGDAU.Unidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SGDAU.Unidade.Domain
{
    public interface IUnidadeRepository: IRepository
    {
        ICollection<EFTJUnidade> GetAllUnidades();
        ICollection<EFTJUnidade> IncluiUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade);
        bool AdicionarUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade);
        bool AlterarUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade);
        bool VerificarCodigoSKP(EFTJPredio predio);
        ICollection<EFTJPredio> AlterarPredio(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio);
        ICollection<EFTJPredio> ExcluirPredio(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio);
        ICollection<EFTJPredio> AdicionarPredioUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio);
        EFTJUnidade GetDadosUnidade(EFTJUnidade unidade);
        ICollection<EFTJPredio> GetDadosPredioUnidade(EFTJUnidade unidade);
        EFTJPredio GetDadosAlterarPredio(EFTJUnidade unidade);
    }

    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly IDatabaseQueryCommand databaseQueryCommand;
        public UnidadeRepository(IDatabaseQueryCommand databaseQueryCommand)
        {
            this.databaseQueryCommand = databaseQueryCommand;
        }

        public string Procedure
        {
            get { return "unidade_sgdai"; }
        }

        public ICollection<EFTJPredio> AlterarPredio(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 13));
            parameters.Add(new SqlParameter("@veEFTJUnidadePredioID", predio.EFTJUnidadePredioID));
            parameters.Add(new SqlParameter("@veDescricao", predio.Descricao));
            parameters.Add(new SqlParameter("@veCodigoSKP", predio.CodigoSKP));
            parameters.Add(new SqlParameter("@veUpdtUserCode", predio.UpdtUserCode));

            return databaseCommandCommit.UpdateReaderList<EFTJPredio>(Procedure, parameters);
        }

        public EFTJUnidade GetDadosUnidade(EFTJUnidade unidade)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 9));
            parameters.Add(new SqlParameter("@veEFTJUnidadeID", unidade.EFTJUnidadeID));

            return this.databaseQueryCommand.GetEntity<EFTJUnidade>(Procedure, parameters);
        }

        public ICollection<EFTJPredio> GetDadosPredioUnidade(EFTJUnidade unidade)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 10));
            parameters.Add(new SqlParameter("@veEFTJUnidadeID", unidade.EFTJUnidadeID));

            return this.databaseQueryCommand.Select<EFTJPredio>(Procedure, parameters);
        }
        public EFTJPredio GetDadosAlterarPredio(EFTJUnidade unidade)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 11));
            parameters.Add(new SqlParameter("@veEFTJUnidadePredioID", unidade.EFTJUnidadePredioID));

            return this.databaseQueryCommand.GetEntity<EFTJPredio>(Procedure, parameters);
        }

        public string PredioToXml(List<EFTJPredio> predios)
        {
            StringBuilder builder = new StringBuilder();
            if (predios != null && predios.Count > 0)
            {
                builder.Append("<Predios>");
                foreach (var item in predios)
                {
                    builder.Append("<Predio>");
                    builder.AppendFormat("<CodigoSKP>{0}</CodigoSKP>", item.CodigoSKP);
                    builder.AppendFormat("<Descricao>{0}</Descricao>", item.Descricao);
                    builder.AppendFormat("<CreateUserCode>{0}</CreateUserCode>", item.CreateUserCode.Split('-')[0]);
                    builder.AppendFormat("<UpdtUserCode>{0}</UpdtUserCode>", item.UpdtUserCode.Split('-')[0]);
                    builder.Append("</Predio>");
                }
                builder.Append("</Predios>");
            }
            return builder.ToString();
        }
        public bool AdicionarUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 8));
            parameters.Add(new SqlParameter("@veDescription", unidade.Description));
            parameters.Add(new SqlParameter("@veArquivamento", unidade.Arquivamento));
            parameters.Add(new SqlParameter("@veDesarquivamento", unidade.Desarquivamento));
            parameters.Add(new SqlParameter("@veCatalogacao", unidade.Catalogacao));
            parameters.Add(new SqlParameter("@veCreateUserCode", unidade.CreateUserCode));
            parameters.Add(new SqlParameter("@veUpdtUserCode", unidade.UpdtUserCode));

            if (!string.IsNullOrEmpty(unidade.Endereco))
                parameters.Add(new SqlParameter("@veEndereco", unidade.Endereco));

            if (!string.IsNullOrEmpty(unidade.Numero))
                parameters.Add(new SqlParameter("@veNumero", unidade.Numero));

            if (!string.IsNullOrEmpty(unidade.Complemento))
                parameters.Add(new SqlParameter("@veComplemento", unidade.Complemento));

            if (!string.IsNullOrEmpty(unidade.Bairro))
                parameters.Add(new SqlParameter("@veBairro", unidade.Bairro));

            if (!string.IsNullOrEmpty(unidade.Cidade))
                parameters.Add(new SqlParameter("@veCidade", unidade.Cidade));

            if (!string.IsNullOrEmpty(unidade.CEP))
                parameters.Add(new SqlParameter("@veCEP", unidade.CEP.Replace("-", string.Empty).Replace(" ", string.Empty)));

            if (!string.IsNullOrEmpty(unidade.Contato))
                parameters.Add(new SqlParameter("@veContato", unidade.Contato));

            if (!string.IsNullOrEmpty(unidade.Email))
                parameters.Add(new SqlParameter("@veEmail", unidade.Email));

            if (!string.IsNullOrEmpty(unidade.Telefone))
                parameters.Add(new SqlParameter("@veTelefone", unidade.Telefone.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty)));

            var xml = PredioToXml(unidade.prediosList);
            if (!string.IsNullOrEmpty(xml))
                parameters.Add(new SqlParameter("@vePrediosXML", xml));

            var unidadeResult = databaseCommandCommit.Update(Procedure, parameters);

            return true;
        }

        public bool AlterarUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 12));
            parameters.Add(new SqlParameter("@veEFTJUnidadeID", unidade.EFTJUnidadeID));
            parameters.Add(new SqlParameter("@veDescription", unidade.Description));
            parameters.Add(new SqlParameter("@veArquivamento", unidade.Arquivamento));
            parameters.Add(new SqlParameter("@veDesarquivamento", unidade.Desarquivamento));
            parameters.Add(new SqlParameter("@veCatalogacao", unidade.Catalogacao));
            parameters.Add(new SqlParameter("@veCreateUserCode", unidade.CreateUserCode));
            parameters.Add(new SqlParameter("@veUpdtUserCode", unidade.UpdtUserCode));

            if (!string.IsNullOrEmpty(unidade.Endereco))
                parameters.Add(new SqlParameter("@veEndereco", unidade.Endereco));

            if (!string.IsNullOrEmpty(unidade.Numero))
                parameters.Add(new SqlParameter("@veNumero", unidade.Numero));

            if (!string.IsNullOrEmpty(unidade.Complemento))
                parameters.Add(new SqlParameter("@veComplemento", unidade.Complemento));

            if (!string.IsNullOrEmpty(unidade.Bairro))
                parameters.Add(new SqlParameter("@veBairro", unidade.Bairro));

            if (!string.IsNullOrEmpty(unidade.Cidade))
                parameters.Add(new SqlParameter("@veCidade", unidade.Cidade));

            if (!string.IsNullOrEmpty(unidade.CEP))
                parameters.Add(new SqlParameter("@veCEP", unidade.CEP.Replace("-", string.Empty).Replace(" ", string.Empty)));

            if (!string.IsNullOrEmpty(unidade.Contato))
                parameters.Add(new SqlParameter("@veContato", unidade.Contato));

            if (!string.IsNullOrEmpty(unidade.Email))
                parameters.Add(new SqlParameter("@veEmail", unidade.Email));

            if (!string.IsNullOrEmpty(unidade.Telefone))
                parameters.Add(new SqlParameter("@veTelefone", unidade.Telefone.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty)));

            var xml = PredioToXml(unidade.prediosList);
            if (!string.IsNullOrEmpty(xml))
                parameters.Add(new SqlParameter("@vePrediosXML", xml));

            var unidadeResult = databaseCommandCommit.Update(Procedure, parameters);

            return true;
        }


        public ICollection<EFTJUnidade> GetAllUnidades()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 5));

            return this.databaseQueryCommand.Select<EFTJUnidade>(Procedure, parameters);
        }

        public ICollection<EFTJUnidade> IncluiUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 2));
            parameters.Add(new SqlParameter("@veDescription", unidade.Description));
            parameters.Add(new SqlParameter("@veUserCode", unidade.CreateUserCode));

            return databaseCommandCommit.UpdateReaderList<EFTJUnidade>(Procedure, parameters);
        }

        public ICollection<EFTJPredio> ExcluirPredio(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 14));
            parameters.Add(new SqlParameter("@veEFTJUnidadePredioID", predio.EFTJUnidadePredioID));

            return databaseCommandCommit.UpdateReaderList<EFTJPredio>(Procedure, parameters);
        }

        public ICollection<EFTJPredio> AdicionarPredioUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 15));
            parameters.Add(new SqlParameter("@veEFTJUnidadeID", predio.EFTJUnidadeID));
            parameters.Add(new SqlParameter("@veDescricao", predio.Descricao));
            parameters.Add(new SqlParameter("@veCodigoSKP", predio.CodigoSKP));
            parameters.Add(new SqlParameter("@veCreateUserCode", predio.CreateUserCode));

            return databaseCommandCommit.UpdateReaderList<EFTJPredio>(Procedure, parameters);
        }

        public bool VerificarCodigoSKP(EFTJPredio predio)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veParametro", 16));
            parameters.Add(new SqlParameter("@veCodigoSKP", predio.CodigoSKP));

            var predioResult = this.databaseQueryCommand.GetEntity<EFTJPredio>(Procedure, parameters);
            return true;
        }
    }
}
