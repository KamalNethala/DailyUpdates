using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Repositories
{
    class ReportGeneratorFactory
    {
        public static IReportGenerator GetReportGenerator(CustomerOrigin customerOrigin)
        {
            IReportGenerator reportGenerator = null;
            if (customerOrigin == CustomerOrigin.USCustomer)
            {
                reportGenerator = new USReportGenerator();
            }

            return reportGenerator;
        }
    }
}
