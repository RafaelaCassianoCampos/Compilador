using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCompilador
{
    class IndiceLib
    {
        private static String codigo;
        private static String inicio;
        private static String tamanho;
 
        public static void setCodigo(String _codigo) { codigo = _codigo; }
        public static void setInicio(String _inicio) { inicio = _inicio; }
        public static void setTamanho(String _tamanho) { tamanho = _tamanho; }
        public static String getCodigo() { return codigo; }
        public static String getInicio() { return inicio; }
        public static String getTamanho() { return tamanho; }

    }
}
