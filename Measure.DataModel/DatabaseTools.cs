using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.DataModel
{
    public class DatabaseTools
    {

      //  public SQLiteConnection conn { get; set; }

        private SQLiteConnection _sqlConn;

        public SQLiteConnection SQLiteConnection
        {
            get {
                if(_sqlConn == null)
                {
                    _sqlConn = new SQLiteConnection("Data Source = MyDatabase2.sqlite; version = 3;");
                }
                return _sqlConn;
            }
            set { _sqlConn = value; }
        }


        public void SetUpDatabase()
        {


            //Make sure the database exists
            if (System.IO.File.Exists("MyDatabase2.sqlite"))
            {

            }
            else
            {
                SQLiteConnection.CreateFile("MyDatabase2.sqlite");


                string strCommandText = "CREATE TABLE records (Id INTEGER PRIMARY KEY AUTOINCREMENT  NOT NULL  UNIQUE, Anxiety REAL, Fear REAL, Depression REAL, DateTime TEXT)";

                
                SQLiteCommand cmd = new SQLiteCommand(strCommandText, this.SQLiteConnection);
                this.SQLiteConnection.Open();
                cmd.ExecuteNonQuery();
                this.SQLiteConnection.Close();

            }
        }

       
    }
}





//CREATE TABLE "main"."records2" ("Id" INTEGER PRIMARY KEY AUTOINCREMENT  NOT NULL  UNIQUE , "Anxiety" FLOAT NOT NULL , "Fear" FLOAT NOT NULL , "Depression" FLOAT NOT NULL , "DateTime" TEXT NOT NULL )