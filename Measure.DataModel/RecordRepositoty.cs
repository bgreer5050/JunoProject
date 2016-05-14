using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.DataModel
{
    public class RecordRepositoty
    {


        public List<Record> GetAllRecords()
        {
            List<Record> _records = new List<Record>();

            DatabaseTools dbTools = new DatabaseTools();
            SQLiteConnection conn = dbTools.SQLiteConnection;
            string strCommandText = "SELECT * FROM records;";
            SQLiteCommand cmd = new SQLiteCommand(strCommandText, conn);
            conn.Open();
            //cmd.ExecuteNonQuery();
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0)); // GetString(0));
                Console.WriteLine(reader.GetFloat(1));
                Console.WriteLine(reader.GetFloat(2));
                Console.WriteLine(reader.GetFloat(3));
                Console.WriteLine(reader.GetString(4));

                DateTime dt = DateTime.Parse(reader.GetString(4));

                Record _rec = new Record { Anxiety = reader.GetInt32(1), Fear = reader.GetInt32(2), Depression = reader.GetInt32(3), DateTime = reader.GetString(4) };
                _records.Add(_rec);
            }

            conn.Close();

            return _records;
        }



       

    }
}
