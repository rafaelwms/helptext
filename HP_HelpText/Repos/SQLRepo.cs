using EasyDescriptionProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDescriptionProvider.Repos
{
    public static class SQLRepo
    {
        
        /// <summary>
        /// Método estático para executar um script DML
        /// </summary>
        /// <param name="commandSql"></param>
        public static void ExecutarComando(string commandSql) 
        {
            SqlConnection conn = new SqlConnection(@"Data Source=WIN-Y4344BT7QG\SQLEXPRESS;Initial Catalog=hp_helptext;Integrated Security=True");
            try 
            { 
                SqlCommand comando = new SqlCommand(commandSql, conn);
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Retorna um DataTable de uma consulta
        /// </summary>
        /// <param name="query"></param>
        /// <returns>System.Data.DataTable</returns>
        public static System.Data.DataTable ObterQuery(string query)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=WIN-Y4344BT7QG\SQLEXPRESS;Initial Catalog=hp_helptext;Integrated Security=True");
            System.Data.DataTable resultado = new System.Data.DataTable();
            try
            {
                using (conn)
                {
                    SqlCommand sqlCommand = new SqlCommand(query, conn);
                    sqlCommand.CommandTimeout = 0;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(resultado);
                }
            }
            catch (Exception)
            {
                throw new Exception("Favor, verifique sua conexão com a VPN.");
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }


    }
}
