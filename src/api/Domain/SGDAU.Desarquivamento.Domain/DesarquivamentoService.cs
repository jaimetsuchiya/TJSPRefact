using SGDAU.Common;
using SGDAU.Desarquivamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Desarquivamento.Domain
{
    public interface IDesarquivamentoPesquisaService
    {
        ICollection<EFTJDesarquivamentoPesquisa> GetDesarquivamentoPesquisa(EFTJDesarquivamentoPesquisa DesarquivamentoPesquisa);
    }


    public class DesarquivamentoPesquisaService : IDesarquivamentoPesquisaService
    {
        private readonly IDesarquivamentoPesquisaRepository DesarquivamentoPesquisaRepository;
        private readonly IContextIronMountain context;

        public DesarquivamentoPesquisaService(IContextIronMountain context, IDesarquivamentoPesquisaRepository DesarquivamentoPesquisaRepository)
        {
            this.DesarquivamentoPesquisaRepository = DesarquivamentoPesquisaRepository;
            this.context = context;
        }

        public ICollection<EFTJDesarquivamentoPesquisa> GetDesarquivamentoPesquisa(EFTJDesarquivamentoPesquisa DesarquivamentoPesquisa)
        {
            return DesarquivamentoPesquisaRepository.GetDesarquivamentoPesquisa(DesarquivamentoPesquisa);
        }
    }
}
