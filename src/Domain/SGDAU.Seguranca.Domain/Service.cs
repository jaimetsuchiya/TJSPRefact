using SGDAU.Seguranca.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Seguranca.Domain
{
    public interface IUsuarioService
    {
        EFTJUserweb ConsultaUsuario(EFTJUserweb userWeb);
        EFTJUserweb Login(EFTJUserweb userWeb);
    }

    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public EFTJUserweb ConsultaUsuario(EFTJUserweb userWeb)
        {
            return this.usuarioRepository.ConsultaUsuario(userWeb);
        }

        public EFTJUserweb Login(EFTJUserweb userWeb)
        {
            return this.usuarioRepository.Login(userWeb);
        }
    }
}
