using GraphQL.Types;
using SGDAU.Common;
using SGDAU.Desarquivamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Desarquivamento.Domain
{
    public interface IDesarquivamentoQuery : IGraphQLSchemaPart
    { 
    }

    public class DesarquivamentoQuery : IDesarquivamentoQuery
    {
        private readonly IDesarquivamentoPesquisaService _service = null;
        public DesarquivamentoQuery(IDesarquivamentoPesquisaService service) => _service = service;

        public void SetQueries(ObjectGraphType graphType)
        {
            graphType.Field<DesarquivamentoType>(
              "Pesquisa",
              arguments: new QueryArguments(
                new QueryArgument<DesarquivamentoType> { Name = "payload" }),
              resolve: context =>
              {
                  var payload = context.GetArgument<DesarquivamentoType>("payload");
                  return _service.GetDesarquivamentoPesquisa(null);
              });

        }
    }
}
