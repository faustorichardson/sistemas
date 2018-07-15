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
    public partial class frmUnidadesNavales : frmBase
    {
        string cModo = "Inicio";

        public frmUnidadesNavales()
        {
            InitializeComponent();
        }

        private void frmUnidadesNavales_Load(object sender, EventArgs e)
        {
            // Limpio el form
            this.Limpiar();

            // Funcion botones
            this.cModo = "Inicio";
            this.Botones();

            // Combos
            this.fillCmbUnidad();
            this.fillCmbCondicion();
            this.fillCmbTipoCombustible();
        }

        private void fillCmbUnidad()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, tipo FROM tipounidades ORDER BY tipo ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("tipo", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbTipoUnidad.ValueMember = "id";
            cmbTipoUnidad.DisplayMember = "tipo";
            cmbTipoUnidad.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();

        }

        private void fillCmbTipoCombustible()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, combustible FROM tiposcombustibles ORDER BY combustible ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("combustible", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbTipoCombustible.ValueMember = "id";
            cmbTipoCombustible.DisplayMember = "combustible";
            cmbTipoCombustible.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        private void fillCmbCondicion()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, condicion FROM condiciones ORDER BY condicion ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("condicion", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbCondicion.ValueMember = "id";
            cmbCondicion.DisplayMember = "condicion";
            cmbCondicion.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
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
                MyCommand.CommandText = "SELECT count(*) FROM unidades";

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
            this.txtCapacidadCombustible.Clear();
            this.txtID.Clear();
            this.txtNombre.Clear();
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
                    this.cmbTipoUnidad.Enabled = false;
                    this.cmbTipoCombustible.Enabled = false;
                    this.txtCapacidadCombustible.Enabled = false;
                    this.cmbCondicion.Enabled = false;
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
                    this.cmbTipoUnidad.Enabled = true;
                    this.cmbTipoCombustible.Enabled = true;
                    this.txtCapacidadCombustible.Enabled = true;
                    this.cmbCondicion.Enabled = true;
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
                    this.cmbTipoUnidad.Enabled = false;
                    this.cmbTipoCombustible.Enabled = false;
                    this.txtCapacidadCombustible.Enabled = false;
                    this.cmbCondicion.Enabled = false;
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
                    this.cmbTipoUnidad.Enabled = true;
                    this.cmbTipoCombustible.Enabled = true;
                    this.txtCapacidadCombustible.Enabled = true;
                    this.cmbCondicion.Enabled = true;
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
                    this.cmbTipoUnidad.Enabled = false;
                    this.cmbTipoCombustible.Enabled = false;
                    this.txtCapacidadCombustible.Enabled = false;
                    this.cmbCondicion.Enabled = false;
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
                    this.txtNombre.Enabled = false;
                    this.cmbTipoUnidad.Enabled = false;
                    this.cmbTipoCombustible.Enabled = false;
                    this.txtCapacidadCombustible.Enabled = false;
                    this.cmbCondicion.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void updateExistencia()
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
                    myCommand.CommandText = "INSERT INTO existencia(id_unidad, cantidad)" +
                        " values(@id, @cantidad)";
                    myCommand.Parameters.AddWithValue("@id", txtID.Text);
                    myCommand.Parameters.AddWithValue("@cantidad", 0);

                    // Step 4 - Opening the connection
                    MyConexion.Open();

                    // Step 5 - Executing the query
                    int nFilas = myCommand.ExecuteNonQuery();
                    if (nFilas > 0)
                    {
                        MessageBox.Show("Existencia Actualizada...");
                    }
                    else
                    {
                        MessageBox.Show("No fue guardada la existencia...");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.Botones();
            this.ProximoCodigo();
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
                        myCommand.CommandText = "INSERT INTO unidades(unidad, tipo, tipo_comb, cap_comb, condicion)" +
                            " values(@unidad, @tipo, @tipo_comb, @cap_comb, @condicion)";
                        myCommand.Parameters.AddWithValue("@unidad", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@tipo", cmbTipoUnidad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@tipo_comb", cmbTipoCombustible.SelectedValue);
                        //
                        // Convierto el campo monto en texto
                        txtCapacidadCombustible.Text = Convert.ToString(txtCapacidadCombustible.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(txtCapacidadCombustible.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        //
                        myCommand.Parameters.AddWithValue("@cap_comb", myValueMonto);
                        myCommand.Parameters.AddWithValue("@condicion", cmbCondicion.SelectedValue);
                        //
                        // Step 4 - Opening the connection
                        MyConexion.Open();

                        // Step 5 - Executing the query
                        myCommand.ExecuteNonQuery();

                        // Step 6 - Closing the connection
                        MyConexion.Close();

                        // MENSAJE DE REGISTRO FINAL
                        MessageBox.Show("Informacion guardada satisfactoriamente...");

                        // REGISTRO EL DATO EN LA TABLA EXISTENCIA
                        this.updateExistencia();

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
                        myCommand.CommandText = "UPDATE unidades SET unidad = @unidad, tipo = @tipo, tipo_comb = @tipo_comb, " +
                            "cap_comb = @cap_comb, condicion = @condicion WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@unidad", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@tipo", cmbTipoUnidad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@tipo_comb", cmbTipoCombustible.SelectedValue);
                        //
                        // Convierto el campo monto en texto
                        txtCapacidadCombustible.Text = Convert.ToString(txtCapacidadCombustible.Text);
                        // Cambio el valor del textbox a decimal
                        string myValue = Convert.ToString(txtCapacidadCombustible.Text);
                        decimal myValueMonto = clsFunctions.ParseCurrencyFormat(myValue);
                        //
                        myCommand.Parameters.AddWithValue("@cap_comb", myValueMonto);
                        myCommand.Parameters.AddWithValue("@condicion", cmbCondicion.SelectedValue);
                        //

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
                cModo = "Inicio";
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
                    MyCommand.CommandText = "SELECT id, unidad, tipo, tipo_comb, cap_comb, condicion " +
                        "FROM unidades WHERE id = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtNombre.Text = MyReader["unidad"].ToString();
                            cmbTipoUnidad.SelectedValue = MyReader["tipo"].ToString();
                            cmbTipoCombustible.SelectedValue = MyReader["tipo_comb"].ToString();

                            // Llamo la funcion para formatear el campo.-
                            txtCapacidadCombustible.Text = MyReader["cap_comb"].ToString();                            
                            decimal monto = Convert.ToDecimal(txtCapacidadCombustible.Text);
                            txtCapacidadCombustible.Text = clsFunctions.GetCurrencyFormat(monto);
                            //
                            cmbCondicion.SelectedValue = MyReader["condicion"].ToString();
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
                sbQuery.Clear();
                sbQuery.Append("SELECT unidades.id, unidades.unidad, tipounidades.tipo as tipounidad, ");
                sbQuery.Append(" tiposcombustibles.combustible as tipocombustible, unidades.cap_comb as capacidad, ");
                sbQuery.Append(" condiciones.condicion");
                sbQuery.Append(" FROM unidades ");
                sbQuery.Append(" INNER JOIN tipounidades ON tipounidades.id = unidades.tipo");
                sbQuery.Append(" INNER JOIN tiposcombustibles ON tiposcombustibles.id = unidades.tipo_comb");
                sbQuery.Append(" INNER JOIN condiciones ON condiciones.id = unidades.condicion");
                sbQuery.Append(cWhere);               

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtUnidadesNavales = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtUnidadesNavales);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtUnidadesNavales.Rows.Count;
                if (nRegistro == 0)
                {
                    MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Dispensario Medico", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cTitulo = "LISTADO DE UNIDADES NAVALES";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptUnidadesNavales orptUnidadesNavales = new rptUnidadesNavales();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptUnidadesNavales.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtUnidadesNavales, orptUnidadesNavales, cTitulo);

                    //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                    ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                    ofrmPrinter.ShowDialog();
                }


            }
            catch (Exception myEx)
            {
                MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                // ExceptionLog.LogError(myEx, false);
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtNombre.Text != "")
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

        private void txtCapacidadCombustible_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCapacidadCombustible_Leave(object sender, EventArgs e)
        {
            if (txtCapacidadCombustible.Text == "")
            {
                MessageBox.Show("Cantidad de combustible incorrecta...");
                txtCapacidadCombustible.Focus();
            }
            else
            {
                // Llamo la funcion para formatear el campo.-
                decimal monto = Convert.ToDecimal(txtCapacidadCombustible.Text);
                txtCapacidadCombustible.Text = clsFunctions.GetCurrencyFormat(monto);
            }            
        }


    }
}
