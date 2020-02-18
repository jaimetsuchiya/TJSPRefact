using GraphQL.Types;
using SGDAU.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Unidade.Domain
{
    public interface IUnidadeQuery : IGraphQLSchemaPart
    { 
    }

    public class UnidadeQuery: IUnidadeQuery
    {
        private readonly IUnidadeService _service = null;
        public UnidadeQuery(IUnidadeService service) => _service = service;

        public void SetQueries(ObjectGraphType graphType)
        {
            graphType.Field<UnidadeType>(
              "Unidade",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  return _service.GetDadosUnidade(new Models.EFTJUnidade() { EFTJUnidadeID = id });
              });

            graphType.Field<ListGraphType<UnidadeType>>(
              "Unidades",
              resolve: context =>
              {
                  return _service.GetAllUnidades();
              });
        }
    }
}
