using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        // METODOS PARA COMUNICARSE CON CAPA DE DATOS

        // Metodo INSERTAR que llama el Metodo INSERTAR de la clase DCategoria
        // de la CAPA DATOS

        public static string Insertar(string nombre, string descripcion)
        {
            // Instanciamiento de mi clase DCategoria
            DCategoria Obj = new DCategoria();

            // Creo los objetos de instanciamiento
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            // Defino el Retorno
            return Obj.Insertar(Obj);
        }

        // Metodo EDITAR que llama el Metodo EDITAR de la clase DCategoria
        // de la CAPA DATOS
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            // Instanciamiento de mi clase DCategoria
            DCategoria Obj = new DCategoria();

            // Creo los objetos de instanciamiento
            Obj.IdCategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            // Defino el Retorno
            return Obj.Editar(Obj);
        }

        // Metodo ELIMINAR que llama el Metodo ELIMINAR de la clase DCategoria
        // de la CAPA DATOS
        public static string Eliminar(int idcategoria)
        {
            // Instanciamiento de mi clase DCategoria
            DCategoria Obj = new DCategoria();

            // Creo los objetos de instanciamiento
            Obj.IdCategoria = idcategoria;
            
            // Defino el Retorno
            return Obj.Eliminar(Obj);
        }

        // Metodo MOSTRAR que llama el Metodo MOSTRAR de la clase DCategoria
        // de la CAPA DATOS
        public DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        // Metodo BUSCAR que llama el Metodo BUSCAR de la clase DCategoria
        // de la CAPA DATOS
        public static DataTable BuscarNombre(string textobuscar)
        {
            // Defino el objeto
            DCategoria Obj = new DCategoria();

            // Indico el valor a buscar
            Obj.TextoBuscar = textobuscar;
            
            // Retorno el objeto
            return Obj.BuscarNombre(Obj);
        }
    }
}
