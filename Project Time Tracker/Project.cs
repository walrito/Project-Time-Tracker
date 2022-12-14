using Elements.Database;
using System.Data.SQLite;

namespace Project_Time_Tracker
{
    public class Project
    {
        public static List<ProjectList> GenerateProjectList(bool excludeInactive, bool excludeHidden)
        {
            List<ProjectList> projectList = new();
            string whereClause = excludeInactive ? " where Active = 1" : " where Active in (0, 1)";
            whereClause += excludeHidden ? " and ProjectID > 0" : "";

            SQLiteDataReader? dr = SQLite.ExecuteReader("select p.ProjectID, p.ProjectName, p.ProjectNotes, p.Active, c.CustomerID, c.CustomerName from Projects p inner join Customers c on c.CustomerID = p.CustomerID" + whereClause + " order by ProjectName collate nocase", SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    projectList.Add(new ProjectList() { ProjectId = dr.GetInt32(0), ProjectName = dr.GetString(1), ProjectNotes = dr.GetString(2), Active = dr.GetBoolean(3), CustomerId = dr.GetInt32(4), CustomerName = dr.GetString(5) });
                }
            }

            return projectList;
        }

        public static void AddProject(string projectName, bool active, string projectNotes, int customerId)
        {
            //int customerId = Customer.GetCustomerId(customerName);

            SQLite.spl.Add(new SQLiteParameter("@ProjectName", projectName));
            SQLite.spl.Add(new SQLiteParameter("@Active", active));
            SQLite.spl.Add(new SQLiteParameter("@ProjectNotes", projectNotes));
            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLite.ExecuteNonQuery("insert into Projects (ProjectName, Active, ProjectNotes, CustomerID) values (@ProjectName, @Active, @ProjectNotes, @CustomerID)", SQLite.spl, "ProjectTimeTracker");
        }

        public static void UpdateProject(int projectId, string projectName, bool active, string projectNotes, int customerId)
        {
            //int customerId = Customer.GetCustomerId(customerName);

            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLite.spl.Add(new SQLiteParameter("@ProjectName", projectName));
            SQLite.spl.Add(new SQLiteParameter("@Active", active));
            SQLite.spl.Add(new SQLiteParameter("@ProjectNotes", projectNotes));
            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLite.ExecuteNonQuery("update Projects set ProjectName = @ProjectName, Active = @Active, ProjectNotes = @ProjectNotes, CustomerID = @CustomerID where ProjectID = @ProjectID", SQLite.spl, "ProjectTimeTracker");
        }

        public static void DeleteProject(int projectId, bool deleteAll)
        {
            string deleteQuery = "delete from Projects";
            if (!deleteAll) deleteQuery += " where ProjectID = @ProjectID";
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLite.ExecuteNonQuery(deleteQuery, SQLite.spl, "ProjectTimeTracker");
        }

        public static int GetProjectId(string projectName, int customerId)
        {
            if (string.IsNullOrEmpty(projectName)) return 0;

            int projectId = 0;
            List<Tuple<string, string>> columnList = new() { Tuple.Create("ProjectName", projectName), Tuple.Create("CustomerID", customerId.ToString()) };

            if (!SQLite.CheckValueExists("Projects", columnList, "ProjectTimeTracker"))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectName", projectName));
                SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
                SQLite.ExecuteNonQuery("insert into Projects (ProjectName, Active, ProjectNotes, CustomerID) values (@ProjectName, 1, '', @CustomerID)", SQLite.spl, "ProjectTimeTracker");
            }

            SQLite.spl.Add(new SQLiteParameter("@ProjectName", projectName));
            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLiteDataReader? dr = SQLite.ExecuteReader("select ProjectID from Projects where ProjectName = @ProjectName and ProjectID > 0 and CustomerID = @CustomerID limit 1", SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    projectId = dr.GetInt32(0);
                }
            }

            return projectId;
        }
    }

    public class ProjectList
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string ProjectNotes { get; set; } = null!;
        public bool Active { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
    }
}