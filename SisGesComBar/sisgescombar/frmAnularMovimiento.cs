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
    public partial class frmAnularMovimiento : frmBase
    {
        string embarcacion = "";
        decimal myCantidad = 0;
        decimal cantAnulada = 0;

        public frmAnularMovimiento()
        {
            InitializeComponent();
        }

        private void frmAnularMovimiento_Load(object sender, EventArgs e)
        {
            // Limpio el form
            this.Limpiar();
        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.embarcacion = "";
            this.embarcacion = "";
            this.myCantidad = 0;
            this.cantAnulada = 0;
            this.txtID.Focus();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {           
            DialogResult Result =
            MessageBox.Show("Anule Movimiento Combustible" + System.Environment.NewLine + "Desea Anular Movimiendo de Combustible ???", "Sistema de Gestion de Combustibles de Barcos", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            switch (Result)
            {
                case DialogResult.Yes:
                    this.anularMovimiento();
                    break;
            }        
        }

        private void anularMovimiento()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Para proceder con anulacion indroduzca el numero.");
                txtID.Focus();
            }
            else
            {
                try
                {
                    // Step 1 - Conexion
                    MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 
                    MySqlCommand MyCommand = MyConexion.CreateCommand();

                    // Step 3
                    //string tipo_movimiento = "E";

                    MyCommand.CommandText = "SELECT status FROM movimientocombustible WHERE id = " + txtID.Text + "";

                    // Step 4
                    MyConexion.Open();

                    // Step 5
                    string MyText = Convert.ToString(MyCommand.ExecuteScalar());

                    // Step 6
                    if (MyText == "0")
                    {
                        MessageBox.Show("Este movimiento ha sido anulado anteriormente o no es una entrada de combustible.");
                    }
                    else
                    {
                        this.actualizarMovimiento();
                        this.buscaEmbarcacion();
                        this.actualizarInventario();
                    }

                    // Step 7
                    MyConexion.Close();

                    this.Limpiar();

                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }            

        }

        private void actualizarMovimiento()
        {
            try
            {

                // Step 1 - Stablishing the connection
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Crear el comando de ejecucion
                MySqlCommand myCommand = MyConexion.CreateCommand();

                // Step 3 - Comando a ejecutar
                myCommand.CommandText = "UPDATE movimientocombustible SET status = @status WHERE id = " + txtID.Text + "";
                myCommand.Parameters.AddWithValue("@status", 0);
                
                // Step 4 - Opening the connection
                MyConexion.Open();

                // Step 5 - Executing the query
                int nFilas = myCommand.ExecuteNonQuery();
                if (nFilas > 0)
                {
                    MessageBox.Show("Movimiento anulado satisfactoriamente...");
                }
                else
                {
                    MessageBox.Show("No se pudo anular el movimiento...");
                }

                // Step 6 - Closing the connection
                MyConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
                throw;
            }
        }

        private void buscaEmbarcacion()
        {
            // BUSCA EXISTENCIA EN INVENTARIO
            try
            {
                // Step 1 - Conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - creating the command object
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3 - creating the commandtext
                MyCommand.CommandText = "SELECT unidadnaval, cantidad FROM movimientocombustible WHERE id = " + txtID.Text + "";

                // Step 4 - connection open
                MyConexion.Open();

                // Step 5 - Creating the DataReader                    
                MySqlDataReader MyReader = MyCommand.ExecuteReader();

                // Step 6 - Verifying if Reader has rows
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        embarcacion = MyReader["unidadnaval"].ToString();
                        cantAnulada = Convert.ToDecimal(MyReader["cantidad"]);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros...");
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

        private void actualizarInventario()
        {            

            // BUSCA CANTIDAD EN EXISTENCIA
            try
            {
                // Step 1 - Conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3
                MyCommand.CommandText = "SELECT cantidad FROM existencia WHERE id_unidad = " + embarcacion + "";

                // Step 4
                MyConexion.Open();

                // Step 5
                myCantidad = Convert.ToDecimal(MyCommand.ExecuteScalar());
                
                // Step 6
                MyConexion.Close();

            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }

            // REALIZO LA OPERACION DE SUMAR O RESTAR A LA EXISTENCIA
            if (rbRecibido.Checked == true)
            {
                // RESTO LA CANTIDAD DE EXISTENCIA
                myCantidad = myCantidad - cantAnulada;
            }
            else
            {
                // SUMO LA CANTIDAD DE EXISTENCIA
                myCantidad = myCantidad + cantAnulada;
            }

            // ACTUALIZA LA EXISTENCIA
            try
            {

                // Step 1 - Stablishing the connection
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Crear el comando de ejecucion
                MySqlCommand myCommand = MyConexion.CreateCommand();

                // Step 3 - Comando a ejecutar
                myCommand.CommandText = "UPDATE existencia SET cantidad = @cantidad WHERE id_unidad = " + embarcacion + "";
                myCommand.Parameters.AddWithValue("@cantidad", myCantidad);

                // Step 4 - Opening the connection
                MyConexion.Open();

                // Step 5 - Executing the query
                int nFilas = myCommand.ExecuteNonQuery();
                if (nFilas > 0)
                {
                    MessageBox.Show("Inventario actualizado satisfactoriamente...");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el inventario...");
                }

                // Step 6 - Closing the connection
                MyConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
                throw;
            }
        }

        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
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

        
    }
}
