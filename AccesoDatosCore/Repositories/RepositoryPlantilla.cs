using System.Data.SqlClient;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Repositories
{
    public class RepositoryPlantilla
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryPlantilla(string cadenaConexion)
        {
            this.cn = new SqlConnection(cadenaConexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        //METODO PARA DEVOLVER TODAS LAS PERSONAS DE LA PLANTILLA
        public List<Plantilla> GetPlantilla()
        {
            string sql = "SELECT * FROM PLANTILLA";
            List<Plantilla> lista = new List<Plantilla>();
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Plantilla plan = new Plantilla();
                plan.IdPlantilla = int.Parse(this.reader["EMPLEADO_NO"].ToString());
                plan.Apellido = this.reader["APELLIDO"].ToString();
                plan.Funcion = this.reader["FUNCION"].ToString();
                plan.Salario = int.Parse(this.reader["SALARIO"].ToString());
                lista.Add(plan);
            }
            this.reader.Close();
            this.cn.Close();
            return lista;
        }

        public List<Plantilla> GetPlantillaFuncion(string funcion)
        {
            string sql = "SELECT * FROM PLANTILLA WHERE FUNCION=@FUNCION";
            List<Plantilla> lista = new List<Plantilla>();
            SqlParameter pamfuncion = new SqlParameter("@FUNCION", funcion);
            this.com.Parameters.Add(pamfuncion);
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Plantilla plan = new Plantilla();
                plan.IdPlantilla = int.Parse(this.reader["EMPLEADO_NO"].ToString());
                plan.Apellido = this.reader["APELLIDO"].ToString();
                plan.Funcion = this.reader["FUNCION"].ToString();
                plan.Salario = int.Parse(this.reader["SALARIO"].ToString());
                lista.Add(plan);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return lista;
        }
    }
}
