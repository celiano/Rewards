using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TercerosController : ApiController
    {

        public Terceros Get(string userName, string password)
        {
            Terceros terceros = new Terceros();
            if (userName == "celiano" && password == "Nspweb2016")
            {
                //terceros.Username = "celiano";
                //terceros.Country = "CO";
            } else
            {
                terceros = null;
            }

            //SqlConnection con = new SqlConnection();
            string datosConexion = @"Data Source=LEHILT-CELIANO\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;";
            //con.ConnectionString = datosConexion;
            //con.Open();

            using (SqlConnection con = new SqlConnection(datosConexion))
            {
                con.Open();
                Terceros terceros = new Terceros();

                SqlCommand Command = con.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = "dbo.GetTerceros";
                SqlDataReader oReader = Command.ExecuteReader();
                while (oReader.Read())
                {
                    Tercero tercero = new Tercero();
                    tercero.Nombres = oReader["Nombres"].ToString();
                    tercero.Apellidos = oReader["Apellidos"].ToString();
                }
            }

                //SqlConnection conn = new SqlConnection("Data Source=LEHILT-CELIANO\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;");
                //SqlCommand command = new SqlCommand("dbo.GetTerceros", conn);
                //command.CommandType = CommandType.StoredProcedure;
                //SqlDataAdapter adapter = new SqlDataAdapter(command);
                //DataSet ds = new DataSet();
                //adapter.Fill(ds, "Products");

                //SqlConnection conn = new SqlConnection("Data Source=Test,1433;Initial Catalog=Test;User ID=HybridConnectionLogin;Password=Testing2016;MultipleActiveResultSets=True");
                //using (SqlConnection DBConnection = new SqlConnection(conn))
                //{

                //}

                return terceros;
        }

    }
}
