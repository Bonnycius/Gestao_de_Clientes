using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_de_Clientes
{
    internal class CadastroUsuario
    {
        private static Usuario[] usuarios = {
            new Usuario() {Usuarios ="Vinicius", Senha="123456"}
        };

        private static Usuario _userLogado = null;

        public static Usuario UsuarioLogado { get { return _userLogado; } private set { _userLogado = value; } }
        public static bool Login(string usuario, string senha)
        {
            foreach (Usuario usuarios1 in usuarios)
            {
                if ( usuarios1.Usuarios == usuario && usuarios1.Senha == senha)
                {
                    UsuarioLogado = usuarios1;
                    return true;
                }
            }
            return false;
        }
    }
}
