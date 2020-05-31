using AMR_Server.Models;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reports.DataServiceLayer;


namespace AMR_Server.Controllers
{
    [Route("Api/Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        IReportDSL _reportDSL;
        private readonly IConverter _converter;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ReportController(IReportDSL reportDSL, IConverter converter, IHostingEnvironment hostingEnvironment)
        {
            _reportDSL = reportDSL;
            _converter = converter;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("CreatePDF")]
        public IActionResult CreatePDF([FromBody]Template template)
        {
            string filePath = _reportDSL.CreatePDF(template.Html);
            return Ok(filePath);
        }

        //public StiReport
    }
}
