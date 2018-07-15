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
    public partial class frmClientes : frmBase
    {
        string cModo = "Inicio";

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.comboProvincia();
            this.Limpiar();            
            this.cModo = "Inicio";
            this.Botones();
        }

        private void comboProvincia()
        {
            try
            {
                // Step 1 
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT provincia_id, nombre FROM provincias ORDER BY nombre ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("provincia_id", typeof(int));
                MyDataTable.Columns.Add("nombre", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6                
                cmbProvincia.ValueMember = "provincia_id";
                cmbProvincia.DisplayMember = "nombre";
                cmbProvincia.DataSource = MyDataTable;

                // Step 7
                MyConexion.Close();
            }
            catch (Exception)
            {
                
                throw;
            }            
        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtNombre.Clear();
            this.txtRNC.Clear();
            this.txtDireccion.Clear();
            this.cmbProvincia.Refresh();
            this.txtTelefono.Clear();
            this.rbTipo_B.Checked = true;
            this.chkStatus.Checked = true;
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
                    this.txtNombre.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtRNC.Enabled = false;
                    this.rbTipo_A.Enabled = false;
                    this.rbTipo_B.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.cmbProvincia.Enabled = false;
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
                    this.txtNombre.Enabled = true;
                    this.txtDireccion.Enabled = true;
                    this.txtRNC.Enabled = true;
                    this.rbTipo_A.Enabled = true;
                    this.rbTipo_B.Enabled = true;
                    this.txtTelefono.Enabled = true;
                    this.cmbProvincia.Enabled = true;
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
                    this.txtNombre.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtRNC.Enabled = false;
                    this.rbTipo_A.Enabled = false;
                    this.rbTipo_B.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.cmbProvincia.Enabled = false;
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
                    this.txtNombre.Enabled = true;
                    this.txtDireccion.Enabled = true;
                    this.txtRNC.Enabled = true;
                    this.rbTipo_A.Enabled = true;
                    this.rbTipo_B.Enabled = true;
                    this.txtTelefono.Enabled = true;
                    this.cmbProvincia.Enabled = true;
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
                    this.txtNombre.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtRNC.Enabled = false;
                    this.rbTipo_A.Enabled = false;
                    this.rbTipo_B.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.cmbProvincia.Enabled = false;
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
                MyCommand.CommandText = "SELECT count(*) FROM clientes";

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
            this.txtNombre.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (txtID.Text == "" || txtNombre.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtNombre.Focus();
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
                        myCommand.CommandText = "INSERT INTO clientes(nombre, rnc, direccion, telefono, provincia, tipo, status)" +
                            " values(@nombre, @rnc, @direccion, @telefono, @provincia, @tipo, @status)";
                        myCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@rnc", txtRNC.Text);
                        myCommand.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        myCommand.Parameters.AddWithValue("@provincia", cmbProvincia.SelectedValue);
                        myCommand.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        // Verificando el tipo
                        if (rbTipo_A.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "A");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "B");
                        }
                        // Verificando el status
                        if (chkStatus.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@status", "A");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@status", "I");
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

                        myCommand.CommandText = "UPDATE clientes SET nombre = @nombre, rnc = @rnc, direccion = @direccion, "+
                            " provincia = @provincia, tipo = @tipo, telefono = @telefono, status = @status WHERE idcliente = "+ txtID.Text +"";
                        myCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@rnc", txtRNC.Text);
                        myCommand.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        myCommand.Parameters.AddWithValue("@provincia", cmbProvincia.SelectedValue);
                        myCommand.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        // Verificando el tipo
                        if (rbTipo_A.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "A");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@tipo", "B");
                        }
                        // Verificando el status
                        if (chkStatus.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@status", "A");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@status", "I");
                        }

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
                    MyCommand.CommandText = "SELECT nombre, rnc, direccion, provincia, telefono, tipo, status " +
                        "FROM clientes WHERE idcliente = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtNombre.Text = MyReader["nombre"].ToString();
                            txtRNC.Text = MyReader["rnc"].ToString();
                            txtDireccion.Text = MyReader["direccion"].ToString();
                            cmbProvincia.SelectedValue = MyReader["provincia"].ToString();
                            txtTelefono.Text = MyReader["telefono"].ToString();
                            if (MyReader["tipo"].ToString() == "A")
                            {
                                rbTipo_A.Checked = true;
                            }
                            else
                            {
                                rbTipo_B.Checked = true;
                            }
                            if (MyReader["status"].ToString() == "A")
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
                sbQuery.Append(" clientes.idcliente, clientes.nombre as cliente, clientes.rnc,");
                sbQuery.Append(" clientes.direccion, clientes.tipo, clientes.status, clientes.telefono,");
                sbQuery.Append(" provincias.nombre as provincia");
                sbQuery.Append(" FROM clientes ");
                sbQuery.Append(" INNER JOIN provincias ON provincias.provincia_id = clientes.provincia");                
                sbQuery.Append(cWhere);

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtClientes = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtClientes);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtClientes.Rows.Count;
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
                    cTitulo = "LISTADO DE CLIENTES";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptClientes orptClientes = new rptClientes();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptClientes.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtClientes, orptClientes, cTitulo);

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
            }

            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbTipo_A_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rbTipo_B_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
