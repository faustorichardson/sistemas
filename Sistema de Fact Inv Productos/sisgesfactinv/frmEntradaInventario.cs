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
    public partial class frmEntradaInventario : frmBase
    {
        int gCodigo = 0;
        string cModo = "Inicio";
        decimal sumaTotal;
        decimal subTotal;
        decimal total;
        decimal monto;
        double itbi = 1.18;
        int selectedRow=0;
        int countFilas = 0;
        //int addInventario;
        //int delInventario;
        int cantExistencia;

        public frmEntradaInventario()
        {
            InitializeComponent();
        }

        private void frmEntradaInventario_Load(object sender, EventArgs e)
        {
            picBox.Image = Properties.Resources.Image_capture_128x128;
            this.Limpiar();
            this.LimpiarTxtGrid();
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
                MyCommand.CommandText = "SELECT count(*) FROM entrada_inventario";

                // Step 4 - Open connection
                MyConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtID.Text = Convert.ToString(codigo);

                // Actualizo el Codigo Global
                gCodigo = codigo;

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
                    txtID.Enabled = false;
                    txtIDSuplidor.Enabled = false;
                    txtSuplidor.Enabled = false;
                    btnBuscar.Enabled = false;
                    dtFecha.Enabled = false;
                    btnBuscarProducto.Enabled = false;
                    btnBuscarSuplidor.Enabled = false;
                    btnAddGrid.Enabled = false;
                    btnDeleteGrid.Enabled = false;
                    txtTipo.Enabled = false;
                    txtPrecioProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    dtgEntradaInventario.Enabled = false;
                    chkITBI.Enabled = false;
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
                    txtID.Enabled = true;
                    txtIDSuplidor.Enabled = true;
                    txtSuplidor.Enabled = true;
                    btnBuscar.Enabled = true;
                    dtFecha.Enabled = true;
                    btnBuscarProducto.Enabled = true;
                    btnBuscarSuplidor.Enabled = true;
                    btnAddGrid.Enabled = true;
                    btnDeleteGrid.Enabled = true;
                    //txtTipo.Enabled = true;
                    txtPrecioProducto.Enabled = true;
                    txtCantidad.Enabled = true;
                    dtgEntradaInventario.Enabled = true;
                    chkITBI.Enabled = true;
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
                    txtID.Enabled = false;
                    txtIDSuplidor.Enabled = false;
                    txtSuplidor.Enabled = false;
                    btnBuscar.Enabled = false;
                    dtFecha.Enabled = false;
                    btnBuscarProducto.Enabled = false;
                    btnBuscarSuplidor.Enabled = false;
                    btnAddGrid.Enabled = false;
                    btnDeleteGrid.Enabled = false;
                    txtTipo.Enabled = false;
                    txtPrecioProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    dtgEntradaInventario.Enabled = false;
                    chkITBI.Enabled = false;
                    break;

                case "Editar":
                    //this.btnNuevo.Enabled = false;
                    //this.btnGrabar.Enabled = true;
                    //this.btnEditar.Enabled = false;
                    //this.btnBuscar.Enabled = false;
                    //this.btnImprimir.Enabled = false;
                    //this.btnEliminar.Enabled = true;
                    //this.btnCancelar.Enabled = true;
                    ////
                    //txtID.Enabled = true;
                    //txtIDSuplidor.Enabled = true;
                    //txtSuplidor.Enabled = true;
                    //btnBuscar.Enabled = true;
                    //dtFecha.Enabled = true;
                    //btnBuscarProducto.Enabled = true;
                    //btnBuscarSuplidor.Enabled = true;
                    //btnAddGrid.Enabled = true;
                    //btnDeleteGrid.Enabled = true;
                    //txtTipo.Enabled = true;
                    //txtPrecioProducto.Enabled = true;
                    //txtCantidad.Enabled = true;
                    //dtgEntradaInventario.Enabled = true;
                    //break;

                case "Buscar":
                    //this.btnNuevo.Enabled = true;
                    //this.btnGrabar.Enabled = false;
                    //this.btnEditar.Enabled = true;
                    //this.btnBuscar.Enabled = true;
                    //this.btnImprimir.Enabled = true;
                    //this.btnEliminar.Enabled = false;
                    //this.btnCancelar.Enabled = false;
                    //this.btnSalir.Enabled = true;
                    ////
                    //txtID.Enabled = false;
                    //txtIDSuplidor.Enabled = false;
                    //txtSuplidor.Enabled = false;
                    //btnBuscar.Enabled = false;
                    //dtFecha.Enabled = false;
                    //btnBuscarProducto.Enabled = false;
                    //btnAddGrid.Enabled = false;
                    //btnDeleteGrid.Enabled = false;
                    //txtTipo.Enabled = false;
                    //txtPrecioProducto.Enabled = false;
                    //txtCantidad.Enabled = false;
                    //dtgEntradaInventario.Enabled = false;
                    //break;

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
                    break;

                default:
                    break;
            }

        }

        private void Limpiar()
        {
            picBox.Image = Properties.Resources.Image_capture_128x128;
            txtID.Clear();
            txtIDSuplidor.Clear();
            txtSuplidor.Clear();
            dtgEntradaInventario.Rows.Clear();
            lblSumaTotal.Text = "0.00";
            lblTotal.Text = "0.00";
            cantExistencia = 0;
            sumaTotal = 0;
            subTotal = 0;
            monto = 0;
            countFilas = 0;
            chkITBI.Checked = false;
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

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (txtIDSuplidor.Text == "")
            {
                MessageBox.Show("No se puede buscar un producto sin antes buscar un suplidor...");
                btnBuscarSuplidor.Focus();
            }
            else
            {
                frmBuscarProductos ofrmBuscarProductos = new frmBuscarProductos();
                ofrmBuscarProductos.ShowDialog();
                string cCodigo = ofrmBuscarProductos.cCodigo;

                // Si selecciono un registro
                if (cCodigo != "" && cCodigo != null)
                {
                    // Mostrar el codigo                      
                    txtIDProducto.Text = Convert.ToString(cCodigo).Trim();
                    try
                    {
                        // Step 1 - clsConexion
                        MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - creating the command object
                        MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                        // Step 3 - creating the commandtext
                        //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                        MyCommand.CommandText = "SELECT * from productos WHERE idproducto = '" + txtIDProducto.Text.Trim() + "'";

                        // Step 4 - connection open
                        MyclsConexion.Open();

                        // Step 5 - Creating the DataReader                    
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();

                        // Step 6 - Verifying if Reader has rows
                        if (MyReader.HasRows)
                        {
                            while (MyReader.Read())
                            {
                                txtProducto.Text = MyReader["producto"].ToString();
                                txtTipo.Text = MyReader["tipo"].ToString();

                                // Leyendo la imagen
                                byte[] img = (byte[])(MyReader["imagen"]);

                                if (img == null)
                                {
                                    picBox.Image = null;
                                }
                                else
                                {
                                    MemoryStream mstream = new MemoryStream(img);
                                    picBox.Image = System.Drawing.Image.FromStream(mstream);
                                }
                            }
                            //this.cModo = "Buscar";
                            //this.Botones();
                            this.txtPrecioProducto.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron registros con este ID de Producto...", "SisGesFactInv", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAddGrid_Click(object sender, EventArgs e)
        {                        
            // VERIFICO QUE PRIMERO SE SELECCIONE UN SUPLIDOR
            if (txtIDSuplidor.Text == "")
            {
                MessageBox.Show("Antes de agregar productos debe de seleccionar el suplidor...");
                this.btnBuscarSuplidor.Focus();
            }
            else if (txtIDProducto.Text == "")
            {
                MessageBox.Show("Antes de agregar productos debe de buscarlos...");
                this.btnBuscarProducto.Focus();
            }
            else
            {
                // BUSCAR INVENTARIO Y AGREGAR
                try
                {
                    // BUSCO INVENTARIO Y LO PASO A LA VARIABLE ADDINVENTARIO
                    this.searchExistencia();

                    // SUMO LA CANTIDAD A LA VARIABLE ADDINVENTARIO
                    //this.addInventario = this.addInventario + Convert.ToInt32(txtCantidad.Text);
                    cantExistencia = cantExistencia + Convert.ToInt32(txtCantidad.Text);

                    // ACTUALIZO EL INVENTARIO
                    this.updateCantidad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
                
                // ACTUALIZANDO LA VARIABLE Y EL LABEL DEL SUBTOTAL
                try
                {
                    // Creo la variable del tipo double "SUBTOTAL" para calcular el resultado de cantidad por precio
                    subTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecioProducto.Text);

                    // Registro la entrada al GRID
                    dtgEntradaInventario.Rows.Add(txtIDProducto.Text, txtProducto.Text, txtTipo.Text, txtPrecioProducto.Text, txtCantidad.Text, subTotal);

                    // Realizo la operacion de sumar el subtotal mas la variable acumuladora sumatotal
                    sumaTotal = sumaTotal + subTotal;

                    // Llamo la funcion para formatear el campo.-
                    monto = Convert.ToDecimal(sumaTotal);
                    lblSumaTotal.Text = clsFunctions.GetCurrencyFormat(monto);

                    // Agrego una fila al contador
                    countFilas = countFilas + 1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

                // ACTUALIZANDO LA VARIABLE Y EL LABEL DEL TOTAL + ITBIs
                if (chkITBI.Checked == true)
                {
                    total = sumaTotal;

                    lblTotal.Text = clsFunctions.GetCurrencyFormat(total);
                }
                else
                {
                    try
                    {
                        // Creo la variable del tipo double "TOTAL" para calcular el resultado de sumatotal por itbi
                        total = sumaTotal * Convert.ToDecimal(itbi);

                        // Formateo la variable TOTAL para llevarlo al label
                        lblTotal.Text = clsFunctions.GetCurrencyFormat(total);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }

            }

            this.LimpiarTxtGrid();
   
        }

        private void searchExistencia()
        {
            // Limpio variable existencia
            cantExistencia = 0;

            // BUSCO LA EXISTENCIA            
            try
            {
                // Step 1 - Conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3
                MyCommand.CommandText = "SELECT cantidad FROM inventario WHERE idproducto = " + txtIDProducto.Text + "";

                // Step 4
                MyConexion.Open();

                // Step 5
                //this.addInventario = Convert.ToInt32(MyCommand.ExecuteScalar());
                cantExistencia = Convert.ToInt32(MyCommand.ExecuteScalar());

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
        
        private void updateCantidad()
        {
            try
            {
                // Step 1 - Stablishing the connection
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Crear el comando de ejecucion
                MySqlCommand myCommand = MyConexion.CreateCommand();

                // Step 3 - Comando a ejecutar
                myCommand.CommandText = "UPDATE inventario SET cantidad = @cantidad " +
                    " WHERE idproducto = " + txtIDProducto.Text + "";
                myCommand.Parameters.AddWithValue("@cantidad", cantExistencia);
                
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void LimpiarTxtGrid()
        {            
            txtIDProducto.Clear();
            txtProducto.Clear();
            txtPrecioProducto.Clear();
            txtTipo.Clear();
            txtCantidad.Clear();
        }

        //private void btnUpdateGrid_Click(object sender, EventArgs e)
        //{
        //    if (txtIDProducto.Text == "")
        //    {
        //        MessageBox.Show("No se puede modificar un valor si no se selecciona...");
        //        this.btnBuscarProducto.Focus();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            // MULTIPLICO NUEVAMENTE EL PRECIO POR LA CANTIDAD PARA OBTENER EL SUBTOTAL
        //            double monto = Convert.ToDouble(txtPrecioProducto.Text) * Convert.ToDouble(txtCantidad);
        //            string subtotal = Convert.ToString(monto);

        //            // ASIGNANDO EL VALOR DEL SELECTEDROW
        //            selectedRow = dtgEntradaInventario.CurrentCell.RowIndex;

        //            // REGISTRO LA INFORMACION ACTUALIZADA EN EL GRID
        //            DataGridViewRow newDataRow = dtgEntradaInventario.Rows[selectedRow];
        //            newDataRow.Cells[0].Value = Convert.ToString(txtIDProducto.Text);
        //            newDataRow.Cells[1].Value = txtProducto.Text;
        //            newDataRow.Cells[2].Value = txtTipo.Text;                    
        //            newDataRow.Cells[3].Value = txtPrecioProducto.Text;
        //            newDataRow.Cells[4].Value = txtCantidad.Text;
        //            newDataRow.Cells[5].Value = subtotal;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            throw;
        //        }                
        //    }
        //}

        private void btnDeleteGrid_Click(object sender, EventArgs e)
        {
            if (countFilas > 0)
            {
                if (txtIDProducto.Text != "" && txtCantidad.Text != "")
                {
                    // BUSCANDO Y ACTUALIZANDO LA EXISTENCIA EN LA TABLA INVENTARIO
                    try
                    {
                        // BUSCO INVENTARIO Y LO PASO A LA VARIABLE ADDINVENTARIO
                        this.searchExistencia();

                        // RESTO LA CANTIDAD A LA VARIABLE EXISTENCIA
                        cantExistencia = cantExistencia - Convert.ToInt32(txtCantidad.Text);

                        // ACTUALIZO EL INVENTARIO
                        this.updateCantidad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }

                    // RESTANDO EL SUBTOTAL A LA VARIABLE SUMATOTAL
                    try
                    {

                        // Creo la variable del tipo double "SUBTOTAL" para calcular el resultado de cantidad por precio
                        subTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecioProducto.Text);

                        // selecciono el indice del registro en el grid
                        selectedRow = dtgEntradaInventario.CurrentCell.RowIndex;

                        // remuevo la linea que corresponde al indice
                        dtgEntradaInventario.Rows.RemoveAt(selectedRow);

                        // Actualizo la variable de las filas
                        countFilas = countFilas - 1;

                        // Actualizo el monto
                        sumaTotal = sumaTotal - subTotal;

                        // Formateo la cifra
                        lblSumaTotal.Text = clsFunctions.GetCurrencyFormat(sumaTotal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }

                    // ACTUALIZANDO LA VARIABLE Y EL LABEL DEL SUBTOTAL + ITBIs
                    if (chkITBI.Checked == true)
                    {
                        total = sumaTotal;

                        lblTotal.Text = clsFunctions.GetCurrencyFormat(total);
                    }
                    else
                    {
                        try
                        {
                            // Creo la variable del tipo double "TOTAL" para calcular el resultado de sumatotal por itbi
                            total = sumaTotal * Convert.ToDecimal(itbi);

                            // Formateo la variable TOTAL para llevarlo al label
                            lblTotal.Text = clsFunctions.GetCurrencyFormat(total);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            throw;
                        }
                    }
                    this.LimpiarTxtGrid();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el producto que desea remover...");
                    this.dtgEntradaInventario.Focus();
                }                
            }
            else
            {
                MessageBox.Show("No hay datos para eliminar o debe de seleccionar el producto...");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.LimpiarTxtGrid();
            this.Botones();
            this.ProximoCodigo();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtIDSuplidor.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtCantidad.Focus();
            }
            else
            {
                if (cModo == "Nuevo")
                {
                    // Verifico nuevamente el siguiente codigo antes de guardar
                    this.ProximoCodigo();

                    try
                    {
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "INSERT INTO entrada_inventario(idsuplidor, suplidor, fecha, monto_total, total)" +
                            " values(@idsuplidor, @suplidor, @fecha, @monto_total, @total)";
                        myCommand.Parameters.AddWithValue("@idsuplidor", txtIDSuplidor.Text);
                        myCommand.Parameters.AddWithValue("@suplidor", txtCantidad.Text);
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);

                        // Convierto el campo monto en texto
                        lblSumaTotal.Text = Convert.ToString(lblSumaTotal.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(lblSumaTotal.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);                        
                        myCommand.Parameters.AddWithValue("@monto_total", myValueMonto);

                        // Convierto el campo monto en texto
                        lblTotal.Text = Convert.ToString(lblTotal.Text);
                        // Cambio el valor del textbox a decimal
                        string myValueTotal = Convert.ToString(lblTotal.Text);
                        decimal myValueMontoTotal = clsFunctions.ParseCurrencyFormat(myValueTotal);                                                
                        myCommand.Parameters.AddWithValue("@total", myValueMontoTotal);

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

                    // Llamo funcion que guarda data del grid
                    this.saveGrid();

                }
                                
                // llamo la funcion para imprimir entrada.-
                this.ImprimeSolicitud();

                // cuando termino de imprimir
                this.Limpiar();
                this.LimpiarTxtGrid();
                this.cModo = "Inicio";
                this.Botones();
            }
        }

        private void saveGrid()
        {
            try
            {
                // Configuro la conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Abro conexion
                MyConexion.Open();

                // Creo bucle de guardar informacion del grid
                for (int row = 0; row < countFilas; row++)
                {
                    MySqlCommand myCommand = new MySqlCommand("INSERT INTO entrada_inventario_detalle(id, idproducto, producto, tipo, precio, cantidad, subtotal)"+ 
                        " values (@id, @idproducto, @producto, @tipo, @precio, @cantidad, @subtotal)", MyConexion);
                    myCommand.Parameters.AddWithValue("@id", gCodigo);
                    myCommand.Parameters.AddWithValue("@idproducto", dtgEntradaInventario.Rows[row].Cells[0].Value);
                    myCommand.Parameters.AddWithValue("@producto", dtgEntradaInventario.Rows[row].Cells[1].Value);
                    myCommand.Parameters.AddWithValue("@tipo", dtgEntradaInventario.Rows[row].Cells[2].Value);
                    
                    // Cambio el valor del grid a decimal
                    string myValue_precio = Convert.ToString(dtgEntradaInventario.Rows[row].Cells[3].Value);
                    decimal myValueMonto_precio = clsFunctions.ParseCurrencyFormat(myValue_precio);
                    myCommand.Parameters.AddWithValue("@precio", myValueMonto_precio);
                    //myCommand.Parameters.AddWithValue("@precio", dtgEntradaInventario.Rows[row].Cells[3].Value);
                    myCommand.Parameters.AddWithValue("@cantidad", dtgEntradaInventario.Rows[row].Cells[4].Value);

                    string myValue_subtotal = Convert.ToString(dtgEntradaInventario.Rows[row].Cells[5].Value);
                    decimal myValueMonto_subtotal = clsFunctions.ParseCurrencyFormat(myValue_subtotal);                    
                    myCommand.Parameters.AddWithValue("@subtotal", myValueMonto_subtotal);

                    // EJECUTO EL COMANDO
                    myCommand.ExecuteNonQuery();
                }

                // Limpio el grid.-
                this.dtgEntradaInventario.Rows.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //if (txtCantidad.Text == "")
            //{
            //    MessageBox.Show("Debe de introducir el numero de una entrada...");
            //    this.txtCantidad.Focus();
            //}
            //else
            //{
            //    // BUSCANDO EN LA TABLA SECUENCIA_SOLICITUDCOMBUSIBLE
            //    try
            //    {
            //        // Step 1 - Conexion
            //        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            //        // Step 2 - creating the command object
            //        MySqlCommand MyCommand = MyConexion.CreateCommand();

            //        // Step 3 - creating the commandtext
            //        MyCommand.CommandText = "SELECT id, fecha, suplidor FROM  WHERE id = " + txtSolicitud.Text + "";

            //        // Step 4 - connection open
            //        MyConexion.Open();

            //        // Step 5 - Creating the DataReader                    
            //        MySqlDataReader MyReader = MyCommand.ExecuteReader();

            //        // Step 6 - Verifying if Reader has rows
            //        if (MyReader.HasRows)
            //        {
            //            while (MyReader.Read())
            //            {
            //                dtFecha.Value = Convert.ToDateTime(MyReader["fecha"]);
            //                txtNota.Text = MyReader["nota"].ToString();
            //            }

            //            this.cModo = "Buscar";
            //            this.Botones();
            //        }
            //        else
            //        {
            //            MessageBox.Show("No se encontraron registros...");
            //            this.cModo = "Inicio";
            //            this.Botones();
            //            this.Limpiar();
            //            this.txtSolicitud.Focus();
            //        }

            //        // Step 6 - Closing all
            //        MyReader.Close();
            //        MyCommand.Dispose();
            //        MyConexion.Close();
            //    }
            //    catch (Exception myEx)
            //    {
            //        MessageBox.Show(myEx.Message);
            //        throw;
            //    }

            //    // BUSCANDO LA INFORMACION EN LA TABLA: SOLICITUD. PARA LUEGO LLENAR EL GRID
            //    if (txtSolicitud.Text != "")
            //    {
            //        try
            //        {
            //            // Establishing the MySQL Connection
            //            MySqlConnection conn = new MySqlConnection(clsConexion.ConectionString);

            //            // Open the connection to db
            //            conn.Open();

            //            // Creating the DataReader
            //            MySqlDataAdapter myAdapter = new MySqlDataAdapter("SELECT tipo_combustible as Id, descripcion_combustible as Combustible," +
            //                " cantidad as Cantidad FROM solicitud WHERE id = " + txtSolicitud.Text + "", conn);

            //            // Creating the Dataset
            //            DataSet myDs = new System.Data.DataSet();

            //            // Filling the data adapter
            //            myAdapter.Fill(myDs, "Solicitud");

            //            // Fill the Gridview                        
            //            dgview.DataSource = myDs.Tables[0];

            //            //this.cModo = "Buscar";
            //            //this.Botones();

            //        }
            //        catch (Exception myEx)
            //        {
            //            MessageBox.Show(myEx.Message);
            //            throw;
            //        }
            //    }

            //}
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmPrintEntradaInventario ofrmPrintEntradaInventario = new frmPrintEntradaInventario();
            ofrmPrintEntradaInventario.ShowDialog();
        }

        private void ImprimeSolicitud()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("No se puede generar una impresion de entrada a inventario sin el codigo...");
                this.txtID.Focus();
            }
            else
            {
                try
                {
                    // private void ImprimeSolicitud()
                    {
                        DialogResult Result =
                        MessageBox.Show("Imprima la Entrada a Inventario" + System.Environment.NewLine + "Desea Imprimir la Entrada a Inventario", "Sistema de Gestion de Facturacion e Inventario", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                        switch (Result)
                        {
                            case DialogResult.Yes:
                                GenerarReporte();
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }
        
        private void GenerarReporte()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("No se permite generar el reporte sin su debida numeracion...");
                txtID.Focus();
            }
            else
            {

                //clsConexion a la base de datos
                MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);
                // Creando el command que ejecutare
                MySqlCommand myCommand = new MySqlCommand();
                // Creando el Data Adapter
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                // Creando el String Builder
                StringBuilder sbQuery = new StringBuilder();
                // Otras variables del entorno
                string cWhere = " WHERE 1 = 1";
                string cUsuario = frmLogin.cUsuarioActual;
                string cTitulo = "";
                int cCodigo = Convert.ToInt32(txtID.Text);

                try
                {
                    // Abro clsConexion
                    myclsConexion.Open();
                    // Creo comando
                    myCommand = myclsConexion.CreateCommand();
                    // Adhiero el comando a la clsConexion
                    myCommand.Connection = myclsConexion;
                    // Filtros de la busqueda
                    //int cCodigoImprimir = Convert.ToInt32(txtIdLicencia.Text);
                    cWhere = cWhere + " AND entrada_inventario.id =" + cCodigo + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT ");
                    sbQuery.Append(" entrada_inventario.id, entrada_inventario.fecha, entrada_inventario.monto_total,");
                    sbQuery.Append(" entrada_inventario.total, entrada_inventario.anulada, entrada_inventario_detalle.idproducto,");
                    sbQuery.Append(" entrada_inventario_detalle.producto, entrada_inventario_detalle.tipo,");
                    sbQuery.Append(" entrada_inventario_detalle.precio, entrada_inventario_detalle.cantidad, ");
                    sbQuery.Append(" entrada_inventario_detalle.subtotal, suplidores.nombre as suplidor, entrada_inventario.total, ");
                    sbQuery.Append(" suplidores.rnc, suplidores.direccion, suplidores.telefono, provincias.nombre as provincia,");
                    sbQuery.Append(" suplidores.idsuplidor");
                    sbQuery.Append(" FROM entrada_inventario");
                    sbQuery.Append(" INNER JOIN entrada_inventario_detalle ON entrada_inventario.id = entrada_inventario_detalle.id");
                    sbQuery.Append(" INNER JOIN suplidores ON suplidores.idsuplidor = entrada_inventario.idsuplidor");
                    sbQuery.Append(" INNER JOIN provincias ON provincias.provincia_id = suplidores.provincia");
                    sbQuery.Append(cWhere);

                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtMovimientoInventario = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtMovimientoInventario);
                    // Cierro el objeto clsConexion
                    myclsConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtMovimientoInventario.Rows.Count;
                    if (nRegistro == 0)
                    {
                        MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema de Gestion de Facturacion e Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        //1ero.HACEMOS LA COLECCION DE PARAMETROS
                        //los campos de parametros contiene un objeto para cada campo de parametro en el informe
                        ParameterFields oParametrosCR = new ParameterFields();
                        //Proporciona propiedades para la recuperacion y configuracion del tipo de los parametros
                        ParameterValues oParametrosValuesCR = new ParameterValues();

                        //2do.CREAMOS LOS PARAMETROS
                        ParameterField oUsuario = new ParameterField();
                        //parametervaluetype especifica el TIPO de valor de parametro
                        //ParameterValueKind especifica el tipo de valor de parametro en la PARAMETERVALUETYPE de la Clase PARAMETERFIELD
                        oUsuario.ParameterValueType = ParameterValueKind.StringParameter;

                        //3ero.VALORES PARA LOS PARAMETROS
                        //ParameterDiscreteValue proporciona propiedades para la recuperacion y configuracion de 
                        //parametros de valores discretos
                        ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                        oUsuarioDValue.Value = cUsuario;

                        //4to. AGREGAMOS LOS VALORES A LOS PARAMETROS
                        oUsuario.CurrentValues.Add(oUsuarioDValue);


                        //5to. AGREGAMOS LOS PARAMETROS A LA COLECCION 
                        oParametrosCR.Add(oUsuario);

                        //nombre del parametro en CR (Crystal Reports)
                        oParametrosCR[0].Name = "cUsuario";

                        //nombre del TITULO DEL INFORME
                        cTitulo = "DETALLE DE ENTRADA DE INVENTARIO";

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptEntradaInventario orptEntradaInventario = new rptEntradaInventario();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;

                        orptEntradaInventario.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtMovimientoInventario, orptEntradaInventario, cTitulo);

                        //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                        ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                        ofrmPrinter.ShowDialog();
                    }
                }
                catch (Exception myEx)
                {
                    MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    clsExceptionLog.LogError(myEx, false);
                    return;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtgEntradaInventario.Rows.Count > 1)
            {
                //DialogResult Result =
                //MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema de Facturacion e Inventario", MessageBoxButtons.YesNo,
                //        MessageBoxIcon.Question);
                //switch (Result)
                //{
                //    case DialogResult.Yes:
                //        cModo = "Actualiza";
                //        btnGrabar_Click(sender, e);
                //        break;
                //}
                MessageBox.Show("Debe eliminar primero los productos agregados...");
                //btnDeleteGrid.Focus();
            }
            else
            {
                this.cModo = "Inicio";
                this.Botones();
            }

            this.Limpiar();
            this.LimpiarTxtGrid();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (countFilas > 0)
            {
                MessageBox.Show("Debe eliminar primero los productos agregados...");
                //btnDeleteGrid.Focus();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBuscarSuplidor_Click(object sender, EventArgs e)
        {
            frmBuscarSuplidor ofrmBuscarSuplidor = new frmBuscarSuplidor();
            ofrmBuscarSuplidor.ShowDialog();
            string cCodigo = ofrmBuscarSuplidor.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtIDSuplidor.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT idsuplidor, nombre from suplidores WHERE idsuplidor = '" + cCodigo + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {                
                            txtSuplidor.Text = MyReader["nombre"].ToString(); 
                           
                            //Verifica si lleva ITBIs o no
                            this.verificaITBI();
                        }
                        //this.cModo = "Buscar";
                        //this.Botones();
                        //this.txtPrecioProducto.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con este ID de Suplidor...", "SisGesFactInv", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void verificaITBI()
        {
            if (txtID.Text != "" && txtSuplidor.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Tipo de facturacion..." + System.Environment.NewLine + "Desea Facturar con ITBIs incluido", "Sistema de Facturacion e Inventario", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.No:
                        this.chkITBI.Checked = true;
                        break;
                }
            }

        }

        private void txtPrecioProducto_Leave(object sender, EventArgs e)
        {
            if (txtPrecioProducto.Text == "")
            {
                MessageBox.Show("No puede dejar la cantidad sin valor...");
                txtPrecioProducto.Focus();
            }
            else
            {
                // Llamo la funcion para formatear el campo.-
                decimal monto = Convert.ToDecimal(txtPrecioProducto.Text);
                txtPrecioProducto.Text = clsFunctions.GetCurrencyFormat(monto);
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

        private void dtgEntradaInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dtgEntradaInventario.Rows[selectedRow];
            // Lleno los campos
            txtIDProducto.Text = row.Cells[0].Value.ToString();
            txtProducto.Text = row.Cells[1].Value.ToString();
            txtTipo.Text = row.Cells[2].Value.ToString();
            txtPrecioProducto.Text = row.Cells[3].Value.ToString();
            txtCantidad.Text = row.Cells[4].Value.ToString();
        }

        private void chkITBI_Click(object sender, EventArgs e)
        {
            if (chkITBI.Checked == true)
            {
                if (countFilas > 0)
                {
                    MessageBox.Show("Para alterar la factura debe borrar los productos...");                    
                }
            }
            else
            {
                if (countFilas > 0)
                {
                    MessageBox.Show("Para alterar la factura debe borrar los productos...");
                    chkITBI.Checked = false;

                }
            }
        }
        
       
        
    }
}
