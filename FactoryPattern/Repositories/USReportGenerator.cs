using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Repositories
{
    public class USReportGenerator : IReportGenerator
    {
        public void Generate()
        {
            DataTable dataTable = new DataTable();

            DataColumn FNColumn = new DataColumn();
            FNColumn.Caption = "Full Name";
            dataTable.Columns.Add(FNColumn);

            DataColumn RevenueColumn = new DataColumn();
            RevenueColumn.Caption = "Revenue";
            dataTable.Columns.Add(RevenueColumn);

            DataColumn NetProfitColumn = new DataColumn();
            NetProfitColumn.Caption = "Net Profit";
            dataTable.Columns.Add(NetProfitColumn);
        }
    }
}