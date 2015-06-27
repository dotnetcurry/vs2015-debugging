using System.Collections.Generic;
using System.Linq;
using MVC_ForDebugging.Models;
namespace MVC_ForDebugging.DataAccess
{
    public class EmployeeDAL
    {
        ApplicationDBEntities ctx;
        public EmployeeDAL()
        {
            ctx = new ApplicationDBEntities(); 
        }

        public List<EmployeeInfo> GetEmployees()
        {
            return ctx.EmployeeInfoes.ToList();
        }

        public EmployeeInfo GetEmployee(int id)
        {
            return ctx.EmployeeInfoes.Find(id);
        }

        public void AddNewEmployee(EmployeeInfo Emp)
        {
            ctx.EmployeeInfoes.Add(Emp);
            ctx.SaveChanges();  
        }
        public void UpdateEmployee(int id, EmployeeInfo Emp)
        {
            var e = ctx.EmployeeInfoes.Find(id);
            if (e != null)
            {
                e.EmpName = Emp.EmpName;
                e.Salary = Emp.Salary;
                e.DeptName = Emp.DeptName;
                e.Designation = Emp.Designation;

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Method to Check of the EmpName is already Exist
        /// </summary>
        /// <param name="ename"></param>
        /// <returns></returns>

        public bool CheckEmpNameExist(string ename)
        {
            bool isExist = false;

            foreach (var item in ctx.EmployeeInfoes.ToList())
            {
                if (item.EmpName.Trim() == ename.ToUpper().Trim())
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }

        /// <summary>
        /// Check whethar the Manage has salary greater than 5000
        /// </summary>
        /// <param name="desig"></param>
        /// <param name="sal"></param>
        /// <returns></returns>
        public bool CheckValidSal(int sal)
        {
            bool isValid = true;
            if (sal < 5000)
            {
                isValid = false;
            }
            return isValid;
        }


        public void DeleteEmployee(int id,EmployeeInfo Emp)
        {
            var e = ctx.EmployeeInfoes.Find(id);
            if (e != null)
            {
                ctx.EmployeeInfoes.Remove(e);
                ctx.SaveChanges();
            }
        }
    }
}
