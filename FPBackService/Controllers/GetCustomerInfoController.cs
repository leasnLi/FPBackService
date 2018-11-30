using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace FPBackService.Controllers
{
    public class GetCustomerInfoController : Controller
    {
        // GET: GetCustomerInfo
        public ActionResult Index()
        {
            return View();
        }

        public async Task<string> GetCard([FromBody] string deviceId)
        {
            string cardNo = await ExecuteDataTable(deviceId);
            return cardNo;
        }

        public async Task<string> ExecuteDataTable(string deviceId)
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["db"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("usp_GetCardInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@deviceId", deviceId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable.Rows[0][0].ToString();
                }
            }
        }
    }
}