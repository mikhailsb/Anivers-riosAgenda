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
                //stringDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BancoDeDados\Aniversariantes.mdf;Integrated Security=True";
                stringDeConexao = @"Server=.\sqlexpress;Database=Aniversariantes;Trusted_Connection=True;";
                //stringDeConexao = @"Server=localhost;Database=Aniversariantes;Trusted_Connection=True";
                                  //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BancoDeDados\Aniversariantes.mdf;Integrated Security=True
                conn = new SqlConnection(stringDeConexao);
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
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 0;
                var read = cmd.ExecuteNonQuery();
                conn.Close();
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
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 0;
                var read = cmd.ExecuteReader();
                dt.Load(read);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
