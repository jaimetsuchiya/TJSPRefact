using GraphQL.Types;
using SGDAU.Advogado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Advogado.Domain
{
    public class AdvogadoType : ObjectGraphType<EFTJAdvogado>
    {
        public AdvogadoType()
        {
            Name = "Advogado";

            Field(x => x.EFTJAdvogadoID, type: typeof(IdGraphType)).Description("Advogado ID.");
            Field(x => x.Nome).Description("Advogado Nome.");
            Field(x => x.Codigo).Description("Advogado OAB.");
            Field(x => x.Ativo).Description("Advogado Ativo.");
            Field(x => x.CreateUserCode).Description("Advogado CreateUserCode.");
            Field(x => x.CreateDTime).Description("Advogado CreateDTime.");
            Field(x => x.UpdtUserCode).Description("Advogado UpdtUserCode.");
            Field(x => x.UpdtDTime).Description("Advogado UpdtDTime.");
            Field(x => x.Origem).Description("Advogado Origem.");

        }
    }
}
