using System;
using System.ComponentModel.DataAnnotations;

namespace Managment.Models
{
    public class EmployeeBasicData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TheRoleOff { get; set; }
    }
}

