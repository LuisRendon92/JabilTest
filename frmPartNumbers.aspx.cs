using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPartNumbers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenaClientes();
            ConsultarNoParts();
            limpiar();

        }
    }

    #region Metodos
    private void limpiar()
    {
        txtNoParte.Text = "";
        ddlCustomer.SelectedValue = "-1";
    }

    private void LlenaClientes()
    {
        try
        {
            clsCustomers cliente = new clsCustomers();
            DataTable dt = new DataTable();
            dt = cliente.ConsultarCustomersActivos();
            if (dt.Rows.Count > 0)
            {
                ddlCustomer.DataSource = dt;
                ddlCustomer.DataValueField = "idCustomer";
                ddlCustomer.DataTextField = "Customer";
                ddlCustomer.DataBind();

                ListItem item = new ListItem();
                item.Value = "-1";
                item.Text = "-- Seleccione un elemento --";
                ddlCustomer.Items.Add(item);
                ddlCustomer.SelectedValue = "-1";
            }
            else
            {
                ListItem item = new ListItem();
                item.Value = "-1";
                item.Text = "-- Seleccione un elemento --";
                ddlCustomer.Items.Add(item);
                ddlCustomer.SelectedValue = "-1";
            }
        }
        catch (Exception e)
        {
            Mensaje(e.Message, "Error!", "error");

        }

    }

    private void ConsultarNoParts()
    {
        ClsPartNumbers noPart = new ClsPartNumbers();
        DataTable dt = new DataTable();
        try
        {
            noPart.available = ddlEstatus.SelectedValue;
            dt = noPart.ConsultarNoParts();
            gvListado.DataSource = dt;
            gvListado.DataBind();
        }
        catch (Exception e)
        {
            Mensaje(e.Message, "Error!", "error");

        }




    }

    private void ExportExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Reporte" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        gvListado.GridLines = GridLines.Both;
        gvListado.HeaderStyle.Font.Bold = true;
        gvListado.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    public void Mensaje(string mensaje, string titulo, string tipo, bool callback = true)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "swal('" + titulo + "','" + mensaje + "','" + tipo + "');", true);
    }

    #endregion
    #region Handlers
    protected void lnkbtnGuardar_Click(object sender, EventArgs e)
    {
        bool result = false;
        if (txtNoParte.Text == "")
        {
            Mensaje("Debe ingresar el número de parte.", "Validación!", "info");
        }
        else if (Int32.Parse(ddlCustomer.SelectedValue) <= 0)
        {
            Mensaje("Debe seleccionar un cliente.", "Validación!", "info");
        }
        else {
            ClsPartNumbers NoPart = new ClsPartNumbers();
            NoPart.partNumber = txtNoParte.Text;
            NoPart.idCustomer = Int32.Parse(ddlCustomer.SelectedValue);
            result = NoPart.Insertar();
            if (result)
            {
                Mensaje("Se guardo correctamente la información.", "Éxito!", "success");
                limpiar();
                ConsultarNoParts();
            }
            else
            {
                Mensaje("error al guardar información.", "Error!", "error");
            }
        }

    }

    protected void ddlEstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConsultarNoParts();
    }
    protected void lnkExportar_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvListado.Rows.Count <= 0)
            {
                Mensaje("Sin registros que exportar.", "Validación", "info");
            }
            else
            {
                ExportExcel();
            }

        }
        catch (Exception ex)
        {
            Mensaje(ex.Message, "Error!", "error");
        }


    
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
      
    }
    #endregion

  
}