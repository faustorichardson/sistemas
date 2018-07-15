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
    public partial class frmPrintMilitaresPorCurso : frmBase
    {
        public frmPrintMilitaresPorCurso()
        {
            InitializeComponent();
        }


        private void frmPrintMilitaresPorCurso_Load(object sender, EventArgs e)
        {
            // Llenando el combo
            this.fillCmbCursos();
        }

        private void fillCmbCursos()
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

            if (chkStatus.Checked == true)
            {
                cWhere = cWhere + " AND entrenamiento.status = 1";                
            }
            else
            {
                cWhere = cWhere + " AND entrenamiento.status = 0";
            }

            cWhere = cWhere + " AND entrenamiento.curso = " + cmbCurso.SelectedValue + "";

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
                sbQuery.Append("entrenamiento.cedula, cursos.curso, militares.rango, ");
                sbQuery.Append("militares.rango_orden, militares.nombre, militares.apellido, ");
                sbQuery.Append("entrenamiento.desde, entrenamiento.hasta, paises.nombre as pais");
                sbQuery.Append(" FROM entrenamiento ");
                sbQuery.Append("INNER JOIN militares ON militares.cedula = entrenamiento.cedula ");
                sbQuery.Append("INNER JOIN cursos ON cursos.id = entrenamiento.curso ");
                sbQuery.Append("INNER JOIN paises ON entrenamiento.pais = paises.id");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY militares.rango_orden ASC");

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
                    if (chkStatus.Checked == true)
                    {
                        cTitulo = "LISTADO PERSONAL MILITAR CON CURSO REALIZADO";
                    }
                    else
                    {
                        cTitulo = "LISTADO PERSONAL MILITAR REALIZANDO CURSO";
                    }
                    

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptListadoPorCurso orptListadoPorCurso = new rptListadoPorCurso();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptListadoPorCurso.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtEntrenamiento, orptListadoPorCurso, cTitulo);

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
       
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
