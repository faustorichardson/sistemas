using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SisGesFactInv
{
    public partial class frmBuscarClientes : frmBase
    {
        public string cCodigo = "";

        public frmBuscarClientes()
        {
            InitializeComponent();
        }

        private void frmBuscarClientes_Load(object sender, EventArgs e)
        {

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            int nPos = 0;
            int nTodo = this.grdCatalogo.GetCellCount(DataGridViewElementStates.Selected);
            if (nTodo > 0)
            {
                int nFila = this.grdCatalogo.SelectedCells[nPos].RowIndex;
                int nCol = this.grdCatalogo.SelectedCells[nPos].ColumnIndex;
                this.cCodigo = Convert.ToString(grdCatalogo[nCol, nFila].Value);

                // forzo la primera columna para el codigo 
                this.cCodigo = Convert.ToString(grdCatalogo[0, nFila].Value);
            }
            this.grdCatalogo.Visible = true;
            this.Close();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.cCodigo = "";
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBuscar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.txtBuscar.Text != "")
                {
                    // Version Consulta sin Store Procedure, solo string de consulta
                    // Version Consulta con Store Procedure parametrizado
                    string cBuscar = "'%" + this.txtBuscar.Text.Trim().ToUpper() + "%'";
                    DataTable dsCatalogo = clsProcesos.DatosGeneral("clientes", " where upper(nombre)  like " + cBuscar + " AND status = 'A' order by nombre ");

                    if (dsCatalogo.Rows.Count > 0)
                    {
                        // borro las lineas del grid y datatable
                        this.grdCatalogo.Rows.Clear();
                        // Mostrar los datos del datatable en el grid
                        foreach (DataRow registro in dsCatalogo.Rows)
                        {
                            this.grdCatalogo.Rows.Add(registro["idcliente"], registro["nombre"].ToString().Trim(), registro["rnc"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hubo coincidencia, favor intente de nuevo!!", "Sistema de Gestion de Facturacion e Inventario",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message, "Sistema de Gestion de Facturacion e Inventario", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                clsExceptionLog.LogError(ex, false);
                //    oTransaccion.Connection.State =  ConnectionState.                                 
                return;
            }
        }

        private void grdCatalogo_DoubleClick(object sender, EventArgs e)
        {
            int nPos = 0;
            int nTodo = this.grdCatalogo.GetCellCount(DataGridViewElementStates.Selected);
            if (nTodo > 0)
            {
                int nFila = this.grdCatalogo.SelectedCells[nPos].RowIndex;
                int nCol = this.grdCatalogo.SelectedCells[nPos].ColumnIndex;
                this.cCodigo = Convert.ToString(grdCatalogo[nCol, nFila].Value);

                // forzo la primera columna para el codigo 
                this.cCodigo = Convert.ToString(grdCatalogo[0, nFila].Value);
            }
            this.grdCatalogo.Visible = true;
            this.Close();
        }
    }
}
