using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCompilador
{
    class ArgLim
    {
        private static String codigo;
        private static String posicao;
        private static String minimo;
        private static String maximo;
        private static String tipo;

        public static void setCodigo(String _codigo) { codigo = _codigo; }
        public static void setposicao(String _posicao) { posicao = _posicao; }
        public static void setminimo(String _minimo) { minimo = _minimo; }
        public static void setmaximo(String _maximo) { maximo = _maximo; }
        public static void settipo(String _tipo) { tipo = _tipo; }
        public static String getCodigo() { return codigo; }
        public static String getposicao() { return posicao; }
        public static String getminimo() { return minimo; }
        public static String getmaximo() { return maximo; }
        public static String gettipo() { return tipo; }
    }
}
