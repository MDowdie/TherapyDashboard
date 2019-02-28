using TherapyDashboard.Models.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static TherapyDashboard.Models.DataTableExtensions;

namespace TherapyDashboard.Models
{
    public class ExportHandler
    {
        #region Dummy Table generation methods
        public static DataTable GenerateDummyClientsDataTable()
        {
            /// Returns a DataTable filled with dummy data on Clients.
            // random seeds and functions:
            Random r = new Random();
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
            string randomString(Random rando, int length, string charbase)
            {
                var output = new char[length];
                for (int i = 0; i < output.Length; i++)
                {
                    output[i] = charbase[rando.Next(charbase.Length)];
                }
                return new String(output);
            }
            DateTime randomDateTime(Random rando)
            {
                DateTime start = new DateTime(1950, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(rando.Next(range));
            }
            // create list of Clients with random field values
            List<Client> input = new List<Client>();
            for (int i = 0; i < r.Next(3, 12); i++)
            {
                Client client = new Client();
                client.Id = "S" + r.Next(10000, 99999);
                client.DateOfBirth = randomDateTime(r);
                client.Ethnicity = Demographics.Ethnicity[r.Next(0,Demographics.Ethnicity.Length)];
                client.Gender = Demographics.Gender[r.Next(0, Demographics.Gender.Length)];
                client.PartnerGender = Demographics.Gender[r.Next(0, Demographics.Gender.Length)];
                client.Race = Demographics.Race[r.Next(0, Demographics.Race.Length)];
                client.RelationshipStatus = Demographics.RelationshipStatus[r.Next(0, Demographics.RelationshipStatus.Length)];
                input.Add(client);
            }
            // convert list to DataTable, and return
            return input.ToDataTable();
        }
        public static DataTable GenerateDummyClientReportDataTable()
        {
            // random seeds and functions:
            Random r = new Random();
            // table and its column setup
            DataTable output_table = new DataTable("Assessments");
            output_table.Columns.Add(new DataColumn("Stay #"));
            output_table.Columns.Add(new DataColumn("Assessment 1", typeof(int)));
            output_table.Columns.Add(new DataColumn("Assessment 2", typeof(int)));
            output_table.Columns.Add(new DataColumn("Assessment 3", typeof(int)));
            // fill rows with random data
            DataRow row;
            for (int i = 0; i <= r.Next(2, 5); i++)
            {
                row = output_table.NewRow();
                foreach (DataColumn col in output_table.Columns)
                {
                    if (col.ColumnName == "Stay #")
                    {
                        row[col] = "Stay " + (1 + i);
                    }
                    else
                    {
                        row[col] = r.Next(4, 35);
                    }
                }
                output_table.Rows.Add(row);
            }
            return output_table;
        }
        #endregion
        public static async Task<byte[]> CreateExcelFileAsync(IHostingEnvironment hostingenviron, DataTable inputTable = null, string[] ChartAxes = null, bool LineChart = false)
        {
            /// creates an Excel file, returning it to the user without changing the page
            /// if inputTable is left as null, it will create a dummy DataTable to use instead
            /// 
            /// Notes about the ChartAxes parameter:
            /// - No chart sheet if ChartAxes parameter is left as null.
            /// - The first listed string in its array is the Y axis set. Each subsequent string in the array is one of the sets that make up the X axis.
            /// 
            /// This code requires the following code (or something super-like it) in the relevant Controller:
            ///
            #region Copy/pastable code for Contollers
            /*
            private readonly IHostingEnvironment _hostingEnvironment;
            public HomeController(IHostingEnvironment environment)
            {
            _hostingEnvironment = environment;
            }
            public async Task<IActionResult> Export(DataTable inputTable, string OutputFilename = "Export")
            {// creates an Excel file, returning it to the user without changing the page
            byte[] memory = await ExportHandler.CreateExcelFileAsync(_hostingEnvironment, inputTable); // creates a dummy file if you don't include an inputTable (consider symptest.Models.Database.DataTableExtensions for an objectlist.ToDataTable<objecttype>() method)
            //send file in memory to user
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", OutputFilename+".xlsx");
            }
            */
            #endregion
            #region Process parameters received
            // if no input table, generates dummy data on Clients to use instead
            if (inputTable != null) { }
            else
            {
                inputTable = GenerateDummyClientsDataTable();
            }
            #endregion
            ///// begin actual method
            string OutputFilename = "ToExport.xlsx"; // this will not be the filename the person downloading will see, that's handled by the Controller method and doesn't involve this function
            string sWebRootFolder = hostingenviron.WebRootPath; // the "wwwroot" folder location on server
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, OutputFilename)); // create Excel file, place in wwwroot folder
            var memory = new MemoryStream(); // necessary in order to be able to delete file before giving file to user
            const int INDEXBASE = 1; //Excel file indices start on 1, not 0, in EPPlus 4.5.2. This is different in EPPlus 4.5.3, but 4.5.3 doesn't seem compatible with .NET Core 2.1, only 2.2
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, OutputFilename), FileMode.Create, FileAccess.Write))
            {
                using (var package = new ExcelPackage())
                {
                    #region generate data sheet
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add(inputTable.TableName); // uses name of DataTable as name of worksheet
                                                                                               // starting position for per-cell runthrough (copy/paste datatable to worksheet)
                    int row, col;
                    row = col = INDEXBASE;
                    int column_count = 0;
                    //\\
                    // table header values added to worksheet
                    foreach (DataColumn currentColumn in inputTable.Columns)
                    {
                        ws.Cells[row, col].Value = currentColumn.ColumnName;
                        col++;
                    }
                    column_count = col - 1; // now we know the number of columns, for chart section later
                                            // move current position in excel file to row after header row
                    row = INDEXBASE + 1;
                    col = INDEXBASE;
                    // contents of each passed in instance
                    foreach (DataRow record in inputTable.Rows)
                    {
                        foreach (var field in record.ItemArray)
                        {
                            ws.Cells[row, col].Value = field;
                            col++;
                        }
                        col = INDEXBASE;
                        row++;
                    }
                    //Autofit all
                    ws.Cells.AutoFitColumns(0);
                    #endregion
                    #region generate chart sheet
                    if (ChartAxes != null) // so long as the string[] parameter for what axes the chart should have isn't still null
                    {
                        if (ChartAxes.Count() >= 2) // need at least 2 axes to make a chart
                        {
                            ExcelWorksheet ws_chart = package.Workbook.Worksheets.Add("Chart"); // we need us a separate worksheet for the chart
                            OfficeOpenXml.Drawing.Chart.eChartType charttype_arg;
                            if (LineChart)
                            {
                                charttype_arg = OfficeOpenXml.Drawing.Chart.eChartType.Line;
                            }
                            else
                            {
                                charttype_arg = OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered;
                            }
                            var diagram = ws_chart.Drawings.AddChart("chart", charttype_arg); // create chart in given worksheet.
                            char[] Letter = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // resource for address mapping. KNOWN BUG: if you go over 26 columns, incorrect data set range definitions (A1, Z2, etc.) will occur. Starts wil space because index base here is 1. Therefore, Letter[1] is 'A'
                            DataTable chartdata;
                            chartdata = inputTable.FilterByColumns(ChartAxes); // get rid of columns not on the graph, and order columns right
                            ws_chart.Cells["A1"].LoadFromDataTable(chartdata, true); // drop into the worksheet the data, as-is
                            for (int i = INDEXBASE + 1; i <= chartdata.Rows.Count + 1; i++) // for each row in the worksheet data that is not part of the header row
                            {
                                #region define what in row i is part of a series of data
                                string row_dataseries = Letter[2].ToString() + i; // intended output like: "B2:D2", "B3:D3", "B4:D4", etc.
                                if (chartdata.Columns.Count > 2)
                                {
                                    row_dataseries += ":" + Letter[chartdata.Columns.Count].ToString() + i;
                                }
                                #endregion
                                #region define the titles of what data is in the specified series
                                string row_dataseries_titles = Letter[2].ToString() + "1"; // intended output like: "B1:D1"
                                if (ChartAxes.Count() > 2)
                                {
                                    row_dataseries_titles += ":" + Letter[ChartAxes.Count()].ToString() + "1";
                                }
                                #endregion
                                var series = diagram.Series.Add(row_dataseries, row_dataseries_titles); // add data series, as defined/found and titled above
                                series.Header = ws_chart.Cells[$"A{i}"].Value.ToString();
                            }
                            diagram.Border.Fill.Color = System.Drawing.Color.Purple; // graph border
                            ws_chart.Cells.AutoFitColumns(0);
                        }
                    }
                    #endregion
                    // title file
                    package.Workbook.Properties.Title = "Generated by the Hubbard House Hope & Healing Dashboard System";
                    // finalize file
                    package.SaveAs(fs);
                }
            }
            // move file from saved-on-server to server-memory
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, OutputFilename), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            // delete file on server after it's been moved to memory
            System.IO.File.Delete(Path.Combine(sWebRootFolder, OutputFilename));
            // ship out
            return memory.ToArray();
        } // end CreateExcelFileAsync method
    }
}
