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
    public partial class frmPrintEstadisticasEscuelas : frmBase
    {
        public frmPrintEstadisticasEscuelas()
        {
            InitializeComponent();
        }

        private void frmPrintEstadisticasEscuelas_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {            
            if (provincias.Checked == true)
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
                string cWhere;                
                string cUsuario = "";
                string cTitulo = "";
                // Verifico si son todas o las publicas
                if (chkTodas.Checked == true)
                {
                    cWhere = " WHERE 1=1";
                    cTitulo = "CANTIDAD DE ESCUELAS POR PROVINCIA";
                }
                else
                {
                    cWhere = " WHERE SECTOR like 'PUBLICO'";
                    cTitulo = "CANTIDAD DE ESCUELAS PUBLICAS POR PROVINCIA";
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
                    //string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                    //string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                    //cWhere = cWhere + " AND fechacita >= " + "'" + fechadesde + "'" + " AND fechacita <= " + "'" + fechahasta + "'" + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT provincia, count(centro) as cantidad");
                    sbQuery.Append(" FROM centros ");
                    sbQuery.Append(cWhere);
                    sbQuery.Append(" GROUP BY provincia");
                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtEscuelas = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtEscuelas);
                    // Cierro el objeto conexion
                    myConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtEscuelas.Rows.Count;
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
                        //cTitulo = "CANTIDAD DE ESCUELAS PUBLICAS POR PROVINCIA";

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptdoctorado_estdisticas_porProvincia orptDoctorado = new rptdoctorado_estdisticas_porProvincia();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;
                        orptDoctorado.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtEscuelas, orptDoctorado, cTitulo);

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

            if (municipios.Checked == true)
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
                string cWhere;
                string cUsuario = "";
                string cTitulo = "";
                // Verifico si son todas o las publicas
                if (chkTodas.Checked == true)
                {
                    cWhere = " WHERE 1=1";
                    cTitulo = "CANTIDAD DE ESCUELAS POR MUNICIPIOS";
                }
                else
                {
                    cWhere = " WHERE SECTOR like 'PUBLICO'";
                    cTitulo = "CANTIDAD DE ESCUELAS PUBLICAS POR MUNICIPIOS";
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
                    //string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                    //string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                    //cWhere = cWhere + " AND fechacita >= " + "'" + fechadesde + "'" + " AND fechacita <= " + "'" + fechahasta + "'" + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT provincia, municipio, count(centro) as cantidad");
                    sbQuery.Append(" FROM centros ");
                    sbQuery.Append(cWhere);
                    sbQuery.Append(" GROUP BY provincia, municipio");
                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtEscuelas = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtEscuelas);
                    // Cierro el objeto conexion
                    myConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtEscuelas.Rows.Count;
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
                        //cTitulo = "CANTIDAD DE ESCUELAS PUBLICAS POR PROVINCIA";

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptdoctorado_estadisticas_porMunicipio orptDoctorado = new rptdoctorado_estadisticas_porMunicipio();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;
                        orptDoctorado.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtEscuelas, orptDoctorado, cTitulo);

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
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
