using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeyCafe.Models;
namespace CoffeyCafe.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        coffeCafeEntities1 obj = new coffeCafeEntities1();
        public ActionResult ViewPaymentDetails()
        {
            return View(obj.Salaries.ToList());
        }

        // GET: Salary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Salary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salary/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Salary EmployeePayment)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Salaries.Add(EmployeePayment);
            obj.SaveChanges();

            return RedirectToAction("ViewPaymentDetails");
        }

        // GET: Salary/Edit/5
        public ActionResult Edit(int id)
        {
            var SalaryToEdit = (from m in obj.Salaries where m.id == id select m).First();
            return View(SalaryToEdit);
        }

        // POST: Salary/Edit/5
        [HttpPost]
        public ActionResult Edit(Salary SalaryToEdit)
        {
            var orignalRecord = (from m in obj.Salaries where m.id == SalaryToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(SalaryToEdit);

            obj.SaveChanges();
            return RedirectToAction("ViewPaymentDetails");
        }

        // GET: Salary/Delete/5
        public ActionResult Delete(Salary SalaryToDelete)
        {
            var d = obj.Salaries.Where(x => x.id == SalaryToDelete.id).FirstOrDefault();
            obj.Salaries.Remove(d);
            obj.SaveChanges();

            return RedirectToAction("ViewPaymentDetails");
        }

        // POST: Salary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
