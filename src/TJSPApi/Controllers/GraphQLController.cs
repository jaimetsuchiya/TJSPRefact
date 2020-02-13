using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDAU.Advogado.Domain;
using SGDAU.Common;
using SGDAU.Unidade.Domain;
using TJSPApi.DTOs;

namespace TJSPApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IAdvogadoQuery _advogadoQuery;
        private readonly IUnidadeQuery _unidadeQuery;

        public GraphQLController(IAdvogadoQuery advogadoQuery, IUnidadeQuery unidadeQuery)
        {
            this._advogadoQuery = advogadoQuery;
            this._unidadeQuery = unidadeQuery;
        }

        private QuerySchema CreateSchema()
        {
            var querySchema = new QuerySchema();
            this._advogadoQuery.SetQueries(querySchema);
            this._unidadeQuery.SetQueries(querySchema);
            return querySchema;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = CreateSchema()
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }


    }

    public class QuerySchema : ObjectGraphType 
    {
        //public QuerySchema(IUnidadeService unidadeService,
        //                   IAdvogadoService advogadoService) 
        //{ 
        //Field<UnidadeType>(
        //  "unidade",
        //  arguments: new QueryArguments(
        //    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
        //  resolve: context =>
        //  {
        //      var id = context.GetArgument<int>("id");
        //      return unidadeService.GetDadosUnidade(new SGDAU.Unidade.Domain.Models.EFTJUnidade() { EFTJUnidadeID = id});
        //  });

        //Field<ListGraphType<UnidadeType>>(
        //  "Unidades",
        //  resolve: context =>
        //  {
        //      return unidadeService.GetAllUnidades();
        //  });

        //Field<AdvogadoType>(
        //      "Advogado",
        //      arguments: new QueryArguments(
        //        new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
        //      resolve: context =>
        //      {
        //          var id = context.GetArgument<int>("id");
        //          return advogadoService.PesquisarAdvogado(new SGDAU.Advogado.Domain.Models.EFTJAdvogado()
        //          {
        //              EFTJAdvogadoID = id
        //          }).FirstOrDefault();
        //      });

        //Field<ListGraphType<AdvogadoType>>(
        //  "Advogados",
        //  resolve: context =>
        //  {
        //      return advogadoService.Pesquisar(new SGDAU.Advogado.Domain.Models.EFTJAdvogado());
        //  });
        //}
    }
}