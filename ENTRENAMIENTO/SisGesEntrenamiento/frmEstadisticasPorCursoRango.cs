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
    public partial class frmEstadisticasPorCursoRango : frmBase
    {
        public frmEstadisticasPorCursoRango()
        {
            InitializeComponent();
        }

        private void frmEstadisticasPorCursoRango_Load(object sender, EventArgs e)
        {
            this.chkStatus.Checked = true;
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
            //string status = "0";

            if (chkStatus.Checked == true)
            {
                cWhere = cWhere + " AND entrenamiento.status = 1";
                //nombre del TITULO DEL INFORME
                cTitulo = "ESTADISTICAS DE ENTRENAMIENTOS REALIZADOS POR RANGO";
              
                //
                if (chkFecha.Checked == true)
                {
                    string fechadesde = dtDesde.Value.ToString("yyyy-MM-dd");
                    string fechahasta = dtHasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND entrenamiento.hasta >= " + "'" + fechadesde + "'" + " AND entrenamiento.hasta <= " + "'" + fechahasta + "'" + "";
                }
            }
            else
            {
                cWhere = cWhere + " AND entrenamiento.status = 0";
                //nombre del TITULO DEL INFORME
                cTitulo = "ESTADISTICAS DE ENTRENAMIENTOS POR RANGO EN LA ACTUALIDAD";

                //
                if (chkFecha.Checked == true)
                {
                    string fechadesde = dtDesde.Value.ToString("yyyy-MM-dd");
                    string fechahasta = dtHasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND entrenamiento.desde >= " + "'" + fechadesde + "'" + " AND entrenamiento.desde <= " + "'" + fechahasta + "'" + "";
                }
            }
           
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
                sbQuery.Append("SELECT COUNT(entrenamiento.cedula) as cantidad, militares.rango, militares.rango_orden");
                sbQuery.Append(" FROM entrenamiento ");
                sbQuery.Append("INNER JOIN militares ON militares.cedula = entrenamiento.cedula ");
                //sbQuery.Append("");
                sbQuery.Append(cWhere);
                sbQuery.Append(" GROUP BY militares.rango");
                //sbQuery.Append(" ORDER BY cursos.curso");

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

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptEstadisticasPorRango orptEstadisticasPorRango = new rptEstadisticasPorRango();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptEstadisticasPorRango.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtEntrenamiento, orptEstadisticasPorRango, cTitulo);

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
