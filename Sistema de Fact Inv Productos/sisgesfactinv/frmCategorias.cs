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
    public partial class frmCategorias : frmBase
    {
        string cModo = "Inicio";

        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            this.cModo = "Inicio";
            this.Limpiar();
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
                MyCommand.CommandText = "SELECT count(*) FROM categorias";

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
                    this.txtCategoria.Enabled = false;
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
                    this.txtCategoria.Enabled = true;
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
                    this.txtCategoria.Enabled = false;
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
                    this.txtCategoria.Enabled = true;
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
                    this.txtCategoria.Enabled = false;
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
                    this.txtCategoria.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtCategoria.Clear();           
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
            if (txtID.Text == "" || txtCategoria.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtCategoria.Focus();
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
                        myCommand.CommandText = "INSERT INTO categorias(categoria) values(@categoria)";
                        myCommand.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                        
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
                        myCommand.CommandText = "UPDATE categorias SET categoria = @categoria WHERE idcategoria = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                        
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
                    MyCommand.CommandText = "SELECT categoria FROM categorias WHERE idcategoria = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtCategoria.Text = MyReader["categoria"].ToString();                            
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
                sbQuery.Append("SELECT idcategoria as idcategorias, categoria");
                sbQuery.Append(" FROM categorias ");
                sbQuery.Append(cWhere);

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtCategoria = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtCategoria);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtCategoria.Rows.Count;
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
                    cTitulo = "LISTADO DE CATEGORIAS";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptCategorias orptCategorias = new rptCategorias();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptCategorias.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtCategoria, orptCategorias, cTitulo);

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

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
