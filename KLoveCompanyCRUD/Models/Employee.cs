using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLoveCompanyCRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
    }
}
