using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniversáriosAgenda.BancoDeDados
{
    public class LocalDB
    {
        string stringDeConexao;
        public SqlConnection conn;
        public LocalDB()
        {
            try
            {
                stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BancoDeDados\Aniversariantes.mdf;Integrated Security=True";
                conn = new SqlConnection(stringDeConexao);
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SqlCommand(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 0;
                var read = cmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SqlQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 0;
                var read = cmd.ExecuteReader();
                dt.Load(read);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
