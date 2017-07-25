using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCompilador
{
    class Gabarito
    {
        private static String code;
        private static String prior;
        private static String info;
        private static String next;

        public static void setCode(String _code) { code = _code; }
        public static void setPrior(String _prior) { prior = _prior; }
        public static void setInfo(String _info) { info = _info; }
        public static void setNext(String _next) { next = _next; }

        public static String getCode() { return code; }
        public static String getPrior() { return prior; }
        public static String getInfo() { return info; }
        public static String getNext() { return next; }
    }
}
