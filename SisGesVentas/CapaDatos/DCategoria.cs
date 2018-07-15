using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        // Variables que componen los campos de tabla de Categorias.
        private int _idCategoria;
        private string _Nombre;
        private string _Descripcion;

        // Variable adicional para busquedas.
        private string _TextoBuscar;
        
        // Encapsulamiento de las variables
        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        // Metodo Constructor
        public DCategoria()
        {
        }

        // Constructor con parametros
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.IdCategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        // METODOS

        // Metodo Insertar
        public string Insertar(DCategoria Categoria)
        {
            // Variable que devuelve la respuesta del resultado
            string Rpta = "";

            try
            {
                // PASO 1 Conexion
                MySqlConnection MyConexion = new MySqlConnection(Conexion.ConectionString);

                // PASO 2 Creo el comando de sentencia SQL
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // PASO 3 Paso los parametros de SQL al MySQLCommand
                MyCommand.CommandText = "spinsertar_categoria";

                // PASO 4 Indico al MyCommand que es del tipo Stored Procedure
                MyCommand.CommandType = CommandType.StoredProcedure;

                // PASO 5 Paso parametros de las variables al Stored Procedure
                
                // IDCategoria
                MySqlParameter ParIDCategoria = new MySqlParameter();
                ParIDCategoria.ParameterName = "idcategoria";
                //ParIDCategoria.DbType = MySqlDbType.Int32;
                ParIDCategoria.Direction = ParameterDirection.Output;
                MyCommand.Parameters.Add(ParIDCategoria);

                // Nombre
                MySqlParameter ParNombre = new MySqlParameter();
                ParNombre.ParameterName = "nombre";
                //ParIDCategoria.DbType = MySqlDbType.Int32;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                ParNombre.Direction = ParameterDirection.Input;
                MyCommand.Parameters.Add(ParNombre);

                // Descripcion
                MySqlParameter ParDescripcion = new MySqlParameter();
                ParDescripcion.ParameterName = "descripcion";
                //ParIDCategoria.DbType = MySqlDbType.Int32;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Categoria.Descripcion;
                ParDescripcion.Direction = ParameterDirection.Input;
                MyCommand.Parameters.Add(ParDescripcion);

                // PASO 6 Ejecutamos el MyCommand
                Rpta = MyCommand.ExecuteNonQuery()==1? "OK":"No se ingreso el registro...";

                // Cierro la conexion (si persiste abierta)
                if (MyConexion.State == ConnectionState.Open) MyConexion.Close();
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
                throw;
            }
            finally
            {
                
            }

            return Rpta;
        }

        // Metodo Actualizar
        public string Editar(DCategoria Categoria)
        {
            // Variable que devuelve la respuesta del resultado
            string Rpta = "";

            try
            {
                // PASO 1 Conexion
                MySqlConnection MyConexion = new MySqlConnection(Conexion.ConectionString);

                // PASO 2 Creo el comando de sentencia SQL
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // PASO 3 Paso los parametros de SQL al MySQLCommand
                MyCommand.CommandText = "speditar_categoria";

                // PASO 4 Indico al MyCommand que es del tipo Stored Procedure
                MyCommand.CommandType = CommandType.StoredProcedure;

                // PASO 5 Paso parametros de las variables al Stored Procedure

                // IDCategoria
                MySqlParameter ParIDCategoria = new MySqlParameter();
                ParIDCategoria.ParameterName = "idcategoria";
                //ParIDCategoria.DbType = MySqlDbType.Int32;
                ParIDCategoria.Value = Categoria.IdCategoria;
                ParIDCategoria.Direction = ParameterDirection.Input;                
                MyCommand.Parameters.Add(ParIDCategoria);

                // Nombre
                MySqlParameter ParNombre = new MySqlParameter();
                ParNombre.ParameterName = "nombre";
                //ParIDCategoria.DbType = MySqlDbType.Int32;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                ParNombre.Direction = ParameterDirection.Input;
                MyCommand.Parameters.Add(ParNombre);

                // Descripcion
                MySqlParameter ParDescripcion = new MySqlParameter();
                ParDescripcion.ParameterName = "descripcion";
                //ParIDCategoria.DbType = MySqlDbType.Int32;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Categoria.Descripcion;
                ParDescripcion.Direction = ParameterDirection.Input;
                MyCommand.Parameters.Add(ParDescripcion);

                // PASO 6 Ejecutamos el MyCommand
                Rpta = MyCommand.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro...";

                // Cierro la conexion (si persiste abierta)
                if (MyConexion.State == ConnectionState.Open) MyConexion.Close();
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
                throw;
            }
            finally
            {

            }

            return Rpta;
        }

        // Metodo Eliminar
        public string Eliminar(DCategoria Categoria)
        {
            // Variable que devuelve la respuesta del resultado
            string Rpta = "";

            try
            {
                // PASO 1 Conexion
                MySqlConnection MyConexion = new MySqlConnection(Conexion.ConectionString);

                // PASO 2 Creo el comando de sentencia SQL
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // PASO 3 Paso los parametros de SQL al MySQLCommand
                MyCommand.CommandText = "speliminar_categoria";

                // PASO 4 Indico al MyCommand que es del tipo Stored Procedure
                MyCommand.CommandType = CommandType.StoredProcedure;

                // PASO 5 Paso parametros de las variables al Stored Procedure

                // IDCategoria
                MySqlParameter ParIDCategoria = new MySqlParameter();
                ParIDCategoria.ParameterName = "idcategoria";
                //ParIDCategoria.DbType = MySqlDbType.Int32;
                ParIDCategoria.Value = Categoria.IdCategoria;
                ParIDCategoria.Direction = ParameterDirection.Input;
                MyCommand.Parameters.Add(ParIDCategoria);

                //// Nombre
                //MySqlParameter ParNombre = new MySqlParameter();
                //ParNombre.ParameterName = "nombre";
                ////ParIDCategoria.DbType = MySqlDbType.Int32;
                //ParNombre.Size = 50;
                //ParNombre.Value = Categoria.Nombre;
                //ParNombre.Direction = ParameterDirection.Input;
                //MyCommand.Parameters.Add(ParNombre);

                //// Descripcion
                //MySqlParameter ParDescripcion = new MySqlParameter();
                //ParDescripcion.ParameterName = "descripcion";
                ////ParIDCategoria.DbType = MySqlDbType.Int32;
                //ParDescripcion.Size = 250;
                //ParDescripcion.Value = Categoria.Descripcion;
                //ParDescripcion.Direction = ParameterDirection.Input;
                //MyCommand.Parameters.Add(ParDescripcion);

                // PASO 6 Ejecutamos el MyCommand
                Rpta = MyCommand.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro...";

                // Cierro la conexion (si persiste abierta)
                if (MyConexion.State == ConnectionState.Open) MyConexion.Close();
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
                throw;
            }
            finally
            {

            }

            return Rpta;
        }

        // Metodo Mostrar
        public DataTable Mostrar()
        {
            // Declaro una variable del tipo Datatable para traer los resultados
            DataTable DtResultado = new DataTable("categoria");
            
            try
            {
                // PASO 1 Defino los parametros de conexion
                MySqlConnection MyConexion = new MySqlConnection(Conexion.ConectionString);

                // PASO 2 Creo el comando
                MySqlCommand MyCommand = MyConexion.CreateCommand();
                
                // PASO 3 Invoco el Stored Procedure
                MyCommand.CommandText = "spmostrar_categoria";

                // PASO 4 Digo que tipo de datos es el MyCommand
                MyCommand.CommandType = CommandType.StoredProcedure;

                // PASO 5 Defino mi variable Data Adapter
                MySqlDataAdapter MyData = new MySqlDataAdapter(MyCommand);

                // PASO 5 lleno el data adapter
                MyData.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
                throw;
            }

            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            // Declaro una variable del tipo Datatable para traer los resultados
            DataTable DtResultado = new DataTable("categoria");

            try
            {
                // PASO 1 Defino los parametros de conexion
                MySqlConnection MyConexion = new MySqlConnection(Conexion.ConectionString);

                // PASO 2 Creo el comando
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // PASO 3 Invoco el Stored Procedure
                MyCommand.CommandText = "spbuscar_categoria";

                // PASO 4 Digo que tipo de datos es el MyCommand
                MyCommand.CommandType = CommandType.StoredProcedure;

                // PASO 5 Defino los parametros de las variables
                MySqlParameter ParTextoBuscar = new MySqlParameter();
                ParTextoBuscar.ParameterName = "textobuscar";
                ParTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                MyCommand.Parameters.Add(ParTextoBuscar);

                // PASO 6 Defino mi variable Data Adapter
                MySqlDataAdapter MyData = new MySqlDataAdapter(MyCommand);

                // PASO 7 lleno el data adapter
                MyData.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
                throw;
            }

            return DtResultado;
        }
    }
}
