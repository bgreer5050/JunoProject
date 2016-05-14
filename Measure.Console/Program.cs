using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DataModel.RecordRepositoty repo = new DataModel.RecordRepositoty();
            repo.GetAllRecords();

            foreach(var rec in repo.GetAllRecords())
            {
                //System.Console.Write("Time: {3} Anxiety: {0} Fear: {1} Depression: {2}", rec.Anxiety, rec.Fear, rec.Depression, rec.DateTime);
                System.Console.WriteLine(rec.Anxiety);
                System.Console.WriteLine(rec.Fear);
                System.Console.WriteLine(rec.Depression);
                System.Console.WriteLine(rec.DateTime);
            }

            System.Console.ReadLine();
        }
    }
}
