using GraphQL.Types;
using SGDAU.Parametros.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Advogado.Domain
{
    public class ParametroType : ObjectGraphType<EFConfig>
    {
        public ParametroType()
        {
            Name = "Parametro";

            //Field(x => x.EFTJAdvogadoID, type: typeof(IdGraphType)).Description("Advogado ID.");
            //Field(x => x.Nome).Description("Advogado Nome.");
            //Field(x => x.Codigo).Description("Advogado OAB.");
            //Field(x => x.Ativo).Description("Advogado Ativo.");
            //Field(x => x.CreateUserCode).Description("Advogado CreateUserCode.");
            //Field(x => x.CreateDTime).Description("Advogado CreateDTime.");
            //Field(x => x.UpdtUserCode).Description("Advogado UpdtUserCode.");
            //Field(x => x.UpdtDTime).Description("Advogado UpdtDTime.");
            //Field(x => x.Origem).Description("Advogado Origem.");

        }
    }
}
