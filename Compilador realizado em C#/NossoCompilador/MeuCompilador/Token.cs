using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCompilador
{
    class Token
    {
        private static String codigo;
        private static String token;
        private static String tipo;
        private static String linha;

        public static void setCodigo(String _codigo) { codigo = _codigo; }
        public static void setToken(String _token) { token = _token; }
        public static void setTipo(String _tipo) { tipo = _tipo; }
        public static void setLinha(String _linha) { linha = _linha; }
        public static String getCodigo() { return codigo; }
        public static String getToken() { return token; }
        public static String getTipo() { return tipo; }
        public static String getLinha() { return linha; }
    }
}
