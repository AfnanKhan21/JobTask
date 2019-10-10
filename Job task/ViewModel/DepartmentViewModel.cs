using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Job_task.ViewModel
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public int NoOfUsers { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}