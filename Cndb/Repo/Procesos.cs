using Cndb.modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cndb.Repo
{
    public class Procesos
    {
        public string connectionString = "Data Source=DESKTOP-8DROPTB\\SQLEXPRESS;Initial Catalog=BdiExamen;Integrated Security=True;";
        public Infoestatus insertar(int Id, string Nombre, string Descripcion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spAgregar", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    SqlDataReader reader = command.ExecuteReader();
                    Infoestatus resul = null;
                    while (reader.Read())
                    {
                        bool estado = false;
                        if(int.Parse(reader[0].ToString()) == 0) { estado = true; }
                        resul = new Infoestatus
                        {
                            Estado = estado,
                            desc = reader.GetString(1)
                        };
                    }
                    return resul;
                }
                catch (SqlException ex)
                {
                    return new Infoestatus
                    {
                        Estado = false,
                        desc = ex.ToString()
                    };
                }
            }
        }
        public Infoestatus update(int Id, string Nombre, string Descripcion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spActualizar", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    SqlDataReader reader = command.ExecuteReader();
                    Infoestatus resul = null;
                    while (reader.Read())
                    {
                        bool estado = false;
                        if (int.Parse(reader[0].ToString()) == 0) { estado = true; }
                        resul = new Infoestatus
                        {
                            Estado = estado,
                            desc = reader.GetString(1)
                        };
                    }
                    return resul;
                }
                catch (SqlException ex)
                {
                    return new Infoestatus
                    {
                        Estado = false,
                        desc = "error"
                    };
                }
            }
        }
        public Infoestatus eliminar(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spEliminar", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);
                    SqlDataReader reader = command.ExecuteReader();
                    Infoestatus resul = null;
                    while (reader.Read())
                    {
                        bool estado = false;
                        if (int.Parse(reader[0].ToString()) == 0) { estado = true; }
                        resul = new Infoestatus
                        {
                            Estado = estado,
                            desc = reader.GetString(1)
                        };
                    }
                    return resul;
                }
                catch (SqlException ex)
                {
                    return new Infoestatus
                    {
                        Estado = false,
                        desc = "error"
                    };
                }
            }
        }

        public List<infotabla> mostrar(string Nombre, string Descripcion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spConsultar", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    SqlDataReader reader = command.ExecuteReader();
                    List<infotabla> es = new List<infotabla>();
                    while (reader.Read())
                    {
                        es.Add(new infotabla
                        {
                            idExample = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2)
                        });

                    }
                    return es;
                }
                catch (SqlException ex)
                {
                    return new List<infotabla>();
                }
            }
        }
    }
}
