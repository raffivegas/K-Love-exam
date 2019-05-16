using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLoveCompanyCRUD.View_Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

        public class AddEmployeeVM /*: IEnumerable<SummaryVM>*/
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

            public string DId { get; set; }
            public string Name { get; set; }

            public Dictionary<string, string> Departments { get; set; }

            public AddEmployeeVM()
            {
                Departments = new Dictionary<string, string>();
            }

            //public IEnumerator<SummaryVM> GetEnumerator()
            //{
            //    return summaryVMs.GetEnumerator();
            //    //throw new NotImplementedException();
            //}

            //IEnumerator IEnumerable.GetEnumerator()
            //{
            //    return GetEnumerator();
            //    //throw new NotImplementedException();
            //}
        }

    }


