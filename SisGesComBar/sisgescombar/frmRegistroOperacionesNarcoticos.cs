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

namespace SisGesComBar
{
    public partial class frmRegistroOperacionesNarcoticos : frmBase
    {
        string cModo = "Inicio";

        public frmRegistroOperacionesNarcoticos()
        {
            InitializeComponent();
        }

        private void frmRegistroOperacionesNarcoticos_Load(object sender, EventArgs e)
        {
            // Limpiando campos
            this.Limpiar();

            // Llenando los combos
            this.fillCmbTipoDroga();
            this.fillCmbUnidadNaval();
            this.fillCmbProvincia();

            // Funcion botones
            this.cModo = "Inicio";
            this.Botones();
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
                MyCommand.CommandText = "SELECT count(*) FROM ops_antinarcoticos";

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

        private void fillCmbProvincia()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT provincia_id, nombre FROM provincias ORDER BY nombre ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("provincia_id", typeof(int));
            MyDataTable.Columns.Add("nombre", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbProvincia.ValueMember = "provincia_id";
            cmbProvincia.DisplayMember = "nombre";
            cmbProvincia.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        private void fillCmbUnidadNaval()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, unidad FROM unidades ORDER BY unidad ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("unidad", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbUnidadNaval.ValueMember = "id";
            cmbUnidadNaval.DisplayMember = "unidad";
            cmbUnidadNaval.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        private void fillCmbTipoDroga()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, tipo FROM tipodrogas ORDER BY tipo ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("tipo", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbTipoDroga.ValueMember = "id";
            cmbTipoDroga.DisplayMember = "tipo";
            cmbTipoDroga.DataSource = MyDataTable;

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
                    this.dtFecha.Enabled = false;
                    this.cmbUnidadNaval.Enabled = false;
                    this.cmbTipoDroga.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    this.txtCantidad.Enabled = false;
                    this.cmbProvincia.Enabled = false;
                    this.txtNota.Enabled = false;
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
                    this.cmbUnidadNaval.Enabled = true;
                    this.cmbTipoDroga.Enabled = true;
                    this.btnBuscarMilitar.Enabled = true;
                    this.txtCantidad.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    this.txtNota.Enabled = true;
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
                    this.cmbUnidadNaval.Enabled = false;
                    this.cmbTipoDroga.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    this.txtCantidad.Enabled = false;
                    this.cmbProvincia.Enabled = false;
                    this.txtNota.Enabled = false;
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
                    this.cmbUnidadNaval.Enabled = true;
                    this.cmbTipoDroga.Enabled = true;
                    this.btnBuscarMilitar.Enabled = true;
                    this.txtCantidad.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    this.txtNota.Enabled = true;
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
                    this.cmbUnidadNaval.Enabled = false;
                    this.cmbTipoDroga.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    this.txtCantidad.Enabled = false;
                    this.cmbProvincia.Enabled = false;
                    this.txtNota.Enabled = false;
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
                    this.cmbUnidadNaval.Enabled = false;
                    this.cmbTipoDroga.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    this.txtCantidad.Enabled = false;
                    this.cmbProvincia.Enabled = false;
                    this.txtNota.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.dtFecha.Refresh();
            this.fillCmbUnidadNaval();
            this.txtCedula.Clear();
            this.txtRango.Clear();
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.fillCmbTipoDroga();
            this.txtCantidad.Clear();
            this.fillCmbProvincia();
            this.txtNota.Clear();
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
            if (txtID.Text == "" || txtCantidad.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtCantidad.Focus();
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
                        myCommand.CommandText = "INSERT INTO ops_antinarcoticos(fecha, embarcacion, comandante, tipodroga,"+
                        "cantidad, lugar, nota) values(@fecha, @unidadnaval, @comandante, @tipodroga, @cantidad, @lugar, @nota)";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@unidadnaval", cmbUnidadNaval.SelectedValue);
                        myCommand.Parameters.AddWithValue("@comandante", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@tipodroga", cmbTipoDroga.SelectedValue);
                        // Convierto el campo monto en texto
                        txtCantidad.Text = Convert.ToString(txtCantidad.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(txtCantidad.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        //
                        myCommand.Parameters.AddWithValue("@cantidad", myValueMonto);
                        //
                        //myCommand.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                        //
                        myCommand.Parameters.AddWithValue("@lugar", cmbProvincia.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nota", txtNota.Text);
                        
                        // Step 4 - Opening the connection
                        MyConexion.Open();

                        // Step 5 - Executing the query
                        int nFilas = myCommand.ExecuteNonQuery();
                        if (nFilas > 0)
                        {
                            MessageBox.Show("Informacion guardada satisfactoriamente...");
                        }
                        else
                        {
                            MessageBox.Show("No fueron guardadas las informaciones...");
                        }

                        // Step 6 - Closing the connection
                        MyConexion.Close();
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
                        myCommand.CommandText = "UPDATE ops_antinarcoticos SET fecha = @fecha, unidadnaval = @unidadnaval, " +
                            "comandante = @comandante, cantidad = @cantidad, lugar = @lugar, nota = @nota WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@unidadnaval", cmbUnidadNaval.SelectedValue);
                        myCommand.Parameters.AddWithValue("@comandante", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@tipodroga", cmbTipoDroga.SelectedValue);
                        myCommand.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                        myCommand.Parameters.AddWithValue("@lugar", cmbProvincia.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nota", txtNota.Text);

                        // Step 4 - Opening the connection
                        MyConexion.Open();

                        // Step 5 - Executing the query
                        int nFilas = myCommand.ExecuteNonQuery();
                        if (nFilas > 0)
                        {
                            MessageBox.Show("Informacion actualiada satisfactoriamente...");
                        }
                        else
                        {
                            MessageBox.Show("No fueron actualizadas las informaciones...");
                        }

                        // Step 6 - Closing the connection
                        MyConexion.Close();

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
                    MyCommand.CommandText = "SELECT id, fecha, embarcacion, comandante, tipodroga, cantidad, lugar, nota " +
                        "FROM ops_antinarcoticos WHERE id = " + txtID.Text + "";

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
                            cmbUnidadNaval.SelectedValue = MyReader["embarcacion"].ToString();
                            txtCedula.Text = MyReader["comandante"].ToString();
                            cmbTipoDroga.SelectedValue = MyReader["tipodroga"].ToString();
                            //txtCantidad.Text = MyReader["cantidad"].ToString();
                            cmbProvincia.SelectedValue = MyReader["lugar"].ToString();
                            txtNota.Text = MyReader["nota"].ToString();

                            // Llamo la funcion para formatear el campo.-
                            txtCantidad.Text = MyReader["cantidad"].ToString();
                            decimal monto = Convert.ToDecimal(txtCantidad.Text);
                            txtCantidad.Text = clsFunctions.GetCurrencyFormat(monto);
                            //
                        }

                        // Funcion Buscar Militar.-
                        this.Busqueda();
                        // Cambio el modo
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

        private void Busqueda()
        {
            if (txtCedula.Text == "")
            {
                MessageBox.Show("No se puede buscar sin cedulas...");
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
                    MyCommand.CommandText = "SELECT rango, nombre, apellido " +
                        "FROM militares WHERE cedula = '" + txtCedula.Text + "'";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtNombre.Text = MyReader["nombre"].ToString();
                            txtApellido.Text = MyReader["apellido"].ToString();
                            txtRango.Text = MyReader["rango"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontro militar...");
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
            frmPrintOperacionesNarcoticos ofrmPrintOperacionesNarcoticos = new frmPrintOperacionesNarcoticos();
            ofrmPrintOperacionesNarcoticos.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtCantidad.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema de Gestion de Operaciones", MessageBoxButtons.YesNo,
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
                        MessageBox.Show("No se encontraron registros con esta cedula...", "SisGesComBar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // keypress//

            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            // LEAVE //

            if (txtCantidad.Text == "")
            {
                MessageBox.Show("No puede dejar la cantidad sin valor...");
                txtCantidad.Focus();
            }
            else
            {
                // Llamo la funcion para formatear el campo.-
                decimal monto = Convert.ToDecimal(txtCantidad.Text);
                txtCantidad.Text = clsFunctions.GetCurrencyFormat(monto);
            }
        }
    }
}
