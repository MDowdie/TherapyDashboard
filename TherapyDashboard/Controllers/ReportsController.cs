using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TherapyDashboard.Models;

namespace TherapyDashboard.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ReportsController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }



        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Export(string OutputFilename = "Data Test")
        {
            byte[] memory = await ExportHandler.CreateExcelFileAsync(_hostingEnvironment); // creates a dummy file if you don't include an inputTable
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", OutputFilename + ".xlsx");
        }

        public async Task<IActionResult> ExportChart(string OutputFilename="Chart Test")
        {
            string[] selected_columns_for_chart = { "Stay #", "Assessment 1", "Assessment 2", "Assessment 3" };
            byte[] memory = await ExportHandler.CreateExcelFileAsync(_hostingEnvironment, ExportHandler.GenerateDummyClientReportDataTable(), selected_columns_for_chart, true);

            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", OutputFilename + ".xlsx");
        }
    }
}