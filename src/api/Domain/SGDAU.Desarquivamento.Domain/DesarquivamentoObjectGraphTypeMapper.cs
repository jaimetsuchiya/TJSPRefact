using GraphQL.Types;
using SGDAU.Desarquivamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Desarquivamento.Domain
{
    public class DesarquivamentoType : ObjectGraphType<EFTJDesarquivamentoPesquisa>
    {
        public DesarquivamentoType()
        {
            Name = "Desarquivamento";
        }
    }
}
