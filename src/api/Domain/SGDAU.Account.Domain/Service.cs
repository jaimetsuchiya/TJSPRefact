using SGDAU.Common;
using SGDAU.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Account.Domain
{
    public interface IAccountService
    {
        ICollection<EFAccount> GetComarcaUsuario(EFAccount efAccount);
        ICollection<EFAccount> GetVaraUsuario(EFAccount efAccount);
    }

    public class AccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IContextIronMountain context;

        public AccountService(IContextIronMountain context, IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
            this.context = context;
        }

        public ICollection<EFAccount> GetComarcaUsuario(EFAccount efAccount)
        {
            ICollection<EFAccount> result = new List<EFAccount>();

            if (efAccount.EFRegiaoID.HasValue)
            {
                result = accountRepository.GetComarcaRegiao(efAccount);
                return result;
            }

            if (efAccount.Categoria == 1 || efAccount.Categoria == 2 || efAccount.Categoria == 5)
            {
                result = accountRepository.GetComararcaAlocacao(efAccount);
            }

            //Recupera Todas as Comarcas pois o usuário é SPI ou RECALL
            if (efAccount.Categoria == 3 || efAccount.Categoria == 4)
            {
                result = accountRepository.GetAllComarca(efAccount.SomenteAtiva);
            }

            return result;
        }

        public ICollection<EFAccount> GetVaraUsuario(EFAccount efAccount)
        {
            ICollection<EFAccount> result = new List<EFAccount>();

            if (efAccount.EFRegiaoID.HasValue)
            {
                result = accountRepository.GetVaraComarca(efAccount);
            }

            if (efAccount.Categoria == 1 || efAccount.Categoria == 5)
            {
                result = accountRepository.GetVaraUsuario(efAccount);
            }

            //Recupera Todas as Comarcas pois o usuário é SPI ou RECALL
            if (efAccount.Categoria == 2 || efAccount.Categoria == 3 || efAccount.Categoria == 4)
            {
                result = accountRepository.GetVaraComarca(efAccount);
            }

            return result;
        }

    }
}
