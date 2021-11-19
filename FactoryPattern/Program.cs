using FactoryPattern.Repositories;
using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IReportGenerator reportGenerator = ReportGeneratorFactory.GetReportGenerator(CustomerOrigin.USCustomer);
            reportGenerator.Generate();
        }
    }
}
