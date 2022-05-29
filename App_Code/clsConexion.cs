using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de clsConexion
/// </summary>
public class clsConexion
{


    static public string GetConnectionString()
    {

        return "Data Source=LRENDONA;Initial Catalog=Jabil;"
            + "Integrated Security=true;";
    }
}