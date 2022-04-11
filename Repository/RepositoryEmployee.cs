using _012.RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _012.RepositoryPattern.Models;

namespace _012.RepositoryPattern.Repository
{
    public class RepositoryEmployee : Iemployee
    {
        // Database Connection Entity.
        private RepositoryPatternEntities repositoryPatternEntities; // name στο Web.config


        public RepositoryEmployee(RepositoryPatternEntities repositoryPatternEntities)
        {
            this.repositoryPatternEntities = repositoryPatternEntities;
        }

        public void DeleteEmpRecord(int emp)
        {
            Employee delemp= repositoryPatternEntities.Employees.Find(emp);
            repositoryPatternEntities.Employees.Remove(delemp);
            repositoryPatternEntities.SaveChanges();
        }

        // Details
        public Employee GetEmpById(int empId)
        {
            return repositoryPatternEntities.Employees.Find(empId);
        }

        public IEnumerable<Employee> getEmployee()
        {
            return repositoryPatternEntities.Employees.ToList();
        }

        public void InsertEmpRecord(Employee emp)
        {
            repositoryPatternEntities.Employees.Add(emp);
            repositoryPatternEntities.SaveChanges();
        }

        public void UpdateEmpRecord(Employee emp)
        {
            repositoryPatternEntities.Entry(emp).State=System.Data.Entity.EntityState.Modified;
            repositoryPatternEntities.SaveChanges();    
        }
    }
}