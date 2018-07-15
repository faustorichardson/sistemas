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
    public partial class frmRegistroCuentasPorPagar : frmBase
    {
        string cModo = "Inicio";

        public frmRegistroCuentasPorPagar()
        {
            InitializeComponent();
        }

        private void frmRegistroCuentasPorPagar_Load(object sender, EventArgs e)
        {
            // Limpiando el formulario
            this.Limpiar();

            // Funcion botones
            this.cModo = "Inicio";
            this.Botones();

            // Llenando los combos
            this.fillCmbSuplidor();
        }

        private void fillCmbSuplidor()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, nombre FROM suplidor ORDER BY nombre ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("nombre", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbSuplidor.ValueMember = "id";
            cmbSuplidor.DisplayMember = "nombre";
            cmbSuplidor.DataSource = MyDataTable;

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
                    this.txtMonto.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.cmbSuplidor.Enabled = false;
                    this.chkStatus.Enabled = false;
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
                    this.txtMonto.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.cmbSuplidor.Enabled = true;
                    this.chkStatus.Enabled = true;
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
                    this.txtMonto.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.cmbSuplidor.Enabled = false;
                    this.chkStatus.Enabled = false;
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
                    this.txtMonto.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.cmbSuplidor.Enabled = true;
                    this.chkStatus.Enabled = true;
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
                    this.txtMonto.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.cmbSuplidor.Enabled = false;
                    this.chkStatus.Enabled = false;
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
                    this.txtMonto.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.cmbSuplidor.Enabled = false;
                    this.chkStatus.Enabled = false;
                    this.txtNota.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtMonto.Clear();
            this.txtNota.Clear();
            this.chkStatus.Checked = false;
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
                MyCommand.CommandText = "SELECT count(*) FROM cxp";

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
            if (txtID.Text == "" || txtMonto.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtMonto.Focus();
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
                        myCommand.CommandText = "INSERT INTO cxp(fecha, suplidor, monto, nota, status)" +
                            " values(@fecha, @suplidor, @monto, @nota, @status)";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@suplidor", cmbSuplidor.SelectedValue);

                        // Convierto el campo monto en texto
                        txtMonto.Text = Convert.ToString(txtMonto.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(txtMonto.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        //
                        myCommand.Parameters.AddWithValue("@monto", myValueMonto);
                        myCommand.Parameters.AddWithValue("@nota", txtNota.Text);

                        // Verifico el estado del status
                        if (chkStatus.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@status", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@status", 0);
                        }

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
                        myCommand.CommandText = "UPDATE cxp SET fecha = @fecha, suplidor = @suplidor, " +
                            "monto = @monto, status = @status, nota = @nota WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@suplidor", cmbSuplidor.SelectedValue);

                        // Convierto el campo monto en texto
                        txtMonto.Text = Convert.ToString(txtMonto.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(txtMonto.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        //
                        myCommand.Parameters.AddWithValue("@monto", myValueMonto);
                        myCommand.Parameters.AddWithValue("@nota", txtNota.Text);

                        // Verifico el estado del status
                        if (chkStatus.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@status", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@status", 0);
                        }

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
                    MyCommand.CommandText = "SELECT id, fecha, suplidor, monto, nota, status " +
                        "FROM cxp WHERE id = " + txtID.Text + "";

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
                            cmbSuplidor.SelectedValue = MyReader["suplidor"].ToString();
                            txtNota.Text = MyReader["nota"].ToString();
                            // Llamo la funcion para formatear el campo.-
                            txtMonto.Text = MyReader["monto"].ToString();
                            decimal monto = Convert.ToDecimal(txtMonto.Text);
                            txtMonto.Text = clsFunctions.GetCurrencyFormat(monto);
                            //
                            
                            
                            // para el estado del checkbox
                            if (MyReader["status"].ToString() == "1")
                            {
                                chkStatus.Checked = true;
                            }
                            else
                            {
                                chkStatus.Checked = false;
                            }

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
            frmPrintCxP ofrmPrintCxP = new frmPrintCxP();
            ofrmPrintCxP.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text != "")
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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (txtMonto.Text == "")
            {
                MessageBox.Show("No puede dejar la cantidad sin valor...");
                this.txtMonto.Focus();
            }
            else
            {
                // Llamo la funcion para formatear el campo.-
                decimal monto = Convert.ToDecimal(txtMonto.Text);
                txtMonto.Text = clsFunctions.GetCurrencyFormat(monto);
            }
        }
    }
}
