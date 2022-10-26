using System;
using Managment.Methods;

namespace Managment.Views
{
    public class ManagmentPanel : Managments
    {
        public static async Task TypeOfManagment()
        {
            Console.WriteLine("What action do you choose?");
            Console.WriteLine("1. Change payment");
            Console.WriteLine("2. Change vacation days");
            Console.WriteLine("3. Add new employee");
            Console.WriteLine("4. Change current project for employee");
            Console.WriteLine("5. Change project status");
            Console.WriteLine("6. Delete employee");
            Console.WriteLine("7. Add new project");
            Console.WriteLine("8. Delete project"); 
            string option = Console.ReadLine();

            UserId userId = LoadUserId;

            switch (Int32.Parse(option))
            {
                case 1:
                    ChangePayment(userId);
                    break;
                case 2:
                    ChangeVacationDays(userId);
                    break;
                case 3:
                    await AddNewEmployee();
                    break;
                case 4:
                    ChangeCurrentProject(userId);
                    break;
                case 5:
                    ChangeProjectStatus();
                    break;
                case 6:
                    DeleteEmployee(userId);
                    break;
                case 7:
                    await AddNewProject();
                    break;
                case 8:
                    DeleteProject();
                    break;
            }
        }
    }
}

