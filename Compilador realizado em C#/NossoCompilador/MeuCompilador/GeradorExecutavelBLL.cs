using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MeuCompilador
{
    class GeradorExecutavelBLL
    {
        private static FileStream infile, outfile;
        
        public static void gravaCodigo()
        {
            int tam, qtdargs, pos;
            String aux;
            char x;

            infile = new System.IO.FileStream("pontocom.lib", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            MeuCompiladorDAL.consultaIndiceLib();
            infile.Position = int.Parse(IndiceLib.getInicio());
            tam = int.Parse(IndiceLib.getTamanho());
            qtdargs = MeuCompiladorDAL.leQtdArgumentos();
            pos = 0;
            aux = Token.getCodigo();
            for (int i = 0; i < tam; ++i)
            {
                x = (char)infile.ReadByte();
                outfile.WriteByte((byte)(x));
                if (qtdargs != 0)
                {
                    MeuCompiladorDAL.leUmTokenValido();
                    ArgLim.setCodigo(aux);
                    ArgLim.setposicao("" + pos);
                    MeuCompiladorDAL.leUmLimite();
                    if (ArgLim.gettipo().Equals("c"))
                        outfile.WriteByte(byte.Parse("" + (48 + int.Parse(Token.getToken()))));
                    else
                        outfile.WriteByte(byte.Parse(Token.getToken()));
                    infile.ReadByte();
                    ++i;
                    ++pos;
                    --qtdargs;
                }

            }
            infile.Close();
        }
        public static void geraExecutavel()
        {
            outfile = new System.IO.FileStream("PROGRAMA.COM",System.IO.FileMode.Create,System.IO.FileAccess.Write);

            MeuCompiladorDAL.populaDR();
            MeuCompiladorDAL.leUmTokenValido();
            while (Erro.getErro() == false)
            {
                if  (int.Parse(Token.getCodigo()) <100)
                {
                    gravaCodigo(); 
                }
                MeuCompiladorDAL.leUmTokenValido();
            }
            Erro.setErro(false);
            outfile.Close();
        }
    }
}
