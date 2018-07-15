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

namespace SisGesFactInv
{
    public partial class frmGastosAdministrativos : frmBase
    {
        string cModo = "Inicio";

        public frmGastosAdministrativos()
        {
            InitializeComponent();
        }

        private void frmGastosAdministrativos_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
            this.fillCmbCategoria();
        }

        // Funcion que convierte un valor decimal a texto para graficarlo en un textbox
        public static string GetCurrencyFormat(decimal myValue)
        {
            return string.Format("{0:#,###0.00}", myValue);
        }

        // Funcion que convierte el decimal de un textbox para salvarlo a la base de datos
        public static decimal ParseCurrencyFormat(string myValue)
        {
            return decimal.Parse(myValue, System.Globalization.NumberStyles.Currency);
        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtDescripcion.Clear();
            this.txtMonto.Clear();
            this.dtFecha.Refresh();
        }

        private void fillCmbCategoria()
        {
            try
            {
                // Step 1 
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT idtipogasto, desc_tipogasto FROM gastos_tipo ORDER BY desc_tipogasto ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("idtipogasto", typeof(int));
                MyDataTable.Columns.Add("desc_tipogasto", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6                
                cmbCategoria.ValueMember = "idtipogasto";
                cmbCategoria.DisplayMember = "desc_tipogasto";
                cmbCategoria.DataSource = MyDataTable;

                // Step 7
                MyConexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
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
                MyCommand.CommandText = "SELECT count(*) FROM gastos";

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
                    this.txtDescripcion.Enabled = false;
                    this.txtMonto.Enabled = false;
                    this.cmbCategoria.Enabled = false;
                    this.dtFecha.Enabled = false;
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
                    this.txtDescripcion.Enabled = true;
                    this.txtMonto.Enabled = true;
                    this.cmbCategoria.Enabled = true;
                    this.dtFecha.Enabled = true;
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
                    this.txtDescripcion.Enabled = false;
                    this.txtMonto.Enabled = false;
                    this.cmbCategoria.Enabled = false;
                    this.dtFecha.Enabled = false;
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
                    this.txtDescripcion.Enabled = true;
                    this.txtMonto.Enabled = true;
                    this.cmbCategoria.Enabled = true;
                    this.dtFecha.Enabled = true;
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
                    this.txtDescripcion.Enabled = false;
                    this.txtMonto.Enabled = false;
                    this.cmbCategoria.Enabled = false;
                    this.dtFecha.Enabled = false;
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
                    this.txtDescripcion.Enabled = false;
                    this.txtMonto.Enabled = false;
                    this.cmbCategoria.Enabled = false;
                    this.dtFecha.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (txtMonto.Text == "")
            {
                MessageBox.Show("No puede dejar la cantidad sin valor...");
                txtMonto.Focus();
            }
            else
            {
                // Llamo la funcion para formatear el campo.-
                decimal monto = Convert.ToDecimal(txtMonto.Text);
                txtMonto.Text = clsFunctions.GetCurrencyFormat(monto);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.Botones();
            this.ProximoCodigo();
            this.cmbCategoria.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                this.txtID.Focus();
            }
            else
            {
                if (cModo == "Nuevo")
                {
                    try
                    {
                        // PRIMERO VERIFICO NUEVAMENTE EL ID
                        this.ProximoCodigo();

                        // Step 1 - Stablishing the connection
                        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "INSERT INTO gastos(categoria, descripcion, monto, fecha)" +
                            " values(@categoria, @descripcion, @monto, @fecha)";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@categoria", cmbCategoria.SelectedValue);
                        myCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        
                        // Convierto el campo monto en texto
                        txtMonto.Text = Convert.ToString(txtMonto.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(txtMonto.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        myCommand.Parameters.AddWithValue("@monto", myValueMonto);

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
                        myCommand.CommandText = "UPDATE gastos SET fecha = @fecha, categoria = @categoria, " +
                            "descripcion = @descripcion, monto = @monto WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@categoria", cmbCategoria.SelectedValue);
                        myCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

                        // Convierto el campo monto en texto
                        txtMonto.Text = Convert.ToString(txtMonto.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(txtMonto.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        myCommand.Parameters.AddWithValue("@monto", myValueMonto);

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
                MessageBox.Show("No se permiten busquedas sin ID...");
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
                    MyCommand.CommandText = "SELECT id, categoria, descripcion, monto, fecha " +
                        "FROM gastos WHERE id = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            cmbCategoria.SelectedValue = MyReader["categoria"].ToString();
                            txtDescripcion.Text = MyReader["descripcion"].ToString();
                            txtMonto.Text = MyReader["monto"].ToString();                            
                            dtFecha.Value = Convert.ToDateTime(MyReader["fecha"].ToString());
                            // Llamo la funcion para formatear el campo.-
                            decimal monto = Convert.ToDecimal(txtMonto.Text);
                            txtMonto.Text = clsFunctions.GetCurrencyFormat(monto);                            
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
      
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtDescripcion.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema de Facturacion e Inventario", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.Yes:
                        cModo = "Actualiza";
                        btnGrabar_Click(sender, e);
                        break;
                }
            }

            this.cModo = "Inicio";
            this.Botones();
            this.Limpiar();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            frmPrintGastosAdministrativos ofrmPrintGastosAdministrativos = new frmPrintGastosAdministrativos();
            ofrmPrintGastosAdministrativos.ShowDialog();
        }
    }
}
