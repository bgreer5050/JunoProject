using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.DataModel
{
    public static class DatabaseTools
    {

        public static void SetUpDatabase()
        {

            if (System.IO.File.Exists("MyDatabase2.sqlite"))
            {

            }
            else
            {
                System.Data.SQLite.SQLiteConnection.CreateFile("MyDatabase2.sqlite");

                System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source = MyDatabase2.sqlite; Version = 3;");

                string strCommandText = "CREATE TABLE records (Anxiety REAL, Fear REAL, Depression REAL, DateTime TEXT)";
                SQLiteCommand cmd = new SQLiteCommand(strCommandText, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
