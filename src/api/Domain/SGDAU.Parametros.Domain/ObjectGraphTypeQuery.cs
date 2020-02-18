using GraphQL.Types;
using SGDAU.Common;
using SGDAU.Parametros.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGDAU.Parametros.Domain
{
    public interface IParametrosQuery : IGraphQLSchemaPart { }

    public class ParametrosQuery: IParametrosQuery
    {
        private readonly IParametroAplicacaoService _service = null;
        public ParametrosQuery(IParametroAplicacaoService service) => _service = service;

        public void SetQueries(ObjectGraphType graphType)
        {
           
        }
    }
}
