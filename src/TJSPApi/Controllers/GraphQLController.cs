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
                _.EnableMetrics = false;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result.Data);
        }

    }

    public class QuerySchema : ObjectGraphType 
    {
        
    }
}