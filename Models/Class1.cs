using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ValidationResult
    {

        
        public string input { get; set; }

        public Boolean isBalanced { get; set; }
    }

    public class ValidationError
    {
        public string name { get; set; }

        public string msg { get; set; }
    }
}