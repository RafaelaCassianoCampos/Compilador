using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCompilador
{
    class AnalisadorSemanticoBLL
    {
        public static void analiseSemantica()
        {
            Erro.setErro(false);
            MeuCompiladorDAL.deletaDelimitadores();
            MeuCompiladorDAL.populaDR();
            MeuCompiladorDAL.leUmTokenValido();
            while (Erro.getErro() == false)
            {
                int aux = MeuCompiladorDAL.leQtdArgumentos();
                for (int i = 0; i < aux; ++i)
                {
                    ArgLim.setCodigo(Token.getCodigo());
                    ArgLim.setposicao("" + i);
                    MeuCompiladorDAL.leUmLimite();
                    MeuCompiladorDAL.leUmTokenValido();
                    if (int.Parse(Token.getToken()) < int.Parse(ArgLim.getminimo()) || int.Parse(Token.getToken()) > int.Parse(ArgLim.getmaximo()))
                    {
                        Erro.setErro("Linha " + Token.getLinha() + ": valor fora da faixa (" + Token.getToken() + ")");
                        return;
                    }
                }
                MeuCompiladorDAL.leUmTokenValido();
            }
            Erro.setErro(false);
        }
    }
}
