using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SGDAU.Common
{
    public interface IContextIronMountain
    {
        JwtData UserData { get; }
        bool IsValid { get; }
        string Name { get; }
    }

    public class ContextIronMountain: IContextIronMountain
    {
        private readonly IConfiguration config;

        public ContextIronMountain(IConfiguration config, ClaimsPrincipal principal)
        {
            if (principal != null && principal.Identity != null && principal.Identity.IsAuthenticated && principal.Claims != null )
            {
                foreach(var claim in principal.Claims)
                {
                    switch (claim.Type)
                    {
                        case ClaimTypes.Name:
                            this.Name = claim.Value;
                            break;

                        case ClaimTypes.UserData:
                            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<JwtData>(claim.Value);
                            this.UserData = data;
                            this.IsValid = data.Hash == JwtData.CalculateHash(this.config, data);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public JwtData UserData { get; private set; }
        public bool IsValid { get; private set; } = false;
        public string Name { get; private set; }
    }
}
