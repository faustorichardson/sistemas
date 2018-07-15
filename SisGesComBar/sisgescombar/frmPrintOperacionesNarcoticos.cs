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
    public partial class frmPrintOperacionesNarcoticos : frmBase
    {
        public frmPrintOperacionesNarcoticos()
        {
            InitializeComponent();
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
                if (rbFecha.Checked == true)
                {
                    string fechadesde = dtFechaDesde.Value.ToString("yyyy-MM-dd");
                    string fechahasta = dtFechaHasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND ops_antinarcoticos.fecha >= " + "'" + fechadesde + "'" + " AND ops_antinarcoticos.fecha <= " + "'" + fechahasta + "'" + "";
                }
                sbQuery.Clear();
                sbQuery.Append("SELECT ");
                sbQuery.Append("ops_antinarcoticos.id, unidades.unidad as embarcacion, ops_antinarcoticos.fecha,");
                sbQuery.Append("militares.abreviatura as cmdte_rango, militares.rango_orden as cmdte_rangoorden, ");
                sbQuery.Append("militares.nombre as cmdte_nombre, militares.apellido as cmdte_apellido, ");
                sbQuery.Append("tipodrogas.tipo as tipodroga, ops_antinarcoticos.cantidad, provincias.nombre");
                sbQuery.Append(" FROM ops_antinarcoticos ");
                sbQuery.Append("INNER JOIN unidades ON unidades.id = ops_antinarcoticos.embarcacion ");
                sbQuery.Append("INNER JOIN militares ON militares.cedula = ops_antinarcoticos.comandante ");
                sbQuery.Append("INNER JOIN tipodrogas ON tipodrogas.id = ops_antinarcoticos.tipodroga ");
                sbQuery.Append("INNER JOIN provincias ON provincias.provincia_id = ops_antinarcoticos.lugar ");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY ops_antinarcoticos.fecha ASC");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtOperaciones = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtOperaciones);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtOperaciones.Rows.Count;
                if (nRegistro == 0)
                {
                    MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Gestion de Operaciones Navales", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cTitulo = "CANTIDAD DE DROGAS INCAUTADAS";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptReporteOperacionesNarcoticos oprtReporteOperacionesNarcoticos = new rptReporteOperacionesNarcoticos();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    oprtReporteOperacionesNarcoticos.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtOperaciones, oprtReporteOperacionesNarcoticos, cTitulo);

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

        private void frmPrintOperacionesNarcoticos_Load(object sender, EventArgs e)
        {

        }
    }
}
