using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeyCafe.Models;
using System.Data;
using System.Data.SqlClient;

namespace CoffeyCafe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult History()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Testimonial()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Team()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }




        public ActionResult Faq()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void Msgconnection(String qry) {

            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcon.ConnectionString = "Data Source=LAPTOP-RFTA97Q7\\SQLEXPRESS01;Initial Catalog=coffeCafe;Integrated Security=True";




            sqlcon.Open();
            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = qry; 
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

        }


        [HttpPost]
        public ActionResult passMessage(Message Instance_Msg)
        {

            String query = "insert into MessageDetails(Name,Email,Phone,Msg) values('"+ Instance_Msg.Name+"','"+ Instance_Msg.Email+"','"+ Instance_Msg.Phone+"','"+ Instance_Msg.Msg+"')";
            Msgconnection(query);

            return View("FeedBack");
        }


    }
}