using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SGDAU.Advogado.Domain;
using SGDAU.Common;
using SGDAU.Unidade.Domain;
using TJSPApi.DTOs;
using TJSPApi.Infrastructure;

namespace TJSPApi.Controllers
{
    [Authorize]
    [Route("api/graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMemoryCache _memoryCache;

        public GraphQLController(IServiceProvider serviceProvider, IMemoryCache memoryCache)
        {
            this._serviceProvider = serviceProvider;
            this._memoryCache = memoryCache;
        }

        private QuerySchema CreateSchema()
        {
            var querySchema = new QuerySchema();
            if (!this._memoryCache.TryGetValue("Schema", out querySchema))
            {
                querySchema = new QuerySchema();
                var allParts = ((IGraphQLSchemaCollection)this._serviceProvider.GetService(typeof(IGraphQLSchemaCollection))).Items;
                foreach (var part in allParts)
                {
                    var queryPart = this._serviceProvider.GetService(part);
                    queryPart.GetType().InvokeMember("SetQueries", BindingFlags.InvokeMethod, null, queryPart, new object[] { querySchema });
                }
                this._memoryCache.CreateEntry("Schema")
                    .SetValue(querySchema)
                    .AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60);
                //this._memoryCache.Set("Schema", 
                //                      , 
                //                      new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60)));
            }
            return querySchema;
        }


        [EnableCors]
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
}