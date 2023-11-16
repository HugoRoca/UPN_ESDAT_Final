using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLUsuario
    {
        private readonly string nombreArchivo = "Usuario";
        private readonly DataAccess<UsuarioModel> dataUsuario;

        public BLUsuario()
        {
            dataUsuario = new DataAccess<UsuarioModel>(nombreArchivo);
        }

        public bool Login(string username, string password)
        {
            List<UsuarioModel> usuarios = dataUsuario.Leer();

            if (usuarios.Count == 0) return false;

            return usuarios.Where(x => x.Usuario.ToLower() == username.ToLower() && x.Passoword.ToLower() == password.ToLower()).Any();
        }

        public UsuarioModel ObtenerUsuario(string username, string password)
        {
            List<UsuarioModel> usuarios = dataUsuario.Leer();

            if (usuarios.Count == 0) return new UsuarioModel();

            List<UsuarioModel> retorno = usuarios.Where(x => x.Usuario.ToLower() == username.ToLower() && x.Passoword.ToLower() == password.ToLower()).ToList();

            return retorno.FirstOrDefault();
        }
    }
}
