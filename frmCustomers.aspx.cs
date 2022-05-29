using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmCustomers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenaEdificios();
            ConsultarClientes();
            limpiar();
           
        }
    }

    #region Metodos
    private void limpiar()
    {
        txtCliente.Text = "";
        txtPrefijo.Text = "";
        ddlEdificio.SelectedValue = "-1";
    }

    private void LlenaEdificios() {
        try
        {
            clsBuilding building = new clsBuilding();
            DataTable dt = new DataTable();
            dt = building.Consultar();
            if (dt.Rows.Count > 0)
            {
                ddlEdificio.DataSource = dt;
                ddlEdificio.DataValueField = "idBuilding";
                ddlEdificio.DataTextField = "Building";
                ddlEdificio.DataBind();

                ListItem item = new ListItem();
                item.Value = "-1";
                item.Text = "-- Seleccione un elemento --";
                ddlEdificio.Items.Add(item);
                ddlEdificio.SelectedValue = "-1";
            }
            else {
                ListItem item = new ListItem();
                item.Value = "-1";
                item.Text = "-- Seleccione un elemento --";
                ddlEdificio.Items.Add(item);
                ddlEdificio.SelectedValue = "-1";
            }
        }
        catch (Exception e)
        {
            Mensaje(e.Message, "Error!", "error");
       
        }

    }

    private void ConsultarClientes()
    {
        clsCustomers cliente = new clsCustomers();
        DataTable dt = new DataTable();
        try
        {
            dt = cliente.ConsultarCustomers();
            gvListadoCustomers.DataSource = dt;
            gvListadoCustomers.DataBind();
        }
        catch (Exception e)
        {
            Mensaje(e.Message, "Error!", "error");
            throw;
        }




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
        if (txtCliente.Text == "") {
            Mensaje("Debe ingresar el nombre del cliente.", "Validación!","info");
        }
        else if (txtPrefijo.Text == "")
        {
            Mensaje("Debe ingresar un nombre corto.", "Validación!", "info");
        }
        else if (Int32.Parse(ddlEdificio.SelectedValue) <= 0)
        {
            Mensaje("Debe seleccionar un edificio.", "Validación!", "info");
        }
        else if (txtPrefijo.Text.Length > 5)
        {
            Mensaje("El nombre corto o prefijo excede los caracteres permitidos.", "Validación!", "info");
        }
        else {
            clsCustomers customer = new clsCustomers();
            customer.customer = txtCliente.Text;
            customer.prefix = txtPrefijo.Text;
            customer.idBuilding = Int32.Parse(ddlEdificio.SelectedValue);
            result = customer.Insertar();
            if (result)
            {
                Mensaje("Se guardo correctamente la información.", "Éxito!", "success");
                limpiar();
                ConsultarClientes();
            }
            else
            {
                Mensaje("error al guardar información.", "Error!", "error");
            }


        }
    }
    #endregion

}