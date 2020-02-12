using SGDAU.Advogado.Domain.Models;
using SGDAU.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Advogado.Domain
{
    public interface IAdvogadoService
    {
        ICollection<EFTJAdvogado> Pesquisar(EFTJAdvogado advogado);

        ICollection<EFTJAdvogado> PesquisarAdvogado(EFTJAdvogado advogado);
        ICollection<EFTJAdvogado> PesquisarRelatorio(EFTJAdvogado advogado);
        bool Incluir(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado);
        bool Alterar(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado);
        bool Excluir(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado);
        ICollection<EFTJAdvogado> PesquisarHistoricoAdvogado(EFTJAdvogado advogado);
    }

    public class AdvogadoService : IAdvogadoService
    {
        private readonly IAdvogadoRepository advogadoRepository;
        public AdvogadoService(IAdvogadoRepository advogadoRepository)
        {
            this.advogadoRepository = advogadoRepository;
        }
        public bool Alterar(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado)
        {
            return this.advogadoRepository.Alterar(dataBaseCommandCommit, advogado);
        }



        public bool Incluir(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado)
        {
            return this.advogadoRepository.Incluir(dataBaseCommandCommit, advogado);
        }

        public ICollection<EFTJAdvogado> PesquisarAdvogado(EFTJAdvogado advogado)
        {
            return this.advogadoRepository.PesquisarAdvogado(advogado);
        }

        public bool Excluir(IDatabaseCommandCommit dataBaseCommandCommit, EFTJAdvogado advogado)
        {
            return this.advogadoRepository.Excluir(dataBaseCommandCommit, advogado);
        }

        public ICollection<EFTJAdvogado> PesquisarHistoricoAdvogado(EFTJAdvogado advogado)
        {
            return this.advogadoRepository.PesquisarHistoricoAdvogado(advogado);
        }

        public ICollection<EFTJAdvogado> PesquisarRelatorio(EFTJAdvogado advogado)
        {
            return this.advogadoRepository.PesquisarRelatorio(advogado);
        }

        public ICollection<EFTJAdvogado> Pesquisar(EFTJAdvogado advogado)
        {
            return this.advogadoRepository.Pesquisar(advogado);
        }
    }
}
