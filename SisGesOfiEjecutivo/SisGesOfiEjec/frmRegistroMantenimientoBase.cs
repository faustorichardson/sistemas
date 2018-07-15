using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Web;
using CrystalDecisions.Windows;
using System.Drawing.Imaging;
using System.IO;

namespace SisGesOfiEjec
{
    public partial class frmRegistroMantenimientoBase : frmBase
    {

        string cModo = "Inicio";

        public frmRegistroMantenimientoBase()
        {
            InitializeComponent();
        }

        private void frmRegistroMantenimientoBase_Load(object sender, EventArgs e)
        {
            // Limpio el form
            this.Limpiar();

            // Combo population
            this.fillCmbActividad();

            // Funcion botones
            this.cModo = "Inicio";
            this.Botones();

        }

        private void fillCmbActividad()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, actividad FROM tipomantenimiento ORDER BY actividad ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("actividad", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbTipoActividad.ValueMember = "id";
            cmbTipoActividad.DisplayMember = "actividad";
            cmbTipoActividad.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        private void ProximoCodigo()
        {
            try
            {
                // Step 1 - Connection stablished
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Create command
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3 - Set the commanndtext property
                MyCommand.CommandText = "SELECT count(*) FROM mantenimientobase";

                // Step 4 - Open connection
                MyConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtID.Text = Convert.ToString(codigo);

                // Step 5 - Close the connection
                MyConexion.Close();
            }
            catch (MySqlException MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }
        }

        private void Botones()
        {
            switch (cModo)
            {
                case "Inicio":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = true;
                    this.dtFecha.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.cmbTipoActividad.Enabled = false;
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = false;
                    this.dtFecha.Enabled = true;
                    this.txtDescripcion.Enabled = true;
                    this.cmbTipoActividad.Enabled = true;
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = true;
                    this.dtFecha.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.cmbTipoActividad.Enabled = false;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = false;
                    this.dtFecha.Enabled = true;
                    this.txtDescripcion.Enabled = true;
                    this.cmbTipoActividad.Enabled = true;
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = true;
                    this.dtFecha.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.cmbTipoActividad.Enabled = false;
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = true;
                    this.dtFecha.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.cmbTipoActividad.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtDescripcion.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.Botones();
            this.ProximoCodigo();            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (txtID.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                this.txtID.Focus();
            }

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                this.txtDescripcion.Focus();
            }
            else
            {
                if (cModo == "Nuevo")
                {
                    try
                    {
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar                        
                        myCommand.CommandText = "INSERT INTO mantenimientobase(fecha, tipoactividad, descripcion) " +
                            " values(@fecha, @tipoactividad, @descripcion)";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@tipoactividad", cmbTipoActividad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        
                        // Step 4 - Opening the connection
                        MyConexion.Open();

                        // Step 5 - Executing the query
                        myCommand.ExecuteNonQuery();

                        // Step 6 - Closing the connection
                        MyConexion.Close();

                        MessageBox.Show("Informacion guardada satisfactoriamente...");

                    }
                    catch (Exception MyEx)
                    {
                        MessageBox.Show(MyEx.Message);
                    }

                }
                else
                {
                    try
                    {
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "UPDATE mantenimientobase SET fecha = @fecha, " +
                            "tipoactividad = @tipoactividad, descripcion = @descripcion " +
                            "WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@tipoactividad", cmbTipoActividad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

                        // Step 4 - Opening the connection
                        MyConexion.Open();

                        // Step 5 - Executing the query
                        myCommand.ExecuteNonQuery();

                        // Step 6 - Closing the connection
                        MyConexion.Close();

                        MessageBox.Show("Informacion actualizada satisfactoriamente...");
                    }
                    catch (Exception MyEx)
                    {
                        MessageBox.Show(MyEx.Message);
                    }

                }

                this.Limpiar();
                this.cModo = "Inicio";
                this.Botones();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("No se permiten busquedas vacias...");
                txtID.Focus();
            }
            else
            {
                try
                {
                    // Step 1 - Conexion
                    MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    MyCommand.CommandText = "SELECT id, fecha, tipoactividad, descripcion " +
                        "FROM mantenimientobase WHERE id = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            dtFecha.Value = Convert.ToDateTime(MyReader["fecha"]);
                            cmbTipoActividad.SelectedValue = MyReader["tipoactividad"].ToString();
                            txtDescripcion.Text = MyReader["descripcion"].ToString();
                        }

                        this.cModo = "Buscar";
                        this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        this.cModo = "Inicio";
                        this.Botones();
                        this.Limpiar();
                        this.txtID.Focus();
                    }

                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyConexion.Close();

                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmPrintListadoMantenimientoBase ofrmPrintListadoMantenimientoBase = new frmPrintListadoMantenimientoBase();
            ofrmPrintListadoMantenimientoBase.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtDescripcion.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema de Gestion Oficial Ejecutivo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.Yes:
                        cModo = "Actualiza";
                        btnGrabar_Click(sender, e);
                        break;
                }
            }

            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
