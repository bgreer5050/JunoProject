using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnHighCharts.Web.Controllers
{
    public class ChartSampleController : Controller
    {
        // GET: ChartSample
        public ActionResult Index()
        {
            //The chart class only accepts arrays

            //Create a collection of data for our chart

            List<DataModel.TransactionCount> transactions = new List<DataModel.TransactionCount> {
                new DataModel.TransactionCount() { MonthName="Jan", Count=30 },
                new DataModel.TransactionCount() {MonthName = "Feb",Count=40 },
                new DataModel.TransactionCount() { MonthName = "Mar",Count=4},
                new DataModel.TransactionCount() { MonthName = "Apr",Count = 35 },
                new DataModel.TransactionCount() { MonthName = "May",Count= 22}

            };

            var xDataMonths = transactions.Select(i => i.MonthName).ToArray();
            var yDataCounts = transactions.Select(i => new object[] { i.Count }).ToArray();

            //Instantiate a HighChart object
            var chart = new Highcharts("chart")
                //define chart type
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line})
               //overall Title of Chart
               .SetTitle(new Title {  Text="Incoming Transactions per hour"})
               //small title below main title
               .SetSubtitle(new Subtitle {  Text="Accounting"})
               //load x values
               .SetXAxis(new XAxis { Categories = xDataMonths })
               //set Y Title
               .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Number of Transactions" } })
               .SetTooltip(new Tooltip {  Enabled=true,
               Formatter = @"function(){return '<b>' + this.series.name + '</b><br/>' + this.x +': '+ this.y; }"
               })



            return View();
        }
    }
}