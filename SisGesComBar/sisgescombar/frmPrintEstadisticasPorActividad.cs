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
    public partial class frmPrintEstadisticasPorActividad : frmBase
    {
        public frmPrintEstadisticasPorActividad()
        {
            InitializeComponent();
        }

        private void frmPrintEstadisticasPorActividad_Load(object sender, EventArgs e)
        {
            // Populate combo box
            this.fillCmbActividad();
        }

        private void fillCmbActividad()
        {
            // Step 1 
            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

            // Step 2
            MyConexion.Open();

            // Step 3
            MySqlCommand MyCommand = new MySqlCommand("SELECT id, actividad FROM actividad ORDER BY actividad ASC", MyConexion);

            // Step 4
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();

            // Step 5
            DataTable MyDataTable = new DataTable();
            MyDataTable.Columns.Add("id", typeof(int));
            MyDataTable.Columns.Add("actividad", typeof(string));
            MyDataTable.Load(MyReader);

            // Step 6
            cmbActividad.ValueMember = "id";
            cmbActividad.DisplayMember = "actividad";
            cmbActividad.DataSource = MyDataTable;

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
            string cWhere = " WHERE 1 = 1 AND movimientocombustible.status = 1";
            cWhere = cWhere + " AND movimientocombustible.actividad = "+ cmbActividad.SelectedValue +"";
            cWhere = cWhere + " AND movimientocombustible.mov = 'S'";
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
                string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                cWhere = cWhere + " AND movimientocombustible.fecha >= " + "'" + fechadesde + "'" + " AND movimientocombustible.fecha <= " + "'" + fechahasta + "'" + "";
                sbQuery.Clear();
                sbQuery.Append("SELECT");
                sbQuery.Append(" unidades.unidad as unidadnaval, actividad.actividad, sum(movimientocombustible.cantidad) as cantidad,");
                sbQuery.Append(" sum(movimientocombustible.millas) as millasnavegadas");
                sbQuery.Append(" FROM movimientocombustible ");
                sbQuery.Append(" INNER JOIN unidades ON unidades.id = movimientocombustible.unidadnaval");
                sbQuery.Append(" INNER JOIN actividad ON actividad.id = movimientocombustible.actividad");
                sbQuery.Append(cWhere);
                sbQuery.Append(" GROUP BY movimientocombustible.unidadnaval");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtMovimientoCombustible = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtMovimientoCombustible);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtMovimientoCombustible.Rows.Count;
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
                    ParameterField oFechaInicial = new ParameterField();
                    ParameterField oFechaFinal = new ParameterField();
                    //parametervaluetype especifica el TIPO de valor de parametro
                    //ParameterValueKind especifica el tipo de valor de parametro en la PARAMETERVALUETYPE de la Clase PARAMETERFIELD
                    oUsuario.ParameterValueType = ParameterValueKind.StringParameter;
                    oFechaInicial.ParameterValueType = ParameterValueKind.DateTimeParameter;
                    oFechaFinal.ParameterValueType = ParameterValueKind.DateTimeParameter;

                    //3ero.VALORES PARA LOS PARAMETROS
                    //ParameterDiscreteValue proporciona propiedades para la recuperacion y configuracion de 
                    //parametros de valores discretos
                    ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                    oUsuarioDValue.Value = cUsuario;
                    ParameterDiscreteValue oFechaDValue = new ParameterDiscreteValue();
                    oFechaDValue.Value = fechadesde;
                    ParameterDiscreteValue oFechaFinDValue = new ParameterDiscreteValue();
                    oFechaFinDValue.Value = fechahasta;

                    //4to. AGREGAMOS LOS VALORES A LOS PARAMETROS
                    oUsuario.CurrentValues.Add(oUsuarioDValue);
                    oFechaInicial.CurrentValues.Add(oFechaDValue);
                    oFechaFinal.CurrentValues.Add(oFechaFinDValue);

                    //5to. AGREGAMOS LOS PARAMETROS A LA COLECCION 
                    oParametrosCR.Add(oUsuario);
                    oParametrosCR.Add(oFechaInicial);
                    oParametrosCR.Add(oFechaFinal);
                    //nombre del parametro en CR (Crystal Reports)
                    oParametrosCR[0].Name = "cUsuario";
                    oParametrosCR[1].Name = "cFechaInicial";
                    oParametrosCR[2].Name = "cFechaFinal";

                    //nombre del TITULO DEL INFORME
                    cTitulo = "ESTADISTICAS DE CONSUMO DE COMBUSTIBLE POR ACTIVIDAD";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptEstadisticoMovimientoCombustiblePorActividad orptEstadisticoMovimientoCombPorActividad = new rptEstadisticoMovimientoCombustiblePorActividad();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptEstadisticoMovimientoCombPorActividad.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtMovimientoCombustible, orptEstadisticoMovimientoCombPorActividad, cTitulo);

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
