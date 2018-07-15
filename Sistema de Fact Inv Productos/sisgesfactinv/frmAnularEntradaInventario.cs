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
    public partial class frmAnularEntradaInventario : frmBase
    {
        public frmAnularEntradaInventario()
        {
            InitializeComponent();
        }

        private void frmAnularEntradaInventario_Load(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void limpiar()
        {
            this.txtSolicitud.Clear();
            this.txtCausa.Clear();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtSolicitud.Text == "")
            {
                MessageBox.Show("No se puede eliminar una entrada a inventario sin numero de entrada...");
                this.txtSolicitud.Focus();
            }
            else
            {
                try
                {
                    DialogResult Result =
                    MessageBox.Show("Esta procediendo a anular una Entrada de Inventario ..." + System.Environment.NewLine + "Esta seguro de proceder con la anulacion", "Sistema de Gestion de Facturacion e Inventario", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                    switch (Result)
                    {
                        case DialogResult.Yes:
                            this.Buscar();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }

        private void Buscar()
        {
            if (txtSolicitud.Text == "")
            {
                MessageBox.Show("Debe de digitar un numero de entrada...");
                this.txtSolicitud.Focus();
            }
            else
            {
                // VERIFICANDO SI HA SIDO ANULADA ANTERIORMENTE ESTA ENTRADA ANTES DE PROCEDER
                try
                {
                    // Step 1 - Conexion
                    MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    MyCommand.CommandText = "SELECT id, anulada FROM entrada_inventario WHERE id = " + txtSolicitud.Text + " AND anulada = 1";

                    // Step 4 - connection open
                    MyCommand.Dispose();
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        MessageBox.Show("Este numero de entrada de inventario fue anulado anteriormente...");
                        this.txtSolicitud.Focus();
                    }
                    else
                    {
                        // Funcion que actualiza la tabla combustible_entrada
                        this.ActualizaEntrada();

                        // Funcion que actualiza los movimientos
                        this.ActualizarMovimiento();

                        // Funcion que actualiza la existencia
                        this.ActualizarExistencia();

                        MessageBox.Show("Proceso de anulacion realizado satisfactoriamente.");
                    }

                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyConexion.Close();
                } catch(Exception myEx){
                    MessageBox.Show(myEx.Message);
                }
            }

            // Limpio informacion
            this.limpiar();

        }

        private void ActualizaEntrada()
        {
            //ACTUALIZANDO LA TABLA ENTRADA_INVENTARIO CON LA ANULACION EN EL CAMPO ANULADA
            //ESTO LE PONDRA UN 1 AL CAMPO ANULADO.
            try
            {
                // Step 1 - Stablishing the connection
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Crear el comando de ejecucion
                MySqlCommand myCommand = MyConexion.CreateCommand();

                // Step 3 - Comando a ejecutar
                myCommand.CommandText = "UPDATE entrada_inventario SET anulada = @anulada, anulada_comentario = @causa WHERE id = " + txtSolicitud.Text + "";
                myCommand.Parameters.AddWithValue("@anulada", 1);
                myCommand.Parameters.AddWithValue("@causa", txtCausa.Text);

                // Step 4 - Opening the connection
                MyConexion.Open();

                // Step 5 - Executing the query
                myCommand.ExecuteNonQuery();

                // Step 6 - Closing the connection
                MyConexion.Close();
                //MessageBox.Show("Informacion actualizada satisfactoriamente...");
            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }
        }

        private void ActualizarMovimiento()
        {
            //ACTUALIZANDO LA TABLA ENTRADA_INVENTARIO_DETALLE CON LA ANULACION EN EL CAMPO ANULADA
            //ESTO LE PONDRA UN 1 AL CAMPO ANULADO.
            try
            {
                // Step 1 - Stablishing the connection
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Crear el comando de ejecucion
                MySqlCommand myCommand = MyConexion.CreateCommand();

                // Step 3 - Comando a ejecutar
                myCommand.CommandText = "UPDATE entrada_inventario_detalle SET anulada = @anulada WHERE id = " + txtSolicitud.Text + "";
                myCommand.Parameters.AddWithValue("@anulada", 1);

                // Step 4 - Opening the connection
                MyConexion.Open();

                // Step 5 - Executing the query
                myCommand.ExecuteNonQuery();

                // Step 6 - Closing the connection
                MyConexion.Close();
                //MessageBox.Show("Informacion actualizada satisfactoriamente...");
            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }
        }

        private void ActualizarExistencia()
        {
            //ACTUALIZANDO LA TABLA INVENTARIO                
            try
            {
                // Step 1 - Stablishing the connection
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Crear el comando de ejecucion
                MySqlCommand myCommand = MyConexion.CreateCommand();

                // Step 3 - Comando a ejecutar
                myCommand.CommandText = "UPDATE inventario" +
                    " INNER JOIN entrada_inventario_detalle ON entrada_inventario_detalle.idproducto = inventario.idproducto" +
                    " SET inventario.cantidad = (inventario.cantidad - entrada_inventario_detalle.cantidad)" +
                    " WHERE entrada_inventario_detalle.id = @anulada";
                myCommand.Parameters.AddWithValue("@anulada", txtSolicitud.Text);

                // Step 4 - Opening the connection
                MyConexion.Open();

                // Step 5 - Executing the query
                myCommand.ExecuteNonQuery();

                // Step 6 - Closing the connection
                MyConexion.Close();
                //MessageBox.Show("Informacion actualizada satisfactoriamente...");
            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
