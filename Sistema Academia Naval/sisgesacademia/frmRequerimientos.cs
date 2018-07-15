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

namespace SisGesAcademia
{
    public partial class frmRequerimientos : frmBase
    {
        string cModo = "Inicio";

        public frmRequerimientos()
        {
            InitializeComponent();
        }

        private void frmRequerimientos_Load(object sender, EventArgs e)
        {
            // Funcion Limpiar Campos
            this.Limpiar();

            // Llenando el combo de dependencias
            this.fillCmbDependencia();

            // Funcion Botones
            this.cModo = "Inicio";
            this.Botones();
        }

        private void fillCmbDependencia()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, dependencia FROM dependencias ORDER BY dependencia ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("dependencia", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbDependencia.ValueMember = "id";
            cmbDependencia.DisplayMember = "dependencia";
            cmbDependencia.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();

        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.cmbDependencia.Refresh();
            this.txtRequerimiento.Clear();
            this.fecharecibido.Refresh();
            this.fecharequerido.Refresh();
            this.montocotizacion.Clear();
            this.txtITBI.Clear();
            this.chkStatus.Checked = false;
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
                    this.cmbDependencia.Enabled = false;
                    this.txtRequerimiento.Enabled = false;
                    this.fecharecibido.Enabled = false;
                    this.fecharequerido.Enabled = false;
                    this.montocotizacion.Enabled = false;
                    this.txtITBI.Enabled = false;
                    this.chkStatus.Enabled = false;
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
                    this.cmbDependencia.Enabled = true;
                    this.txtRequerimiento.Enabled = true;
                    this.fecharecibido.Enabled = true;
                    this.fecharequerido.Enabled = true;
                    this.montocotizacion.Enabled = true;
                    this.txtITBI.Enabled = false;
                    this.chkStatus.Enabled = true;
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
                    this.cmbDependencia.Enabled = false;
                    this.txtRequerimiento.Enabled = false;
                    this.fecharecibido.Enabled = false;
                    this.fecharequerido.Enabled = false;
                    this.montocotizacion.Enabled = false;
                    this.txtITBI.Enabled = false;
                    this.chkStatus.Enabled = false;
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
                    this.cmbDependencia.Enabled = true;
                    this.txtRequerimiento.Enabled = true;
                    this.fecharecibido.Enabled = true;
                    this.fecharequerido.Enabled = true;
                    this.montocotizacion.Enabled = true;
                    this.txtITBI.Enabled = false;
                    this.chkStatus.Enabled = true;
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
                    this.cmbDependencia.Enabled = false;
                    this.txtRequerimiento.Enabled = false;
                    this.fecharecibido.Enabled = false;
                    this.fecharequerido.Enabled = false;
                    this.montocotizacion.Enabled = false;
                    this.txtITBI.Enabled = false;
                    this.chkStatus.Enabled = false;
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
                    this.cmbDependencia.Enabled = false;
                    this.txtRequerimiento.Enabled = false;
                    this.fecharecibido.Enabled = false;
                    this.fecharequerido.Enabled = false;
                    this.montocotizacion.Enabled = false;
                    this.txtITBI.Enabled = false;
                    this.chkStatus.Enabled = false;
                    break;

                default:
                    break;
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
                MyCommand.CommandText = "SELECT count(*) FROM requerimientos";

                // Step 4 - Open connection
                MyConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                this.txtID.Text = Convert.ToString(codigo);
                this.cmbDependencia.Focus();

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
            cModo = "Nuevo";
            this.Limpiar();
            this.Botones();
            this.ProximoCodigo();
            this.cmbDependencia.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtRequerimiento.Text == "" || montocotizacion.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtRequerimiento.Focus();
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
                        myCommand.CommandText = "INSERT INTO requerimientos(id, dependencia, requerimiento, fecharegistro, fecharequerido, monto_cotizacion, monto_itbi, status)" +
                            " values(@id, @dependencia, @requerimiento, @fecharegistro, @fecharequerido, @monto, @itbi, @status)";
                        myCommand.Parameters.AddWithValue("@id", txtID.Text);
                        myCommand.Parameters.AddWithValue("@dependencia", cmbDependencia.SelectedValue);
                        myCommand.Parameters.AddWithValue("@requerimiento", txtRequerimiento.Text);
                        myCommand.Parameters.AddWithValue("@fecharegistro", fecharecibido.Value.ToString("yyyy-MM-dd"));
                        myCommand.Parameters.AddWithValue("@fecharequerido", fecharequerido.Value.ToString("yyyy-MM-dd"));                                                
                        
                        // Convierto el campo monto en texto
                        montocotizacion.Text = Convert.ToString(montocotizacion.Text);                                                                        
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(montocotizacion.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        myCommand.Parameters.AddWithValue("@monto", myValueMonto);

                        // Convierto el campo ITBIs en texto
                        this.txtITBI.Text = Convert.ToString(txtITBI.Text);
                        // Cambio el valor del textbox a decimal
                        string myValueI = Convert.ToString(txtITBI.Text);
                        decimal myValueMontoI = clsFunctions.ParseCurrencyFormat(myValueI);
                        myCommand.Parameters.AddWithValue("@itbi", myValueMontoI);

                        // Chequeo el Status
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
                        myCommand.CommandText = "UPDATE requerimientos SET dependencia = @dependencia, requerimiento = @requerimiento, " +
                            "fecharegistro = @fecharegistro, fecharequerido = @fecharequerido, monto_cotizacion = @monto, "+
                            " status = @status, monto_itbi = @itbi WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@id", txtID.Text);
                        myCommand.Parameters.AddWithValue("@dependencia", cmbDependencia.SelectedValue);
                        myCommand.Parameters.AddWithValue("@requerimiento", txtRequerimiento.Text);
                        myCommand.Parameters.AddWithValue("@fecharegistro", fecharecibido.Value.ToString("yyyy-MM-dd"));
                        myCommand.Parameters.AddWithValue("@fecharequerido", fecharequerido.Value.ToString("yyyy-MM-dd"));                        
                        
                        // Convierto el campo monto en texto
                        montocotizacion.Text = Convert.ToString(montocotizacion.Text);                        
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(montocotizacion.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        myCommand.Parameters.AddWithValue("@monto", myValueMonto);

                        // Convierto el campo ITBIs en texto
                        this.txtITBI.Text = Convert.ToString(txtITBI.Text);
                        // Cambio el valor del textbox a decimal
                        string myValueI = Convert.ToString(txtITBI.Text);
                        decimal myValueMontoI = clsFunctions.ParseCurrencyFormat(myValueI);
                        myCommand.Parameters.AddWithValue("@itbi", myValueMontoI);

                        // Chequeo el Status
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

            if (this.txtID.Text == "")
            {
                MessageBox.Show("No se permiten busquedas sin argumentos...");
                this.txtID.Focus();
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
                    MyCommand.CommandText = "SELECT dependencia, requerimiento, fecharegistro, fecharequerido, monto_cotizacion, monto_itbi, status " +
                        "FROM requerimientos WHERE id = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            cmbDependencia.SelectedValue = MyReader["dependencia"].ToString();
                            txtRequerimiento.Text = MyReader["requerimiento"].ToString();
                            fecharecibido.Value = Convert.ToDateTime(MyReader["fecharegistro"]);
                            fecharequerido.Value = Convert.ToDateTime(MyReader["fecharequerido"]);
                            //
                            montocotizacion.Text = MyReader["monto_cotizacion"].ToString();                            
                            // Llamo la funcion para formatear el campo.-
                            decimal monto = Convert.ToDecimal(montocotizacion.Text);
                            montocotizacion.Text = clsFunctions.GetCurrencyFormat(monto);
                            //
                            txtITBI.Text = MyReader["monto_itbi"].ToString();
                            // Llamo la funcion para formatear el campo
                            decimal montoI = Convert.ToDecimal(txtITBI.Text);
                            txtITBI.Text = clsFunctions.GetCurrencyFormat(montoI);

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
            frmPrintRequerimientos ofrmPrintRequerimientos = new frmPrintRequerimientos();
            ofrmPrintRequerimientos.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtRequerimiento.Text != "" || montocotizacion.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema Gestion de Compras", MessageBoxButtons.YesNo,
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

        private void montocotizacion_Leave(object sender, EventArgs e)
        {
            decimal monto = Convert.ToDecimal(montocotizacion.Text);
            montocotizacion.Text = clsFunctions.GetCurrencyFormat(monto);

            double cifra = 0.18;
            cifra = cifra * Convert.ToDouble(montocotizacion.Text);

            txtITBI.Text = Convert.ToString(cifra);
        }
        
        private void txtITBI_Leave(object sender, EventArgs e)
        {
            //decimal monto = Convert.ToDecimal(txtITBI.Text);
            //txtITBI.Text = clsFunctions.GetCurrencyFormat(monto);
        }

        
    }
}
