using Elements.Database;
using System.Data.SQLite;

namespace Project_Time_Tracker
{
    public class Project
    {
        public static List<ProjectList> GenerateProjectList(bool excludeInactive, bool excludeHidden)
        {
            List<ProjectList> projectList = new();
            string whereClause = excludeInactive ? "where Active = 1 " : "where Active in (0, 1) ";
            whereClause += excludeHidden ? "and ProjectID > 0 " : "";
            string query = "select p.ProjectID, p.ProjectName, p.ProjectNotes, p.Active from Projects p " + whereClause + "order by ProjectName collate nocase";

            SQLiteDataReader? dr = SQLite.ExecuteReader(query, SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    projectList.Add(new ProjectList() { ProjectId = dr.GetInt32(0), ProjectName = dr.GetString(1), ProjectNotes = dr.GetString(2), Active = dr.GetBoolean(3) });
                }
                dr.Close();
            }

            return projectList;
        }

        public static int AddProject(string projectName, bool active, string projectNotes)
        {
            SQLite.spl.Add(new SQLiteParameter("@ProjectName", projectName));
            SQLite.spl.Add(new SQLiteParameter("@ProjectNotes", projectNotes));
            SQLite.spl.Add(new SQLiteParameter("@Active", active));
            return SQLite.ExecuteNonQuery("insert into Projects (ProjectName, ProjectNotes, Active) values (@ProjectName, @ProjectNotes, @Active)", SQLite.spl, "ProjectTimeTracker");
        }

        public static void UpdateProject(int projectId, string projectName, bool active, string projectNotes)
        {
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLite.spl.Add(new SQLiteParameter("@ProjectName", projectName));
            SQLite.spl.Add(new SQLiteParameter("@ProjectNotes", projectNotes));
            SQLite.spl.Add(new SQLiteParameter("@Active", active));
            SQLite.ExecuteNonQuery("update Projects set ProjectName = @ProjectName, ProjectNotes = @ProjectNotes, Active = @Active where ProjectID = @ProjectID", SQLite.spl, "ProjectTimeTracker");
        }

        public static void DeleteProject(int projectId, bool deleteAll)
        {
            string deleteQuery = "delete from Projects";
            if (!deleteAll) deleteQuery += " where ProjectID = @ProjectID";
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLite.ExecuteNonQuery(deleteQuery, SQLite.spl, "ProjectTimeTracker");

            deleteQuery = "delete from CustomerProject";
            if (!deleteAll) deleteQuery += " where ProjectID = @ProjectID";
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLite.ExecuteNonQuery(deleteQuery, SQLite.spl, "ProjectTimeTracker");

            if (projectId == 0 || deleteAll) { SQLite.PopulateDefaultTableValues("ProjectTimeTracker"); }
        }

        public static int GetProjectId(string projectName)
        {
            if (string.IsNullOrEmpty(projectName)) return 0;

            int projectId = -1;

            SQLite.spl.Add(new SQLiteParameter("@ProjectName", projectName));
            SQLiteDataReader? dr = SQLite.ExecuteReader("select ProjectID from Projects where ProjectName = @ProjectName and ProjectID > 0 limit 1", SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    projectId = dr.GetInt32(0);
                }
                dr.Close();
            }
            else
            {
                projectId = AddProject(projectName, true, "");
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
    }
}