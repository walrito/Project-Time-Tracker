using Elements.Database;
using System.Data.SQLite;

namespace Project_Time_Tracker
{
    public class CustomerProject
    {
        public static List<CustomerProjectList> GenerateCustomerProjectList(bool excludeInactive)
        {
            List<CustomerProjectList> customerProjectList = new();
            string whereClause = excludeInactive ? "where p.Active = 1 " : "where p.Active in (0, 1) ";
            string query = "select cp.CustomerProjectID, cp.CustomerID, cp.ProjectID, c.CustomerName || ' - ' || p.ProjectName CustomerProjectName from CustomerProject cp " +
                "inner join Projects p on p.ProjectID = cp.ProjectID " +
                "inner join Customers c on c.CustomerID = cp.CustomerID " +
                whereClause +
                "order by CustomerProjectName collate nocase";

            SQLiteDataReader? dr = SQLite.ExecuteReader(query, SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    customerProjectList.Add(new CustomerProjectList { CustomerProjectId = dr.GetInt32(0), CustomerId = dr.GetInt32(1), ProjectId = dr.GetInt32(2), CustomerProjectName = dr.GetString(3) });
                }
            }

            return customerProjectList;
        }

        public static int AddCustomerProject(int customerId, int projectId)
        {
            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            string query = "insert into CustomerProject (CustomerID, ProjectID) select @CustomerID, @ProjectID " +
                "where not exists (select 1 from CustomerProject where CustomerID = @CustomerID and ProjectID = @ProjectID)";
            return SQLite.ExecuteNonQuery(query, SQLite.spl, "ProjectTimeTracker");
        }

        public static void DeleteCustomerProject(int customerId, int projectId)
        {
            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            string query = "delete from CustomerProject where CustomerID = @CustomerID and ProjectID = @ProjectID";
            SQLite.ExecuteNonQuery(query, SQLite.spl, "ProjectTimeTracker");

            if (customerId == 0 || projectId == 0) { SQLite.PopulateDefaultTableValues("ProjectTimeTracker"); }
        }

        public static int GetCustomerProjectId(int customerId, int projectId)
        {
            int customerProjectId = -1;

            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", projectId));
            SQLiteDataReader? dr = SQLite.ExecuteReader("select CustomerProjectID from CustomerProject where CustomerID = @CustomerID and ProjectID = @ProjectID limit 1", SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    customerProjectId = dr.GetInt32(0);
                }
            }
            else
            {
                customerProjectId = AddCustomerProject(customerId, projectId);
            }

            return customerProjectId;
        }
    }

    public class CustomerProjectList
    {
        public int CustomerProjectId { get; set; }
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }
        public string? CustomerProjectName { get; set; }
    }
}