using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SGDAU.Common;
using SGDAU.Seguranca.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace SGDAU.Seguranca.Domain
{
    public interface ISegurancaService
    {
        EFTJUserweb ConsultaUsuario(EFTJUserweb userWeb);
        EFTJUserweb Login(EFTJUserweb userWeb);

        string Authenticate(Authenticate dto);
    }

    public class SegurancaService: ISegurancaService
    {
        private readonly ISegurancaRepository segurancaRepository;
        private readonly IConfiguration configurationService;

        public SegurancaService(IConfiguration configurationService, ISegurancaRepository segurancaRepository)
        {
            this.configurationService = configurationService;
            this.segurancaRepository = segurancaRepository;
        }

        public EFTJUserweb ConsultaUsuario(EFTJUserweb userWeb)
        {
            return this.segurancaRepository.ConsultaUsuario(userWeb);
        }

        public EFTJUserweb Login(EFTJUserweb userWeb)
        {
            return this.segurancaRepository.Login(userWeb);
        }

        public string Authenticate(Authenticate dto)
        {
            
            //Recupera o usuário
            var usuarioModel = this.ConsultaUsuario(new EFTJUserweb()
            {
                Login = dto.Login
            });

            if(usuarioModel == null)
            {
                usuarioModel = this.ConsultaUsuario(new EFTJUserweb()
                {
                    CPF = dto.Login
                });
            }

            if (usuarioModel == null)
                return null;

            var password =  String.Join("", System.Security.Cryptography.SHA1.Create().ComputeHash(
                                Encoding.UTF8.GetBytes(
                                    String.Concat(usuarioModel.pwdKey, dto.Password)
                                )
                            ).Select(x => x.ToString("X2"))).ToLower();

            //Valida o Usuário e Senha
            this.Login(new SGDAU.Seguranca.Domain.Models.EFTJUserweb()
            {
                Login = dto.Login,
                PassWord = password
            });

            var jwtData = new JwtData()
            {
                AllocatedVaraID = usuarioModel.VaraAlocacao,
                BusinessUnitID = usuarioModel.EFTJUnidadeID,
                PrinterID = usuarioModel.EFTJImpressoraID,
                RegionID = usuarioModel.EFRegiaoID,
                GroupID = usuarioModel.EFGrupoID,
                CategoryID = usuarioModel.Categoria,
                FirstName = usuarioModel.Nome,
                Login = dto.Login,
                UserID = usuarioModel.EFUserID,
                ClientID = dto.ClientId
            };

            //Calcula o hash de validação com os dados do usuário
            var hash = String.Join("", System.Security.Cryptography.SHA256.Create().ComputeHash(
                                Encoding.UTF8.GetBytes(
                                    String.Concat(this.configurationService.GetSection("Authentication:Seed").Value, Newtonsoft.Json.JsonConvert.SerializeObject(jwtData), this.configurationService.GetSection("Authentication:Sufix").Value)
                                )
                            ).Select(x => x.ToString("X2"))).ToLower();

            jwtData.Hash = hash;

            //Gera o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.configurationService.GetSection("Authentication:SecretKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = this.configurationService.GetSection("Authentication:IssuerName").Value,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioModel.Nome),
                    new Claim(ClaimTypes.UserData, Newtonsoft.Json.JsonConvert.SerializeObject(jwtData))
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
