﻿using System;
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
    public partial class frmCombustibleGastado : frmBase
    {
        decimal myCantidad = 0;
        string cModo = "Inicio";

        public frmCombustibleGastado()
        {
            InitializeComponent();
        }

        private void frmCombustibleGastado_Load(object sender, EventArgs e)
        {
            // Limpiando el formulario
            this.Limpiar();

            // Llenando los combos
            this.fillCmbActividad();
            this.fillCmbUnidad();

            // Funcion botones
            this.cModo = "Inicio";
            this.Botones();
        }

        private void fillCmbUnidad()
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

        private void fillCmbActividad()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, actividad FROM actividad ORDER BY actividad ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("actividad", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbActividad.ValueMember = "id";
            cmbActividad.DisplayMember = "actividad";
            cmbActividad.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        private void Limpiar()
        {
            this.txtCantidad.Clear();
            this.txtDescripcion.Clear();
            this.txtID.Clear();
            this.txtMillas.Clear();
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
                    this.txtCantidad.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.cmbActividad.Enabled = false;
                    this.cmbUnidadNaval.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.txtMillas.Enabled = false;
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
                    this.txtCantidad.Enabled = true;
                    this.txtDescripcion.Enabled = true;
                    this.cmbActividad.Enabled = true;
                    this.cmbUnidadNaval.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.txtMillas.Enabled = true;
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
                    this.txtCantidad.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.cmbActividad.Enabled = false;
                    this.cmbUnidadNaval.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.txtMillas.Enabled = false;
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
                    this.txtCantidad.Enabled = true;
                    this.txtDescripcion.Enabled = true;
                    this.cmbActividad.Enabled = true;
                    this.cmbUnidadNaval.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.txtMillas.Enabled = true;
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
                    this.txtCantidad.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.cmbActividad.Enabled = false;
                    this.cmbUnidadNaval.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.txtMillas.Enabled = false;
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
                    this.txtCantidad.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.cmbActividad.Enabled = false;
                    this.cmbUnidadNaval.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.txtMillas.Enabled = false;
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
                MyCommand.CommandText = "SELECT count(*) FROM movimientocombustible";

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

        private void searchExistencia()
        {
            // BUSCO LA EXISTENCIA            
            try
            {
                // Step 1 - Conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3
                MyCommand.CommandText = "SELECT cantidad FROM existencia WHERE id_unidad = " + cmbUnidadNaval.SelectedValue + "";

                // Step 4
                MyConexion.Open();

                // Step 5
                this.myCantidad = Convert.ToDecimal(MyCommand.ExecuteScalar());

                //if (myCantidad == 0)
                //{
                //    myCantidad = 0;
                //}
                // Step 6
                //this.txtDepartamento.Text = MyText;

                // Step 7
                MyConexion.Close();

            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }
        }

        private void addCantidad()
        {

            if (Convert.ToDecimal(txtCantidad.Text) > myCantidad)
            {
                MessageBox.Show("La cantidad a reducir no puede ser mayor que la existencia...");
                this.txtCantidad.Focus();
            }
            else
            {
                // RESTO LA CANTIDAD EN EXISTENCIA CON LA CANTIDAD QUE SE VA A RECIBIR
                myCantidad = myCantidad - Convert.ToDecimal(txtCantidad.Text);
            }
            // COMPARO A VER SI LA CANTIDAD QUE SE RECIBIRA ES MAYOR QUE LA CAPACIDAD DE LA EMBARCACION
            // BUSCO LA EXISTENCIA            
            try
            {
                // Step 1 - Conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3
                MyCommand.CommandText = "SELECT cap_comb FROM unidades WHERE id = " + cmbUnidadNaval.SelectedValue + "";

                // Step 4
                MyConexion.Open();

                // Step 5
                decimal CapCombustible = Convert.ToDecimal(MyCommand.ExecuteScalar());

                if (myCantidad > CapCombustible)
                {
                    this.cModo = "Negativo";
                    MessageBox.Show("La cantidad de combustible excede la capacidad de la embarcacion...");
                }

                // Step 7
                MyConexion.Close();

            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }
        }

        private void updateCantidad()
        {
            if (this.cModo != "Negativo")
            {
                try
                {
                    // Step 1 - Stablishing the connection
                    MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - Crear el comando de ejecucion
                    MySqlCommand myCommand = MyConexion.CreateCommand();

                    // Step 3 - Comando a ejecutar
                    myCommand.CommandText = "UPDATE existencia SET cantidad = @cantidad " +
                        " WHERE id_unidad = " + cmbUnidadNaval.SelectedValue + "";
                    myCommand.Parameters.AddWithValue("@cantidad", myCantidad);

                    // Step 4 - Opening the connection
                    MyConexion.Open();

                    // Step 5 - Executing the query
                    int nFilas = myCommand.ExecuteNonQuery();
                    if (nFilas > 0)
                    {
                        MessageBox.Show("Existencia actualizada satisfactoriamente...");
                    }
                    else
                    {
                        MessageBox.Show("No fue actualizada la existencia...");
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
                        // ACTUALIZANDO LA EXISTENCIA
                        this.searchExistencia();
                        this.addCantidad();
                        this.updateCantidad();

                        if (this.cModo != "Negativo")
                        {
                            // Step 1 - Stablishing the connection
                            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                            // Step 2 - Crear el comando de ejecucion
                            MySqlCommand myCommand = MyConexion.CreateCommand();

                            // Step 3 - Comando a ejecutar
                            myCommand.CommandText = "INSERT INTO movimientocombustible(fecha, unidadnaval, cantidad, actividad,"+
                            " actividad_detalle, mov, status, millas) values(@fecha, @unidadnaval, @cantidad, @actividad, @detalle, @mov, @status, @millas)";
                            myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                            myCommand.Parameters.AddWithValue("@unidadnaval", cmbUnidadNaval.SelectedValue);

                            // Convierto el campo monto en texto
                            txtCantidad.Text = Convert.ToString(txtCantidad.Text);
                            // Cambio el valor del textbox a decimal
                            string myValue = Convert.ToString(txtCantidad.Text);
                            decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                            //                        
                            myCommand.Parameters.AddWithValue("@cantidad", myValueMonto);

                            // Convierto el campo milla en texto
                            txtMillas.Text = Convert.ToString(txtMillas.Text);
                            // Cambio el valor del textbox a decimal
                            string myValueMillas = Convert.ToString(txtMillas.Text);
                            decimal myValueMontoMillas = clsFunctions.ParseCurrencyFormat(myValueMillas);
                            //                        
                            myCommand.Parameters.AddWithValue("@millas", myValueMontoMillas);
                            
                            myCommand.Parameters.AddWithValue("@actividad", cmbActividad.SelectedValue);
                            myCommand.Parameters.AddWithValue("@detalle", txtDescripcion.Text);
                            myCommand.Parameters.AddWithValue("@mov", 'S');
                            myCommand.Parameters.AddWithValue("@status", 1);

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
                        myCommand.CommandText = "UPDATE entrada SET fecha = @fecha, unidadnaval = @unidadnaval, " +
                            "cantidad = @cantidad, actividad = @actividad, actividad_detalle = @actividad_detalle, "+
                            "millas = @millas WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@unidadnaval", cmbUnidadNaval.SelectedValue);

                        // Convierto el campo monto en texto
                        txtCantidad.Text = Convert.ToString(txtCantidad.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(txtCantidad.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        //                        
                        myCommand.Parameters.AddWithValue("@cantidad", myValueMonto);

                        // Convierto el campo milla en texto
                        txtMillas.Text = Convert.ToString(txtMillas.Text);
                        // Cambio el valor del textbox a decimal
                        string myValueMillas = Convert.ToString(txtMillas.Text);
                        decimal myValueMontoMillas = clsFunctions.ParseCurrencyFormat(myValueMillas);
                        //                        
                        myCommand.Parameters.AddWithValue("@millas", myValueMontoMillas);
                            

                        myCommand.Parameters.AddWithValue("@actividad", cmbActividad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@actividad_detalle", txtDescripcion.Text);

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
                    MyCommand.CommandText = "SELECT fecha, unidadnaval, cantidad, actividad, actividad_detalle, millas " +
                        "FROM movimientocombustible WHERE id = " + txtID.Text + "";

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
                            cmbUnidadNaval.SelectedValue = MyReader["unidadnaval"].ToString();
                            // Llamo la funcion para formatear el campo.-
                            txtCantidad.Text = MyReader["cantidad"].ToString();
                            decimal monto = Convert.ToDecimal(txtCantidad.Text);
                            txtCantidad.Text = clsFunctions.GetCurrencyFormat(monto);
                            //
                            
                            // Llamo la funcion para formatear el campo.-
                            txtMillas.Text = MyReader["millas"].ToString();
                            decimal montoMillas = Convert.ToDecimal(txtMillas.Text);
                            txtMillas.Text = clsFunctions.GetCurrencyFormat(montoMillas);
                            //
                            
                            cmbActividad.SelectedValue = MyReader["actividad"].ToString();
                            txtDescripcion.Text = MyReader["actividad_detalle"].ToString();
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

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtDescripcion.Text != "" || txtDescripcion.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema Gestion de Combustibles Barcos", MessageBoxButtons.YesNo,
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

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMillas_Leave(object sender, EventArgs e)
        {
            if (txtMillas.Text == "")
            {
                MessageBox.Show("No puede dejar la cantidad sin valor...");
                this.txtMillas.Focus();
            }
            else
            {
                // Llamo la funcion para formatear el campo.-
                decimal monto = Convert.ToDecimal(txtMillas.Text);
                txtMillas.Text = clsFunctions.GetCurrencyFormat(monto);
            }
        }
    }
}
