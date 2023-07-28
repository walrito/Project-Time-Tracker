using Elements.Database;
using System.Data.SQLite;

namespace Project_Time_Tracker
{
    public class Time
    {
        public static List<TimeList> GenerateTimeList(int customerProjectId)
        {
            List<TimeList> timeList = new();
            string query = "select TimeID, Start, End, Start || ' - ' || End TimeSpan, TimeNotes from Times where CustomerProjectID = @CustomerProjectID order by Start || ' - ' || End collate nocase desc";

            SQLite.spl.Add(new SQLiteParameter("@CustomerProjectID", customerProjectId));
            SQLiteDataReader? dr = SQLite.ExecuteReader(query, SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    timeList.Add(new TimeList() { TimeId = dr.GetInt32(0), Start = dr.GetDateTime(1), End = dr.GetDateTime(2), TimeSpan = dr.GetString(3), TimeNotes = dr.GetString(4) });
                }
                dr.Close();
            }

            return timeList;
        }

        public static int AddTime(string start, string end, string duration, string durationDecimal, string timeNotes, int customerProjectId)
        {
            SQLite.spl.Add(new SQLiteParameter("@Start", start));
            SQLite.spl.Add(new SQLiteParameter("@End", end));
            SQLite.spl.Add(new SQLiteParameter("@Duration", duration));
            SQLite.spl.Add(new SQLiteParameter("@DurationDecimal", durationDecimal));
            SQLite.spl.Add(new SQLiteParameter("@TimeNotes", timeNotes));
            SQLite.spl.Add(new SQLiteParameter("@CustomerProjectID", customerProjectId));
            return SQLite.ExecuteNonQuery("insert into Times (Start, End, Duration, DurationDecimal, TimeNotes, CustomerProjectID) values (@Start, @End, @Duration, @DurationDecimal, @TimeNotes, @CustomerProjectID)", SQLite.spl, "ProjectTimeTracker");
        }

        public static int UpdateTime(int timeId, string start, string end, string duration, string durationDecimal, string timeNotes, int customerProjectId)
        {
            SQLite.spl.Add(new SQLiteParameter("@TimeID", timeId));
            SQLite.spl.Add(new SQLiteParameter("@Start", start));
            SQLite.spl.Add(new SQLiteParameter("@End", end));
            SQLite.spl.Add(new SQLiteParameter("@Duration", duration));
            SQLite.spl.Add(new SQLiteParameter("@DurationDecimal", durationDecimal));
            SQLite.spl.Add(new SQLiteParameter("@TimeNotes", timeNotes));
            SQLite.spl.Add(new SQLiteParameter("@CustomerProjectID", customerProjectId));
            return SQLite.ExecuteNonQuery("update Times set Start = @Start, End = @End, Duration = @Duration, DurationDecimal = @DurationDecimal, TimeNotes = @TimeNotes, CustomerProjectID = @CustomerProjectID where TimeID = @TimeID", SQLite.spl, "ProjectTimeTracker");
        }

        public static void DeleteTime(int timeId, bool deleteAll)
        {
            string deleteQuery = "delete from Times";
            if (!deleteAll) deleteQuery += " where TimeID = @TimeID";
            SQLite.spl.Add(new SQLiteParameter("@TimeID", timeId));
            SQLite.ExecuteNonQuery(deleteQuery, SQLite.spl, "ProjectTimeTracker");
        }

        public static string GetDuration(DateTime start, DateTime end)
        {
            DateTime newStart = new(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Kind);
            DateTime newEnd = new(end.Year, end.Month, end.Day, end.Hour, end.Minute, end.Second, end.Kind);
            return newEnd.Subtract(newStart).ToString(@"d\:hh\:mm\:ss");
        }

        public static string GetDurationDecimal(DateTime start, DateTime end)
        {
            DateTime newStart = new(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Kind);
            DateTime newEnd = new(end.Year, end.Month, end.Day, end.Hour, end.Minute, end.Second, end.Kind);
            return ((Math.Ceiling(newEnd.Subtract(newStart).TotalMinutes / 6.0) * 6.0) / 60).ToString();
        }
    }

    public class TimeList
    {
        public int TimeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string TimeSpan { get; set; } = null!;
        public string TimeNotes { get; set; } = null!;
    }
}