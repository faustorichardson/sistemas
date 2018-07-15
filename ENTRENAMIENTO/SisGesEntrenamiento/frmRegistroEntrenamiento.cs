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

namespace SisGesEntrenamiento
{
    public partial class frmRegistroEntrenamiento : frmBase
    {
        //string pais = "";
        string cModo = "Inicio";
        string militarCedula = "";

        public frmRegistroEntrenamiento()
        {
            InitializeComponent();
        }

        private void frmRegistroEntrenamiento_Load(object sender, EventArgs e)
        {
            // Funcion Limpiar
            this.Limpiar();

            // Funcion de los Botones           
            this.cModo = "Inicio";
            this.Botones();            

            // Fill Combo's
            this.fillCmbCurso();
            this.fillCmbPais();
            this.fillEstado();
            //this.fillCmbRango();
        }

        private void fillEstado()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, nombre FROM estado ORDER BY nombre ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("nombre", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbEstado.ValueMember = "id";
            cmbEstado.DisplayMember = "nombre";
            cmbEstado.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        private void fillCmbPais()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, nombre FROM paises ORDER BY nombre ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("nombre", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbPais.ValueMember = "id";
            cmbPais.DisplayMember = "nombre";
            cmbPais.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        private void fillCmbCurso()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, curso FROM cursos ORDER BY curso ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("curso", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbCurso.ValueMember = "id";
            cmbCurso.DisplayMember = "curso";
            cmbCurso.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        //private void fillCmbRango()
        //{
        //    // Step 1 
        //    MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

        //    // Step 2
        //    MyConexion.Open();

        //    // Step 3
        //    MySqlCommand MyCommand = new MySqlCommand("SELECT rango_id, rango_descripcion FROM rangos", MyConexion);

        //    // Step 4
        //    MySqlDataReader MyReader;
        //    MyReader = MyCommand.ExecuteReader();

        //    // Step 5
        //    DataTable MyDataTable = new DataTable();
        //    MyDataTable.Columns.Add("rango_id", typeof(int));
        //    MyDataTable.Columns.Add("rango_descripcion", typeof(string));
        //    MyDataTable.Load(MyReader);

        //    // Step 6
        //    cmbRango.ValueMember = "rango_id";
        //}

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
                    this.cmbCurso.Enabled = false;
                    this.cmbPais.Enabled = false;
                    this.cmbEstado.Enabled = false;
                    this.dtDesde.Enabled = false;
                    this.dtHasta.Enabled = false;
                    this.chkStatus.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    this.txtOficio.Enabled = false;
                    this.txtOficioFecha.Enabled = false;
                    this.txtNota.Enabled = false;
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
                    this.cmbCurso.Enabled = true;
                    this.cmbPais.Enabled = true;
                    this.cmbEstado.Enabled = true;
                    this.dtDesde.Enabled = true;
                    this.dtHasta.Enabled = true;
                    this.chkStatus.Enabled = true;
                    this.btnBuscarMilitar.Enabled = true;
                    this.txtOficio.Enabled = true;
                    this.txtOficioFecha.Enabled = true;
                    this.txtNota.Enabled = true;
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
                    this.cmbCurso.Enabled = false;
                    this.cmbPais.Enabled = false;
                    this.cmbEstado.Enabled = false;
                    this.dtDesde.Enabled = false;
                    this.dtHasta.Enabled = false;
                    this.chkStatus.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    this.txtOficio.Enabled = false;
                    this.txtOficioFecha.Enabled = false;
                    this.txtNota.Enabled = false;
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
                    this.cmbCurso.Enabled = true;
                    this.cmbPais.Enabled = true;
                    this.cmbEstado.Enabled = true;
                    this.dtDesde.Enabled = true;
                    this.dtHasta.Enabled = true;
                    this.chkStatus.Enabled = true;
                    this.btnBuscarMilitar.Enabled = true;
                    this.txtOficio.Enabled = true;
                    this.txtOficioFecha.Enabled = true;
                    this.txtNota.Enabled = true;
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
                    this.cmbCurso.Enabled = false;
                    this.cmbPais.Enabled = false;
                    this.cmbEstado.Enabled = false;
                    this.dtDesde.Enabled = false;
                    this.dtHasta.Enabled = false;
                    this.chkStatus.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    this.txtOficio.Enabled = false;
                    this.txtOficioFecha.Enabled = false;
                    this.txtNota.Enabled = false;
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
                    this.cmbCurso.Enabled = false;
                    this.cmbPais.Enabled = false;
                    this.cmbEstado.Enabled = false;
                    this.dtDesde.Enabled = false;
                    this.dtHasta.Enabled = false;
                    this.chkStatus.Enabled = false;
                    this.btnBuscarMilitar.Enabled = false;
                    this.txtOficio.Enabled = false;
                    this.txtOficioFecha.Enabled = false;
                    this.txtNota.Enabled = false;
                    break;

                default:
                    break;
            }

        }                            

        private void Limpiar()
        {
            this.chkStatus.Checked = false;
            this.txtID.Clear();
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.txtRango.Clear();
            this.txtOficio.Clear();
            this.txtOficioFecha.Clear();
            this.txtNota.Clear();
            this.cmbPais.Refresh();
            this.fillEstado();
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
                MyCommand.CommandText = "SELECT count(*) FROM entrenamiento";

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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtCedula.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtID.Focus();
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
                        myCommand.CommandText = "INSERT INTO entrenamiento(cedula, curso, desde, hasta, pais, estado, oficio, oficio_fecha,"+
                            "notas, status) values(@cedula, @curso, @desde, @hasta, @pais, @estado, @oficio, @oficiofecha, @notas, @status)";
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@curso", cmbCurso.SelectedValue);
                        myCommand.Parameters.AddWithValue("@desde", dtDesde.Value);
                        myCommand.Parameters.AddWithValue("@hasta", dtHasta.Value);
                        myCommand.Parameters.AddWithValue("@pais", cmbPais.SelectedValue);
                        myCommand.Parameters.AddWithValue("@estado", cmbEstado.SelectedValue);
                        myCommand.Parameters.AddWithValue("@oficio", txtOficio.Text);
                        myCommand.Parameters.AddWithValue("@oficiofecha", txtOficioFecha.Text);
                        myCommand.Parameters.AddWithValue("@notas", txtNota.Text);
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

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "UPDATE entrenamiento SET cedula = @cedula, curso = @curso, " +
                            "desde = @desde, hasta = @hasta, pais = @pais, estado = @estado, oficio = @oficio, "+ 
                            "oficio_fecha = @oficiofecha, notas = @notas, status = @status WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@curso", cmbCurso.SelectedValue);
                        myCommand.Parameters.AddWithValue("@desde", dtDesde.Value);
                        myCommand.Parameters.AddWithValue("@hasta", dtHasta.Value);
                        myCommand.Parameters.AddWithValue("@pais", cmbPais.SelectedValue);
                        myCommand.Parameters.AddWithValue("@estado", cmbEstado.SelectedValue);
                        myCommand.Parameters.AddWithValue("@oficio", txtOficio.Text);
                        myCommand.Parameters.AddWithValue("@oficiofecha", txtOficioFecha.Text);
                        myCommand.Parameters.AddWithValue("@notas", txtNota.Text);
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
                        int nFilas = myCommand.ExecuteNonQuery();
                        if (nFilas > 0)
                        {
                            MessageBox.Show("Informacion actualizada satisfactoriamente...");
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
                    MyCommand.CommandText = "SELECT id, cedula, curso, desde, hasta, pais, estado, oficio, oficio_fecha, notas, status " +
                        "FROM entrenamiento WHERE id = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            cmbCurso.SelectedValue = MyReader["curso"].ToString();
                            cmbPais.SelectedValue = MyReader["pais"].ToString();
                            cmbEstado.SelectedValue = MyReader["estado"].ToString();
                            dtDesde.Value = Convert.ToDateTime(MyReader["desde"].ToString());
                            dtHasta.Value = Convert.ToDateTime(MyReader["hasta"].ToString());
                            string Estado = MyReader["status"].ToString();
                            if (Estado == "1")
                            {
                                chkStatus.Checked = true;
                            }
                            else
                            {
                                chkStatus.Checked = false;
                            }
                            txtCedula.Text = MyReader["cedula"].ToString();
                            militarCedula = MyReader["cedula"].ToString();
                            txtOficio.Text = MyReader["oficio"].ToString();
                            txtOficioFecha.Text = MyReader["oficio_fecha"].ToString();
                            txtNota.Text = MyReader["notas"].ToString();
                        }

                        this.cModo = "Buscar";
                        this.Botones();

                        // Funcion Buscar.-
                        this.Busqueda();
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

        private void Busqueda()
        {
            if (txtCedula.Text == "")
            {
                MessageBox.Show("No se puede buscar sin cedulas...");
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
                    MyCommand.CommandText = "SELECT rango, nombre, apellido " +
                        "FROM militares WHERE cedula = '" + militarCedula + "'";

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
                            txtApellido.Text = MyReader["apellido"].ToString();
                            txtRango.Text = MyReader["rango"].ToString();
                        }                       
                    }
                    else
                    {
                        MessageBox.Show("No se encontro militar registrado en este curso...");
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
            string cWhere = " WHERE 1 = 1 AND status = 0";
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
                sbQuery.Append("SELECT");
                sbQuery.Append(" entrenamiento.id, entrenamiento.cedula, militares.rango, militares.rango_orden,");
                sbQuery.Append(" militares.nombre, militares.apellido, cursos.curso,");
                sbQuery.Append(" entrenamiento.desde, entrenamiento.hasta, paises.nombre as pais,");
                sbQuery.Append(" entrenamiento.`status`");
                sbQuery.Append(" FROM entrenamiento ");
                sbQuery.Append(" INNER JOIN cursos ON cursos.id = entrenamiento.curso");
                sbQuery.Append(" INNER JOIN paises ON paises.id = entrenamiento.pais");
                sbQuery.Append(" INNER JOIN militares ON militares.cedula = entrenamiento.cedula");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY hasta ASC");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtEntrenamiento = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtEntrenamiento);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtEntrenamiento.Rows.Count;
                if (nRegistro == 0)
                {
                    MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Gestion de Entrenamiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cTitulo = "LISTADO DE MILITARES CURSANDO ENTRENAMIENTO";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptListadoMilitaresCursandoEntrenamiento orptListadoMilitaresCursandoEntrenamiento = new rptListadoMilitaresCursandoEntrenamiento();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptListadoMilitaresCursandoEntrenamiento.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtEntrenamiento, orptListadoMilitaresCursandoEntrenamiento, cTitulo);

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
            if (txtCedula.Text != "" || txtID.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema de Gestion de Entrenamiento", MessageBoxButtons.YesNo,
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

        private void btnBuscarMilitar_Click(object sender, EventArgs e)
        {
            frmBuscarMilitar ofrmBuscarMilitar = new frmBuscarMilitar();
            ofrmBuscarMilitar.ShowDialog();
            string cCodigo = ofrmBuscarMilitar.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtCedula.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT * from militares WHERE cedula = '" + txtCedula.Text.Trim() + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtRango.Text = MyReader["rango"].ToString();
                            txtNombre.Text = MyReader["nombre"].ToString();
                            txtApellido.Text = MyReader["apellido"].ToString();
                        }
                        //this.cModo = "Buscar";
                        //this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con esta cedula...", "SisGesEntrenamiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.txtCedula.Focus();
                        //this.cModo = "Inicio";
                        //this.Botones();
                        //this.Limpiar();
                        //this.txtID.Focus();
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

        private void fillCmbEstado()
        {
            // Transpaso el valor del indice del combo a la variable pais
            //this.pais = cmbPais.SelectedIndex.ToString();
            //int buscapais = Convert.ToInt32(pais);

            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, nombre FROM estado WHERE pais ="+ cmbPais.SelectedValue +" ORDER BY nombre ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("nombre", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbEstado.ValueMember = "id";
            cmbEstado.DisplayMember = "nombre";
            cmbEstado.DataSource = MyDataTable;

            // Step 7
            MyConexion.Close();
        }

        private void cmbPais_Click(object sender, EventArgs e)
        {            
            this.fillCmbEstado();
        }

        private void cmbPais_MouseClick(object sender, MouseEventArgs e)
        {
            //this.fillCmbEstado();
        }

        private void cmbEstado_Leave(object sender, EventArgs e)
        {
            //this.fillCmbEstado();
        }

        private void cmbEstado_MouseClick(object sender, MouseEventArgs e)
        {
            //this.fillCmbEstado();
        }

        private void cmbEstado_Click(object sender, EventArgs e)
        {
            this.fillCmbEstado();
        }
    }
}
