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
    public partial class frmFacturacion : frmBase
    {

        int gCodigo = 0;
        string cModo = "Inicio";
        decimal sumaTotal;
        decimal subTotal;
        decimal total;
        decimal monto;
        double itbi = 1.18;
        int selectedRow = 0;
        int countFilas = 0;
        //int addInventario;
        //int delInventario;
        int cantExistencia;


        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
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
                MyCommand.CommandText = "SELECT count(*) FROM facturacion";

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
                    txtIDCliente.Enabled = false;
                    txtCliente.Enabled = false;
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
                    txtID.Enabled = false;
                    txtIDCliente.Enabled = false;
                    txtCliente.Enabled = false;
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
                    txtIDCliente.Enabled = false;
                    txtCliente.Enabled = false;
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
            txtIDCliente.Clear();
            txtCliente.Clear();
            dtgEntradaInventario.Rows.Clear();
            lblSumaTotal.Text = "0.00";
            lblTotal.Text = "0.00";
            cantExistencia = 0;
            sumaTotal = 0;
            subTotal = 0;
            monto = 0;
            countFilas = 0;
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
            if (txtID.Text == "" || txtIDCliente.Text == "" || countFilas <= 0)
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
                        myCommand.CommandText = "INSERT INTO facturacion(idcliente, fecha, monto_b, monto_n)" +
                            " values(@idcliente, @fecha, @monto_b, @monto_n)";                        
                        myCommand.Parameters.AddWithValue("@idcliente", txtIDCliente.Text);                        
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);

                        // Convierto el campo monto en texto
                        lblSumaTotal.Text = Convert.ToString(lblSumaTotal.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(lblSumaTotal.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        myCommand.Parameters.AddWithValue("@monto_b", myValueMonto);

                        // Convierto el campo monto en texto
                        lblTotal.Text = Convert.ToString(lblTotal.Text);
                        // Cambio el valor del textbox a decimal
                        string myValueTotal = Convert.ToString(lblTotal.Text);
                        decimal myValueMontoTotal = clsFunctions.ParseCurrencyFormat(myValueTotal);
                        myCommand.Parameters.AddWithValue("@monto_n", myValueMontoTotal);

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

        private void ImprimeSolicitud()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("No se puede generar una impresion de facturacion de inventario sin el codigo...");
                this.txtID.Focus();
            }
            else
            {
                try
                {
                    // private void ImprimeSolicitud()
                    {
                        DialogResult Result =
                        MessageBox.Show("Imprima la Facturacion" + System.Environment.NewLine + "Desea Imprimir la Facturacion", "Sistema de Gestion de Facturacion e Inventario", MessageBoxButtons.YesNo,
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
                txtCantidad.Focus();
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
                    cWhere = cWhere + " AND facturacion.idfacturacion =" + cCodigo + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT ");
                    sbQuery.Append(" facturacion.idfacturacion as id, facturacion_detalle.idproducto,");
                    sbQuery.Append(" facturacion_detalle.producto, facturacion_detalle.tipo,");
                    sbQuery.Append(" facturacion_detalle.precio, facturacion_detalle.cantidad, facturacion.fecha, ");
                    sbQuery.Append(" facturacion_detalle.subtotal, clientes.idcliente, clientes.nombre as cliente,");
                    sbQuery.Append(" clientes.rnc, provincias.nombre as provincia, clientes.direccion, clientes.telefono,");
                    sbQuery.Append(" facturacion.monto_n as total");
                    sbQuery.Append(" FROM facturacion");
                    sbQuery.Append(" INNER JOIN facturacion_detalle ON facturacion_detalle.idfacturacion = facturacion.idfacturacion");
                    sbQuery.Append(" INNER JOIN clientes ON clientes.idcliente = facturacion.idcliente");
                    sbQuery.Append(" INNER JOIN provincias ON provincias.provincia_id = clientes.provincia");
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
                        cTitulo = "FACTURA DETALLE";

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptFacturaDetalle orptFacturaDetalle = new rptFacturaDetalle();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;
                        orptFacturaDetalle.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtMovimientoInventario, orptFacturaDetalle, cTitulo);

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
                    MySqlCommand myCommand = new MySqlCommand("INSERT INTO facturacion_detalle(idfacturacion, idproducto, producto, tipo, precio, cantidad, subtotal)" +
                        " values (@id, @idproducto, @producto, @tipo, @precio, @cantidad, @subtotal)", MyConexion);
                    myCommand.Parameters.AddWithValue("@id", gCodigo);
                    myCommand.Parameters.AddWithValue("@idproducto", dtgEntradaInventario.Rows[row].Cells[0].Value);
                    myCommand.Parameters.AddWithValue("@producto", dtgEntradaInventario.Rows[row].Cells[1].Value);
                    myCommand.Parameters.AddWithValue("@tipo", dtgEntradaInventario.Rows[row].Cells[2].Value);
                    //myCommand.Parameters.AddWithValue("@precio", dtgEntradaInventario.Rows[row].Cells[3].Value);
                    //myCommand.Parameters.AddWithValue("@cantidad", dtgEntradaInventario.Rows[row].Cells[4].Value);
                    //myCommand.Parameters.AddWithValue("@subtotal", dtgEntradaInventario.Rows[row].Cells[5].Value);

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

                dtgEntradaInventario.Rows.Clear();


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

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtgEntradaInventario.Rows.Count > 1)
            {                
                MessageBox.Show("Debe eliminar primero los productos agregados...");             
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

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (txtIDCliente.Text == "" && txtTipoCliente.Text == "")
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
                        // verifico el tipo para filtrar en la base de datos
                        if (txtTipoCliente.Text == "A")
                        {
                            MyCommand.CommandText = "SELECT idproducto, producto, tipo, precio_a as precio, imagen from productos WHERE idproducto = '" + txtIDProducto.Text.Trim() + "'";
                        }
                        else
                        {
                            MyCommand.CommandText = "SELECT idproducto, producto, tipo, precio_b as precio, imagen from productos WHERE idproducto = '" + txtIDProducto.Text.Trim() + "'";
                        }

                        // Step 4 - connection open
                        MyclsConexion.Open();

                        // Step 5 - Creating the DataReader                    
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();

                        // Step 6 - Verifying if Reader has rows
                        if (MyReader.HasRows)
                        {
                            while (MyReader.Read())
                            {
                                txtIDProducto.Text = MyReader["idproducto"].ToString();
                                txtProducto.Text = MyReader["producto"].ToString();
                                txtTipo.Text = MyReader["tipo"].ToString();
                                txtPrecioProducto.Text = MyReader["precio"].ToString();

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
            if (txtIDCliente.Text == "")
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

                    // Verifico si la existencia es mayor o menos que la cantidad a facturar
                    if (cantExistencia > Convert.ToInt32(txtCantidad.Text))
                    {
                        // RESTO LA CANTIDAD LA CANTIDAD A LA VARIABLE ADDINVENTARIO
                        //this.addInventario = this.addInventario + Convert.ToInt32(txtCantidad.Text);
                        cantExistencia = cantExistencia - Convert.ToInt32(txtCantidad.Text);

                        // ACTUALIZO EL INVENTARIO
                        this.updateCantidad();


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
                        // DESPUES QUE AGREGO AL GRID Y ACTUALIZO EL INVENTARIO LIMPIO LOS CAMPOS
                        this.LimpiarTxtGrid();

                    }
                    else
                    {
                        MessageBox.Show("La cantidad a facturar es mayor que la cantidad en existencia...");
                        this.txtCantidad.Focus();
                    }                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }                

            }
            
        }

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
                        cantExistencia = cantExistencia + Convert.ToInt32(txtCantidad.Text);

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

        private void btnBuscarSuplidor_Click(object sender, EventArgs e)
        {
            frmBuscarClientes ofrmBuscarClientes = new frmBuscarClientes();
            ofrmBuscarClientes.ShowDialog();            
            string cCodigo = ofrmBuscarClientes.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtIDCliente.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT nombre, tipo from clientes WHERE idcliente = '" + cCodigo + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {

                            txtCliente.Text = MyReader["nombre"].ToString();
                            txtTipoCliente.Text = MyReader["tipo"].ToString();
                            
                            // Verifica Forma de Facturacion
                            this.verificaITBI();
                        }                        
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
            if (txtID.Text != "" && txtIDCliente.Text != "")
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
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
