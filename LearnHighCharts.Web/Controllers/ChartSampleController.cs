using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
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
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
               //overall Title of Chart
               .SetTitle(new Title { Text = "Incoming Transactions per hour" })
               //small title below main title
               .SetSubtitle(new Subtitle { Text = "Accounting" })
               //load x values
               .SetXAxis(new XAxis { Categories = xDataMonths })
               //set Y Title
               .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Number of Transactions" } })
               .SetTooltip(new Tooltip
               {
                   Enabled = true,
                   Formatter = @"function(){return '<b>' + this.series.name + '</b><br/>' + this.x +': '+ this.y; }"
               })
               .SetPlotOptions(new PlotOptions
               {
                   Line = new PlotOptionsLine
                   {

                       DataLabels = new PlotOptionsLineDataLabels
                       {
                           Enabled = true
                       },
                       EnableMouseTracking = false
                   }
               })
               .SetSeries(new[]
               {
                   new Series { Name="Hour",Data = new Data(yDataCounts) },
                   //you can add more y data to create a second line
                   // new Series{Name="Other Name",Data= new Data(otherData)}

               }
               );


            return View(chart);
        }


        public ActionResult ChartByAjax()
        {
            return View();
        }


        //public ActionResult GetSampleData1()
        //{

        //    List<Anx> mylist = new List<Anx>();


        //    Anx a = new Anx();
        //    a.name = "7";

        //    var list = new List<double?>();
        //    list.Add(3.2);
        //    list.Add(2.2);
        //    list.Add(1.2);
        //    list.Add(4.2);
        //    list.Add(2.2);
        //    list.Add(1.2);

        //    a.data = list;

        //    return Json(a,JsonRequestBehavior.AllowGet);

        //}



        public ActionResult GetSampleData2()
        {
            return View();
        }



        public ActionResult GetSampleData3()
        {
            List<Record> records = Record.GetMockSet();


            DotNet.Highcharts.Highcharts chart = new Highcharts("chart");
            chart.SetTitle(new Title { Text = "My Chart" });
            XAxis xaxis = new XAxis();
            xaxis.Title = new XAxisTitle { Text = @"Date / Time", Enabled = "true" };
           

            //Create a List to hold our categories and convert it to an array and assign it to categories
            List<string> strCategories = new List<string>();


            Series serAX = new Series(); //Each Series will need a Data object which holds an array of objects with values (data points)
            Series serFr = new Series();
            Series serDep = new Series();


            serAX.Name = "Anxiety";
            serDep.Name = "Depression";
            serFr.Name = "Fear";


            Data axData = new Data(new object[records.Count]);
            Data fearData = new Data(new object[records.Count]);
            Data depData = new Data(new object[records.Count]);

            int counter = 0;
            foreach (var rec in records)
            {
                strCategories.Add(rec.DateTime.ToString());
                axData.ArrayData[counter] = rec.Anxiety;
                fearData.ArrayData[counter] = rec.Fear;
                depData.ArrayData[counter] = rec.Depression;

                counter += 1;
            }

            serAX.Data = axData;
            serDep.Data = depData;
            serFr.Data = fearData;

            //Create a series array
            Series[] allSeries = new Series[3];
            allSeries[0] = serAX;
            allSeries[1] = serDep;
            allSeries[2] = serFr;

            xaxis.Categories = strCategories.ToArray();
            
            chart.SetXAxis(xaxis);


          


            

            chart.SetSeries(allSeries);
            
            //Series[] series = new Series[4];
           


            return View(chart);
        }

        //public class Record
        //{

        //    public string DateTime { get; set; }
        //    public decimal Anxiety { get; set; }
        //    public decimal Fear { get; set; }
        //    public decimal Depression { get; set; }

        //    public static List<Record> GetMockSet()
        //    {
        //        System.Random rnd = new Random();

        //        var records = new List<Record>();

        //        DateTime dt = new System.DateTime(2016, 5, 1, 0, 0, 0);

        //        for(var x = 0m; x < 24.0m; x +=.25m)
        //        {
        //            var record = new Record { Anxiety = GetRandomNumber(rnd), Depression = GetRandomNumber(rnd), Fear = GetRandomNumber(rnd), DateTime = dt.TimeOfDay.ToString()};
        //            records.Add(record);
        //            dt = dt.AddMinutes(15.0d);
        //        }
        //        return records;
        //    }

        //    private static decimal GetRandomNumber(System.Random rnd)
        //    {
        //        int result = rnd.Next(0, 50);
        //        decimal decResult = decimal.Parse((result / 10.0).ToString());
        //        return decResult;
        //    }

        //}
    }
}