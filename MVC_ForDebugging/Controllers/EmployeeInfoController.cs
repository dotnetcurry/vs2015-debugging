using System.Web.Mvc;

using MVC_ForDebugging.Models;
using MVC_ForDebugging.DataAccess;
using System.Diagnostics;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Linq;

using System.Web.Script.Serialization;

namespace MVC_ForDebugging.Controllers
{
    public class EmployeeInfoController : Controller
    {

        EmployeeDAL obj;
        public EmployeeInfoController()
        {
            obj = new EmployeeDAL(); 
        }


        // GET: EmployeeInfo
        public ActionResult Index()
        {
            var Emps = obj.GetEmployees();
            int i = 0;
            var jObj = new JavaScriptSerializer();
            var jsonData =   jObj.Serialize(Emps);
            return View(Emps);
        }

         

        // GET: EmployeeInfo/Details/5
        public ActionResult Details(int id)
        {
            var Emp = obj.GetEmployee(id);
            return View(Emp);
        }

        // GET: EmployeeInfo/Create
        public ActionResult Create()
        {
            var Emp = new EmployeeInfo();
            return View(Emp);
        }

        // POST: EmployeeInfo/Create
        [HttpPost]
        public ActionResult Create(EmployeeInfo Emp)
        {
            try
            {
                if (obj.CheckEmpNameExist(Emp.EmpName) == true && obj.CheckValidSal(Emp.Salary))
                {
                    obj.AddNewEmployee(Emp);
                    return RedirectToAction("Index");
                }
                else {
                    return View(Emp);

                }
            }
            catch
            {
                return View(Emp);
            }
        }

        // GET: EmployeeInfo/Edit/5
        public ActionResult Edit(int id)
        {
            var Emp = obj.GetEmployee(id);
            return View(Emp);
        }

        // POST: EmployeeInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeInfo Emp)
        {
            try
            {
                obj.UpdateEmployee(id, Emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeInfo/Delete/5
        public ActionResult Delete(int id)
        {
            var Emp = obj.GetEmployee(id);
            return View(Emp);
        }

        // POST: EmployeeInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeInfo Emp)
        {
            try
            {
                obj.DeleteEmployee(id, Emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(Emp);
            }
        }
    }
}
