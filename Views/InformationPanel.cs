using System;
using Managment.Methods;
using Microsoft.EntityFrameworkCore;

namespace Managment.Views;
public class InformationPanel : Informations
{
    
    public static async Task TypeOfInformations()
    {
        PrintingOptions();
        var query = await DownloadingFromDatabase();

        Console.Write("Input: ");
        var option = Console.ReadLine();

        switch (Int32.Parse(option))
        {
            case 1:
                PrintingDatas(query.OrderBy(hi => hi.HireDate).Select(n => n.Employee.FirstName), query.OrderBy(hi => hi.HireDate).Select(pay => pay.PaymentNet), "paymant gross");
                break;
            case 2:
                PrintingDatas(query.Select(n => n.Employee.FirstName), query.Select(da => da.HireDate), "work sice");
                break;
            case 3:
                PrintingDatas(query.Select(n => n.Employee.FirstName), query.Select(left => left.DaysOfVacationLeft), "has days of vacation left");
                break;
            case 4:
                PrintingDatas(query.Select(n => n.Employee.FirstName), query.Select(proj => proj.ActuallProjectId), "is working on project number"); break;
                break;
        }
    }

    public static async Task<IQueryable<Models.EmployeeExtensionData>> DownloadingFromDatabase()
    {
        IQueryable<Models.EmployeeExtensionData> query;
        var db = new ManagmentContext(); // cannot use using statemant, cuz i have DI error - Cannot access a disposed context instance
        query = await Task.Run(() => db.EmployeeExtensionDataSet.Include(em => em.Employee)
                                                                .Include(ac => ac.ActuallProject));
        return query;
    }

    public static async Task PrintingOptions()
    {
        await Task.Run(() =>
        {
            Console.WriteLine("What informations are you interested in?");
            Console.WriteLine("1. Payments");
            Console.WriteLine("2. Working time in company");
            Console.WriteLine("3. Remaining vacation days");
            Console.WriteLine("4. What is the current project he/she is working on");
        });
    }
}
