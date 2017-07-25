using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace MeuCompilador
{
    class MeuCompiladorDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Compilador.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader resultAS, resultgab, resultqtdarg, resultlimites;

        public static void conecta()
        {
            Erro.setErro(false);
            try
            {
                conn.Open();
            }
            catch
            {
                Erro.setErro("A conexão falhou!");
                return;
            }
        }

        public static void desconecta()
        {
            conn.Close();
        }

        public static void inseriUmTokenValido()
        {
            String aux = "insert into TTokensValidos(codigo,token,tipo,linha) values (" + Token.getCodigo() + ",'" + Token.getToken() + "','" + Token.getTipo() + "'," + Token.getLinha() + ")";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }

        public static void deletaTTokensValidos()
        {
            String aux = "delete * from TTokensValidos";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }

        public static void deletaDelimitadores()
        {
            String aux = "delete * from TTokensValidos where Tipo = 'Delimitador'";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }

        public static void consultaUmToken()
        {
            OleDbDataReader result;
            String aux = "select * from TTokens where Token ='" + Token.getToken() + "'";

            strSQL = new OleDbCommand(aux, conn);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
                Token.setCodigo("" + result.GetInt32(0));
            else
                Erro.setErro("Linha " + Token.getLinha() + ": " + Token.getToken() + " (Token não identificado)");
        }

        public static void consultaIndiceLib()
        {
            OleDbDataReader resultInd;
            String aux = "select * from TIndLib where codigo =" + Token.getCodigo();

            strSQL = new OleDbCommand(aux, conn);
            resultInd = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (resultInd.Read())
            {
                IndiceLib.setInicio("" + resultInd.GetInt32(1));
                IndiceLib.setTamanho("" + resultInd.GetInt32(2));
            }
        }
        public static void populaDR()
        {
            String aux = "select * from TTokensValidos";

            strSQL = new OleDbCommand(aux, conn);
            resultAS = strSQL.ExecuteReader();
        }

        public static void leUmTokenValido()
        {
            Erro.setErro(false);
            if (resultAS.Read())
            {
                Token.setCodigo("" + resultAS.GetInt32(0));
                Token.setToken(resultAS.GetString(1));
                Token.setTipo(resultAS.GetString(2));
                Token.setLinha("" + resultAS.GetInt32(3));
            }
            else
                Erro.setErro(true);

        }

        public static void populaGabarito(int _code)
        {
            String aux = "select * from gabarito where code = " + _code;

            strSQL = new OleDbCommand(aux, conn);
            resultgab = strSQL.ExecuteReader();
        }

        public static void leGabarito()
        {
            Erro.setErro(false);
            if (resultgab.Read())
            {
                Gabarito.setCode("" + resultgab.GetInt32(0));
                Gabarito.setPrior(resultgab.GetString(1));
                Gabarito.setInfo("" + resultgab.GetInt32(2));
                Gabarito.setNext(resultgab.GetString(3));
            }
            else
                Erro.setErro(true);
        }

        public static int leQtdArgumentos()
        {
            String aux = "select * from TQtdArgumentos where Codigo =" + Token.getCodigo();

            strSQL = new OleDbCommand(aux, conn);
            resultqtdarg = strSQL.ExecuteReader();
            resultqtdarg.Read();
            return resultqtdarg.GetInt32(1);
        }

        public static void leUmLimite()
        {
            String aux = "select * from TArgLimites where codigo =" + ArgLim.getCodigo() + " and posicao =" + ArgLim.getposicao();

            strSQL = new OleDbCommand(aux, conn);
            resultlimites = strSQL.ExecuteReader();
            if (resultlimites.Read())
            {
                ArgLim.setminimo("" + resultlimites.GetInt32(2));
                ArgLim.setmaximo("" + resultlimites.GetInt32(3));
                ArgLim.settipo(resultlimites.GetString(4));
            }
        }

    }
}
