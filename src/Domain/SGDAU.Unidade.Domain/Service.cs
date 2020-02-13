using SGDAU.Repository.Infrastructure;
using SGDAU.Unidade.Domain.Models;
using System;
using System.Collections.Generic;

namespace SGDAU.Unidade.Domain
{
    public interface IUnidadeService
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

    public class UnidadeService : IUnidadeService
    {
        private readonly IUnidadeRepository unidadeRepository;

        public UnidadeService(IUnidadeRepository unidadeRepository)
        {
            this.unidadeRepository = unidadeRepository;
        }

        public ICollection<EFTJPredio> AdicionarPredioUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio)
        {
            return this.unidadeRepository.AdicionarPredioUnidade(databaseCommandCommit, predio);
        }

        public bool AdicionarUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade)
        {
            return this.unidadeRepository.AdicionarUnidade(databaseCommandCommit, unidade);
        }

        public ICollection<EFTJPredio> AlterarPredio(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio)
        {
            return this.unidadeRepository.AlterarPredio(databaseCommandCommit, predio);
        }

        public bool AlterarUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade)
        {
            return this.unidadeRepository.AlterarUnidade(databaseCommandCommit, unidade);
        }

        public ICollection<EFTJPredio> ExcluirPredio(IDatabaseCommandCommit databaseCommandCommit, EFTJPredio predio)
        {
            return this.unidadeRepository.ExcluirPredio(databaseCommandCommit, predio);
        }

        public ICollection<EFTJUnidade> GetAllUnidades()
        {
            return unidadeRepository.GetAllUnidades();
        }

        public EFTJPredio GetDadosAlterarPredio(EFTJUnidade unidade)
        {
            return this.unidadeRepository.GetDadosAlterarPredio(unidade);
        }

        public ICollection<EFTJPredio> GetDadosPredioUnidade(EFTJUnidade unidade)
        {
            return this.unidadeRepository.GetDadosPredioUnidade(unidade);
        }

        public EFTJUnidade GetDadosUnidade(EFTJUnidade unidade)
        {
            return this.unidadeRepository.GetDadosUnidade(unidade);
        }

        public ICollection<EFTJUnidade> IncluiUnidade(IDatabaseCommandCommit databaseCommandCommit, EFTJUnidade unidade)
        {
            return unidadeRepository.IncluiUnidade(databaseCommandCommit, unidade);
        }

        public bool VerificarCodigoSKP(EFTJPredio predio)
        {
            return this.unidadeRepository.VerificarCodigoSKP(predio);
        }
    }
}
