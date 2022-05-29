using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de clsBuilding
/// </summary>
public class clsBuilding
{

    #region Propiedades
    public int idBuilding { get; set; }
    public String building { get; set; }
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
                using (SqlCommand cmd = new SqlCommand("pa_Agregar_building", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@building", SqlDbType.VarChar).Value = building;
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


    public DataTable Consultar()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conexion = new SqlConnection(clsConexion.GetConnectionString()))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("pa_Consultar_building", conexion))
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

    #endregion
 

    public clsBuilding()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}