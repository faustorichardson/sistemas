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
    public partial class frmRegistroNovedades : frmBase
    {
        string cModo = "Inicio";
        string militarCedula = "";

        public frmRegistroNovedades()
        {
            InitializeComponent();
        }

        private void frmRegistroNovedades_Load(object sender, EventArgs e)
        {
            // Limpiando el form
            this.Limpiar();

            // Combos Population
            this.fillCmbTipoNovedad();

            // Funcion botones
            this.cModo = "Inicio";
            this.Botones();
        }

        private void fillCmbTipoNovedad()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, tipo FROM tiponovedad ORDER BY tipo ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("tipo", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbTipoNovedad.ValueMember = "id";
            cmbTipoNovedad.DisplayMember = "tipo";
            cmbTipoNovedad.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
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
                    this.cmbTipoNovedad.Enabled = false;
                    this.txtNovedad.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
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
                    this.cmbTipoNovedad.Enabled = true;
                    this.txtNovedad.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.btnBuscarMilitar.Enabled = true;
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
                    this.cmbTipoNovedad.Enabled = false;
                    this.txtNovedad.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
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
                    this.cmbTipoNovedad.Enabled = true;
                    this.txtNovedad.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.btnBuscarMilitar.Enabled = true;
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
                    this.cmbTipoNovedad.Enabled = false;
                    this.txtNovedad.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
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
                    this.cmbTipoNovedad.Enabled = false;
                    this.txtNovedad.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtCedula.Clear();
            this.txtRango.Clear();
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.txtNovedad.Clear();
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
                MyCommand.CommandText = "SELECT count(*) FROM novedades";

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

            if (txtCedula.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                this.txtCedula.Focus();
            }
            if (txtNovedad.Text == ""){
                MessageBox.Show("No se permiten campos vacios...");
                this.txtNovedad.Focus();
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
                        myCommand.CommandText = "INSERT INTO novedades(fecha, novedad_tipo, novedad_nota, oficial_supervisor) " +
                            " values(@fecha, @novedad_tipo, @novedad_nota, @oficial_supervisor)";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@novedad_tipo", cmbTipoNovedad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@novedad_nota", txtNovedad.Text);                                                
                        myCommand.Parameters.AddWithValue("@oficial_supervisor", txtCedula.Text);                        

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
                        myCommand.CommandText = "UPDATE novedades SET fecha = @fecha, novedad_tipo = @novedad_tipo, " +
                            "novedad_nota = @novedad_nota, oficial_supervisor = @oficial_supervisor " +
                            "WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@novedad_tipo", cmbTipoNovedad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@novedad_nota", txtNovedad.Text);
                        myCommand.Parameters.AddWithValue("@oficial_supervisor", txtCedula.Text);   

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
                cModo = "Inicio";
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
                    MyCommand.CommandText = "SELECT id, fecha, novedad_tipo, novedad_nota, oficial_supervisor " +
                        "FROM novedades WHERE id = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            dtFecha.Value = Convert.ToDateTime(MyReader["fecha"].ToString());
                            txtCedula.Text = MyReader["oficial_supervisor"].ToString();
                            militarCedula = MyReader["oficial_supervisor"].ToString();
                            txtNovedad.Text = MyReader["novedad_nota"].ToString();
                            cmbTipoNovedad.SelectedValue = MyReader["novedad_tipo"];                            
                        }

                        // Funcion que busca el rango y nombre del militar
                        this.BuscarMilitar();
                        // Funcion que modifica el estado de los botones
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

        private void BuscarMilitar()
        {
            try
            {
                // Step 1 - Conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - creating the command object
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3 - creating the commandtext
                MyCommand.CommandText = "SELECT militares.rango, militares.nombre, militares.apellido " +
                    "FROM militares WHERE cedula = '" + militarCedula + "'";

                // Step 4 - connection open
                MyConexion.Open();

                // Step 5 - Creating the DataReader                    
                MySqlDataReader MyReader = MyCommand.ExecuteReader();

                // Step 6 - Verifying if Reader has rows
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        txtRango.Text = MyReader["rango"].ToString();
                        txtNombre.Text = MyReader["nombre"].ToString();
                        txtApellido.Text = MyReader["apellido"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros con esta CEDULA...");
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
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
                throw;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmPrintListadoNovedades ofrmPrintListadoNovedades = new frmPrintListadoNovedades();
            ofrmPrintListadoNovedades.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtCedula.Text != "" || txtNovedad.Text != "")
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

        private void btnBuscarMilitar_Click(object sender, EventArgs e)
        {
            frmBuscarMilitar ofrmBuscarMilitar = new frmBuscarMilitar();
            ofrmBuscarMilitar.ShowDialog();
            string cCodigo = ofrmBuscarMilitar.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtCedula.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT * from militares WHERE cedula = '" + txtCedula.Text.Trim() + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtRango.Text = MyReader["rango"].ToString();
                            txtNombre.Text = MyReader["nombre"].ToString();
                            txtApellido.Text = MyReader["apellido"].ToString();
                        }
                        //this.cModo = "Buscar";
                        //this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con esta cedula...", "SisGesOfiEjecutivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.txtCedula.Focus();
                        //this.cModo = "Inicio";
                        //this.Botones();
                        //this.Limpiar();
                        //this.txtID.Focus();
                    }
                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyclsConexion.Close();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }
    }
}
