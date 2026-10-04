using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetDawnData()
        {
            string Jsonobject = string.Empty;
            try
            {
                string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ReportServer"].ConnectionString;
                string spName = Convert.ToString( ConfigurationManager.AppSettings["SPName"]) ;
                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = spName;
                //cmd.Parameters.AddWithValue("@SearchItem", ClientId);
                //cmd.Parameters.AddWithValue("@SearchType", SPParameterValue);
                //cmd.Parameters.AddWithValue("@BrchName", SearchBranch);
                //add any parameters the stored procedure might require
                cnn.Open();
                var adapter = new SqlDataAdapter(cmd);
                var dataset = new DataSet();
                adapter.Fill(dataset);

                cnn.Close();

                if (dataset != null)
                {
                    Jsonobject = Newtonsoft.Json.JsonConvert.SerializeObject(dataset.Tables[0]);

                }

                else
                    Jsonobject = "nodatafound";
            }
            catch (Exception ex)
            {
                Jsonobject = ex.Message;
            }

            return  Jsonobject;
        }


    }
}
