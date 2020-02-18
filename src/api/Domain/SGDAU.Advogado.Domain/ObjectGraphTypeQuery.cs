using GraphQL.Types;
using SGDAU.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGDAU.Advogado.Domain
{
    public interface IAdvogadoQuery : IGraphQLSchemaPart { }

    public class AdvogadoQuery: IAdvogadoQuery
    {
        private readonly IAdvogadoService _service = null;
        public AdvogadoQuery(IAdvogadoService service) => _service = service;

        public void SetQueries(ObjectGraphType graphType)
        {
            graphType.Field<AdvogadoType>(
                  "Advogado",
                  arguments:

            new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
                  resolve: context =>
                  {
                      var id = context.GetArgument<int>("id");
                      return _service.PesquisarAdvogado(new Models.EFTJAdvogado()
                      {
                          EFTJAdvogadoID = id
                      }).FirstOrDefault();
                  });

            graphType.Field<ListGraphType<AdvogadoType>>(
              "Advogados",
              resolve: context =>
              {
                  return _service.PesquisarAdvogado(new Models.EFTJAdvogado() { QuantidadeRegistrosPorPagina = 100, pagina = 1 });
              });
        }
    }
}
