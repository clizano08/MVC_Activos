using Business_Logic.Utils;
using Data_Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class UsuarioBL
    {
        public UsuarioEL GetUsuarioById(int pIdUsuario)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            return usuarioDB.GetUsuarioById(pIdUsuario);
        }
        public UsuarioEL GetUsuarioByCedula(string pCedula)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            return usuarioDB.GetUsuarioByCedula(pCedula);
        }
        public List<UsuarioEL> GetAllUsuario()
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            return usuarioDB.GetAllUsuario();
        }
        public UsuarioEL InsertUsuario(UsuarioEL pUsuario)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            pUsuario.Contrasenna = Criptography.EncrypthAES(pUsuario.Contrasenna);
            return usuarioDB.InsertUsuario(pUsuario);
        }
        public UsuarioEL UpdateUsuario(UsuarioEL pUsuario)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            return usuarioDB.UpdateUsuario(pUsuario);
        }
        public UsuarioEL UpdatePasswordUsuario(UsuarioEL pUsuario)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            pUsuario.Contrasenna = Criptography.EncrypthAES(pUsuario.Contrasenna);
            return usuarioDB.UpdatePasswordUsuario(pUsuario);
        }
        public bool DeleteUsuario(int pIdUsuario)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            return usuarioDB.DeleteUsuario(pIdUsuario);
        }
    }
}
