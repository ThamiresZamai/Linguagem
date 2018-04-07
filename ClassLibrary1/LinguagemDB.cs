using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace BancoDadosDB

{
    public class LinguagemDB
    {
        private DB db;
        public bool Insert(Linguagem linguagem)
        {
            try
            {
                string sql = "INSERT INTO Linguagem (NOME, PONTUACAO) VALUES ('" + linguagem.nome + "' " + ",'" + linguagem.pontuacao + "' )";

                using (db = new DB())
                {
                    db.ExecutarComando(sql);
                }
            }
            catch (Exception e)
            {

                return false;
            }
            return true;
        }

        public List<Linguagem> ListarTipo()
        {
            using (db = new DB())
            {
                var sql = "SELECT id, NOME, PONTUACAO FROM LINGUAGEM";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);

            }
        }

        private List<Linguagem> TransformaSQLReaderEmList
            (SqlDataReader retorno)
        {
            var listMensagem = new List<Linguagem>();

            while (retorno.Read())
            {
                var item = new Linguagem()
                {
                    nome = retorno["Nome"].ToString(),
                    pontuacao = Convert.ToInt32(retorno["Pontuacao"].ToString()),
                };
                listMensagem.Add(item);
            }
            return listMensagem;
        }
    }
}
