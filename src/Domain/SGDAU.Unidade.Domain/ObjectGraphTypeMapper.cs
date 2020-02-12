using GraphQL.Types;
using SGDAU.Unidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Unidade.Domain
{
    public class UnidadeType : ObjectGraphType<EFTJUnidade>
    {
        public UnidadeType()
        {
            Name = "Unidade";

            Field(x => x.EFTJUnidadeID, type: typeof(IdGraphType)).Description("Unidade ID.");
            Field(x => x.Description).Description("Unidade Nome.");
        }
    }
}
