using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGDAU.Common
{
    public class JwtData
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public int? GroupID { get; set; }
        public int? CategoryID { get; set; }
        public int? RegionID { get; set; }
        public int? BusinessUnitID { get; set; }
        public int? PrinterID { get; set; }
        public decimal? AllocatedVaraID { get; set; }
        public string ClientID { get; set; }
        public string Hash { get; set; } = null;
        public AccessDTO[] AccessPermissions { get; set; }

        public static string CalculateHash(IConfiguration configurationService, JwtData data)
        {
            if (data == null || configurationService == null)
                return null;

            var instanteToCalculate = Newtonsoft.Json.JsonConvert.DeserializeObject<JwtData>(
                                        Newtonsoft.Json.JsonConvert.SerializeObject(data)
                                    );

            instanteToCalculate.Hash = null;
            return String.Join("", System.Security.Cryptography.SHA256.Create().ComputeHash(
                                            Encoding.UTF8.GetBytes(
                                                String.Concat(configurationService.GetSection("Authentication:Seed").Value, Newtonsoft.Json.JsonConvert.SerializeObject(data), configurationService.GetSection("Authentication:Sufix").Value)
                                            )
                                       ).Select(x => x.ToString("X2"))).ToLower();
        }
    }

    public class AccessDTO
    { 
        public int ID { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int? ParentID { get; set; }
    }

}
