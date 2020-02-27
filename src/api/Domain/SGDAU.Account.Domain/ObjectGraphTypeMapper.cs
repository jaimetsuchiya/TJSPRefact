using GraphQL.Types;
using SGDAU.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Account.Domain
{
    public class AccountType : ObjectGraphType<EFAccount>
    {
        public AccountType()
        {
            Name = "Account";

            Field(x => x.EFAccountID, type: typeof(IdGraphType)).Description("Account ID.");
            Field(x => x.AccountName).Description("Account Name.");
            Field(x => x.LevelCode).Description("LevelCode");
            Field(x => x.EFAccountIDF).Description("Parent Account");
            Field(x => x.Categoria).Description("Category Account");
            Field(x => x.EFRegiaoID).Description("Region Account");
        }

        public int Categoria { get; internal set; }
        public int? EFRegiaoID { get; internal set; }

        public string AccountCode { get; internal set; }
        public string AccountName { get; internal set; }
        public decimal EFAccountID { get; internal set; }
        public decimal? EFAccountID3 { get; internal set; }
        public decimal? EFAccountID4 { get; internal set; }
        public decimal? EFAccountIDF { get; internal set; }
    }
}
