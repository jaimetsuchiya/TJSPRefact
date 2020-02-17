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
        public ContextIronMountain(ClaimsPrincipal principal)
        {
            if (principal != null && principal.Identity != null && principal.Identity.IsAuthenticated && principal.Claims != null )
            {
                var data = new JwtData();
                foreach(var claim in principal.Claims)
                {
                    switch (claim.Type.Trim())
                    {
                        case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name":
                            this.Name = claim.Value;
                            break;

                        case "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata":
                            data = Newtonsoft.Json.JsonConvert.DeserializeObject<JwtData>(claim.Value);
                            this.UserData = data;
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
