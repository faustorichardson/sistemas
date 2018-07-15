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
    public partial class frmProductos : frmBase
    {
        string cModo = "Inicio";

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {            
            this.Limpiar();
            this.fillCmbCategoria();
            this.cModo = "Inicio";
            this.Botones();
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
                    this.txtProducto.Enabled = false;
                    this.txtReferencia.Enabled = false;
                    this.txtPrecioA.Enabled = false;
                    this.txtPrecioB.Enabled = false;
                    this.txtReorden.Enabled = false;
                    this.cmbCategoria.Enabled = false;
                    this.rbTipo1.Enabled = false;
                    this.rbTipo2.Enabled = false;
                    this.rbTipo3.Enabled = false;
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
                    this.txtProducto.Enabled = true;
                    this.txtReferencia.Enabled = true;
                    this.txtPrecioA.Enabled = true;
                    this.txtPrecioB.Enabled = true;
                    this.txtReorden.Enabled = true;
                    this.cmbCategoria.Enabled = true;
                    this.rbTipo1.Enabled = true;
                    this.rbTipo2.Enabled = true;
                    this.rbTipo3.Enabled = true;
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
                    this.txtProducto.Enabled = false;
                    this.txtReferencia.Enabled = false;
                    this.txtPrecioA.Enabled = false;
                    this.txtPrecioB.Enabled = false;
                    this.txtReorden.Enabled = false;
                    this.cmbCategoria.Enabled = false;
                    this.rbTipo1.Enabled = false;
                    this.rbTipo2.Enabled = false;
                    this.rbTipo3.Enabled = false;
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
                    this.txtProducto.Enabled = true;
                    this.txtReferencia.Enabled = true;
                    this.txtPrecioA.Enabled = true;
                    this.txtPrecioB.Enabled = true;
                    this.txtReorden.Enabled = true;
                    this.cmbCategoria.Enabled = true;
                    this.rbTipo1.Enabled = true;
                    this.rbTipo2.Enabled = true;
                    this.rbTipo3.Enabled = true;
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
                    this.txtProducto.Enabled = false;
                    this.txtReferencia.Enabled = false;
                    this.txtPrecioA.Enabled = false;
                    this.txtPrecioB.Enabled = false;
                    this.txtReorden.Enabled = false;
                    this.cmbCategoria.Enabled = false;
                    this.rbTipo1.Enabled = false;
                    this.rbTipo2.Enabled = false;
                    this.rbTipo3.Enabled = false;
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
                    this.txtProducto.Enabled = false;
                    this.txtReferencia.Enabled = false;
                    this.txtPrecioA.Enabled = false;
                    this.txtPrecioB.Enabled = false;
                    this.txtReorden.Enabled = false;
                    this.cmbCategoria.Enabled = false;
                    this.rbTipo1.Enabled = false;
                    this.rbTipo2.Enabled = false;
                    this.rbTipo3.Enabled = false;
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
                MyCommand.CommandText = "SELECT count(*) FROM productos";

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

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtDescripcion.Clear();
            this.txtPrecioA.Clear();
            this.txtPrecioB.Clear();
            this.txtProducto.Clear();
            this.txtReferencia.Clear();
            this.rbTipo1.Checked = true;
            this.picBox.Image = null;
            this.picBox.Image = Properties.Resources.Image_capture_128x128;
            this.txtPicture.Text = "C:\\SisGesFactInv\\productos\\Image_capture_128x128.png";
            this.txtReorden.Clear();
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
                MySqlCommand MyCommand = new MySqlCommand("SELECT idcategoria, categoria FROM categorias ORDER BY categoria ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("idcategoria", typeof(int));
                MyDataTable.Columns.Add("categoria", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbCategoria.ValueMember = "idcategoria";
                cmbCategoria.DisplayMember = "categoria";
                cmbCategoria.DataSource = MyDataTable;

                // Step 7
                MyConexion.Close();

            }
            catch (Exception)
            {
                
                throw;
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
            // declarando la variable del tipo imagen
            byte[] imageBT = null;

            if (txtPicture.Text != "")
            {
                // Habilitando las variables que me guardaran el valor de la imagen                
                FileStream fStream = new FileStream(this.txtPicture.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageBT = br.ReadBytes((int)fStream.Length);
                // Fin del codigo correspondiente para la lectura de la imagen.
            }
            else
            {
                this.txtPicture.Text = "C:\\SisGesFactInv\\productos\\Image_capture_128x128.png";
            }
            
            if (txtID.Text == "" || txtProducto.Text == "" || txtPicture.Text == "" || picBox.Image == null)
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtProducto.Focus();
            }
            else
            {
                if (cModo == "Nuevo")
                {
                    // AGREGO EL PRODUCTO A LA TABLA PRODUCTO
                    try
                    {
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "INSERT INTO productos(referencia, producto, descripcion, idcategoria," +
                            " precio_a, precio_b, tipo, imagen, rutafoto, reorden) values(@referencia, @nombre, @descripcion, @idcategoria, "+
                            " @precio_a, @precio_b, @tipo, @imagen, @rutafoto, @reorden)";
                        myCommand.Parameters.AddWithValue("@referencia", txtReferencia.Text);
                        myCommand.Parameters.AddWithValue("@nombre", txtProducto.Text);
                        myCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        myCommand.Parameters.AddWithValue("@idcategoria", cmbCategoria.SelectedValue);
                        myCommand.Parameters.AddWithValue("@imagen", imageBT);
                        myCommand.Parameters.AddWithValue("@rutafoto", txtPicture.Text);
                        // Cambio el valor del textbox a decimal
                        // Monto A
                        string myValue_A = Convert.ToString(txtPrecioA.Text);
                        decimal myValueMonto_A = clsFunctions.ParseCurrencyFormat(myValue_A);
                        myCommand.Parameters.AddWithValue("@precio_a", myValueMonto_A);
                        // Monto B
                        string myValue_B = Convert.ToString(txtPrecioB.Text);
                        decimal myValueMonto_B = clsFunctions.ParseCurrencyFormat(myValue_B);                        
                        myCommand.Parameters.AddWithValue("@precio_b", myValueMonto_B);
                        // TIPO
                        if (rbTipo1.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "1");
                        }
                        else if (rbTipo2.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "2");
                        }
                        else if (rbTipo3.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "3");
                        }

                        myCommand.Parameters.AddWithValue("@reorden", txtReorden.Text);

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

                    // AGREGO EL PRODUCTO A LA TABLA DE INVENTARIO
                    this.insertarInventario();

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
                        myCommand.CommandText = "UPDATE productos SET referencia = @referencia, producto = @nombre, "+
                            " descripcion = @descripcion, idcategoria = @idcategoria, precio_a = @precio_a, reorden = @reorden, "+
                            "precio_b = @precio_b, tipo = @tipo, imagen = @imagen, rutafoto = @rutafoto WHERE idproducto ="+ txtID.Text +"";
                        myCommand.Parameters.AddWithValue("@referencia", txtReferencia.Text);
                        myCommand.Parameters.AddWithValue("@nombre", txtProducto.Text);
                        myCommand.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        myCommand.Parameters.AddWithValue("@idcategoria", cmbCategoria.SelectedValue);
                        myCommand.Parameters.AddWithValue("@imagen", imageBT);
                        myCommand.Parameters.AddWithValue("@rutafoto", txtPicture.Text);
                        // Cambio el valor del textbox a decimal
                        // Monto A
                        string myValue_A = Convert.ToString(txtPrecioA.Text);
                        decimal myValueMonto_A = clsFunctions.ParseCurrencyFormat(myValue_A);
                        myCommand.Parameters.AddWithValue("@precio_a", myValueMonto_A);
                        // Monto B
                        string myValue_B = Convert.ToString(txtPrecioB.Text);
                        decimal myValueMonto_B = clsFunctions.ParseCurrencyFormat(myValue_B);
                        myCommand.Parameters.AddWithValue("@precio_b", myValueMonto_B);
                        // TIPO
                        if (rbTipo1.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "1");
                        }
                        else if (rbTipo2.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "2");
                        }
                        else if (rbTipo3.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "3");
                        }

                        myCommand.Parameters.AddWithValue("@reorden", txtReorden.Text);

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

        private void insertarInventario()
        {
            try
            {
                // Step 1 - Stablishing the connection
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Crear el comando de ejecucion
                MySqlCommand myCommand = MyConexion.CreateCommand();

                // Step 3 - Comando a ejecutar
                myCommand.CommandText = "INSERT INTO inventario(idproducto, cantidad)" +
                    " values(@idproducto, @cantidad)";
                myCommand.Parameters.AddWithValue("@idproducto", txtID.Text);
                myCommand.Parameters.AddWithValue("@cantidad", 0);
                
                // Step 4 - Opening the connection
                MyConexion.Open();

                // Step 5 - Executing the query
                int nFilas = myCommand.ExecuteNonQuery();
                if (nFilas > 0)
                {
                    MessageBox.Show("Registro creado en la tabla Inventario...");
                }
                else
                {
                    MessageBox.Show("No fue creado el registro en la tabla inventario...");
                }

                // Step 6 - Closing the connection
                MyConexion.Close();
            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
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
                    MyCommand.CommandText = "SELECT referencia, producto, descripcion, idcategoria, precio_a, "+
                        "precio_b, tipo, imagen, rutafoto, reorden" +
                        " FROM productos WHERE idproducto = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtReferencia.Text = MyReader["referencia"].ToString();
                            txtProducto.Text = MyReader["producto"].ToString();
                            txtDescripcion.Text = MyReader["descripcion"].ToString();
                            cmbCategoria.SelectedValue = MyReader["idcategoria"].ToString();
                            txtPrecioA.Text = MyReader["precio_a"].ToString();
                            txtPrecioB.Text = MyReader["precio_b"].ToString();
                            txtPicture.Text = MyReader["rutafoto"].ToString();
                            txtReorden.Text = MyReader["reorden"].ToString();
                            if (MyReader["tipo"].ToString() == "1")
                            {
                                rbTipo1.Checked = true;
                            }
                            else if (MyReader["tipo"].ToString() == "2")
                            {
                                rbTipo2.Checked = true;
                            }
                            else
                            {
                                rbTipo3.Checked = true;
                            }

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

                        // Llamo la funcion para formatear el campo.-
                        decimal montoA = Convert.ToDecimal(txtPrecioA.Text);
                        txtPrecioA.Text = clsFunctions.GetCurrencyFormat(montoA);

                        // Llamo la funcion para formatear el campo.-
                        decimal montoB = Convert.ToDecimal(txtPrecioB.Text);
                        txtPrecioB.Text = clsFunctions.GetCurrencyFormat(montoB);

                        // Cambio los modos de los botones
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
            //Conexion a la base de datos
            MySqlConnection myConexion = new MySqlConnection(clsConexion.ConectionString);
            // Creando el command que ejecutare
            MySqlCommand myCommand = new MySqlCommand();
            // Creando el Data Adapter
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            // Creando el String Builder
            StringBuilder sbQuery = new StringBuilder();
            // Otras variables del entorno
            string cWhere = " WHERE 1 = 1";
            string cUsuario = "";
            string cTitulo = "";

            try
            {
                // Abro conexion
                myConexion.Open();
                // Creo comando
                myCommand = myConexion.CreateCommand();
                // Adhiero el comando a la conexion
                myCommand.Connection = myConexion;
                // Filtros de la busqueda
                //string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                //string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                //cWhere = cWhere + " AND fechacita >= " + "'" + fechadesde + "'" + " AND fechacita <= " + "'" + fechahasta + "'" + "";
                sbQuery.Clear();
                sbQuery.Append("SELECT ");
                sbQuery.Append(" productos.idproducto, productos.producto, productos.referencia,");
                sbQuery.Append(" productos.descripcion, productos.precio_a, productos.precio_b,");
                sbQuery.Append(" productos.reorden, categorias.categoria");
                sbQuery.Append(" FROM productos ");
                sbQuery.Append(" INNER JOIN categorias ON categorias.idcategoria = productos.idcategoria ");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY productos.producto ASC ");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtProductos = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtProductos);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtProductos.Rows.Count;
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
                    cTitulo = "LISTADO DE PRODUCTOS";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptProductos orptProductos = new rptProductos();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptProductos.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtProductos, orptProductos, cTitulo);

                    //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                    ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                    ofrmPrinter.ShowDialog();
                }


            }
            catch (Exception myEx)
            {
                MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                //ExceptionLog.LogError(myEx, false);
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtProducto.Text != "")
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

        private void txtPrecioA_Leave(object sender, EventArgs e)
        {
            //Llamo la funcion para formatear el campo.-
            decimal monto = Convert.ToDecimal(txtPrecioA.Text);
            txtPrecioA.Text = clsFunctions.GetCurrencyFormat(monto);
        }

        private void txtPrecioB_Leave(object sender, EventArgs e)
        {
            //Llamo la funcion para formatear el campo.-
            decimal monto = Convert.ToDecimal(txtPrecioB.Text);
            txtPrecioB.Text = clsFunctions.GetCurrencyFormat(monto);
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.JPG)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                txtPicture.Text = picPath;
                picBox.ImageLocation = picPath;
            }
        }

        private void txtReorden_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtReorden_Leave(object sender, EventArgs e)
        {
            if (txtReorden.Text == "")
            {
                MessageBox.Show("No puede dejar la cantidad de REORDeN sin valor...");
                txtReorden.Focus();
            }            
        }


    }
}
