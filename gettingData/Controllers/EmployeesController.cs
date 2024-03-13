using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gettingData.Services;
using gettingData.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;

namespace gettingData.Controllers
{
    public class EmployeesController : Controller
    {

        public ActionResult Index()

        {

            List<employeeEntity> emp = new List<employeeEntity>();
            emp.Add(new employeeEntity());
            return View(emp);
        }

        [HttpGet]
        public JsonResult AjaxMethod123(int pageIndex,int PageSize)
        {
            //string searchTerm = ""; int RecordCount;
            employeeEntityModel model = new employeeEntityModel();
            //model.SearchTerm = searchTerm;
            model.PageIndex = pageIndex;
            model.PageSize = 5;

            List<employeeEntity> employeeEntity = new List<employeeEntity>();
            string constring = ConfigurationManager.ConnectionStrings["EmployeeDbConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("getData_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchTerm", model.SearchTerm);
                    cmd.Parameters.AddWithValue("@PageIndex", model.PageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", model.PageSize);
                    //cmd.Parameters.Add("@RecordCount", SqlDbType.VarChar, 30);
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        employeeEntity.Add(new employeeEntity
                        {
                            employeeId = int.Parse(sdr["employeeId"].ToString()),
                            firstName = sdr["firstName"].ToString(),
                            lastName = sdr["lastName"].ToString(),
                            mobileNumber = sdr["mobileNumber"].ToString()
                        });
                    }
                    con.Close();

                    model.Employees = employeeEntity;
                    model.RecordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                  
                }
            }   
            var result = model.Employees;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
