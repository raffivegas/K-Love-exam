using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLoveCompanyCRUD.View_Models
{
    public class SummaryVM
    {
        public int EId { get; set; }
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

        public int DId { get; set; }
        public string Name { get; set; }

        public SummaryVM()
        {
           
        }
    }

}
