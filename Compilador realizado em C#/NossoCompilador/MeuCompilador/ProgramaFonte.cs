using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCompilador
{
    class ProgramaFonte
    {
        private static String pathnome;

        public static void setPathNome(String _pathnome) { pathnome = _pathnome; }
        public static String getPathNome() { return pathnome; }
    }
}
