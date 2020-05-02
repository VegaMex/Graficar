using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Conector
    {
        private static string ObtenerCadenaDeConexion()
        {
            string servidor = "localhost"; // IP del servidor
            string puerto = "3306"; // Puerto
            string usuario = "root"; // Usuario
            string password = "root"; // Contraseña
            string database = "world"; // Base da datos
            string allow = "true";
            return String.Format("Server={0};Database={4};Uid={2};Pwd={3};Allow User Variables={5};", servidor, puerto, usuario, password, database, allow);
        }

        public DataTable ObtenDatosSQL(string comandoSQL)
        {
            return ObtenDatosSQL(comandoSQL, new string[] { }, new object[] { });
        }

        public DataTable ObtenDatosSQL(string comandoSQL, string[] columnas, object[] valores)
        {
            DataTable dataTable = null;
            var conexionSQL = new MySqlConnection();

            try
            {
                var adaptadorSQL = new MySqlDataAdapter();
                var comandoEjecutable = HazComandoEjecutable(columnas, valores);
                var dataSet = new DataSet();

                conexionSQL.ConnectionString = ObtenerCadenaDeConexion();
                conexionSQL.Open();
                comandoEjecutable.CommandText = comandoSQL;

                adaptadorSQL.SelectCommand = comandoEjecutable;
                adaptadorSQL.SelectCommand.Connection = conexionSQL;
                adaptadorSQL.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            finally
            {
                conexionSQL.Close();
            }

            return dataTable;
        }

        private static MySqlCommand HazComandoEjecutable(string[] columnas, object[] claves)
        {
            var comandoEjecutable = new MySqlCommand();

            int menor = Math.Min(columnas.Length, claves.Length);
            for (int i = 0; i < menor; i++)
            {
                comandoEjecutable.Parameters.AddWithValue("@" + columnas[i], claves[i]);
            }

            return comandoEjecutable;
        }
    }
}
