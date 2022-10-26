using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managment.Models
{
    public class EmployeeExtensionData
    {
        public int Id { get; set; }

        [ForeignKey("EmployeId")]
        public EmployeeBasicData? Employee { get; set; }
        public int? EmployeId { get; set; }

        [ForeignKey("ActuallProjectId")]
        public ProjectsData? ActuallProject { get; set; }
        public int? ActuallProjectId { get; set; }


        public int PaymentGross { get; set; }
        public int PaymentNet { get; set; }
        public DateTime HireDate { get; set; }


        public int YearsOfExperience { get; set; } // yeaors of experience in this position
        public int DaysOfVacation { get; set; }
        public int DaysOfVacationLeft { get; set; }

    }
}

