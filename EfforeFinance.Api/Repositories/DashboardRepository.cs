using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using EfforeFinance.Api.Models;

namespace EfforeFinance.Api.Repositories
{
    public class DashboardRepository
    {
        private readonly string _connectionString;

        public DashboardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public decimal ObterSaldoConta(int idConta)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_ObterSaldoConta", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("idConta", idConta);

                    conexao.Open();
                    var resultado = comando.ExecuteScalar();

                    return resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0m;
                }
            }
        }

        public List<ResumoDespesa> ObterResumoDespesas(int idUsuario, int mes, int ano)
        {
            var lista = new List<ResumoDespesa>();

            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("sp_ResumoDespesasMensais", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    comando.Parameters.AddWithValue("@mes", mes);
                    comando.Parameters.AddWithValue("@ano", ano);

                    conexao.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ResumoDespesa
                            {
                                Categoria = reader["Categoria"].ToString(),
                                ValorGasto = Convert.ToDecimal(reader["ValorGasto"]),
                                PorcentagemDaReceita = Convert.ToDecimal(reader["PorcentagemDaReceita"])
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
