using GraphQL.Types;
using System;

namespace SGDAU.Common
{
    public interface IGraphQLSchemaPart
    {
        void SetQueries(ObjectGraphType graphType);
    }
}
