using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gettingData.Models
{

    public class employeeEntityModel
    {
        public List<employeeEntity> Employees { get; set; }
        public string SearchTerm { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
    }

    public class employeeEntity
    {
       
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNumber { get; set; }
    }
}