using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCompilador
{
    class AnalisadorSintaticoBLL
    {
        public static void validaSequencia()
        {
            Erro.setErro(false);
            MeuCompiladorDAL.populaGabarito(int.Parse(Token.getCodigo()));
            MeuCompiladorDAL.leGabarito();
            if (Erro.getErro())
            {
                Erro.setErro("Linha " + Token.getLinha() + "- token inesperado: " + Token.getToken());
                return;
            }
            
            while (!Erro.getErro())
            {
                if (Token.getCodigo() != Gabarito.getInfo())
                {
                    Erro.setErro("Linha " + Token.getLinha() + "- token inesperado: " + Token.getToken());
                    return;
                }
                if (Gabarito.getNext() != "eof") MeuCompiladorDAL.leUmTokenValido();
                MeuCompiladorDAL.leGabarito();
            }
            Erro.setErro(false);
        }

        public static void analiseSintatica()
        {

            MeuCompiladorDAL.populaDR();

            MeuCompiladorDAL.leUmTokenValido();
            while (Erro.getErro() == false)
            {
                validaSequencia();
                if (Erro.getErro()) return;
                MeuCompiladorDAL.leUmTokenValido();
            }
            Erro.setErro(false);
        }

    }
}
