using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TherapyDashboard.Models;
using TherapyDashboard.Models.Database;

namespace TherapyDashboard.Controllers
{
    [Authorize(Policy = "CanGenerateReports")]
    public class ReportsController : Controller
    {
        private readonly TherapyDashboardContext _context;

        private readonly IHostingEnvironment _hostingEnvironment;
        public ReportsController(IHostingEnvironment environment, TherapyDashboardContext context)
        {
            _context = context;
            _hostingEnvironment = environment;
        }



        public IActionResult Index()
        {
            DbSet<CFARSAssessment> cfars = _context.CFARSAssessments;
            DbSet<PPSRAssessment> ppsr = _context.PPSRAssessments;
            DbSet<PCLAssessment> pcl = _context.PCLAssessments;


            ViewData["avgCFARS"] = cfars.Average(c => c.Score);
            ViewData["ctCFARS"] = cfars.Count();
            ViewData["maxCFARS"] = cfars.Max(c => c.Score);
            ViewData["minCFARS"] = cfars.Min(c => c.Score);

            ViewData["avgPPSR"] = ppsr.Average(c => c.Score);
            ViewData["ctPPSR"] = ppsr.Count();
            ViewData["maxPPSR"] = ppsr.Max(c => c.Score);
            ViewData["minPPSR"] = ppsr.Min(c => c.Score);

            ViewData["avgPCL"] = pcl.Average(c => c.Score);
            ViewData["ctPCL"] = pcl.Count();
            ViewData["maxPCL"] = pcl.Max(c => c.Score);
            ViewData["minPCL"] = pcl.Min(c => c.Score);



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