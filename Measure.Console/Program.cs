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
        }
    }
}
