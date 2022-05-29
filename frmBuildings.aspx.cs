using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class frmBuildings : System.Web.UI.Page
{
    clsBuilding cBuilding = new clsBuilding();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ConsultarEdificios();
            txtEdificio.Text = "";
        }
    }

    #region Metodos
    private void ConsultarEdificios()
    {
        clsBuilding edificio = new clsBuilding();
        DataTable dt = new DataTable();
        try
        {
            dt = edificio.Consultar();
            gvListadoBuildings.DataSource = dt;
            gvListadoBuildings.DataBind();
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
    public void gvListadoBuildings_PreRender(Object sender, EventArgs e)
    {

        if (gvListadoBuildings.Rows.Count > 0)
        {
            gvListadoBuildings.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }

    protected void lnkbtnGuardar_Click(object sender, EventArgs e)
    {
        bool result = false;
        if (txtEdificio.Text == "")
        {
            Mensaje("Debe ingresar el nombre del edificio.", "Validación!", "info");
        }
        else
        {
            cBuilding.building = txtEdificio.Text;
            result = cBuilding.Insertar();
            if (result)
            {
                Mensaje("Se guardo correctamente la información.", "Éxito!", "success");
                txtEdificio.Text = "";
                ConsultarEdificios();
            }
            else
            {
                Mensaje("error al guardar información.", "Error!", "error");
            }
        }
    }

    #endregion

  
}