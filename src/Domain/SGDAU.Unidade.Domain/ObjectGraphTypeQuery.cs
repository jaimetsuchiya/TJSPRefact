using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Unidade.Domain
{
    public class UnidadeQuery: ObjectGraphType
    {
        public UnidadeQuery(IUnidadeService service)
        {
            Field<UnidadeType>(
              "Unidade",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  return service.GetDadosUnidade(new Models.EFTJUnidade() { EFTJUnidadeID = id });
              });

            Field<ListGraphType<UnidadeType>>(
              "Unidades",
              resolve: context =>
              {
                  return service.GetAllUnidades();
              });
        }
    }
}
