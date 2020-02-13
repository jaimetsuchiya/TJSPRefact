using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private readonly IServiceProvider _serviceProvider;

        public GraphQLController(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        private QuerySchema CreateSchema()
        {
            var querySchema = new QuerySchema();
            //var allParts = ((IGraphQLSchemaCollection)this._serviceProvider.GetService(typeof(IGraphQLSchemaCollection))).Items;
            //foreach(var part in allParts)
            //{
            //    var queryPart = this._serviceProvider.GetService(part);
            //    queryPart.GetType().InvokeMember("SetQueries", BindingFlags.Public, null, queryPart, new object[] { querySchema });
            //}

            ((IAdvogadoQuery)this._serviceProvider.GetService(typeof(IAdvogadoQuery))).SetQueries(querySchema);
            ((IUnidadeQuery)this._serviceProvider.GetService(typeof(IUnidadeQuery))).SetQueries(querySchema);
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