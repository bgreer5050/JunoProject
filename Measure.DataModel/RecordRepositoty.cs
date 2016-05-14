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


        public void GetAllRecords()
        {
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


            }

            conn.Close();

        }

    }
}
