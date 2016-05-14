using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.DataModel
{
   public class Record
    {
        public string DateTime { get; set; }
        public decimal Anxiety { get; set; }
        public decimal Fear { get; set; }
        public decimal Depression { get; set; }

        public static List<Record> GetMockSet()
        {
            System.Random rnd = new Random();

            var records = new List<Record>();

            DateTime dt = new System.DateTime(2016, 5, 1, 0, 0, 0);

            for (var x = 0m; x < 24.0m; x += .25m)
            {
                var record = new Record { Anxiety = GetRandomNumber(rnd), Depression = GetRandomNumber(rnd), Fear = GetRandomNumber(rnd), DateTime = dt.TimeOfDay.Hours.ToString() };
                records.Add(record);
                dt = dt.AddMinutes(15.0d);
            }
            return records;
        }

        private static decimal GetRandomNumber(System.Random rnd)
        {
            int result = rnd.Next(0, 50);
            decimal decResult = decimal.Parse((result / 10.0).ToString());
            return decResult;
        }
    }
}
