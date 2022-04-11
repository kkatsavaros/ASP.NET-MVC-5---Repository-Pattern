using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _012.RepositoryPattern.Models;

namespace _012.RepositoryPattern.Repository
{
    internal interface Iemployee
    {
        //1.
        void InsertEmpRecord(Employee emp);

        //2. ΅When the page loads i wnt the list of all the employed details for that
        //   i am using ienumerable.
        IEnumerable<Employee> getEmployee(); // GetAllEmpRecords();

        //3.
        void UpdateEmpRecord(Employee emp);

        //4. 
        void DeleteEmpRecord(int emp);

        //5. Για τις λεπτομέρειες
        Employee GetEmpById(int empId);

    }
}
