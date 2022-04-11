using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  
using System.Web.Mvc;
       
using _012.RepositoryPattern.Models;     // folder
using _012.RepositoryPattern.Repository; // folder

namespace _012.RepositoryPattern.Controllers
{
    public class EmpController : Controller
    {

        private Iemployee iemp; // Προσθέτω το Interface Iemployee.



        // Δημιουργία constructor για αυτόν τον EmpController.

        public EmpController()
        {
            this.iemp = new RepositoryEmployee(new RepositoryPatternEntities());  // 12.34
        }



        // ----------------------------------------------------------------------------------------
        // Fetching
        // ----------------------------------------------------------------------------------------
        // GET: Emp - fecthing
        public ActionResult Index()
        {
            var emplist = iemp.getEmployee().ToList(); // <------------------- [14.10]
            return View(emplist);
        }
        // ----------------------------------------------------------------------------------------



        // ----------------------------------------------------------------------------------------
        // Details
        // ----------------------------------------------------------------------------------------
        // GET: Emp/Details/5 - Details
        public ActionResult Details(int id)
        {
            var getemp = iemp.GetEmpById(id); // getemp είναι Employee object.
            
            var empdisplay = new Employee();

            empdisplay.Id=getemp.Id;
            empdisplay.Names = getemp.Names;
            empdisplay.Email = getemp.Email;
            empdisplay.Salary = getemp.Salary;
                        
            return View(empdisplay);
        }
        // ----------------------------------------------------------------------------------------




        // ----------------------------------------------------------------------------------------
        // Insert
        // ----------------------------------------------------------------------------------------
        // GET: Emp/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Employee());
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Employee empinsert)
        {
            try
            {
                // TODO: Add insert logic here
                var addemp=new Employee();
                addemp.Names=empinsert.Names;
                addemp.Email=empinsert.Email;
                addemp.Salary=empinsert.Salary ;
                iemp.InsertEmpRecord(addemp);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // ----------------------------------------------------------------------------------------



        // ----------------------------------------------------------------------------------------
        // Edit
        // ----------------------------------------------------------------------------------------
        // GET: Emp/Create  - Θα δείξουμε την επιλογή.
        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {

            var getemp = iemp.GetEmpById(id); // getemp είναι Employee object.

            var empdisplay = new Employee();

            empdisplay.Id = getemp.Id;
            empdisplay.Names = getemp.Names;
            empdisplay.Email = getemp.Email;
            empdisplay.Salary = getemp.Salary;


            return View(empdisplay);
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee empupdate, FormCollection collection)
        {
            try
            {
                iemp.UpdateEmpRecord(empupdate);  

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // ----------------------------------------------------------------------------------------



        // ----------------------------------------------------------------------------------------
        // Delete
        // ----------------------------------------------------------------------------------------
        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            var empdel=iemp.GetEmpById(id);
            return View(empdel);
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                iemp.DeleteEmpRecord(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // ----------------------------------------------------------------------------------------

    }
}
