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
    public partial class frmPrintEntradaInventario : frmBase
    {
        public frmPrintEntradaInventario()
        {
            InitializeComponent();
        }

        private void frmPrintEntradaInventario_Load(object sender, EventArgs e)
        {

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
            string cWhere = " WHERE 1 = 1 AND anulada = 0";
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
                string fechadesde = dtDesde.Value.ToString("yyyy-MM-dd");
                string fechahasta = dtHasta.Value.ToString("yyyy-MM-dd");
                cWhere = cWhere + " AND fecha >= " + "'" + fechadesde + "'" + " AND fecha <= " + "'" + fechahasta + "'" + "";
                sbQuery.Clear();
                sbQuery.Append("SELECT ");
                sbQuery.Append(" entrada_inventario.id, entrada_inventario.idsuplidor, suplidores.nombre as suplidor,");
                sbQuery.Append(" entrada_inventario.fecha, entrada_inventario.total as subtotal");
                sbQuery.Append(" FROM entrada_inventario ");
                sbQuery.Append(" INNER JOIN suplidores ON entrada_inventario.idsuplidor = suplidores.idsuplidor");
                sbQuery.Append(cWhere);


                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtMovimientoInventario = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtMovimientoInventario);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtMovimientoInventario.Rows.Count;
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
                    cTitulo = "LISTADO DE ENTRADA A INVENTARIO";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptEntradaInventario_Listado orptEntradaInventarioListado = new rptEntradaInventario_Listado();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptEntradaInventarioListado.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtMovimientoInventario, orptEntradaInventarioListado, cTitulo);

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
