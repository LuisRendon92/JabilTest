using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de clsCustomers
/// </summary>
public class clsCustomers
{
    #region Propiedades
    public int idCustomer { get; set; }
    public String customer { get; set; }
    public String prefix { get; set; }
    public int idBuilding { get; set; }
    public Boolean available { get; set; }
    #endregion


    #region Metodos
    public bool Insertar()
    {
        Boolean result = false;

        using (SqlConnection conexion = new SqlConnection(clsConexion.GetConnectionString()))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("pa_Agregar_customer", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = customer;
                    cmd.Parameters.Add("@prefix", SqlDbType.NVarChar,5).Value = prefix;
                    cmd.Parameters.Add("@idBuilding", SqlDbType.Int).Value = idBuilding;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }

            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
        }




        return result;
    }


    public DataTable ConsultarCustomers()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conexion = new SqlConnection(clsConexion.GetConnectionString()))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("pa_ConsultarLista_Customers", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        return dt;
    }


    public DataTable ConsultarCustomersActivos()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conexion = new SqlConnection(clsConexion.GetConnectionString()))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from Customers where available=1", conexion))
                {
       
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        return dt;
    }

    #endregion

    public clsCustomers()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}