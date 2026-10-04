using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CallCenterSecure.Controllers
{
    public class ExposeData : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("/api/GetDownData")]
        public string GetDownData()
        {

            try
            {
                string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ReportServer"].ConnectionString;
                string spName = "Kredits_MssdPmt";
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
                    string Jsonobject = Newtonsoft.Json.JsonConvert.SerializeObject(dataset.Tables[0]);
                    return Jsonobject;
                }

                else
                    return "nodatafound";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}