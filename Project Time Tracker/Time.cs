using Elements.Database;
using System.Data.SQLite;

namespace Project_Time_Tracker
{
    public class Time
    {
        public static List<TimeFilter> GenerateTimeFilterList()
        {
            List<TimeFilter> timeFilterList = new();

            SQLiteDataReader? dr = SQLite.ExecuteReader("select p.ProjectID, c.CustomerName || ' - ' || p.ProjectName as CustomerAndProject from Projects p inner join Customers c on c.CustomerID = p.CustomerID where p.Active = 1 order by c.CustomerName || ' - ' || p.ProjectName collate nocase", SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    timeFilterList.Add(new TimeFilter() { ProjectId = dr.GetInt32(0), CustomerAndProject = dr.GetString(1) });
                }
            }

            return timeFilterList;
        }

        public static List<TimeList> GenerateTimeList(int projectId)
        {
            List<TimeList> timeList = new();

            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLiteDataReader? dr = SQLite.ExecuteReader("select TimeID, Start, End, Start || ' - ' || End as TimeSpan, TimeNotes from Times where ProjectID = @ProjectID order by Start || ' - ' || End collate nocase desc", SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    timeList.Add(new TimeList() { TimeId = dr.GetInt32(0), Start = dr.GetDateTime(1), End = dr.GetDateTime(2), TimeSpan = dr.GetString(3), TimeNotes = dr.GetString(4) });
                }
            }

            return timeList;
        }

        public static void AddTime(string start, string end, float duration, string timeNotes, int projectId)
        {
            SQLite.spl.Add(new SQLiteParameter("@Start", start));
            SQLite.spl.Add(new SQLiteParameter("@End", end));
            SQLite.spl.Add(new SQLiteParameter("@Duration", duration));
            SQLite.spl.Add(new SQLiteParameter("@TimeNotes", timeNotes));
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLite.ExecuteNonQuery("insert into Times (Start, End, Duration, TimeNotes, ProjectID) values (@Start, @End, @Duration, @TimeNotes, @ProjectID)", SQLite.spl, "ProjectTimeTracker");
        }

        public static void UpdateTime(int timeId, string start, string end, float duration, string timeNotes, int projectId)
        {
            SQLite.spl.Add(new SQLiteParameter("@TimeID", timeId));
            SQLite.spl.Add(new SQLiteParameter("@Start", start));
            SQLite.spl.Add(new SQLiteParameter("@End", end));
            SQLite.spl.Add(new SQLiteParameter("@Duration", duration));
            SQLite.spl.Add(new SQLiteParameter("@TimeNotes", timeNotes));
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLite.ExecuteNonQuery("update Times set Start = @Start, End = @End, Duration = @Duration, TimeNotes = @TimeNotes, ProjectID = @ProjectID where TimeID = @TimeID", SQLite.spl, "ProjectTimeTracker");
        }

        public static void DeleteTime(int timeId, bool deleteAll)
        {
            string deleteQuery = "delete from Times";
            if (!deleteAll) deleteQuery += " where TimeID = @TimeID";
            SQLite.spl.Add(new SQLiteParameter("@TimeID", timeId));
            SQLite.ExecuteNonQuery(deleteQuery, SQLite.spl, "ProjectTimeTracker");
        }
    }
}

public class TimeFilter
{
    public int ProjectId { get; set; }
    public string CustomerAndProject { get; set; } = null!;
}

public class TimeList
{
    public int TimeId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string TimeSpan { get; set; } = null!;
    public string TimeNotes { get; set; } = null!;
}