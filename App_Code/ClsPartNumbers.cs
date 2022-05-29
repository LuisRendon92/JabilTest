using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ClsPartNumbers
/// </summary>
public class ClsPartNumbers
{

    #region Propiedades
    public int idPartNumber { get; set; }
    public String partNumber { get; set; }
    public int idCustomer { get; set; }
    public string available { get; set; }
    #endregion


    #region Metodos
    public bool Insertar()
    {
        Boolean result = false;

        using (SqlConnection conexion = new SqlConnection(clsConexion.GetConnectionString()))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("pa_Agregar_NoParte", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@partNumber", SqlDbType.VarChar).Value = partNumber;
                    cmd.Parameters.Add("@idCustomer", SqlDbType.Int).Value = idCustomer;
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


    public DataTable ConsultarNoParts()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conexion = new SqlConnection(clsConexion.GetConnectionString()))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("pa_ConsultarLista_NoParts", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@available", SqlDbType.TinyInt).Value = available;
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
    public ClsPartNumbers()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}