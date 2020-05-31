using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.DataServiceLayer
{
    public interface IReportDSL
    {
        string CreatePDF(string html);
    }
}
