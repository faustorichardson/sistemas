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
    public partial class frmPrintReimpresiones : frmBase
    {
        public frmPrintReimpresiones()
        {
            InitializeComponent();
        }

        private void frmPrintReimpresiones_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.rbEntradas.Checked = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (rbEntradas.Checked == true)
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("No se permite generar el reporte sin su debida numeracion...");
                    txtID.Focus();
                }
                else
                {

                    //clsConexion a la base de datos
                    MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);
                    // Creando el command que ejecutare
                    MySqlCommand myCommand = new MySqlCommand();
                    // Creando el Data Adapter
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                    // Creando el String Builder
                    StringBuilder sbQuery = new StringBuilder();
                    // Otras variables del entorno
                    string cWhere = " WHERE 1 = 1";
                    string cUsuario = frmLogin.cUsuarioActual;
                    string cTitulo = "";
                    int cCodigo = Convert.ToInt32(txtID.Text);

                    try
                    {
                        // Abro clsConexion
                        myclsConexion.Open();
                        // Creo comando
                        myCommand = myclsConexion.CreateCommand();
                        // Adhiero el comando a la clsConexion
                        myCommand.Connection = myclsConexion;
                        // Filtros de la busqueda
                        //int cCodigoImprimir = Convert.ToInt32(txtIdLicencia.Text);
                        cWhere = cWhere + " AND entrada_inventario.id =" + cCodigo + "";
                        sbQuery.Clear();
                        sbQuery.Append("SELECT ");
                        sbQuery.Append(" entrada_inventario.id, entrada_inventario.fecha, entrada_inventario.monto_total,");
                        sbQuery.Append(" entrada_inventario.total, entrada_inventario.anulada, entrada_inventario_detalle.idproducto,");
                        sbQuery.Append(" entrada_inventario_detalle.producto, entrada_inventario_detalle.tipo,");
                        sbQuery.Append(" entrada_inventario_detalle.precio, entrada_inventario_detalle.cantidad, ");
                        sbQuery.Append(" entrada_inventario_detalle.subtotal, suplidores.nombre as suplidor, entrada_inventario.total, ");
                        sbQuery.Append(" suplidores.rnc, suplidores.direccion, suplidores.telefono, provincias.nombre as provincia,");
                        sbQuery.Append(" suplidores.idsuplidor");
                        sbQuery.Append(" FROM entrada_inventario");
                        sbQuery.Append(" INNER JOIN entrada_inventario_detalle ON entrada_inventario.id = entrada_inventario_detalle.id");
                        sbQuery.Append(" INNER JOIN suplidores ON suplidores.idsuplidor = entrada_inventario.idsuplidor");
                        sbQuery.Append(" INNER JOIN provincias ON provincias.provincia_id = suplidores.provincia");
                        sbQuery.Append(cWhere);

                        // Paso los valores de sbQuery al CommandText
                        myCommand.CommandText = sbQuery.ToString();
                        // Creo el objeto Data Adapter y ejecuto el command en el
                        myAdapter = new MySqlDataAdapter(myCommand);
                        // Creo el objeto Data Table
                        DataTable dtMovimientoInventario = new DataTable();
                        // Lleno el data adapter
                        myAdapter.Fill(dtMovimientoInventario);
                        // Cierro el objeto clsConexion
                        myclsConexion.Close();

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
                            cTitulo = "DETALLE DE ENTRADA DE INVENTARIO";

                            //6to Instanciamos nuestro REPORTE
                            //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                            rptEntradaInventario orptEntradaInventario = new rptEntradaInventario();

                            //pasamos el nombre del TITULO del Listado
                            //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                            // oListado.SummaryInfo.ReportTitle = cTitulo;

                            orptEntradaInventario.SummaryInfo.ReportTitle = cTitulo;

                            //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                            frmPrinter ofrmPrinter = new frmPrinter(dtMovimientoInventario, orptEntradaInventario, cTitulo);

                            //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                            ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                            ofrmPrinter.ShowDialog();
                        }
                    }
                    catch (Exception myEx)
                    {
                        MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        clsExceptionLog.LogError(myEx, false);
                        return;
                    }
                }
            }
            else if (rbFacturas.Checked == true)
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("No se permite generar el reporte sin su debida numeracion...");
                    txtID.Focus();
                }
                else
                {

                    //clsConexion a la base de datos
                    MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);
                    // Creando el command que ejecutare
                    MySqlCommand myCommand = new MySqlCommand();
                    // Creando el Data Adapter
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                    // Creando el String Builder
                    StringBuilder sbQuery = new StringBuilder();
                    // Otras variables del entorno
                    string cWhere = " WHERE 1 = 1";
                    string cUsuario = frmLogin.cUsuarioActual;
                    string cTitulo = "";
                    int cCodigo = Convert.ToInt32(txtID.Text);

                    try
                    {
                        // Abro clsConexion
                        myclsConexion.Open();
                        // Creo comando
                        myCommand = myclsConexion.CreateCommand();
                        // Adhiero el comando a la clsConexion
                        myCommand.Connection = myclsConexion;
                        // Filtros de la busqueda
                        //int cCodigoImprimir = Convert.ToInt32(txtIdLicencia.Text);
                        cWhere = cWhere + " AND facturacion.idfacturacion =" + cCodigo + "";
                        sbQuery.Clear();
                        sbQuery.Append("SELECT ");
                        sbQuery.Append(" facturacion.idfacturacion as id, facturacion_detalle.idproducto,");
                        sbQuery.Append(" facturacion_detalle.producto, facturacion_detalle.tipo,");
                        sbQuery.Append(" facturacion_detalle.precio, facturacion_detalle.cantidad, facturacion.fecha,");
                        sbQuery.Append(" facturacion_detalle.subtotal, clientes.idcliente, clientes.nombre as cliente,");
                        sbQuery.Append(" clientes.rnc, provincias.nombre as provincia, clientes.direccion, clientes.telefono,");
                        sbQuery.Append(" facturacion.monto_n as total ");
                        sbQuery.Append(" FROM facturacion");
                        sbQuery.Append(" INNER JOIN facturacion_detalle ON facturacion_detalle.idfacturacion = facturacion.idfacturacion");
                        sbQuery.Append(" INNER JOIN clientes ON clientes.idcliente = facturacion.idcliente");
                        sbQuery.Append(" INNER JOIN provincias ON provincias.provincia_id = clientes.provincia");
                        sbQuery.Append(cWhere);

                        // Paso los valores de sbQuery al CommandText
                        myCommand.CommandText = sbQuery.ToString();
                        // Creo el objeto Data Adapter y ejecuto el command en el
                        myAdapter = new MySqlDataAdapter(myCommand);
                        // Creo el objeto Data Table
                        DataTable dtMovimientoInventario = new DataTable();
                        // Lleno el data adapter
                        myAdapter.Fill(dtMovimientoInventario);
                        // Cierro el objeto clsConexion
                        myclsConexion.Close();

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
                            cTitulo = "FACTURA DETALLE";

                            //6to Instanciamos nuestro REPORTE
                            //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                            rptFacturaDetalle orptFacturaDetalle = new rptFacturaDetalle();

                            //pasamos el nombre del TITULO del Listado
                            //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                            // oListado.SummaryInfo.ReportTitle = cTitulo;
                            orptFacturaDetalle.SummaryInfo.ReportTitle = cTitulo;

                            //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                            frmPrinter ofrmPrinter = new frmPrinter(dtMovimientoInventario, orptFacturaDetalle, cTitulo);

                            //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                            ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                            ofrmPrinter.ShowDialog();
                        }
                    }
                    catch (Exception myEx)
                    {
                        MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        clsExceptionLog.LogError(myEx, false);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de elegir que opcion de impresion desea...");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
