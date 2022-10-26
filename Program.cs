using System;
using Managment.Views;
using Managment.ExtensionMethods;

namespace Managment
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Michal! Choose what do you want to do");
            Console.WriteLine("1.Informations.");
            Console.WriteLine("2.Managment.");
            string choose = Console.ReadLine();

            switch (Int32.Parse(choose))
            {
                case 1:
                    await InformationPanel.TypeOfInformations();
                    break;
                case 2:
                    await ManagmentPanel.TypeOfManagment();
                    break;
            }
        }
    }
}
