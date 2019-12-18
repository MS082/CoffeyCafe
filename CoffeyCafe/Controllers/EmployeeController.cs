using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeyCafe.Models;
namespace CoffeyCafe.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        coffeCafeEntities1 obj = new coffeCafeEntities1();

        public ActionResult ViewEmployee()
        {
            return View(obj.Employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Employee EmployeetoAdd)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Employees.Add(EmployeetoAdd);
            obj.SaveChanges();

            return RedirectToAction("ViewEmployee");
            
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int ID)
        {
            var EmployeeToEdit = (from m in obj.Employees where m.id == ID select m).First();
            return View(EmployeeToEdit);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee EmployeeToEdit)
        {

            var orignalRecord = (from m in obj.Employees where m.id == EmployeeToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(EmployeeToEdit);

            obj.SaveChanges();
            return RedirectToAction("ViewEmployee");
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(Employee EmployeeToDelete)
        {
            var d = obj.Employees.Where(x => x.id ==EmployeeToDelete.id).FirstOrDefault();
            obj.Employees.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("ViewEmployee");
        }

        // POST: Employee/Delete/5
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
