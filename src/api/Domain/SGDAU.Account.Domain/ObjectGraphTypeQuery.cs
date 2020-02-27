using GraphQL.Types;
using SGDAU.Common;
using SGDAU.Account.Domain;
using SGDAU.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace SGDAU.Account.Domain
{
    public interface IAccountQuery : IGraphQLSchemaPart
    {
    }

    public class AccountQuery: IAccountQuery
    {
        private readonly IAccountService _service = null;
        private readonly IMapper _iMapper;

        public AccountQuery(IAccountService service)
        {
            _service = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EFAccount, AccountType>();
            });
            _iMapper = config.CreateMapper();
        }

        public void SetQueries(ObjectGraphType graphType)
        {
            graphType.Field<AccountType>(
              "ComarcasUsuario",
              arguments: new QueryArguments(
                new QueryArgument<AccountType> { Name = "account", Description = "Account Instance" }
              ),
              resolve: context =>
              {
                  return _service.GetComarcaUsuario(
                            _iMapper.Map<EFAccount>(
                                context.GetArgument<AccountType>("account")
                            )
                         );
              });

            graphType.Field<AccountType>(
              "VarasComarcaUsuario",
              arguments: new QueryArguments(
                new QueryArgument<AccountType> { Name = "account", Description = "Account Instance" }
              ),
              resolve: context =>
              {
                  return _service.GetVaraUsuario(
                              _iMapper.Map<EFAccount>(
                                  context.GetArgument<AccountType>("account")
                              )
                         );
              });
        }
    }
}
