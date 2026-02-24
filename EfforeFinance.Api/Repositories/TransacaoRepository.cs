using System;
using System.Data;
using Microsoft.Data.SqlClient;
using EfforeFinance.Api.Models;

namespace EfforeFinance.Api.Repositories
{
    public class TransacaoRepository
    {
        private readonly string _connectionString;

        public TransacaoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InserirTransacao(Transacao transacao)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_InserirTransacao", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@idConta", transacao.idConta);
                    comando.Parameters.AddWithValue("@idCategoria", transacao.idCategoria);
                    comando.Parameters.AddWithValue("@vlTransacao", transacao.vlTransacao);
                    comando.Parameters.AddWithValue("@dtTransacao", transacao.dtTransacao);
                    comando.Parameters.AddWithValue("@deTransacao", transacao.deTransacao);
                    comando.Parameters.AddWithValue("@tpTransacao", transacao.tpTransacao);
                    comando.Parameters.AddWithValue("@statusTransacao", transacao.statusTransacao);

                    conexao.Open();

                    var resultado = comando.ExecuteScalar();

                    return Convert.ToInt32(resultado);
                }
            }
        }
    }
}
