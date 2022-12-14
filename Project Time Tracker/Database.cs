using Elements.Logger;
using System.Data;
using System.Data.SQLite;

namespace Elements.Database
{
    internal class SQLite
    {
        public static List<SQLiteParameter> spl = new();

        public static bool CreateDatabase(string databaseName)
        {
            try
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + databaseName + ".sqlite"))
                {
                    Logging.LogMessage("SystemLog", "Database not found, creating file", "log", "CheckDb");
                    SQLiteConnection.CreateFile(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + databaseName + ".sqlite");
                }
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ErrorLog", ex.Message, "error", "CreateDatabase");
                return false;
            }
        }

        public static void PopulateDatabaseTables(string databaseName)
        {
            try
            {
                if (CreateDatabase(databaseName))
                {
                    ExecuteNonQuery("create table if not exists Customers (CustomerID integer primary key not null, CustomerName text not null)", spl, databaseName);
                    ExecuteNonQuery("create table if not exists Projects (ProjectID integer primary key not null, ProjectName text not null, Active int not null, ProjectNotes text not null, CustomerID integer not null, constraint fk_customers foreign key (CustomerID) references Customers (CustomerID) on delete cascade)", spl, databaseName);
                    ExecuteNonQuery("create table if not exists Times (TimeID integer primary key not null, Start text not null, End text not null, Duration text not null, TimeNotes text not null, ProjectID integer not null, constraint fk_projects foreign key (ProjectID) references Projects (ProjectID) on delete cascade)", spl, databaseName);
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ErrorLog", ex.Message, "error", "PopulateDatabaseTables");
            }
        }

        public static void PopulateDefaultTableValues(string databaseName)
        {
            try
            {
                if (CreateDatabase(databaseName))
                {
                    ExecuteNonQuery("insert into Customers (CustomerID, CustomerName) select 0, '<Undefined>' where not exists (select 1 from Customers where CustomerID = 0)", spl, databaseName);
                    ExecuteNonQuery("insert into Projects (ProjectID, ProjectName, Active, ProjectNotes, CustomerID) select 0, '<Undefined>', 1, '', 0 where not exists (select 1 from Projects where ProjectID = 0)", spl, databaseName);
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ErrorLog", ex.Message, "error", "PopulateDefaultTableValues");
            }
        }

        public static bool CheckValueExists(string tableName, List<Tuple<string, string>> columnList, string databaseName)
        {
            try
            {
                bool result = false;
                string query = "select exists (select 1 from " + tableName;
                string whereClause = "";
                for (int i = 0; i < columnList.Count; i++)
                {
                    if (i == 0) whereClause += " where ";
                    spl.Add(new SQLiteParameter("@" + columnList[i].Item1, columnList[i].Item2));
                    whereClause += columnList[i].Item1 + " = @" + columnList[i].Item1;
                    if (i + 1 < columnList.Count) whereClause += " and ";
                }
                query += whereClause += " collate nocase)";

                SQLiteDataReader? dr = ExecuteReader(query, spl, databaseName);
                if (dr != null)
                {
                    while (dr.Read()) result = dr.GetBoolean(0);
                }
                else
                {
                    result = false;
                }
                spl.Clear();
                return result;
            }
            catch (Exception ex)
            {
                spl.Clear();
                Logging.LogMessage("ErrorLog", ex.Message, "error", "ExecuteNonQuery");
                return false;
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

        public static bool ExecuteNonQuery(string query, List<SQLiteParameter> paramList, string databaseName)
        {
            try
            {
                SQLiteConnection conn = new("Data Source=" + AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\" + databaseName + ".sqlite; foreign keys=true; Version=3;");
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                using SQLiteCommand cmd = new(query, conn);
                if (spl.Count > 0) { cmd.Parameters.AddRange(paramList.ToArray()); }
                cmd.ExecuteNonQuery();
                spl.Clear();
                return true;
            }
            catch (Exception ex)
            {
                spl.Clear();
                Logging.LogMessage("ErrorLog", ex.Message, "error", "ExecuteNonQuery");
                return false;
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