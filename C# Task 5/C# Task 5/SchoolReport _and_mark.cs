using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task_5
{
     sealed class SchoolReport
    {
        public string ReportTitle {  get; set; }
        public SchoolReport(string reportTitle)
        {
            ReportTitle = reportTitle;
        }
        public void DisplayReportTitle()
        {
            Console.WriteLine("Report Title" + ReportTitle);
        }
    }
}

/////another class cannot inherit from SchoolReport becous is sealed classs