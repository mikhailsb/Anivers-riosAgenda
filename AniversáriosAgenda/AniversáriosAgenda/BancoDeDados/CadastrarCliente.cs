using AniversáriosAgenda.Classe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniversáriosAgenda.BancoDeDados
{
    public class CadastrarCliente
    {
        LocalDB db;
        public CadastrarCliente()
        {
            db = new LocalDB();
        }
        public void IncluirCliente(Aniversariante niver)
        {
            try
            {
                var SQL = $@"INSERT INTO Aniversariante (Nome, DataNacimento, Descricao) 
                    VALUES('{niver.Nome}', '{niver.DataNacimento.ToString("dd/MM/yyyy")}', '{niver.Descricao}')";

                db.SqlCommand(SQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AlterarCliente(Aniversariante niver)
        {
            try
            {
                var SQL = $@"UPDATE Aniversariante SET Nome = '{niver.Nome}', DataNacimento = '{niver.DataNacimento.ToString("dd/MM/yyyy")}', Descricao = '{niver.Descricao}'
                            WHERE Id = {niver.Id}";

                db.SqlCommand(SQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeletarCliente(Aniversariante niver)
        { }
        public DataTable RetornarClientes()
        {
            try
            {
                string sql = "SELECT * FROM [dbo].[Aniversariante]";
                var retorno = db.SqlQuery(sql);
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
