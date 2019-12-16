using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeyCafe.Models;
using System.Data.SqlClient;


namespace CoffeyCafe.Controllers
{
    public class AdminDetailsController : Controller
    {
        // GET: AdminDetails
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLoginCheck(AdminDetails instance_Admin) {


            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataReader sqldr;

            sqlcon.ConnectionString = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=coffeCafe;Integrated Security=True";
            sqlcon.Open();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "select * from AdminDetails where AdminName='" + instance_Admin.AdminName + "' and AdminPassword='" + instance_Admin.AdminPassword + "'";

            sqldr = sqlcmd.ExecuteReader();

            if (sqldr.Read())
            {
                sqlcon.Close();
                return View("AdminDashBoard");
            }
            else
            {
                sqlcon.Close();
                return View("Wrong");
            }



        }

    }
}