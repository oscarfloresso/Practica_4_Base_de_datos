using System;
using MySql.Data.MySqlClient;

namespace Practica_4_Base_de_datos
{
    public class Contacto : MySql
    {
        public Contacto()
        {
        }

        public void mostrarTodos()
        {
            this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(),
            myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();
            if (!myReader.HasRows)
                Console.WriteLine("La base de datos esta vacia");
            while (myReader.Read())
            {
                string id = myReader["id"].ToString();
                string nombre = myReader["nombre"].ToString();
                string telefono = myReader["telefono"].ToString();
                Console.WriteLine("\nId: " + id +
                "\nNombre: " + nombre +
                "\nTelefono: " + telefono);
            }

            myReader.Close();
            myReader = null;
            myCommand.Dispose();
            myCommand = null;
            this.cerrarConexion();
        }

        public string consultaId(string id)
        {
            string consulta = "";
            this.abrirConexion();
            string query = "Select * From contacto Where id = ?id";
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("?id", id);
            MySqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                consulta = myReader["id"].ToString() +
                    myReader["nombre"].ToString() +
                    myReader["telefono"].ToString();
            }
            return consulta;
        }

        public void insertarRegistroNuevo(string nombre, string telefono)
        {
            this.abrirConexion();
            string sql = "INSERT INTO `contacto` (`nombre`, `telefono`) VALUES ('" + nombre + "', '" + telefono + "')";
            this.ejecutarComando(sql);
            this.cerrarConexion();
        }

        public void editarRegistro(string id, string nombre, string telefono)
        {
            this.abrirConexion();
            string sql = "UPDATE `contacto` SET `nombre`='" + nombre + "',`telefono`='" + telefono + "'  WHERE (`id`='" + id + "')";
            this.ejecutarComando(sql);
            this.cerrarConexion();
        }

        public void eliminarRegistroPorId(string id)
        {
            this.abrirConexion();
            string sql = "DELETE FROM `contacto` WHERE (`id`='" + id + "')";
            this.ejecutarComando(sql);
            this.cerrarConexion();
        }

        private int ejecutarComando(string sql)
        {
            MySqlCommand myCommand = new MySqlCommand(sql, this.myConnection);
            int afectadas = myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myCommand = null;
            return afectadas;
        }

        private string querySelect()
        {
            return "SELECT * " +
            "FROM contacto";
        }
    }
}