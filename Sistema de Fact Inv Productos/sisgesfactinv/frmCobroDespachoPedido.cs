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
    public partial class frmCobroDespachoPedido : frmBase
    {

        string cModo = "Inicio";

        public frmCobroDespachoPedido()
        {
            InitializeComponent();
        }

        private void frmCobroDespachoPedido_Load(object sender, EventArgs e)
        {
            this.cModo = "Inicio";
            this.Botones();
        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtIDCliente.Clear();
            this.txtCliente.Clear();
            this.txtMontoBruto.Clear();
            this.txtMontoNeto.Clear();
            this.chkDespachada.Checked = false;
            this.chkCobrada.Checked = false;
            this.chkDespachada.Checked = false;
        }

        private void Botones()
        {
            switch (cModo)
            {
                case "Inicio":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //                    
                    this.txtID.Enabled = true;
                    this.txtIDCliente.Enabled = false;
                    this.txtCliente.Enabled = false;
                    this.txtMontoBruto.Enabled = false;
                    this.txtMontoNeto.Enabled = false;
                    this.chkCobrada.Enabled = false;
                    this.chkDespachada.Enabled = false;
                    this.chkAnulada.Enabled = false;
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
                    this.txtIDCliente.Enabled = false;
                    this.txtCliente.Enabled = false;
                    this.txtMontoBruto.Enabled = false;
                    this.txtMontoNeto.Enabled = false;
                    this.chkCobrada.Enabled = true;
                    this.chkDespachada.Enabled = true;
                    this.chkAnulada.Enabled = false;
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //                    
                    this.txtID.Enabled = false;
                    this.txtIDCliente.Enabled = false;
                    this.txtCliente.Enabled = false;
                    this.txtMontoBruto.Enabled = false;
                    this.txtMontoNeto.Enabled = false;
                    this.chkCobrada.Enabled = false;
                    this.chkDespachada.Enabled = false;
                    this.chkAnulada.Enabled = false;
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
                    this.txtIDCliente.Enabled = false;
                    this.txtCliente.Enabled = false;
                    this.txtMontoBruto.Enabled = false;
                    this.txtMontoNeto.Enabled = false;
                    this.chkCobrada.Enabled = true;
                    this.chkDespachada.Enabled = true;
                    this.chkAnulada.Enabled = false;
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
                    this.txtIDCliente.Enabled = false;
                    this.txtCliente.Enabled = false;
                    this.txtMontoBruto.Enabled = false;
                    this.txtMontoNeto.Enabled = false;
                    this.chkCobrada.Enabled = false;
                    this.chkDespachada.Enabled = false;
                    this.chkAnulada.Enabled = false;
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //                    
                    this.txtID.Enabled = false;
                    this.txtIDCliente.Enabled = false;
                    this.txtCliente.Enabled = false;
                    this.txtMontoBruto.Enabled = false;
                    this.txtMontoNeto.Enabled = false;
                    this.chkCobrada.Enabled = false;
                    this.chkDespachada.Enabled = false;
                    this.chkAnulada.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            // VERIFICO SI TENGO UNA FACTURA EN CONSULTA Y SI EL CLIENTE FUE BUSCADO.-
            if (txtID.Text == "" || txtIDCliente.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");                
            }
            else
            {
                if (chkAnulada.Checked == true)
                {
                    MessageBox.Show("Esta factura esta cancelada no puede ser cobrada ni despachada...");
                }
                else
                {
                    if (chkDespachada.Checked == false && chkCobrada.Checked == true)
                    {
                        MessageBox.Show("No se puede cobrar una factura si no se ha despachado...");
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
                            myCommand.CommandText = "UPDATE facturacion SET status = @status, despachada = @despachada" +
                                " WHERE idfacturacion = " + txtID.Text + "";

                            // SI EL STATUS ES 1 LA FACTURA FUE COBRADA SI FUE 0 NO FUE COBRADA
                            if (chkCobrada.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@status", 1);
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@status", 0);
                            }

                            // SI DESPACHADA = 1 FUE DESPACHADA SI ES IGUAL A 0 NO FUE DESPACHADA
                            if (chkDespachada.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@despachada", 1);
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@despachada", 0);
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
                    MyCommand.CommandText = "SELECT idfacturacion, idcliente, fecha, monto_b, monto_n, status, despachada, anulada " +
                        "FROM facturacion WHERE idfacturacion = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            this.txtIDCliente.Text = MyReader["idcliente"].ToString();
                            this.dtFecha.Value = Convert.ToDateTime(MyReader["fecha"]);
                            
                            // formateo los montos
                            this.txtMontoBruto.Text = MyReader["monto_b"].ToString();
                            // Llamo la funcion para formatear el campo.-
                            decimal montoB = Convert.ToDecimal(txtMontoBruto.Text);
                            txtMontoBruto.Text = clsFunctions.GetCurrencyFormat(montoB);

                            // formateo los montos
                            this.txtMontoNeto.Text = MyReader["monto_n"].ToString();
                            // Llamo la funcion para formatear el campo.-
                            decimal montoN = Convert.ToDecimal(txtMontoNeto.Text);
                            txtMontoNeto.Text = clsFunctions.GetCurrencyFormat(montoN);

                            // Verifico el status
                            string status = MyReader["status"].ToString();
                            if (status == "1")
                            {
                                this.chkCobrada.Checked = true;
                            }
                            else
                            {
                                this.chkCobrada.Checked = false;
                            }

                            string despachada = MyReader["despachada"].ToString();
                            if (despachada == "1")
                            {
                                this.chkDespachada.Checked = true;
                            }
                            else
                            {
                                this.chkDespachada.Checked = false;
                            }

                            string anulada = MyReader["anulada"].ToString();
                            if (anulada == "1")
                            {
                                this.chkAnulada.Checked = true;
                            }
                            else
                            {
                                this.chkAnulada.Checked = false;
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

                    // Busco el nombre del cliente
                    this.BuscarCliente();

                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }

        private void BuscarCliente()
        {
            if (txtID.Text == "" && txtIDCliente.Text == "")
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
                    MyCommand.CommandText = "SELECT nombre FROM clientes WHERE idcliente = " + txtIDCliente.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtCliente.Text = MyReader["nombre"].ToString();                            
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
            frmPrintCobroDespacho ofrmPrintCobroDespacho = new frmPrintCobroDespacho();
            ofrmPrintCobroDespacho.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
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

                this.Limpiar();
                this.cModo = "Inicio";
                this.Botones();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}
