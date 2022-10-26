using System;
using Managment.Models;
using Managment.ExtensionMethods;


namespace Managment.Methods
{
    public class Managments
    {
        public delegate int UserId();

        public static void ChangePayment(UserId userId)
        {
            var context = new ManagmentContext();
            var identity = userId();
            var entity = context.EmployeeExtensionDataSet.FirstOrDefault(iden => iden.Id == identity);

            Console.Write("Enter new payment: ");
            string gross = Console.ReadLine();
            int grossIntiger = Int32.Parse(gross);
            double brutto = grossIntiger.NetPaymantCalculation();

            entity.PaymentGross = Int32.Parse(gross);
            entity.PaymentNet = (int)brutto;
            context.SaveChanges();
        }

        public static void ChangeVacationDays(UserId userId)
        {
            var context = new ManagmentContext();
            var identity = userId();
            var entity = context.EmployeeExtensionDataSet.FirstOrDefault(iden => iden.Id == identity);

            Console.Write("Enter new left vacation cays: ");
            string days = Console.ReadLine();
            entity.DaysOfVacationLeft = Int32.Parse(days);
            context.SaveChanges();
        }

        public static void ChangeCurrentProject(UserId userId)
        {
            var context = new ManagmentContext();
            var identity = userId();
            var entity = context.EmployeeExtensionDataSet.FirstOrDefault(iden => iden.Id == identity);

            Console.Write("Enter id of new project: ");
            string id = Console.ReadLine();
            entity.ActuallProjectId = Int32.Parse(id);
            context.SaveChanges();
        }

        public static void ChangeProjectStatus()
        {
            var context = new ManagmentContext();
            Console.Write("Enter Id of project: ");
            string id = Console.ReadLine();
            var entity = context.ProjectsDataSet.FirstOrDefault(iden => iden.Id == Int32.Parse(id));

            Console.Write("Enter status of Project [T/F]");
            string status = Console.ReadLine();
            if (string.Equals(status, "T"))
            {
                entity.Complited = true;

            }
            else
            {
                entity.Complited = false;

            }
            context.SaveChanges();
        }


        public static void DeleteEmployee(UserId userId)
        {
            var context = new ManagmentContext();
            var identity = userId();
            var entity = context.EmployeeBasicDataSet.FirstOrDefault(iden => iden.Id == identity);
            var entity2 = context.EmployeeExtensionDataSet.FirstOrDefault(iden => iden.EmployeId == identity);


            context.EmployeeBasicDataSet.Remove(entity);
            context.EmployeeExtensionDataSet.Remove(entity2);

            context.SaveChanges();

        }

        public static void DeleteProject()
        {
            var context = new ManagmentContext();
            Console.Write("Enter Id of project: ");
            string id = Console.ReadLine();
            var entity = context.ProjectsDataSet.FirstOrDefault(iden => iden.Id == Int32.Parse(id));


            context.ProjectsDataSet.Remove(entity);
            context.SaveChanges();

        }

        public static int LoadUserId()
        {
            Console.WriteLine("Enter employee identification number:");
            string id = Console.ReadLine();
            return Int32.Parse(id);
        }

        public static async Task AddNewEmployee()
        {
            var db = new ManagmentContext();

            // Ading basic datas
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();

            Console.Write("Enter employee last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter employee role in team: ");
            string role = Console.ReadLine();

            EmployeeBasicData employeeBasicData = new()
            {
                FirstName = name, LastName = lastName, TheRoleOff = role
            };

            //Adding extension datas
            Console.Write("Enter gross payment: ");
            string gross = Console.ReadLine();
            int grossIntiger = Int32.Parse(gross);
            double brutto = grossIntiger.NetPaymantCalculation();

            Console.Write("Years of experience: ");
            string experience = Console.ReadLine();

            Console.Write("Days of vacation: ");
            string vacation = Console.ReadLine();

            Console.Write("Days of vacation left: ");
            string vacationleft = Console.ReadLine();

            Console.Write("Id of project on which she/he will work: ");
            string projectId = Console.ReadLine();
            if (string.IsNullOrEmpty(projectId))
            {
                projectId = "None";
            }

            EmployeeExtensionData employeeExtensionData = new()
            {
                Employee = employeeBasicData,
                PaymentGross = Int32.Parse(gross),
                PaymentNet = (int)brutto,
                HireDate = DateTime.Now,
                ActuallProject = db.ProjectsDataSet.Where(iden => iden.Id == Int32.Parse(projectId)).FirstOrDefault(),
                YearsOfExperience = Int32.Parse(experience),
                DaysOfVacation = Int32.Parse(vacation),
                DaysOfVacationLeft = Int32.Parse(vacationleft),

            };

            await db.AddRangeAsync(employeeBasicData, employeeExtensionData);
            await db.SaveChangesAsync();
        }

        public static async Task AddNewProject()
        {
            var db = new ManagmentContext();
            Console.Write("Enter project name: ");
            string name = Console.ReadLine();

            Console.Write("Enter client number: ");
            string number = Console.ReadLine();

            Console.Write("Enter potential costs: ");
            string cost = Console.ReadLine();

            Console.Write("Enter potential profit: ");
            string profit = Console.ReadLine();

            Console.Write("Enter project manager Id: ");
            string manager = Console.ReadLine();

            Console.Write("Enter deadline date: [f.e. 2023/02/13 13:00:53]");
            string date = Console.ReadLine();
            DateTime dateTime = DateTime.Parse(date);

            ProjectsData projectsData = new()
            {
                Name = name,
                ClientNumber = number,
                Costs = Int32.Parse(cost),
                PotentialProfit = Int32.Parse(profit),
                ManagerOfProject = db.EmployeeBasicDataSet.Where(iden => iden.Id == Int32.Parse(manager)).FirstOrDefault(),
                Deadline = dateTime
                
            };

            await db.AddAsync(projectsData);
            await db.SaveChangesAsync();
        }

    }
}

