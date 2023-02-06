using Elements.Logger;
using System.Data;
using System.Data.SQLite;

namespace Elements.Database
{
    internal class SQLite
    {
        public static List<SQLiteParameter> spl = new();

        public static void CreateDatabase(string dbName)
        {
            try
            {
                string dbFilePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + dbName + ".sqlite";

                if (!File.Exists(dbFilePath))
                {
                    Logging.LogMessage("SystemLog", "Database not found, creating file", "log", "CheckDb");
                    SQLiteConnection.CreateFile(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + dbName + ".sqlite");
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ErrorLog", ex.Message, "error", "CreateDatabase");
            }
        }

        public static void PopulateDatabaseTables(string dbName)
        {
            try
            {
                ExecuteNonQuery("create table if not exists Customers (CustomerID integer primary key not null, CustomerName text unique not null)", spl, dbName);
                ExecuteNonQuery("create table if not exists Projects (ProjectID integer primary key not null, ProjectName text unique not null, Active integer not null, ProjectNotes text not null)", spl, dbName);
                ExecuteNonQuery("create table if not exists CustomerProject (CustomerProjectID integer primary key not null, CustomerID integer not null, ProjectID integer not null)", spl, dbName);
                ExecuteNonQuery("create table if not exists Times (TimeID integer primary key not null, Start text not null, End text not null, Duration text not null, DurationDecimal text not null, TimeNotes text not null, CustomerProjectID integer not null, constraint fk_customerproject foreign key (CustomerProjectID) references CustomerProject (CustomerProjectID) on delete cascade)", spl, dbName);
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ErrorLog", ex.Message, "error", "PopulateDatabaseTables");
            }
        }

        public static void PopulateDefaultTableValues(string dbName)
        {
            try
            {
                ExecuteNonQuery("insert into Customers (CustomerID, CustomerName) select 0, '<Unassigned>' where not exists (select 1 from Customers where CustomerID = 0)", spl, dbName);
                ExecuteNonQuery("insert into Projects (ProjectID, ProjectName, ProjectNotes, Active) select 0, '<Unassigned>', '', 1 where not exists (select 1 from Projects where ProjectID = 0)", spl, dbName);
                ExecuteNonQuery("insert into CustomerProject (CustomerProjectID, CustomerID, ProjectID) select 0, 0, 0 where not exists (select 1 from CustomerProject where CustomerProjectID = 0)", spl, dbName);
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ErrorLog", ex.Message, "error", "PopulateDefaultTableValues");
            }
        }

        public static SQLiteDataReader? ExecuteReader(string query, List<SQLiteParameter> paramList, string databaseName)
        {
            try
            {
                SQLiteConnection conn = new("Data Source=" + AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + databaseName + ".sqlite; foreign keys=true; Version=3;");
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                using SQLiteCommand cmd = new(query, conn);
                if (spl.Count > 0) { cmd.Parameters.AddRange(paramList.ToArray()); }
                SQLiteDataReader? dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                spl.Clear();
                return dr;
            }
            catch (Exception ex)
            {
                spl.Clear();
                Logging.LogMessage("ErrorLog", ex.Message, "error", "ExecuteReader");
                return null;
            }
        }

        public static int ExecuteNonQuery(string query, List<SQLiteParameter> paramList, string databaseName)
        {
            int rowId = -1;

            try
            {
                SQLiteConnection conn = new("Data Source=" + AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + databaseName + ".sqlite; foreign keys=true; Version=3;");
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                using SQLiteCommand cmd = new(query, conn);
                SQLiteTransaction transaction;
                transaction = conn.BeginTransaction();
                if (spl.Count > 0) { cmd.Parameters.AddRange(paramList.ToArray()); }
                cmd.ExecuteNonQuery();
                spl.Clear();
                rowId = (int)conn.LastInsertRowId;
                transaction.Commit();
                return rowId;
            }
            catch (Exception ex)
            {
                spl.Clear();
                Logging.LogMessage("ErrorLog", ex.Message, "error", "ExecuteNonQuery");
                return rowId;
            }
        }

        public static DataTable? FillDataTable(string query, List<SQLiteParameter> paramList, string databaseName)
        {
            try
            {
                SQLiteConnection conn = new("Data Source=" + AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + databaseName + ".sqlite; foreign keys=true; Version=3;");
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                using SQLiteCommand cmd = new(query, conn);
                if (spl.Count > 0) { cmd.Parameters.AddRange(paramList.ToArray()); }

                using SQLiteDataAdapter da = new(cmd);
                DataTable? dt = new();
                da.Fill(dt);
                spl.Clear();
                return dt;
            }
            catch (Exception ex)
            {
                spl.Clear();
                Logging.LogMessage("ErrorLog", ex.Message, "error", "FillDataTable");
                return null;
            }
        }
    }
}