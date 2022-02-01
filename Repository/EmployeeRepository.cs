using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoExperionWebAPI_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoExperionWebAPI_1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //data fields
        private readonly DemoExperionDBContext _context;

        //default constructor
        //constructor based dependency injection
        public EmployeeRepository(DemoExperionDBContext context)
        {
            _context = context;
        }

        //Implement the interface
        #region Get All Employees
        public async Task<List<Employee>> GetAllEmployees()
        {   
            if(_context != null)
            {
              return await _context.Employee.ToListAsync();
            }
            return null;
        }

        #endregion

        #region Add Employee
        public async Task<int> AddEmployee(Employee employee)
        {
            if(_context != null)
            {
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync(); //commit the transaction
                return employee.EmployeeId;
            }
            return 0;
        }
        #endregion

        #region update an Employee
        public async Task UpdateEmployee(Employee employee)
        {
            if (_context != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync(); //commit the transaction

            }
        }

        #region get employee by id
        public async Task<ActionResult<Employee>> GetEmployeeById(int? id)
        {
            if(_context != null)
            {
                var employee = await _context.Employee.FindAsync(id);  //primarykey
                return employee;
            }
            return null;
        }
        #endregion

        #region delete an employee
        public async Task<int> DeleteEmployee(int? id)
        {
            int result =0;
            if (_context != null)
            {                                           //linq and lambda expression
                var employee = await _context.Employee.FirstOrDefaultAsync(emp =>emp.EmployeeId ==id);
                //check condition
                if(employee != null)
                {
                    //delete
                    _context.Employee.Remove(employee);

                    //commit
                   result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion

     #endregion
    }
}
