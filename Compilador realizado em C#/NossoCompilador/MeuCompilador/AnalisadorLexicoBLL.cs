using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MeuCompilador
{
    class AnalisadorLexicoBLL
    {
        public static void filtro()
        {
            FileStream infile, outfile;
            int tam;
            char x;

            infile = new System.IO.FileStream(ProgramaFonte.getPathNome(),
                                               System.IO.FileMode.Open,
                                               System.IO.FileAccess.Read);
            outfile = new System.IO.FileStream("pftmp.txt",
                                               System.IO.FileMode.Create,
                                               System.IO.FileAccess.Write);

            tam = (int)infile.Length;
            for (int i = 0; i < tam; ++i)
            {
                x = (char)infile.ReadByte();
                if (x == '#')
                {
                    ++i;
                    do
                    {
                        x = (char)infile.ReadByte();
                        ++i;
                    }
                    while (x != '#');
                }
                else
                    if (x != ' ')
                        outfile.WriteByte((byte)char.ToUpper(x));
            }
            infile.Close();
            outfile.Close();
        }

        public static void scanner()
        {
            FileStream infile;
            int tam;
            int kl = 1;
            char x;
            String aux="";

            infile = new System.IO.FileStream("pftmp.txt",
                                               System.IO.FileMode.Open,
                                               System.IO.FileAccess.Read);
            
            MeuCompiladorDAL.deletaTTokensValidos();
            tam = (int)infile.Length;
            for (int i = 0; i < tam; ++i)
            {
                x = (char)infile.ReadByte();

                if (char.IsDigit(x))
                {
                    while (char.IsDigit(x))
                    {
                        aux = aux + x;
                        x = (char)infile.ReadByte();
                        ++i;
                    }
                    Token.setCodigo("200");
                    Token.setToken(aux);
                    Token.setTipo("Inteiro");
                    Token.setLinha(kl.ToString());
                    MeuCompiladorDAL.inseriUmTokenValido();
                    aux = "";
                }
                
                if (char.IsLetter(x))
                {
                    aux = "";
                    while (char.IsLetter(x))
                    {
                        aux = aux + x;
                        x = (char)infile.ReadByte();
                        ++i;
                    }
                    Token.setToken(aux);
                    Token.setTipo("String");
                    Token.setLinha(kl.ToString());
                    MeuCompiladorDAL.consultaUmToken();
                    if (Erro.getErro())
                        return;
                    else
                        MeuCompiladorDAL.inseriUmTokenValido();
                    aux = "";
                }

                if (char.IsPunctuation(x) || char.IsSymbol(x))
                {
                    Token.setToken(x.ToString());
                    Token.setTipo("Delimitador");
                    Token.setLinha(kl.ToString());
                    MeuCompiladorDAL.consultaUmToken();
                    if (Erro.getErro())
                        return;
                    else
                        MeuCompiladorDAL.inseriUmTokenValido();
                }
                
                if (x == 13) ++kl;
                
            }
            infile.Close();
        }

    }
}
