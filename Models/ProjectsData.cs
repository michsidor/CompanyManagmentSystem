using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managment.Models
{
    public class ProjectsData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Deadline { get; set; }
        public string? ClientNumber { get; set; }
        public int Costs { get; set; }
        public int PotentialProfit { get; set; }

        [DefaultValue(false)]
        public bool Complited { get; set; }

        [DefaultValue(null)]
        [ForeignKey("ManagerOfProjectId")]
        public EmployeeBasicData? ManagerOfProject { get; set; }
        public int? ManagerOfProjectId { get; set; }
    }
}

