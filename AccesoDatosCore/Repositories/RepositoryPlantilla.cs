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

        //METODO PARA DEVOLVER LAS DIFERENTES FUNCIONES
        public List<string> GetFunciones()
        {
            string sql = "SELECT DISTINCT FUNCION FROM PLANTILLA";
            this.com.CommandText = sql;
            List<string> funciones = new List<string>();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string funcion = this.reader["FUNCION"].ToString();
                funciones.Add(funcion);
            }
            this.reader.Close();
            this.cn.Close();
            return funciones;
        }

        public int IncrementarSalariosFunciones(string funcion, int incremento)
        {
            string sql = "UPDATE PLANTILLA SET SALARIO = SALARIO + @INCREMENTO WHERE FUNCION=@FUNCION";
            SqlParameter pamfuncion = new SqlParameter("@FUNCION", funcion);
            SqlParameter pamincremento = new SqlParameter("@INCREMENTO", incremento);
            this.com.Parameters.Add(pamfuncion);
            this.com.Parameters.Add(pamincremento);
            this.com.CommandText = sql;
            this.cn.Open();
            int modificados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return modificados;
        }
    }
}
