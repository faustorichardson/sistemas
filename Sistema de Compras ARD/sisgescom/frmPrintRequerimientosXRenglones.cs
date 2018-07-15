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

namespace SisGesCom
{
    public partial class frmPrintRequerimientosXRenglones : frmBase
    {
        public frmPrintRequerimientosXRenglones()
        {
            InitializeComponent();
        }

        private void frmPrintRequerimientosXRenglones_Load(object sender, EventArgs e)
        {
            this.chkTodos.Checked = true;
            this.fechadesde.Enabled = false;
            this.fechahasta.Enabled = false;
            this.fillcmbDependencia();  
        }

        private void fillcmbDependencia()
        {
            try
            {
                // Step 1 
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT id_renglon, desc_renglon FROM renglones ORDER BY desc_renglon ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("id_renglon", typeof(int));
                MyDataTable.Columns.Add("desc_renglon", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbDependencia.ValueMember = "id_renglon";
                cmbDependencia.DisplayMember = "desc_renglon";
                cmbDependencia.DataSource = MyDataTable;

                // Step 7
                MyConexion.Close();

            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
                throw;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // GENERANDO EL LISTADO DE REQUERIMIENTOS EN GENERAL
            if (chkTodos.Checked == true)
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
                //string myStatus;
                string cWhere = " WHERE 1 = 1";
                string cUsuario = frmLogin.cUsuarioActual;
                string cTitulo = "";

                // Verifico si se quiere Requerimientos Pendientes o los Adquiridos.
                if (chkAdquiridos.Checked == true)
                {
                    cWhere = cWhere + " AND requerimientos.status = 1";
                }
                else
                {
                    cWhere = cWhere + " AND requerimientos.status = 0";
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
                    sbQuery.Append("SELECT renglones.desc_renglon as renglon, dependencias.dependencia, requerimientos.id, requerimientos.requerimiento,");
                    sbQuery.Append(" requerimientos.fecharequerido, requerimientos.fecharegistro, requerimientos.monto_cotizacion as monto, requerimientos.monto_itbi as itbi");
                    sbQuery.Append(" FROM renglones");
                    sbQuery.Append(" INNER JOIN dependencias ON dependencias.renglon = renglones.id_renglon");
                    sbQuery.Append(" INNER JOIN requerimientos ON requerimientos.dependencia = dependencias.id");
                    sbQuery.Append(cWhere);
                    sbQuery.Append(" ORDER BY renglones.desc_renglon ASC");

                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtRequerimientos = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtRequerimientos);
                    // Cierro el objeto conexion
                    myConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtRequerimientos.Rows.Count;
                    if (nRegistro == 0)
                    {
                        MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Gestion de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (chkAdquiridos.Checked == true)
                        {
                            cTitulo = "LISTADO DE REQUERIMIENTOS ADQUIRIDOS POR RENGLONES";
                        }
                        else
                        {
                            cTitulo = "LISTADO DE REQUERIMIENTOS PENDIENTES POR RENGLONES";
                        }

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptRequerimientosTodosPorRenglones orptRequerimientosTodosPorRenglones = new rptRequerimientosTodosPorRenglones();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;                        
                        orptRequerimientosTodosPorRenglones.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtRequerimientos, orptRequerimientosTodosPorRenglones, cTitulo);

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
            // GENERANDO EL LISTADO POR FECHAS DE REQUERIMIENTOS
            else if (chkFecha.Checked == true)
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
                //string myStatus;
                string cWhere = " WHERE 1 = 1";
                string cUsuario = frmLogin.cUsuarioActual;
                string cTitulo = "";

                // Verifico si se quiere Requerimientos Pendientes o los Adquiridos.
                if (chkAdquiridos.Checked == true)
                {
                    cWhere = cWhere + " AND status = 1";
                }
                else
                {
                    cWhere = cWhere + " AND status = 0";
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
                    string fechaDesde = fechadesde.Value.ToString("yyyy-MM-dd");
                    string fechaHasta = fechahasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND fecharequerido >= " + "'" + fechaDesde + "'" + " AND fecharequerido <= " + "'" + fechaHasta + "'" + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT renglones.desc_renglon as renglon, dependencias.dependencia, requerimientos.id, requerimientos.requerimiento,");
                    sbQuery.Append(" requerimientos.fecharequerido, requerimientos.fecharegistro, requerimientos.monto_cotizacion as monto, requerimientos.monto_itbi as itbi");
                    sbQuery.Append(" FROM renglones");
                    sbQuery.Append(" INNER JOIN dependencias ON dependencias.renglon = renglones.id_renglon");
                    sbQuery.Append(" INNER JOIN requerimientos ON requerimientos.dependencia = dependencias.id");
                    sbQuery.Append(cWhere);
                    sbQuery.Append(" ORDER BY renglones.desc_renglon ASC");

                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtRequerimientos = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtRequerimientos);
                    // Cierro el objeto conexion
                    myConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtRequerimientos.Rows.Count;
                    if (nRegistro == 0)
                    {
                        MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Gestion de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        oFechaDValue.Value = fechaDesde;
                        ParameterDiscreteValue oFechaFinDValue = new ParameterDiscreteValue();
                        oFechaFinDValue.Value = fechaHasta;

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
                        if (chkAdquiridos.Checked == true)
                        {
                            cTitulo = "LISTADO DE REQUERIMIENTOS ADQUIRIDOS POR FECHA Y RENGLON";
                        }
                        else
                        {
                            cTitulo = "LISTADO DE REQUERIMIENTOS PENDIENTES POR FECHA Y RENGLON";
                        }

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptRequerimientosxFechaxRenglones orptRequerimientosxFechaxRenglones = new rptRequerimientosxFechaxRenglones();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;                        
                        orptRequerimientosxFechaxRenglones.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtRequerimientos, orptRequerimientosxFechaxRenglones, cTitulo);

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
            // GENERANDO EL LISTADO POR DEPENDENCIAS
            else if (chkDependencia.Checked == true)
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
                //string myStatus;
                string cWhere = " WHERE 1 = 1";
                cWhere = cWhere + " AND renglones.id_renglon = "+ cmbDependencia.SelectedValue + "";

                // Parametros de titulo y usuario
                string cUsuario = frmLogin.cUsuarioActual;
                string cTitulo = "";

                // Verifico si se quiere Requerimientos Pendientes o los Adquiridos.
                if (chkAdquiridos.Checked == true)
                {
                    cWhere = cWhere + " AND status = 1";
                }
                else
                {
                    cWhere = cWhere + " AND status = 0";
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
                    //string fechaDesde = fechadesde.Value.ToString("yyyy-MM-dd");
                    //string fechaHasta = fechahasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND requerimientos.dependencia =" + cmbDependencia.SelectedValue + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT requerimientos.id, dependencias.dependencia, requerimientos.requerimiento,");
                    sbQuery.Append(" requerimientos.fecharegistro, requerimientos.fecharequerido,");
                    sbQuery.Append(" requerimientos.monto_cotizacion as monto, requerimientos.monto_itbi as itbi,");
                    sbQuery.Append(" renglones.desc_renglon as renglon");
                    sbQuery.Append(" FROM requerimientos ");
                    sbQuery.Append(" INNER JOIN dependencias ON dependencias.id = requerimientos.dependencia");
                    sbQuery.Append(" INNER JOIN renglones ON renglones.id_renglon = dependencias.renglon");
                    sbQuery.Append(cWhere);
                    sbQuery.Append(" ORDER BY renglon ASC");

                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtRequerimientos = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtRequerimientos);
                    // Cierro el objeto conexion
                    myConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtRequerimientos.Rows.Count;
                    if (nRegistro == 0)
                    {
                        MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema Gestion de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (chkAdquiridos.Checked == true)
                        {
                            cTitulo = "LISTADO DE REQUERIMIENTOS ADQUIRIDOS";
                        }
                        else
                        {
                            cTitulo = "LISTADO DE REQUERIMIENTOS PENDIENTES";
                        }

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptRequerimientosxDependencia orptRequerimientosxDependencia = new rptRequerimientosxDependencia();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;                        
                        orptRequerimientosxDependencia.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtRequerimientos, orptRequerimientosxDependencia, cTitulo);

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

                this.cmbDependencia.Refresh();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == true)
            {
                this.fechadesde.Enabled = false;
                this.fechahasta.Enabled = false;
                this.cmbDependencia.Enabled = false;
            }
            
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked == true)
            {
                this.fechadesde.Enabled = true;
                this.fechahasta.Enabled = true;
            }
            else
            {
                this.fechadesde.Enabled = false;
                this.fechahasta.Enabled = false;
            }
        }

        private void chkDependencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDependencia.Checked == true)
            {
                this.cmbDependencia.Enabled = true;
            }
            else
            {
                this.cmbDependencia.Enabled = false;
            }
        }
    }
}
